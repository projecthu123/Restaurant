
using Restaurant.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Restaurant.Models.Repositories
{
    public class MasterMenuRepository : IRepository<MasterMenu>
    {
        private readonly AppDbContect db;

        public MasterMenuRepository(AppDbContect _db)
        {
            this.db = _db;
        }

        public void Active(int Id)
        {
            var data = db.MasterMenus.Where(x => x.MasterMenuId == Id).SingleOrDefault();
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            
            db.MasterMenus.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterMenu Btatata)
        {

            Btatata.CreateDate = DateTime.Now;
            Btatata.IsActive = true;
            Btatata.IsDelete = false;
            db.MasterMenus.Add(Btatata);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterMenu Btatata)
        {
            Btatata.EditDate = DateTime.Now;
            var data = Find(Id);
            data.IsDelete = true;
            data.EditDate= DateTime.Now;
            db.SaveChanges();
        }

        public MasterMenu Find(int Id)
        {
            var data = db.MasterMenus.SingleOrDefault(x => x.MasterMenuId == Id);

            return data;
        }

        public void Update(int Id, MasterMenu Btatata)
        {
            Btatata.EditDate = DateTime.Now;
            Btatata.IsDelete = false;
            Btatata.IsActive = true;
            db.MasterMenus.Update(Btatata);
            db.SaveChanges();
        }

        public List<MasterMenu> View()
        {
            return db.MasterMenus.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterMenu> ViewClient()
        {
            return db.MasterMenus.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
