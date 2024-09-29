
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class MasterSocialMediumRepository : IRepository<MasterSocialMedia>
    {
        private readonly AppDbContect db;

        public MasterSocialMediumRepository(AppDbContect db)
        {
            this.db = db;
        }

        public void Active(int Id)
        {
            var data = db.MasterSocialMedia.Where(x => x.MasterSocialMediaId == Id).SingleOrDefault();
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
           
            db.MasterSocialMedia.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterSocialMedia Btatata)
        {
            Btatata.CreateDate = DateTime.Now;
            Btatata.IsDelete = false;
            Btatata.IsActive = true;
            db.MasterSocialMedia.Add(Btatata);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterSocialMedia Btatata)
        {
            var data = Find(Id);
           data.IsDelete = true;
            data.IsActive = false;
            db.SaveChanges();
        }

        public MasterSocialMedia Find(int Id)
        {
            var data = db.MasterSocialMedia.SingleOrDefault(x => x.MasterSocialMediaId == Id);
            return data;
        }

        public void Update(int Id, MasterSocialMedia Btatata)
        {
            db.MasterSocialMedia.Update(Btatata);
            db.SaveChanges();
        }

        public List<MasterSocialMedia> View()
        {
            return db.MasterSocialMedia.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterSocialMedia> ViewClient()
        {
            return db.MasterSocialMedia.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
