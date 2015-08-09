using System;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using LunchboxWebControls;
using WebApplication4.Presenter;
using WebApplication4.View;

namespace WebApplication4
{   
    public partial class BackOrder : Page, IBackOrderView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           ScriptManager.RegisterStartupScript(this, typeof(Page), "UpdateMsg", "document.getElementById('menu_backorder').className  =document.getElementById('menu_backorder').className +  ' active';", true);
           Show();

        }

        public DefaultPresenter DefaultPresenter
        {
            get { return ((Master.Default)Master).Presenter; }
        }

        public void Show()
        {
            LunchboxGridView2.DataSource = Presenter.GetBackOrders(((Master.Default)Master).GoDaddyAccount);
            LunchboxGridView2.DataBind();
        }


        public string DomainName
        {
            get { return domainName.Text; }
        }

        int IBackOrderView.CreditstoUse
        {
            get { return int.Parse("1"); }
        }

        string IBackOrderView.AlertEmail1
        {
            get { return AlertEmail1.Text; }
        }

        string IBackOrderView.AlertEmail2
        {
            get { return AlertEmail2.Text; }
        }

        private BackOrderPresenter Presenter
        {
            get { return new BackOrderPresenter(this); }
        }

        public DateTime DateToPlaceOrder
        {
            get { return DateTime.Parse(datetimepickervalue.Value, new CultureInfo("en-US", true)); }
        }

        protected void LinkButton2_OnClick(object sender, EventArgs e)
        {
            backorderMessage.InnerText = "Error saving.. Please try again";
            //if (Presenter.CheckDomainValid())
            //{
            //Presenter.CheckDomainValid();
            Presenter.SaveBackOrder(((Master.Default)Master).GoDaddyAccount);
                backorderMessage.InnerText = "Succesfully added new backorder";
            //}

            const string moo = "$('#backorderMessage').fadeIn(300).delay(1000).fadeOut('slow'); ";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "fadeit", moo, true);
            Show();
        }

        protected void MyBids_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }

        protected void gvAgency_Sorting(object sender, GridViewSortEventArgs e)
        {
            var grid = sender as LunchboxGridView;
            grid.Order(Presenter.GetBackOrders(DefaultPresenter.View.GoDaddyAccount).AsQueryable(), e.SortExpression);
        }

        protected void OnCancel(object sender, EventArgs e)
        {
            Show();
        }
    }
}