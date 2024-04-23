using ppedv.CarCare.Model;
using ppedv.CarCare.Model.Contracts;

namespace ppedv.CarCare.Data.EfCore
{
    public class CarCareContextRepositoryAdapter : IRepository
    {
        CarCareContext context;

        public CarCareContextRepositoryAdapter(string conString)
        {
            context = new CarCareContext(conString);
        }

        public void Add<T>(T entity) where T : Entity
        {
            //if (typeof(T) == typeof(Car))
            //    context.Cars.Add(entity as Car);
            context.Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : Entity
        {
            context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            return context.Set<T>().ToList();
        }

        public T? GetById<T>(int id) where T : Entity
        {
            return context.Set<T>().Find(id);
        }

        public void SaveAll()
        {
            context.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            context.Set<T>().Update(entity);
        }
    }
}
