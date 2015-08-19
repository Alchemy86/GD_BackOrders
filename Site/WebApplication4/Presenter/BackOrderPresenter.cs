using System;
using System.Linq;
using ASEntityFramework;
using WebApplication4.Model;
using WebApplication4.View;

namespace WebApplication4.Presenter
{
    public class BackOrderPresenter
    {
        protected IBackOrderView View;
        protected BackOrderModal Modal;

        public BackOrderPresenter(IBackOrderView view, IDefaultView defaultView)
        {
            View = view;
            Modal = new BackOrderModal(defaultView);
        }

        public bool CheckDomainValid()
        {
            //if (DefaultView.GdHelper.GoDaddyApi.LoggedIn())
            //{
            //    DefaultView.GdHelper.GoDaddyApi.Login(DefaultView.GoDaddyAccount.GoDaddyUsername,
            //        DefaultView.GoDaddyAccount.GoDaddyPassword);
            //}
            
            //return DefaultView.GdHelper.GoDaddyApi.CheckBackOrderDomain_IsValid(View.DomainName);
            return true;
        }

        public void DeleteBackOrder(Guid backorder)
        {
            Modal.DeleteBackOrder(backorder);
        }

        public IQueryable<BackOrders> GetBackOrders(GoDaddyAccount account)
        {
            return Modal.GetBackOrders(account);
        }

        public IQueryable<AuctionHistoryView> LoadBackOrderHistory(BackOrders backorder)
        {
            return Modal.GetBackOrderHistory(backorder);
        }

        public void SaveBackOrder(GoDaddyAccount account)
        {
            var backOrder = new BackOrders
            {
                OrderID = Guid.NewGuid(),
                GoDaddyAccount = account.AccountID,
                AlertEmail1 = View.AlertEmail1,
                AlertEmail2 = View.AlertEmail2,
                CreditsToUse = View.CreditstoUse,
                DateToOrder = View.DateToPlaceOrder,
                Private = false,
                DomainName = View.DomainName
            };

            Modal.SaveBackOrder(backOrder);
        }
    }
}
