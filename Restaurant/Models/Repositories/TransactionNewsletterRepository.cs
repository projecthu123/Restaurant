
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class TransactionNewsletterRepository : IRepository<TransactionNewsletter>
    {
        private readonly AppDbContect db;

        public TransactionNewsletterRepository(AppDbContect dp)
        {
            db = dp;
        }

        public void Active(int Id)
        {
            var data = db.TransactionNewsletters.Where(x => x.TransactionNewsletterId == Id).SingleOrDefault();
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            data.EditId = "1";
            db.TransactionNewsletters.Update(data);
            db.SaveChanges();
        }

        public void Add(TransactionNewsletter Btatata)
        {
            db.TransactionNewsletters.Add(Btatata);
            db.SaveChanges();
        }

        public void Delete(int Id, TransactionNewsletter Btatata)
        {
            var data = Find(Id);
            db.TransactionNewsletters.Remove(data);
            db.SaveChanges();
        }

        public TransactionNewsletter Find(int Id)
        {
            var data = db.TransactionNewsletters.SingleOrDefault(x => x.TransactionNewsletterId == Id);
            return data;
        }

        public void Update(int Id, TransactionNewsletter Btatata)
        {
            db.TransactionNewsletters.Update(Btatata);

                }

        public List<TransactionNewsletter> View()
        {
            return db.TransactionNewsletters.Where(x => x.IsDelete == false).ToList();
        }

        public List<TransactionNewsletter> ViewClient()
        {
            return db.TransactionNewsletters.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
