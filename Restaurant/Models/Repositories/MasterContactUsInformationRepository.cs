
using Restaurant.Data;
using System.Threading.Tasks.Dataflow;

namespace Restaurant.Models.Repositories
{
    public class MasterContactUsInformationRepository : IRepository<MasterContactUsInformation>
    {
        private readonly AppDbContect db;

        public MasterContactUsInformationRepository(AppDbContect db)
        {
            this.db = db;
        }

        public void Active(int Id)
        {
            var data = db.MasterContactUsInformations.Where(x => x.MasterContactUsInformationId == Id).SingleOrDefault();
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
           
            db.MasterContactUsInformations.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterContactUsInformation Btatata)
        {
            Btatata.CreateDate = DateTime.Now;
            Btatata.IsActive = true;
            Btatata.IsDelete = false;
            db.MasterContactUsInformations.Add(Btatata);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterContactUsInformation Btatata)
        {
            Btatata.EditDate = DateTime.Now;
            var data = Find(Id);
             data.IsDelete = true;
            db.SaveChanges();
        }

        public MasterContactUsInformation Find(int Id)
        {
            var data = db.MasterContactUsInformations.SingleOrDefault(x => x.MasterContactUsInformationId == Id);

            return data;
        }

        public void Update(int Id, MasterContactUsInformation Btatata)
        {
            Btatata.EditDate = DateTime.Now;
            Btatata.IsActive = true;
            Btatata.IsDelete = false;
            db.MasterContactUsInformations.Update(Btatata);
            db.SaveChanges();
        }

        public List<MasterContactUsInformation> View()
        {
            return db.MasterContactUsInformations.Where(x => x.IsDelete == false).ToList();

        }

        public List<MasterContactUsInformation> ViewClient()
        {
            return db.MasterContactUsInformations.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
