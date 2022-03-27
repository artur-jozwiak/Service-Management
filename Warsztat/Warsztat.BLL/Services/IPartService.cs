using Warsztat.BLL.Models;

namespace Warsztat.BLL.Services
{
    public interface IPartService
    {
        void Update(Part model);
        List<Part> GetAll();
        void Delete(int id);
        Part GetById(int id);
        void Create(Part part);
        void SaveToFile();
        int GetNextId();



    }
}