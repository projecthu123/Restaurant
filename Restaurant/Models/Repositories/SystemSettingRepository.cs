
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class SystemSettingRepository : IRepository<SystemSetting>
    {
        private readonly AppDbContect db;

        public SystemSettingRepository(AppDbContect db)
        {
            this.db = db;
        }

        public void Active(int Id)
        {
            var data = db.SystemSettings.Where(x => x.SystemSettingId == Id).SingleOrDefault();
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            
            db.SystemSettings.Update(data);
            db.SaveChanges();
        }

        public void Add(SystemSetting Btatata)
        {
            Btatata.IsActive = true;
            Btatata.IsDelete = false;
          db.SystemSettings.Add(Btatata);
            db.SaveChanges();
        }

        public void Delete(int Id, SystemSetting Btatata)
        {
            var data = Find(Id);
           data.IsDelete = true;
            data.IsActive = false;
            db.SaveChanges();
        }

        public SystemSetting Find(int Id)
        {
            var data = db.SystemSettings.SingleOrDefault(x => x.SystemSettingId == Id);
            return data;
        }

        public void Update(int Id, SystemSetting Btatata)
        {
            db.SystemSettings.Update(Btatata);
            db.SaveChanges();
        }

        public List<SystemSetting> View()
        {
            return db.SystemSettings.Where(x => x.IsDelete == false).ToList();

        }

        public List<SystemSetting> ViewClient()
        {
            return db.SystemSettings.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
