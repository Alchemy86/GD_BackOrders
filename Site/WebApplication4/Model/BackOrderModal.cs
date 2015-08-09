using System.Data.Entity.Migrations;
using System.Linq;
using ASEntityFramework;

namespace WebApplication4.Model
{
    public class BackOrderModal
    {
        protected ASEntities Ds { get; private set; }

        public BackOrderModal()
        {
            Ds=new ASEntities();
        }

        public void SaveBackOrder(BackOrders backorder)
        {
            Ds.BackOrders.AddOrUpdate(backorder);
            Ds.SaveChanges();
        }

        public IQueryable<BackOrders> GetBackOrders(GoDaddyAccount account)
        {
            return Ds.BackOrders.Where(x=>x.GoDaddyAccount == account.AccountID).ToList().AsQueryable();
        }

    }
}
