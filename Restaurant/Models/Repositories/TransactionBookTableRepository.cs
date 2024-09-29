
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class TransactionBookTableRepository : IRepository<TransactionBookTable>
    {
        private readonly AppDbContect db;

        public TransactionBookTableRepository(AppDbContect db)
        {
            this.db = db;
        }
        public void Active(int Id)
        {
            var data = db.TransactionBookTables.Where(x => x.TransactionBookTableId == Id).SingleOrDefault();
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            data.EditId = "1";
            db.TransactionBookTables.Update(data);
            db.SaveChanges();
        }

        public void Add(TransactionBookTable Btatata)
        {
            db.TransactionBookTables.Add(Btatata);
            db.SaveChanges();
        }

        public void Delete(int Id, TransactionBookTable Btatata)
        {
          var data=Find(Id);
            db.TransactionBookTables.Remove(Btatata);
            db.SaveChanges();

        }

        public TransactionBookTable Find(int Id)
        {
            var data = db.TransactionBookTables.SingleOrDefault(x => x.TransactionBookTableId == Id);
            return data;
        }

        public void Update(int Id, TransactionBookTable Btatata)
        {
           db.TransactionBookTables.Update(Btatata);
            db.SaveChanges();
        }

        public List<TransactionBookTable> View()
        {
            return db.TransactionBookTables.Where(x => x.IsDelete == false).ToList();
        }

        public List<TransactionBookTable> ViewClient()
        {
        return db.TransactionBookTables.Where(x => x.IsDelete == false).ToList();       
        }
    }
}
