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

        public BackOrderPresenter(IBackOrderView view)
        {
            View = view;
            Modal = new BackOrderModal();
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

        public IQueryable<BackOrders> GetBackOrders(GoDaddyAccount account)
        {
            return Modal.GetBackOrders(account);
        }

        public void SaveBackOrder(GoDaddyAccount account)
        {
            var backOrder = new BackOrders();
            backOrder.OrderID = Guid.NewGuid();
            backOrder.GoDaddyAccount = account.AccountID;
            backOrder.AlertEmail1 = View.AlertEmail1;
            backOrder.AlertEmail2 = View.AlertEmail2;
            backOrder.CreditsToUse = View.CreditstoUse;
            backOrder.DateToOrder = View.DateToPlaceOrder;
            backOrder.Private = false;
            backOrder.DomainName = View.DomainName;

            Modal.SaveBackOrder(backOrder);
        }
    }
}
