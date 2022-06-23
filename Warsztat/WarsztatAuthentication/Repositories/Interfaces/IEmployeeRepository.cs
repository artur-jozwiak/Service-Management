using Warsztat.BLL.Models;

namespace Warsztat_v2.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        void Delete(int id);
        void Update(Employee employee);
        public Employee GetById(int id);
    }
}