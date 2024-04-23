using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HalloAsync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OhneThread(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(1000);
                pb1.Value = i;
            }
        }

        private void StartTask(object sender, RoutedEventArgs e)
        {
            ((Button)sender).IsEnabled = false;
            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(100);
                    pb1.Dispatcher.Invoke(() => pb1.Value = i);
                }
                this.Dispatcher.Invoke(() => ((Button)sender).IsEnabled = true);
            });
        }

        private void StartTaskMitTS(object sender, RoutedEventArgs e)
        {
            var ts = TaskScheduler.FromCurrentSynchronizationContext();
            cts = new CancellationTokenSource();
            ((Button)sender).IsEnabled = false;
            var t1 = Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(100);
                    Task.Factory.StartNew(() => pb1.Value = i, CancellationToken.None, TaskCreationOptions.None, ts);

                    if (cts.IsCancellationRequested)
                    {
                        //clean up
                        cts.Token.ThrowIfCancellationRequested();
                        //break; //nicht wenn ThrowIfCancellationRequested
                    }

                }
            }, cts.Token);
            t1.ContinueWith(t => ((Button)sender).IsEnabled = true, ts);
            t1.ContinueWith(t => MessageBox.Show("OK"), CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, ts);
            t1.ContinueWith(t => MessageBox.Show("Aborted"), CancellationToken.None, TaskContinuationOptions.OnlyOnCanceled, ts);
        }

        CancellationTokenSource cts = null;

        private void Abort(object sender, RoutedEventArgs e)
        {
            cts?.Cancel();
        }

        private async void StartAA(object sender, RoutedEventArgs e)
        {
            ((Button)sender).IsEnabled = false;
            cts = new CancellationTokenSource();

            try
            {
                for (int i = 0; i < 100; i++)
                {
                    await Task.Delay(100, cts.Token);
                    pb1.Value = i;
                }
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Task canceld");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler: {ex.Message}");
            }

            ((Button)sender).IsEnabled = true;
        }


        public long AlteLangsameFunction(int zahl)
        {
            Thread.Sleep(4000);
            return zahl * 2;
        }

        public Task<long> AlteLangsameFunctionAsync(int zahl)
        {
            return Task.Run(() => AlteLangsameFunction(zahl));
        }


        private async void StartAlt(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(AlteLangsameFunction(500).ToString());
            MessageBox.Show((await AlteLangsameFunctionAsync (500)).ToString());
            //MessageBox.Show(AlteLangsameFunctionAsync(500).Result.ToString()); 
        }
    }
}