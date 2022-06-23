using Warsztat.BLL.Models;

namespace Warsztat_v2.Repositories.Interfaces
{
    public interface ICarRepository
    {
        void Add(Car car);
        void Delete(int id);
        void Update(Car car);
        public Car GetById(int id);
    }
}