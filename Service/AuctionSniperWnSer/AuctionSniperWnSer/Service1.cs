﻿using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.ServiceProcess;
using System.Threading;
using ASEntityFramework;
using AuctionSniperDLL.Business;
using AuctionSniperDLL.Business.Sites;
using Timer = System.Timers.Timer;

namespace AuctionSniperWnSer
{
    partial class Service1 : ServiceBase
    {
        public Timer CheckTimer { get; set; }
        public Timer AlertTimer { get; set; }
            
        public Service1()
        {
            InitializeComponent();
        }

        private bool Debug { get; set; }

        public void OnDebug()
        {
            Debug = true;
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                Email.SendEmail("codebyexample@gmail.com", "ServiceStarted", "Started the service");
                Console.WriteLine(@"Backorder Service Started");
                CheckDB();
                Email.SendEmail("codebyexample@gmail.com", "ServiceTested", "Successfull test");
            }
            catch (Exception ex)
            {
                Email.SendEmail("codebyexample@gmail.com", "Backorder ServiceTested", "failed test: " + ex.Message);
            }
            
            var th1 = new Thread(() =>
            {
                CheckTimer = new Timer(10000); // Run every 10 sec
                CheckTimer.Elapsed += EmailCheckTimer_Elapsed;
                CheckTimer.Enabled = true;
                CheckTimer.Start();
            });
            th1.SetApartmentState(ApartmentState.STA);
            th1.IsBackground = true;
            th1.Start();
        }

        void AlertTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                CheckAlerts();
            }
            catch (Exception ex)
            {
                SendErrorReport(ex);
            }

        }

        void SendErrorReport(Exception ex)
        {
            try
            {
                var message = ex.Message + Environment.NewLine +
                          ex.StackTrace + Environment.NewLine;
                message += ex.InnerException.Message;
                new Error().Add(message);
                Email.SendEmail("codebyexample@gmail.com", "Backorder Service Error - Alerts",
                        ex.Message + Environment.NewLine +
                        ex.StackTrace + Environment.NewLine);
            }
            catch (Exception)
            {

            }
            
        }

        void EmailCheckTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                CheckBackOrders();
            }
            catch (Exception ex)
            {
                SendErrorReport(ex);
            }

        }

        //private const int Timediff = -8;
        /// <summary>
        /// Emai Alerts Trigger
        /// </summary>
        /// <summary>
        /// Emai Alerts Trigger
        /// </summary>
        private void CheckAlerts()
        {
            var ds =
            new ASEntities();
                AlertTimer.Stop();
                var alertsToProcess = ds.Alerts.Where(x => x.Processed == false).ToList();
                foreach (var alert in alertsToProcess)
                {
                    var ts =
                        alert.TriggerTime.Subtract(Settings.GetPacificTime());
                    if (ts.TotalSeconds < Convert.ToInt32(Properties.Settings.Default.BidTime))
                    {
                        try
                        { 

                            alert.Processed = true;
                            ds.Alerts.AddOrUpdate(alert);
                            ds.SaveChanges();

                            var id = alert.AuctionID;
                            var user = from a in ds.Auctions
                                join gda in ds.GoDaddyAccount on a.AccountID equals gda.AccountID
                                join u in ds.Users on gda.UserID equals u.UserID
                                where (a.AuctionID == id)
                                select new {u.Username, a.DomainName, a.AuctionRef, a.MyBid, gda.GoDaddyUsername, gda.GoDaddyPassword, u.ReceiveEmails};

                            if (!user.Any())
                            {
                                continue;
                            }
                            var account = user.First();

                            var alert1 = alert;
                            var gd = new GoDaddyAuctions2Cs();
                            if (alert1.Description == "WIN ALERT")
                            {
                                gd.Login(account.GoDaddyUsername, account.GoDaddyPassword);
                                if (gd.WinCheck(account.DomainName))
                                {
                                    if (Settings.GetPacificTime() > alert1.TriggerTime.AddHours(4))
                                    {
                                        var item = new AuctionHistory
                                        {
                                            HistoryID = Guid.NewGuid(),
                                            Text = "Auction Check (Delayed)",
                                            CreatedDate = Settings.GetPacificTime(),
                                            AuctionLink = alert1.AuctionID
                                        };
                                        ds.AuctionHistory.Add(item);
                                        var item2 = new AuctionHistory
                                        {
                                            HistoryID = Guid.NewGuid(),
                                            Text = "Auction WON",
                                            CreatedDate = Settings.GetPacificTime(),
                                            AuctionLink = alert1.AuctionID
                                        };
                                        ds.AuctionHistory.Add(item);
                                        ds.AuctionHistory.Add(item2);
                                    }
                                    else
                                    {
                                        var item = new AuctionHistory
                                        {
                                            HistoryID = Guid.NewGuid(),
                                            Text = "Auction WON",
                                            CreatedDate = Settings.GetPacificTime(),
                                            AuctionLink = alert1.AuctionID
                                        };
                                        ds.AuctionHistory.Add(item);
                                    }

                                    ds.SaveChanges();
                                }
                                else
                                {
                                    if (Settings.GetPacificTime() > alert1.TriggerTime.AddHours(4))
                                    {
                                        var item = new AuctionHistory
                                        {
                                            HistoryID = Guid.NewGuid(),
                                            Text = "Auction Check (Delayed)",
                                            CreatedDate = Settings.GetPacificTime(),
                                            AuctionLink = alert1.AuctionID
                                        };
                                        ds.AuctionHistory.Add(item);
                                        var item2 = new AuctionHistory
                                        {
                                            HistoryID = Guid.NewGuid(),
                                            Text = "Auction LOST",
                                            CreatedDate = Settings.GetPacificTime(),
                                            AuctionLink = alert1.AuctionID
                                        };
                                        ds.AuctionHistory.Add(item);
                                        ds.AuctionHistory.Add(item2);
                                    }
                                    else
                                    {
                                        var item = new AuctionHistory
                                        {
                                            HistoryID = Guid.NewGuid(),
                                            Text = "Auction LOST",
                                            CreatedDate = Settings.GetPacificTime(),
                                            AuctionLink = alert1.AuctionID
                                        };

                                    ds.AuctionHistory.Add(item);
                                }
                                ds.SaveChanges();
                                }
                            }
                            else
                            {
                                    var minBid = gd.CheckAuction(account.AuctionRef);
                                    if (account.MyBid >= minBid)
                                    {
                                        if (account.ReceiveEmails)
                                        {
                                            var item = new AuctionHistory
                                            {
                                                HistoryID = Guid.NewGuid(),
                                                Text = "Bid Reminder Email Sent",
                                                CreatedDate = Settings.GetPacificTime(),
                                                AuctionLink = alert1.AuctionID
                                            };

                                            ds.AuctionHistory.Add(item);
                                            ds.SaveChanges();

                                            API.Email(account.Username, "12 Hour Auction Reminder",
                                                "A quick reminder!" + Environment.NewLine +
                                                "Your maximum bid of $" + account.MyBid +
                                                "will (thus far!) seal the win!" +
                                                Environment.NewLine +
                                                "Site: " + account.DomainName, "Domain Auction Sniper");
                                        }
                                    }
                                    else
                                    {
                                        if (account.ReceiveEmails)
                                        {
                                            var item = new AuctionHistory
                                            {
                                                HistoryID = Guid.NewGuid(),
                                                Text = "Alerted - Auction will be lost",
                                                CreatedDate = Settings.GetPacificTime(),
                                                AuctionLink = alert1.AuctionID
                                            };

                                            ds.AuctionHistory.Add(item);
                                            ds.SaveChanges();

                                            API.Email(account.Username, "Auction will be lost",
                                                "A quick reminder!" + Environment.NewLine +
                                                "If you don't increase your maximum bid to $" + minBid +
                                                " or more you will loose!" + Environment.NewLine +
                                                "Site: " + account.DomainName, "Domain Auction Sniper");
                                        }
                                        else
                                        {
                                            var item = new AuctionHistory
                                            {
                                                HistoryID = Guid.NewGuid(),
                                                Text = "Auction will be lost - Email warning is disabled",
                                                CreatedDate = Settings.GetPacificTime(),
                                                AuctionLink = alert1.AuctionID
                                            };

                                            ds.AuctionHistory.Add(item);
                                            ds.SaveChanges();
                                        }
                                    }
                                }
                            


                        }
                        catch (Exception ex)
                        {
                            SendErrorReport(ex);
                            ds.Dispose();
                            AlertTimer.Start();
                        }

                    }
                }
                ds.Dispose();
                AlertTimer.Start();
        }

        protected override void OnStop()
        {
            Email.SendEmail("codebyexample@gmail.com", "backorder Service Stopped", "Stopped the service");
            Console.WriteLine(@"Service Stopped");
        }

        private void CheckBackOrders()
        {
            using (var ds = new ASEntities())
            {
                CheckTimer.Stop();
                var tomorrow = Settings.GetPacificTime().AddDays(1);
                var backordersToProcess = ds.BackOrders.Where(x => x.Processed == false && x.DateToOrder <= tomorrow).ToList();
                foreach (var order in backordersToProcess)
                {
                    var ts =
                        order.DateToOrder.Subtract(Settings.GetPacificTime());
                    if (ts.TotalSeconds < Convert.ToInt32(Properties.Settings.Default.BidTime) &&
                       ts.TotalSeconds > 0)
                    {
                        try
                        {
                            order.Processed = true;
                            ds.BackOrders.AddOrUpdate(order);
                            ds.SaveChanges();

                            var item = new AuctionHistory
                            {
                                HistoryID = Guid.NewGuid(),
                                Text = "Order Process Started",
                                CreatedDate = Settings.GetPacificTime(),
                                AuctionLink = order.OrderID
                            };

                            ds.AuctionHistory.Add(item);
                            ds.SaveChanges();

                            var account = ds.GoDaddyAccount.First(x => x.AccountID == order.GoDaddyAccount);
                            var th = new Thread(() =>
                            {
                                try
                                {
                                    var gd = new GoDaddyAuctions2Cs();
                                    if (gd.Login(account.GoDaddyUsername, account.GoDaddyPassword))
                                    {
                                        AddHistoryItem(order.OrderID, "Logged in: " + account.GoDaddyUsername);
                                    }

                                    if (gd.CheckBackOrderDomain_IsValid(order.DomainName))
                                    {
                                        AddHistoryItem(order.OrderID, "Domain confirmed valid: " + order.DomainName);
                                        if (gd.ValidateMonitorEmail(order.AlertEmail1, order.AlertEmail2))
                                        {
                                            AddHistoryItem(order.OrderID, "Alert Email validated: " + order.AlertEmail1);
                                            AddHistoryItem(order.OrderID, "Final submission failed, please check the error log ");
                                        }
                                        else
                                        {
                                            AddHistoryItem(order.OrderID, "Alert Email invalid, order not procesed: " + order.AlertEmail1);
                                        }
                                    }
                                    else
                                    {
                                        AddHistoryItem(order.OrderID, "Domain invalid, order not procesed: " + order.DomainName);
                                    }
                                }
                                catch (Exception e)
                                {
                                    SendErrorReport(e);
                                }


                            });
                            th.SetApartmentState(ApartmentState.STA);
                            th.IsBackground = true;
                            th.Start();
                        }
                        catch (Exception ex)
                        {
                            SendErrorReport(ex);
                        }

                    }
                }

                CheckTimer.Start();
            }
        }

        public void AddHistoryItem(Guid ID, String Message)
        {
            using (var ds = new ASEntities())
            {
                var item = new AuctionHistory
                {
                    HistoryID = Guid.NewGuid(),
                    Text = Message,
                    CreatedDate = Settings.GetPacificTime(),
                    AuctionLink = ID
                };

                ds.AuctionHistory.Add(item);
                ds.SaveChanges();
            }

        }

        //Run the check
        private void CheckDB()
        {
            using (var ds = new ASEntities())
            {
                CheckTimer.Stop();
                var tomorrow = Settings.GetPacificTime().AddDays(1);
                var auctionsToProcess = ds.Auctions.Where(x => x.Processed == false && x.EndDate <= tomorrow).ToList();
                foreach (var auction in auctionsToProcess)
                {
                    var ts =
                        auction.EndDate.Subtract(Settings.GetPacificTime());
                    if (ts.TotalSeconds < Convert.ToInt32(Properties.Settings.Default.BidTime) &&
                        (auction.MinBid < auction.MyBid || auction.MinBid == auction.MyBid) && ts.TotalSeconds > 0)
                    {
                        try
                        {
                            auction.Processed = true;
                            ds.Auctions.AddOrUpdate(auction);
                            ds.SaveChanges();
                             
                            var item = new AuctionHistory
                            {
                                HistoryID = Guid.NewGuid(),
                                Text = "Bid Process Started",
                                CreatedDate = Settings.GetPacificTime(),
                                AuctionLink = auction.AuctionID
                            };

                            ds.AuctionHistory.Add(item);
                            ds.SaveChanges();

                            var account = ds.GoDaddyAccount.First(x => x.AccountID == auction.AccountID);
                            var auction1 = auction;
                            var auction2 = auction;
                            var th = new Thread(() =>
                            {
                                try
                                {
                                    var gd = new GoDaddyAuctions2Cs();
                                    gd.PlaceBid(account, auction1);
                                    Email.SendEmail("codebyexample@gmail.com", "Placing a bid", "Account: " + account.GoDaddyUsername + Environment.NewLine +
                                    "Site: " + auction2.DomainName);
                                }
                                catch (Exception e)
                                {
                                    SendErrorReport(e);
                                }
                                

                            });
                            th.SetApartmentState(ApartmentState.STA);
                            th.IsBackground = true;
                            th.Start();
                        }
                        catch (Exception ex)
                        {
                            SendErrorReport(ex);
                        }

                    }
                }

                CheckTimer.Start();
            }
        }
    }
}
