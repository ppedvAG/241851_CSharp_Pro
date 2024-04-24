using Microsoft.Extensions.DependencyInjection;
using ppedv.CarCare.UI.WPF.ViewModels;
using System.Windows.Controls;

namespace ppedv.CarCare.UI.WPF.Views
{
    /// <summary>
    /// Interaction logic for CarsView.xaml
    /// </summary>
    public partial class CarsView : UserControl
    {
        public CarsView()
        {
            InitializeComponent();
            DataContext = App.Current.Services.GetService<CarsViewModel>();
        }
    }
}
