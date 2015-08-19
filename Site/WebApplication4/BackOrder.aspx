<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Default.Master" AutoEventWireup="true" CodeBehind="BackOrder.aspx.cs" Inherits="WebApplication4.BackOrder" %>
<%@ Register TagPrefix="cc1" Namespace="LunchboxWebControls" Assembly="LunchboxWebControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadHolder" runat="server">
<script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/moment.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/bootstrap-datetimepicker.js"></script>
    <link href="Content/bootstrap-datetimepicker.css" rel="stylesheet" />
    
    <script type="text/javascript">

        function zxcCountDown(id, mess, secs, mins, hrs, days) {
            var obj = document.getElementById(id);
            var oop = obj.oop;
            if (!oop) obj.oop = new ZxcCountDownOop(obj, mess, secs, mins, hrs, days);
            else {
                clearTimeout(oop.to);
                oop.mess = mess;
                oop.mhd = [mins, hrs, days];
                oop.srt = new Date().getTime();
                oop.fin = new Date().getTime() + ((days || 0) * 86400) + ((hrs || 0) * 3600) + ((mins || 0) * 60) + ((secs || 0));
                oop.end = ((oop.fin - oop.srt));
                oop.to = null;
                oop.cng();
            }
        }

        function ZxcCountDownOop(obj, mess, secs, mins, hrs, days) {
            this.obj = obj;
            this.mess = mess;
            this.mhd = [mins, hrs, days];
            var date = new Date();
            this.fin = new Date(date.getFullYear(), date.getMonth(), date.getDate() + (days || 0), date.getHours() + (hrs || 0), date.getMinutes() + (mins || 0), date.getSeconds() + (secs || 0));
            this.to = null;
            this.cng();
        }

        ZxcCountDownOop.prototype.cng = function () {
            var now = new Date(), s = (this.fin - now) / 1000 + 1, d = Math.floor(s / 60 / 60 / 24), h = Math.floor(s / 60 / 60 - d * 24), m = Math.floor(s / 60 - h * 60 - d * 24 * 60), s = Math.floor(s - m * 60 - h * 3600 - d * 24 * 60 * 60);
            if (this.fin - now > -500) {
                this.obj.innerHTML = (this.mhd[2] ? (d > 9 ? d : '0' + d) + ' days ' : '') + (this.mhd[1] || this.mhd[2] ? (h > 9 ? h : '0' + h) + ' hours ' : '') + (this.mhd[0] || this.mhd[1] || this.mhd[2] ? (m > 9 ? m : '0' + m) + ' minutes ' : '') + (s > 9 ? s : '0' + s) + ' seconds';
                this.to = setTimeout(function (oop) { return function () { oop.cng(); } }(this), 1000);
            }
            else {
                this.obj.innerHTML = this.mess || '';
            }
        }

        /*]]>*/
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageTopDesc" runat="server">
    Backorders
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContentHolder" runat="server">
    <div class="col-md-12">
        <span>My Current Orders
            <a id="AddBackOrder" data-toggle="modal" href="#backorder" style="color: #ffffff; margin: 5px 5px " class="btn btn-xs btn-success">Add</a> 
            <Label ClientIDMode="Static" ID="backorderMessage" style="display:none" Class="alert alert-success pull-right" role="alert" ForeColor="Green" runat="server" />
        </span>
        <ul id="tabs" class="nav nav-tabs" data-tabs="tabs">
            <li class="active pull-right"><a href="#Current" data-toggle="tab">Current</a></li>
            <li class="pull-right"><a href="#Historical" data-toggle="tab">Historical</a></li>
        </ul>
        
        <div id="my-tab-content" class="tab-content">
            <div class="tab-pane active" id="Current">
                <cc1:LunchboxGridView OnRowCommand="MyBids_RowCommand" ID="LunchboxGridView2" runat="server" AutoGenerateColumns="False"  
                    OnRowDataBound="grdView_OnRowDataBoundCurrent"  AccessKeyDataKeyNames="OrderID"  CellPadding="4" CssClass="gridOverall" GridLines="None" 
                    AllowSorting="True" Width="100%" onsorting="gvAgency_Sorting" OnRowEditing="LunchboxGridView2_OnRowEditing">
                    <EmptyDataTemplate>No items currenlty set</EmptyDataTemplate>
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="20px">
                        <itemtemplate>
                            <a id="togg" data-toggle="modal" onclick="divexpandcollapse('<%#Eval("OrderID")%>')" href="#<%#Eval("OrderID")%>" />
                            <div class="modal fade" id="<%#Eval("OrderID")%>" role="dialog">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <form class="form-inline" role="form">
                                        <div class="modal-header">
                                            <h4>History<span class="glyphicon glyphicon-signal pull-right"></span></h4>
                                            <h5>(Times are server based)</h5>
                                        </div> 
                                        <div class="modal-body">
                                            <asp:GridView ID="grdViewOrdersOfCustomer" 
                                                    runat="server" AutoGenerateColumns="false"
                                                    CellPadding="4" CssClass="gridOverall" GridLines="None" AllowSorting="False" Width="100%"
                                                    DataKeyNames="HistoryID">
                                                <columns>
                                                    <asp:BoundField ItemStyle-Width="150px" 
                                                        DataField="CreatedDate" HeaderText="Created" />
                                                    <asp:BoundField ItemStyle-Width="150px" 
                                                        DataField="Text" HeaderText="Description" />
                                                </columns>
                                            </asp:GridView>
                                        </div>
                                        <div class="modal-footer">
                                            <a class="btn btn-default" data-dismiss="modal">Close</a>
                                        </div>
                                    </form>
                                </div>
                            </div>
                            </div>
                        </itemtemplate>
                        </asp:TemplateField>
                        <asp:HyperLinkField
                            DataNavigateUrlFields="DomainName"
                            DataNavigateUrlFormatString="https://auctions.godaddy.com/trpItemListing.aspx?miid={0}"
                            DataTextField="DomainName"
                            HeaderText="Domain"
                            Target="_blank"
                            SortExpression="DomainName" />
                        <asp:BoundField HeaderText="Process Date" ReadOnly="True" SortExpression="DateToOrder" DataField="DateToOrder" HtmlEncode="false"/>
                        <asp:TemplateField HeaderText="Count Down" SortExpression="EndDate">
                            <ItemTemplate >
                                <span id="timer_<%# Container.DataItemIndex %>"
                                    class="timer" 
                                    data-start='<%#Eval("DateToOrder", "{0:M/dd/yyyy H:mm:ss}")%>'
                                    data-currentTime='<%# AuctionSniperDLL.Business.Settings.GetPacificTime().ToString("M/dd/yyyy H:mm:ss") %>'></span>
                            </ItemTemplate>
                        </asp:TemplateField>
                    
                        <asp:TemplateField>
                        <EditItemTemplate>
                            <span class="pull-right">
                                <asp:LinkButton Text="Update" style="color: #ffffff; margin: 5px 0 5px 20px" CssClass="btn btn-xs btn-primary" runat="server" CommandName="Update" CommandArgument='<%#Eval("OrderID")%>'/>
                                <asp:LinkButton Text="Cancel" style="color: #ffffff; margin: 5px 5px " CssClass="btn btn-xs btn-warning" runat="server" OnClick = "OnCancel" />
                            </span>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="" SortExpression="">
                            <ItemTemplate>
                                <span class="pull-right">
                                <asp:LinkButton id="lnkBtnDel" style="color: #ffffff; margin: 5px 0 5px 20px" CssClass="btn btn-xs btn-danger" runat="server" CommandName="DeleteRow" OnClientClick="return confirm('Are you sure you want to Delete this Record?');" CommandArgument='<%#Eval("OrderID")%>'>Delete</asp:LinkButton>
                                <a id="SetBid" data-toggle="modal" onclick="myFunction2('<%#Eval("OrderID")%>')" data-id="<%#Eval("OrderID")%>" href="#<%#Eval("OrderID")%>" style="color: #ffffff; margin: 5px 5px " class="open-AddBookDialog btn btn-xs btn-primary">History</a> 
                            </span>
                                    </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="gridRow" />
                    <AlternatingRowStyle CssClass="gridAltRow" />
                    <HeaderStyle CssClass="gridHeader" />
                </cc1:LunchboxGridView>
            </div>
            
            <div class="tab-pane" id="Historical">
                
            </div>
        </div>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <div class="modal fade" id="backorder" role="dialog">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4>Add a new Backorder <span class="glyphicon glyphicon-plus pull-right"></span></h4>
                    </div> 
                        <div class="modal-body">
                            <div class="form-group">
                            <label class="sr-only">Details</label>
                                <label>Domain Name:</label>
                                <br/>
                                <asp:TextBox ID="domainName" Width="350px" placeholder="Enter Domain Name (Domain.Extension)" required runat="server"></asp:TextBox>
                                <br/>
                                <label>Alert Emails:</label>
                                <br/>
                                <asp:TextBox ID="AlertEmail1" placeholder="Email address 1" runat="server" required></asp:TextBox>
                                <asp:TextBox ID="AlertEmail2" placeholder="Email address 2" runat="server"></asp:TextBox>
                                <br/>
                                <label>Date To Place Order:</label>
                                <div runat="server" ClientIDMode="Static" class='input-group date' id='datetimepicker1'>
                                    <input id="datetimepickervalue" type='datetime' data-format="yyyy-MM-dd hh:mm:ss" runat="server" class="form-control" required />
                                    <span class="input-group-addon">
                                        <span class="glyphicon glyphicon-calendar"></span>
                                    </span>
                                </div>
                                <asp:TextBox Visible="False" ID="datePickedHidden" runat="server" required></asp:TextBox>
                                <br/>
                                <label>Credits To Use:</label>
                                <input runat="server" type="number" class="form-control" id="credits" placeholder="Credits" min="1" required/>
                                <br/>
                                <asp:LinkButton ID="LinkButton2" OnClick="LinkButton2_OnClick" runat="server" class="btn btn-default">Submit</asp:LinkButton>
                            </div>

                            </div>
                        </div> 
                    </div>
                    <div class="modal-footer">
                        <a class="btn btn-default" id="closebug" data-dismiss="modal">Close</a>
                    </div>
                </div>  
                
            </ContentTemplate>
        </asp:UpdatePanel>


    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $('#datetimepicker1').datetimepicker();
        });
        </script>
    <script type='text/javascript'>
        //generate countdown timers for every auction - booya
        function applyTimers() {
            $(".timer").each(function () {
                var dateFuture = new Date($(this).data("start"));
                var dateNow = new Date($(this).data("currenttime"));

                var seconds = Math.floor((dateFuture - (dateNow)) / 1000);
                var minutes = Math.floor(seconds / 60);
                var hours = (Math.floor(minutes / 60));
                var days = Math.floor(hours / 24);

                hours = hours - (days * 24);
                minutes = minutes - (days * 24 * 60) - (hours * 60);
                seconds = seconds - (days * 24 * 60 * 60) - (hours * 60 * 60) - (minutes * 60);
                zxcCountDown($(this).attr("id"), 'Ended', seconds, minutes, hours, days);

            });
        };

        $(document).ready(function () {
            applyTimers();
        });

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            applyTimers();
        });

</script>
</asp:Content>
