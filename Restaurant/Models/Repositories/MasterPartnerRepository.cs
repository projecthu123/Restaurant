
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class MasterPartnerRepository : IRepository<MasterPartner>
    {
        private readonly AppDbContect db;

        public MasterPartnerRepository(AppDbContect db)
        {
            this.db = db;
        }

        public void Active(int Id)
        {
            var data = db.MasterPartners.Where(x => x.MasterPartnerId == Id).SingleOrDefault();
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
           
            db.MasterPartners.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterPartner Btatata)
        {
            Btatata.IsActive = true;
            Btatata.IsDelete = false;
            db.MasterPartners.Add(Btatata);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterPartner Btatata)
        {
            var data = Find(Id);
           data.IsDelete = true;
            data.IsActive = false;
            db.SaveChanges();
        }

        public MasterPartner Find(int Id)
        {
            var data = db.MasterPartners.SingleOrDefault(x => x.MasterPartnerId == Id);

            return data;
        }

        public void Update(int Id, MasterPartner Btatata)
        {
            db.MasterPartners.Update(Btatata);
            db.SaveChanges();
        }

        public List<MasterPartner> View()
        {
            return db.MasterPartners.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterPartner> ViewClient()
        {
            return db.MasterPartners.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
