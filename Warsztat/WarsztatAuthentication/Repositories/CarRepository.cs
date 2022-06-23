using Warsztat.BLL.Models;
using Warsztat_v2.Data;
using Warsztat_v2.Repositories.Interfaces;

namespace Warsztat_v2.Repositories
{
    public class CarRepository : ICarRepository
    {
        public ServiceContext Context { get; set; }
        public List<Car> CarList { get; set; }
        public CarRepository(ServiceContext context)
        {
            Context = context;
            CarList = context.Cars.ToList();
        }

        public void Add(Car car)
        {
            Context.Cars.Add(car);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var car = GetById(id);
            Context.Cars.Remove(car);
            Context.SaveChanges();
        }

        public Car GetById(int id)
        {
            return CarList.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Car model)
        {
            var car = GetById(model.Id);
            car.CarModel = model.CarModel;
            car.CarMark = model.CarMark;
            car.YearProduction = model.YearProduction;
            Context.SaveChanges();
        }
    }
}
