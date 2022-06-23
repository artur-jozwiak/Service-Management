using Warsztat.BLL.Models;

namespace Warsztat_v2.Repositories.Interfaces
{
    public interface IPartRepository
    {
        void Add(Part part);
        void Delete(int id);
        void Update(Part part);
        public Part GetById(int id);
    }
}