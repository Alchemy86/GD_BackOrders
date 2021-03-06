﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.34014.
// 
#pragma warning disable 1591

namespace AuctionSniperWnSer.LunchboxAPI {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="LunchboxCode APIBinding", Namespace="url")]
    public partial class LunchboxCodeAPI : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback LoginOperationCompleted;
        
        private System.Threading.SendOrPostCallback LoginWPOperationCompleted;
        
        private System.Threading.SendOrPostCallback EmailOperationCompleted;
        
        private System.Threading.SendOrPostCallback ReportBugOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public LunchboxCodeAPI() {
            this.Url = global::AuctionSniperWnSer.Properties.Settings.Default.AuctionSniperWnSer_LunchboxAPI_LunchboxCode_API;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event LoginCompletedEventHandler LoginCompleted;
        
        /// <remarks/>
        public event LoginWPCompletedEventHandler LoginWPCompleted;
        
        /// <remarks/>
        public event EmailCompletedEventHandler EmailCompleted;
        
        /// <remarks/>
        public event ReportBugCompletedEventHandler ReportBugCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://www.lunchboxcode.com/service/php/service.php/Login", RequestNamespace="", ResponseNamespace="")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string Login(string name, string password, string software) {
            object[] results = this.Invoke("Login", new object[] {
                        name,
                        password,
                        software});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void LoginAsync(string name, string password, string software) {
            this.LoginAsync(name, password, software, null);
        }
        
        /// <remarks/>
        public void LoginAsync(string name, string password, string software, object userState) {
            if ((this.LoginOperationCompleted == null)) {
                this.LoginOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLoginOperationCompleted);
            }
            this.InvokeAsync("Login", new object[] {
                        name,
                        password,
                        software}, this.LoginOperationCompleted, userState);
        }
        
        private void OnLoginOperationCompleted(object arg) {
            if ((this.LoginCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LoginCompleted(this, new LoginCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://www.lunchboxcode.com/service/php/service.php/LoginWP", RequestNamespace="", ResponseNamespace="")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string LoginWP(string name, string password) {
            object[] results = this.Invoke("LoginWP", new object[] {
                        name,
                        password});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void LoginWPAsync(string name, string password) {
            this.LoginWPAsync(name, password, null);
        }
        
        /// <remarks/>
        public void LoginWPAsync(string name, string password, object userState) {
            if ((this.LoginWPOperationCompleted == null)) {
                this.LoginWPOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLoginWPOperationCompleted);
            }
            this.InvokeAsync("LoginWP", new object[] {
                        name,
                        password}, this.LoginWPOperationCompleted, userState);
        }
        
        private void OnLoginWPOperationCompleted(object arg) {
            if ((this.LoginWPCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LoginWPCompleted(this, new LoginWPCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://www.lunchboxcode.com/service/php/service.php/Email", RequestNamespace="", ResponseNamespace="")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string Email(string to, string title, string content, string from) {
            object[] results = this.Invoke("Email", new object[] {
                        to,
                        title,
                        content,
                        from});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void EmailAsync(string to, string title, string content, string from) {
            this.EmailAsync(to, title, content, from, null);
        }
        
        /// <remarks/>
        public void EmailAsync(string to, string title, string content, string from, object userState) {
            if ((this.EmailOperationCompleted == null)) {
                this.EmailOperationCompleted = new System.Threading.SendOrPostCallback(this.OnEmailOperationCompleted);
            }
            this.InvokeAsync("Email", new object[] {
                        to,
                        title,
                        content,
                        from}, this.EmailOperationCompleted, userState);
        }
        
        private void OnEmailOperationCompleted(object arg) {
            if ((this.EmailCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.EmailCompleted(this, new EmailCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://www.lunchboxcode.com/service/php/service.php/ReportBug", RequestNamespace="", ResponseNamespace="")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string ReportBug(string software, string error, string user) {
            object[] results = this.Invoke("ReportBug", new object[] {
                        software,
                        error,
                        user});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ReportBugAsync(string software, string error, string user) {
            this.ReportBugAsync(software, error, user, null);
        }
        
        /// <remarks/>
        public void ReportBugAsync(string software, string error, string user, object userState) {
            if ((this.ReportBugOperationCompleted == null)) {
                this.ReportBugOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReportBugOperationCompleted);
            }
            this.InvokeAsync("ReportBug", new object[] {
                        software,
                        error,
                        user}, this.ReportBugOperationCompleted, userState);
        }
        
        private void OnReportBugOperationCompleted(object arg) {
            if ((this.ReportBugCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ReportBugCompleted(this, new ReportBugCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void LoginCompletedEventHandler(object sender, LoginCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class LoginCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal LoginCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void LoginWPCompletedEventHandler(object sender, LoginWPCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class LoginWPCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal LoginWPCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void EmailCompletedEventHandler(object sender, EmailCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class EmailCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal EmailCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void ReportBugCompletedEventHandler(object sender, ReportBugCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ReportBugCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ReportBugCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591