using Warsztat.BLL.Models;
using Warsztat_v2.Data;
using Warsztat_v2.Repositories.Interfaces;

namespace Warsztat_v2.Repositories
{
    public class PartRepository : IPartRepository
    {
        public ServiceContext Context { get; set; }
        public List<Part> PartList { get; set; }
        public PartRepository(ServiceContext context)
        {
            Context = context;
            PartList = context.Parts.ToList();
        }

        public void Add(Part part)
        {
            Context.Parts.Add(part);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var part = GetById(id);
            Context.Parts.Remove(part);
            Context.SaveChanges();
        }

        public Part GetById(int id)
        {
            return PartList.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Part model)
        {
            var part = GetById(model.Id);
            part.PartPrice = model.PartPrice;
            part.Quantity = model.Quantity;
            part.PartName = model.PartName;
            Context.SaveChanges();
        }
    }
}
