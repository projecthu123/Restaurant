
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class MasterOfferRepository : IRepository<MasterOffer>
    {
        private readonly AppDbContect db;

        public MasterOfferRepository(AppDbContect db)
        {
            this.db = db;
        }

        public void Active(int Id)
        {
            var data = db.MasterOffers.Where(x => x.MasterOfferId == Id).SingleOrDefault();
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            
            db.MasterOffers.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterOffer Btatata)
        {
           Btatata.IsActive = true;
            Btatata.IsDelete=false;
            Btatata.CreateDate = DateTime.Now;
            db.MasterOffers.Add(Btatata);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterOffer Btatata)
        {
            var data = Find(Id);
           
            data.IsDelete = true;
            db.SaveChanges();
        }

        public MasterOffer Find(int Id)
        {
            var data = db.MasterOffers.SingleOrDefault(x => x.MasterOfferId == Id);

            return data;
        }

        public void Update(int Id, MasterOffer Btatata)
        {
            Btatata.EditDate= DateTime.Now;
            db.MasterOffers.Update(Btatata);
            db.SaveChanges();
        }

        public List<MasterOffer> View()
        {
            return db.MasterOffers.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterOffer> ViewClient()
        {
            return db.MasterOffers.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
