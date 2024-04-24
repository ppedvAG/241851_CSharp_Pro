using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ppedv.CarCare.Logic.Core;
using ppedv.CarCare.Model;
using ppedv.CarCare.Model.Contracts;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;

namespace ppedv.CarCare.UI.WPF.ViewModels
{
    public partial class CarsViewModel : ObservableObject
    {
        private readonly IRepository repo;

        public SaveCommand SaveCommand { get; set; }
        //public ICommand NewCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        public ICommand LoadBlueMondayCarsCommand { get; set; }

        public CarsViewModel(IRepository repo, GarageService gs)
        {
            this.repo = repo;

            Cars = new ObservableCollection<Car>();
            LoadCommand = new RelayCommand(() =>
            {
                Cars.Clear();
                var query = repo.Query<Car>().OrderBy(x => x.Color).Take(10);

                query.ToList().ForEach(c => Cars.Add(c));
            });

            SaveCommand = new SaveCommand(repo);
            //NCommand = new RelayCommand(AddNewCar);
            LoadBlueMondayCarsCommand = new RelayCommand(() =>
            {
                Cars.Clear();
                gs.GetAllBlueMondayCars().ToList().ForEach(c => Cars.Add(c));
            });

            LoadCommand.Execute(null);

        }

        [RelayCommand]
        private void ExportCSV()
        {
            var expCars = Cars.Select(x => new { Name = x.Model, Farbe = x.Color, Jahr = x.BuiltDate.Year });
            using var sw = new StreamWriter("export.csv");
            foreach (var c in expCars)
            {
                sw.WriteLine($"{c.Name};{c.Farbe};{c.Jahr};");
            }
        }

        [RelayCommand]
        private void Add()
        {
            var newCar = new Car()
            {
                Manufacturer = new Manufacturer() { Name = "M1" },
                Model = "Neu",
                KW = 100,
                Color = "weiss",
                BuiltDate = DateTime.Now
            };
            repo.Add(newCar);
            Cars.Add(newCar);
            SelectedCar = newCar;
        }

        public ObservableCollection<Car> Cars { get; set; }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(PS))]
        [NotifyPropertyChangedFor(nameof(KW))]
        private Car selectedCar;


        public string PS
        {
            get
            {
                if (SelectedCar == null)
                    return "--";

                return $"{SelectedCar.KW * 1.35962} PS";
            }
        }

        public int KW
        {
            get
            {
                if (SelectedCar == null)
                    return -1;
                return SelectedCar.KW;
            }
            set
            {
                if (SelectedCar != null)
                    SelectedCar.KW = value;
                OnPropertyChanged(nameof(PS));
            }
        }

    }
}
