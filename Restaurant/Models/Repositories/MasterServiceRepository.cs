
using Restaurant.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Restaurant.Models.Repositories
{
    public class MasterServiceRepository : IRepository<MasterService>
    {
        private readonly AppDbContect db;

        public MasterServiceRepository(AppDbContect db)
        {
            this.db = db;
        }

        public void Active(int Id)
        {
            var data = db.MasterServices.Where(x => x.MasterServiceId == Id).SingleOrDefault();
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            
            db.MasterServices.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterService Btatata)
        {
            Btatata.CreateDate = DateTime.Now;
            Btatata.IsActive = true;
            Btatata.IsDelete = false;
            db.MasterServices.Add(Btatata);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterService Btatata)
        {
            var data = Find(Id);
            data.EditDate = DateTime.Now;
            data.IsDelete = true;
            data.IsActive = false;
            db.SaveChanges();
        }

        public MasterService Find(int Id)
        {
            var data = db.MasterServices.SingleOrDefault(x => x.MasterServiceId == Id);

            return data;
        }

        public void Update(int Id, MasterService Btatata)
        {
            Btatata.EditDate = DateTime.Now;
            Btatata.IsDelete = false;
            Btatata.IsActive = true;
            db.MasterServices.Update(Btatata);
            db.SaveChanges();
        }

        public List<MasterService> View()
        {
            return db.MasterServices.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterService> ViewClient()
        {
            return db.MasterServices.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
