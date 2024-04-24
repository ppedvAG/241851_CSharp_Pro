using ppedv.CarCare.Model;
using ppedv.CarCare.Model.Contracts;

namespace ppedv.CarCare.Logic.Core
{
    public class GarageService
    {
        private readonly IRepository repository;

        public GarageService(IRepository repository)
        {
            //guard class
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));

            this.repository = repository;
        }

        public IEnumerable<Car> GetAllBlueMondayCars()
        {
            return repository.GetAll<Car>().Where(x => x.Color == "blue" && x.BuiltDate.DayOfWeek == DayOfWeek.Monday);
        }
    }
}
