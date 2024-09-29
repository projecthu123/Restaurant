
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class MasterWorkingHourRepository : IRepository<MasterWorkingHour>
    {
        private readonly AppDbContect db;

        public MasterWorkingHourRepository(AppDbContect db)
        {
            this.db = db;
        }
        public void Active(int Id)
        {
            var data = db.MasterWorkingHours.Where(x => x.MasterWorkingHourId == Id).SingleOrDefault();
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
          
            db.MasterWorkingHours.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterWorkingHour Btatata)
        {
            Btatata.IsActive = true;
            Btatata.IsDelete = false;
         db.MasterWorkingHours.Add(Btatata);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterWorkingHour Btatata)
        {
            var data = Find(Id);
           data.IsDelete = true;
            data.IsActive = false;
            db.SaveChanges();
        }

        public MasterWorkingHour Find(int Id)
        {
            var data = db.MasterWorkingHours.SingleOrDefault(x => x.MasterWorkingHourId == Id);
            return data;
        }

        public void Update(int Id, MasterWorkingHour Btatata)
        {
            db.MasterWorkingHours.Update(Btatata);
            db.SaveChanges();
        }

        public List<MasterWorkingHour> View()
        {
            return db.MasterWorkingHours.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterWorkingHour> ViewClient()
        {
            return db.MasterWorkingHours.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
