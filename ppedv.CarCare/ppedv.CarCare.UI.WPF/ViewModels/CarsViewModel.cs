using ppedv.CarCare.Model;
using ppedv.CarCare.Model.Contracts;
using System.ComponentModel;

namespace ppedv.CarCare.UI.WPF.ViewModels
{
    public class CarsViewModel : INotifyPropertyChanged
    {
        private readonly IRepository repo;
        private Car selectedCar;

        public event PropertyChangedEventHandler? PropertyChanged;

        public SaveCommand SaveCommand { get; set; }

        public CarsViewModel(IRepository repo)
        {
            this.repo = repo;

            Cars = new List<Car>(repo.GetAll<Car>());
            SaveCommand = new SaveCommand(repo);
        }

        public List<Car> Cars { get; set; }
        public Car SelectedCar
        {
            get => selectedCar;
            set
            {
                selectedCar = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedCar)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(KW)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PS)));
            }
        }

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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PS)));

            }
        }

        //hack -> DI later
        public CarsViewModel() : this(new Data.EfCore.CarCareContextRepositoryAdapter("Server=(localdb)\\mssqllocaldb;Database=CarCare_Test;Trusted_Connection=true;"))
        { }

    }
}
