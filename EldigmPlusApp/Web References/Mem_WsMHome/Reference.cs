﻿//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 이 소스 코드가 Microsoft.VSDesigner, 버전 4.0.30319.42000에서 자동으로 생성되었습니다.
// 
#pragma warning disable 1591

namespace EldigmPlusApp.Mem_WsMHome {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="BasicHttpBinding_IWsMainHome", Namespace="http://tempuri.org/")]
    public partial class WsMainHome : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback sDbNmOperationCompleted;
        
        private System.Threading.SendOrPostCallback sSiteMenuOperationCompleted;
        
        private System.Threading.SendOrPostCallback sSiteSubMenu1OperationCompleted;
        
        private System.Threading.SendOrPostCallback sSiteSubMenu2OperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public WsMainHome() {
            this.Url = global::EldigmPlusApp.Properties.Settings.Default.EldigmPlusApp_Mem_WsMHome_WsMainHome;
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
        public event sDbNmCompletedEventHandler sDbNmCompleted;
        
        /// <remarks/>
        public event sSiteMenuCompletedEventHandler sSiteMenuCompleted;
        
        /// <remarks/>
        public event sSiteSubMenu1CompletedEventHandler sSiteSubMenu1Completed;
        
        /// <remarks/>
        public event sSiteSubMenu2CompletedEventHandler sSiteSubMenu2Completed;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IWsMainHome/sDbNm", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string sDbNm([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string pMemcoCd, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] out string reData, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] out string reMsg) {
            object[] results = this.Invoke("sDbNm", new object[] {
                        pMemcoCd});
            reData = ((string)(results[1]));
            reMsg = ((string)(results[2]));
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void sDbNmAsync(string pMemcoCd) {
            this.sDbNmAsync(pMemcoCd, null);
        }
        
        /// <remarks/>
        public void sDbNmAsync(string pMemcoCd, object userState) {
            if ((this.sDbNmOperationCompleted == null)) {
                this.sDbNmOperationCompleted = new System.Threading.SendOrPostCallback(this.OnsDbNmOperationCompleted);
            }
            this.InvokeAsync("sDbNm", new object[] {
                        pMemcoCd}, this.sDbNmOperationCompleted, userState);
        }
        
        private void OnsDbNmOperationCompleted(object arg) {
            if ((this.sDbNmCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.sDbNmCompleted(this, new sDbNmCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IWsMainHome/sSiteMenu", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string sSiteMenu([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string pDbNm, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string pSiteCd, [System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)] [System.Xml.Serialization.XmlArrayItemAttribute(Namespace="http://schemas.datacontract.org/2004/07/EldigmPlusSvc_Memco.WebSvc.MainHome")] out DataTopMenu[] reList, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] out string reMsg) {
            object[] results = this.Invoke("sSiteMenu", new object[] {
                        pDbNm,
                        pSiteCd});
            reList = ((DataTopMenu[])(results[1]));
            reMsg = ((string)(results[2]));
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void sSiteMenuAsync(string pDbNm, string pSiteCd) {
            this.sSiteMenuAsync(pDbNm, pSiteCd, null);
        }
        
        /// <remarks/>
        public void sSiteMenuAsync(string pDbNm, string pSiteCd, object userState) {
            if ((this.sSiteMenuOperationCompleted == null)) {
                this.sSiteMenuOperationCompleted = new System.Threading.SendOrPostCallback(this.OnsSiteMenuOperationCompleted);
            }
            this.InvokeAsync("sSiteMenu", new object[] {
                        pDbNm,
                        pSiteCd}, this.sSiteMenuOperationCompleted, userState);
        }
        
        private void OnsSiteMenuOperationCompleted(object arg) {
            if ((this.sSiteMenuCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.sSiteMenuCompleted(this, new sSiteMenuCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IWsMainHome/sSiteSubMenu1", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string sSiteSubMenu1([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string pDbNm, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string pSiteCd, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string pTopMenuCd, [System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)] [System.Xml.Serialization.XmlArrayItemAttribute(Namespace="http://schemas.datacontract.org/2004/07/EldigmPlusSvc_Memco.WebSvc.MainHome")] out DataSubMenu1[] reList, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] out string reMsg) {
            object[] results = this.Invoke("sSiteSubMenu1", new object[] {
                        pDbNm,
                        pSiteCd,
                        pTopMenuCd});
            reList = ((DataSubMenu1[])(results[1]));
            reMsg = ((string)(results[2]));
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void sSiteSubMenu1Async(string pDbNm, string pSiteCd, string pTopMenuCd) {
            this.sSiteSubMenu1Async(pDbNm, pSiteCd, pTopMenuCd, null);
        }
        
        /// <remarks/>
        public void sSiteSubMenu1Async(string pDbNm, string pSiteCd, string pTopMenuCd, object userState) {
            if ((this.sSiteSubMenu1OperationCompleted == null)) {
                this.sSiteSubMenu1OperationCompleted = new System.Threading.SendOrPostCallback(this.OnsSiteSubMenu1OperationCompleted);
            }
            this.InvokeAsync("sSiteSubMenu1", new object[] {
                        pDbNm,
                        pSiteCd,
                        pTopMenuCd}, this.sSiteSubMenu1OperationCompleted, userState);
        }
        
        private void OnsSiteSubMenu1OperationCompleted(object arg) {
            if ((this.sSiteSubMenu1Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.sSiteSubMenu1Completed(this, new sSiteSubMenu1CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IWsMainHome/sSiteSubMenu2", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string sSiteSubMenu2([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string pDbNm, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string pSiteCd, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string pTopMenuCd, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string pSubMenuCd, [System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)] [System.Xml.Serialization.XmlArrayItemAttribute(Namespace="http://schemas.datacontract.org/2004/07/EldigmPlusSvc_Memco.WebSvc.MainHome")] out DataSubMenu2[] reList, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] out string reMsg) {
            object[] results = this.Invoke("sSiteSubMenu2", new object[] {
                        pDbNm,
                        pSiteCd,
                        pTopMenuCd,
                        pSubMenuCd});
            reList = ((DataSubMenu2[])(results[1]));
            reMsg = ((string)(results[2]));
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void sSiteSubMenu2Async(string pDbNm, string pSiteCd, string pTopMenuCd, string pSubMenuCd) {
            this.sSiteSubMenu2Async(pDbNm, pSiteCd, pTopMenuCd, pSubMenuCd, null);
        }
        
        /// <remarks/>
        public void sSiteSubMenu2Async(string pDbNm, string pSiteCd, string pTopMenuCd, string pSubMenuCd, object userState) {
            if ((this.sSiteSubMenu2OperationCompleted == null)) {
                this.sSiteSubMenu2OperationCompleted = new System.Threading.SendOrPostCallback(this.OnsSiteSubMenu2OperationCompleted);
            }
            this.InvokeAsync("sSiteSubMenu2", new object[] {
                        pDbNm,
                        pSiteCd,
                        pTopMenuCd,
                        pSubMenuCd}, this.sSiteSubMenu2OperationCompleted, userState);
        }
        
        private void OnsSiteSubMenu2OperationCompleted(object arg) {
            if ((this.sSiteSubMenu2Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.sSiteSubMenu2Completed(this, new sSiteSubMenu2CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/EldigmPlusSvc_Memco.WebSvc.MainHome")]
    public partial class DataTopMenu {
        
        private int tOP_MENU_CDField;
        
        private bool tOP_MENU_CDFieldSpecified;
        
        private string tOP_MENU_NMField;
        
        /// <remarks/>
        public int TOP_MENU_CD {
            get {
                return this.tOP_MENU_CDField;
            }
            set {
                this.tOP_MENU_CDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TOP_MENU_CDSpecified {
            get {
                return this.tOP_MENU_CDFieldSpecified;
            }
            set {
                this.tOP_MENU_CDFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string TOP_MENU_NM {
            get {
                return this.tOP_MENU_NMField;
            }
            set {
                this.tOP_MENU_NMField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/EldigmPlusSvc_Memco.WebSvc.MainHome")]
    public partial class DataSubMenu2 {
        
        private string mENU_CDField;
        
        private int tOP_MENU_CDField;
        
        private bool tOP_MENU_CDFieldSpecified;
        
        private int sUB_MENU_CDField;
        
        private bool sUB_MENU_CDFieldSpecified;
        
        private string mENU_NMField;
        
        private string mEMOField;
        
        private string mENU_PATHField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string MENU_CD {
            get {
                return this.mENU_CDField;
            }
            set {
                this.mENU_CDField = value;
            }
        }
        
        /// <remarks/>
        public int TOP_MENU_CD {
            get {
                return this.tOP_MENU_CDField;
            }
            set {
                this.tOP_MENU_CDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TOP_MENU_CDSpecified {
            get {
                return this.tOP_MENU_CDFieldSpecified;
            }
            set {
                this.tOP_MENU_CDFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public int SUB_MENU_CD {
            get {
                return this.sUB_MENU_CDField;
            }
            set {
                this.sUB_MENU_CDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SUB_MENU_CDSpecified {
            get {
                return this.sUB_MENU_CDFieldSpecified;
            }
            set {
                this.sUB_MENU_CDFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string MENU_NM {
            get {
                return this.mENU_NMField;
            }
            set {
                this.mENU_NMField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string MEMO {
            get {
                return this.mEMOField;
            }
            set {
                this.mEMOField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string MENU_PATH {
            get {
                return this.mENU_PATHField;
            }
            set {
                this.mENU_PATHField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/EldigmPlusSvc_Memco.WebSvc.MainHome")]
    public partial class DataSubMenu1 {
        
        private int sUB_MENU_CDField;
        
        private bool sUB_MENU_CDFieldSpecified;
        
        private string sUB_MENU_NMField;
        
        /// <remarks/>
        public int SUB_MENU_CD {
            get {
                return this.sUB_MENU_CDField;
            }
            set {
                this.sUB_MENU_CDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SUB_MENU_CDSpecified {
            get {
                return this.sUB_MENU_CDFieldSpecified;
            }
            set {
                this.sUB_MENU_CDFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string SUB_MENU_NM {
            get {
                return this.sUB_MENU_NMField;
            }
            set {
                this.sUB_MENU_NMField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void sDbNmCompletedEventHandler(object sender, sDbNmCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class sDbNmCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal sDbNmCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
        
        /// <remarks/>
        public string reData {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
        
        /// <remarks/>
        public string reMsg {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[2]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void sSiteMenuCompletedEventHandler(object sender, sSiteMenuCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class sSiteMenuCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal sSiteMenuCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
        
        /// <remarks/>
        public DataTopMenu[] reList {
            get {
                this.RaiseExceptionIfNecessary();
                return ((DataTopMenu[])(this.results[1]));
            }
        }
        
        /// <remarks/>
        public string reMsg {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[2]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void sSiteSubMenu1CompletedEventHandler(object sender, sSiteSubMenu1CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class sSiteSubMenu1CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal sSiteSubMenu1CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
        
        /// <remarks/>
        public DataSubMenu1[] reList {
            get {
                this.RaiseExceptionIfNecessary();
                return ((DataSubMenu1[])(this.results[1]));
            }
        }
        
        /// <remarks/>
        public string reMsg {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[2]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void sSiteSubMenu2CompletedEventHandler(object sender, sSiteSubMenu2CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class sSiteSubMenu2CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal sSiteSubMenu2CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
        
        /// <remarks/>
        public DataSubMenu2[] reList {
            get {
                this.RaiseExceptionIfNecessary();
                return ((DataSubMenu2[])(this.results[1]));
            }
        }
        
        /// <remarks/>
        public string reMsg {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[2]));
            }
        }
    }
}

#pragma warning restore 1591