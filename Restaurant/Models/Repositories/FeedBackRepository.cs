
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class FeedBackRepository : IRepository<FeedBack>
    {
        public AppDbContect Db { get; }
        public FeedBackRepository(AppDbContect db)
        {
            Db = db;
        }

        

        public void Active(int Id)
        {

            var data = Find(Id);
            data.IsActive=!data.IsActive;
            data.EditDate = DateTime.Now;
            Db.SaveChanges();



        }

        public void Add(FeedBack Btatata)
        {
            Btatata.IsActive = true;
            Btatata.CreateDate = DateTime.Now;
            Db.FeedBack.Add(Btatata);
            Db.SaveChanges();
        }

        public void Delete(int Id, FeedBack Btatata)
        {
          var data= Find(Id);
            data.IsDelete = true;
            data.IsActive = false;
            data.EditDate = DateTime.Now;
            Db.SaveChanges();
        }

        public FeedBack Find(int Id)
        {
            var data = Db.FeedBack.SingleOrDefault(x => x.FeedBackId == Id);

            return data;
        }

        public void Update(int Id, FeedBack Btatata)
        {
           var data=Find(Id);
            data.EditDate= DateTime.Now;
            Db.SaveChanges();
        }

        public List<FeedBack> View()
        {
            return Db.FeedBack.Where(x => x.IsDelete == false).ToList();
        }

        public List<FeedBack> ViewClient()
        {
            return Db.FeedBack.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
