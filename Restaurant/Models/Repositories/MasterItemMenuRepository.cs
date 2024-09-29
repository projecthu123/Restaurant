
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class MasterItemMenuRepository : IRepository<MasterItemMenu>
    {
        private readonly AppDbContect db;

        public MasterItemMenuRepository(AppDbContect db)
        {
            this.db = db;
        }

        public void Active(int Id)
        {
            var data = db.MasterItemMenus.Where(x => x.MasterItemMenuId == Id).SingleOrDefault();
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
           
            db.MasterItemMenus.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterItemMenu Btatata)
        {
            Btatata.CreateDate = DateTime.Now;
           
            Btatata.IsActive=true;
            Btatata.IsDelete=false;

            db.MasterItemMenus.Add(Btatata);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterItemMenu Btatata)
        {

            Btatata.EditDate = DateTime.Now;
            var data = Find(Id);
            data.IsDelete = true;
            db.SaveChanges();
        }

        public MasterItemMenu Find(int Id)
        {
            var data = db.MasterItemMenus.SingleOrDefault(x => x.MasterItemMenuId == Id);

            return data;
        }

        public void Update(int Id, MasterItemMenu Btatata)
        {
            
            Btatata.EditDate = DateTime.Now;
            Btatata.IsActive = true;
            Btatata.IsDelete=false;

            db.MasterItemMenus.Update(Btatata);
            db.SaveChanges();
        }

        public List<MasterItemMenu> View()
        {
            return db.MasterItemMenus.Include(z=>z.MasterCategoryMenu).Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterItemMenu> ViewClient()
        {
            return db.MasterItemMenus.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
