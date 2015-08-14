using System;
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

        public void DeleteBackOrder(Guid backorder)
        {
            var order = Ds.BackOrders.First(x => x.OrderID == backorder);
            Ds.BackOrders.Remove(order);
            Ds.SaveChanges();
        }

        public void SaveBackOrder(BackOrders backorder)
        {
            var history = new AuctionHistory();
            history.AuctionLink = backorder.OrderID;
            history.CreatedDate = AuctionSniperDLL.Business.Settings.GetDateTimeOffSet();
            history.Text = "Added";
            Ds.AuctionHistory.Add(history);
            Ds.BackOrders.AddOrUpdate(backorder);
            Ds.SaveChanges();
        }

        public IQueryable<BackOrders> GetBackOrders(GoDaddyAccount account)
        {
            return Ds.BackOrders.Where(x=>x.GoDaddyAccount == account.AccountID).ToList().AsQueryable();
        }

        public IQueryable<AuctionHistoryView> GetBackOrderHistory(BackOrders auction)
        {
            return Ds.AuctionHistoryView.Where(x => x.AuctionLink == auction.OrderID).ToList().AsQueryable();
        }
    }
}
