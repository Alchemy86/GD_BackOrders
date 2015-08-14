using System;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASEntityFramework;
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
           if (!IsPostBack)
           {
               Show();
           }
        }

        public DefaultPresenter DefaultPresenter
        {
            get { return ((Master.Default)Master).Presenter; }
        }

        public void Show()
        {
            LunchboxGridView2.DataSource = Presenter.GetBackOrders(((Master.Default)Master).GoDaddyAccount);
            LunchboxGridView2.DataBind();

            LunchboxGridView2.Columns[4].Visible = false;
            LunchboxGridView2.Columns[5].Visible = true;
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
            Response.Redirect(Request.RawUrl);
        }

        protected void MyBids_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                var refid = Guid.Parse(e.CommandArgument.ToString());
                Presenter.DeleteBackOrder(refid);
                ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).Style.Add("display", "none");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "UpdateMsg", "javascript:document.location.reload();", true);
            }
            Show();
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

        protected void grdView_OnRowDataBoundCurrent(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;
            var grdViewOrdersOfCustomer = (GridView)e.Row.FindControl("grdViewOrdersOfCustomer");

            var auction = (BackOrders)e.Row.DataItem;
            var history = Presenter.LoadBackOrderHistory(auction).ToList().OrderBy(x => x.CreatedDate);
            grdViewOrdersOfCustomer.DataSource = history;
            grdViewOrdersOfCustomer.DataBind();

            e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(LunchboxGridView2, "Edit$" + e.Row.RowIndex);
            e.Row.Attributes["style"] = "cursor:pointer";

            //e.Row.Cells[6].CssClass = auction.MyBid > auction.MinBid ? "bidfine" : "bidtolow";
        }

        protected void LunchboxGridView2_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            var grid = sender as GridView;
            grid.EditIndex = e.NewEditIndex;
            ScriptManager.RegisterStartupScript(this, typeof(Page), "editFix", "var list = document.getElementsByTagName('input')[0];list.setAttribute('onkeypress', 'return isNumberKey(event)');", true);

            Show();
            grid.Columns[4].Visible = true;
            grid.Columns[5].Visible = false;
        }
    }
}