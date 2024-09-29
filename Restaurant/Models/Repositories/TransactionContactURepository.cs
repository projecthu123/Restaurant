
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class TransactionContactURepository : IRepository<TransactionContactUs>
    {
        private readonly AppDbContect db;

        public TransactionContactURepository(AppDbContect db)
        {
            this.db = db;
        }

        public void Active(int Id)
        {
            var data = db.TransactionContactUs.Where(x => x.TransactionContactUsId == Id).SingleOrDefault();
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            data.EditId = "1";
            db.TransactionContactUs.Update(data);
            db.SaveChanges();
        }

        public void Add(TransactionContactUs Btatata)
        {
       db.TransactionContactUs.Add(Btatata);
            db.SaveChanges();
        }

        public void Delete(int Id, TransactionContactUs Btatata)
        {
            var data=Find(Id);
            db.TransactionContactUs.Remove(Btatata);
            db.SaveChanges();

        }

        public TransactionContactUs Find(int Id)
        {
            var data = db.TransactionContactUs.SingleOrDefault(x => x.TransactionContactUsId == Id);
            return data;
        }

        public void Update(int Id, TransactionContactUs Btatata)
        {
            db.TransactionContactUs.Update(Btatata);
            db.SaveChanges();
        }

        public List<TransactionContactUs> View()
        {
            return db.TransactionContactUs.Where(x => x.IsDelete == false).ToList();
        }

        public List<TransactionContactUs> ViewClient()
        {
            return db.TransactionContactUs.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
