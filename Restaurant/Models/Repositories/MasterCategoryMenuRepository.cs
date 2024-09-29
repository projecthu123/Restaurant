
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class MasterCategoryMenuRepository : IRepository<MasterCategoryMenu>
    {
        private readonly AppDbContect db;

        public MasterCategoryMenuRepository(AppDbContect db)
        {
            this.db = db;
        }

        public void Active(int Id)
        {
            var data = db.MasterCategoryMenus.Where(x => x.MasterCategoryMenuId == Id).SingleOrDefault();
            data.IsActive = !data.IsActive;
           data.EditDate = DateTime.Now;
            db.MasterCategoryMenus.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterCategoryMenu Btatata)
        {
            Btatata.CreateDate = DateTime.Now;
            Btatata.IsActive = true;
            Btatata.IsDelete = false;
            db.MasterCategoryMenus.Add(Btatata);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterCategoryMenu Btatata)
        {
            var data = Find(Id);
            data.IsDelete= true;
            data.EditDate = DateTime.Now;
            db.SaveChanges();
        }

        public MasterCategoryMenu Find(int Id)
        {
           var data=db.MasterCategoryMenus.SingleOrDefault(x => x.MasterCategoryMenuId == Id);
           
            return data;
        }

        public void Update(int Id, MasterCategoryMenu Btatata)
        {
           
          
            Btatata.CreateDate= DateTime.Now;
            db.MasterCategoryMenus.Update(Btatata);
            Btatata.IsDelete = false;
            Btatata.IsActive = true;
            db.SaveChanges();
        }

        public List<MasterCategoryMenu> View()
        {
            return db.MasterCategoryMenus.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterCategoryMenu> ViewClient()
        {
            return db.MasterCategoryMenus.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
