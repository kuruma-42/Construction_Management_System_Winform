﻿//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EldigmPlusApp.WsMHome {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DataTopMenu", Namespace="http://schemas.datacontract.org/2004/07/EldigmPlusSvc_Memco.WebSvc.MainHome")]
    [System.SerializableAttribute()]
    public partial class DataTopMenu : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TOP_MENU_CDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TOP_MENU_NMField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TOP_MENU_CD {
            get {
                return this.TOP_MENU_CDField;
            }
            set {
                if ((this.TOP_MENU_CDField.Equals(value) != true)) {
                    this.TOP_MENU_CDField = value;
                    this.RaisePropertyChanged("TOP_MENU_CD");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TOP_MENU_NM {
            get {
                return this.TOP_MENU_NMField;
            }
            set {
                if ((object.ReferenceEquals(this.TOP_MENU_NMField, value) != true)) {
                    this.TOP_MENU_NMField = value;
                    this.RaisePropertyChanged("TOP_MENU_NM");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DataSubMenu1", Namespace="http://schemas.datacontract.org/2004/07/EldigmPlusSvc_Memco.WebSvc.MainHome")]
    [System.SerializableAttribute()]
    public partial class DataSubMenu1 : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SUB_MENU_CDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SUB_MENU_NMField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SUB_MENU_CD {
            get {
                return this.SUB_MENU_CDField;
            }
            set {
                if ((this.SUB_MENU_CDField.Equals(value) != true)) {
                    this.SUB_MENU_CDField = value;
                    this.RaisePropertyChanged("SUB_MENU_CD");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SUB_MENU_NM {
            get {
                return this.SUB_MENU_NMField;
            }
            set {
                if ((object.ReferenceEquals(this.SUB_MENU_NMField, value) != true)) {
                    this.SUB_MENU_NMField = value;
                    this.RaisePropertyChanged("SUB_MENU_NM");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DataSubMenu2", Namespace="http://schemas.datacontract.org/2004/07/EldigmPlusSvc_Memco.WebSvc.MainHome")]
    [System.SerializableAttribute()]
    public partial class DataSubMenu2 : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MENU_CDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TOP_MENU_CDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SUB_MENU_CDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MENU_NMField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MEMOField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MENU_PATHField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MENU_CD {
            get {
                return this.MENU_CDField;
            }
            set {
                if ((object.ReferenceEquals(this.MENU_CDField, value) != true)) {
                    this.MENU_CDField = value;
                    this.RaisePropertyChanged("MENU_CD");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TOP_MENU_CD {
            get {
                return this.TOP_MENU_CDField;
            }
            set {
                if ((this.TOP_MENU_CDField.Equals(value) != true)) {
                    this.TOP_MENU_CDField = value;
                    this.RaisePropertyChanged("TOP_MENU_CD");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public int SUB_MENU_CD {
            get {
                return this.SUB_MENU_CDField;
            }
            set {
                if ((this.SUB_MENU_CDField.Equals(value) != true)) {
                    this.SUB_MENU_CDField = value;
                    this.RaisePropertyChanged("SUB_MENU_CD");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public string MENU_NM {
            get {
                return this.MENU_NMField;
            }
            set {
                if ((object.ReferenceEquals(this.MENU_NMField, value) != true)) {
                    this.MENU_NMField = value;
                    this.RaisePropertyChanged("MENU_NM");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public string MEMO {
            get {
                return this.MEMOField;
            }
            set {
                if ((object.ReferenceEquals(this.MEMOField, value) != true)) {
                    this.MEMOField = value;
                    this.RaisePropertyChanged("MEMO");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public string MENU_PATH {
            get {
                return this.MENU_PATHField;
            }
            set {
                if ((object.ReferenceEquals(this.MENU_PATHField, value) != true)) {
                    this.MENU_PATHField = value;
                    this.RaisePropertyChanged("MENU_PATH");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WsMHome.IWsMainHome")]
    public interface IWsMainHome {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWsMainHome/sDbNm", ReplyAction="http://tempuri.org/IWsMainHome/sDbNmResponse")]
        EldigmPlusApp.WsMHome.sDbNmResponse sDbNm(EldigmPlusApp.WsMHome.sDbNmRequest request);
        
        // CODEGEN: 작업에 여러 개의 반환 값이 있기 때문에 메시지 계약을 생성하는 중입니다.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWsMainHome/sDbNm", ReplyAction="http://tempuri.org/IWsMainHome/sDbNmResponse")]
        System.Threading.Tasks.Task<EldigmPlusApp.WsMHome.sDbNmResponse> sDbNmAsync(EldigmPlusApp.WsMHome.sDbNmRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWsMainHome/sSiteMenu", ReplyAction="http://tempuri.org/IWsMainHome/sSiteMenuResponse")]
        EldigmPlusApp.WsMHome.sSiteMenuResponse sSiteMenu(EldigmPlusApp.WsMHome.sSiteMenuRequest request);
        
        // CODEGEN: 작업에 여러 개의 반환 값이 있기 때문에 메시지 계약을 생성하는 중입니다.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWsMainHome/sSiteMenu", ReplyAction="http://tempuri.org/IWsMainHome/sSiteMenuResponse")]
        System.Threading.Tasks.Task<EldigmPlusApp.WsMHome.sSiteMenuResponse> sSiteMenuAsync(EldigmPlusApp.WsMHome.sSiteMenuRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWsMainHome/sSiteSubMenu1", ReplyAction="http://tempuri.org/IWsMainHome/sSiteSubMenu1Response")]
        EldigmPlusApp.WsMHome.sSiteSubMenu1Response sSiteSubMenu1(EldigmPlusApp.WsMHome.sSiteSubMenu1Request request);
        
        // CODEGEN: 작업에 여러 개의 반환 값이 있기 때문에 메시지 계약을 생성하는 중입니다.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWsMainHome/sSiteSubMenu1", ReplyAction="http://tempuri.org/IWsMainHome/sSiteSubMenu1Response")]
        System.Threading.Tasks.Task<EldigmPlusApp.WsMHome.sSiteSubMenu1Response> sSiteSubMenu1Async(EldigmPlusApp.WsMHome.sSiteSubMenu1Request request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWsMainHome/sSiteSubMenu2", ReplyAction="http://tempuri.org/IWsMainHome/sSiteSubMenu2Response")]
        EldigmPlusApp.WsMHome.sSiteSubMenu2Response sSiteSubMenu2(EldigmPlusApp.WsMHome.sSiteSubMenu2Request request);
        
        // CODEGEN: 작업에 여러 개의 반환 값이 있기 때문에 메시지 계약을 생성하는 중입니다.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWsMainHome/sSiteSubMenu2", ReplyAction="http://tempuri.org/IWsMainHome/sSiteSubMenu2Response")]
        System.Threading.Tasks.Task<EldigmPlusApp.WsMHome.sSiteSubMenu2Response> sSiteSubMenu2Async(EldigmPlusApp.WsMHome.sSiteSubMenu2Request request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sDbNm", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class sDbNmRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string pMemcoCd;
        
        public sDbNmRequest() {
        }
        
        public sDbNmRequest(string pMemcoCd) {
            this.pMemcoCd = pMemcoCd;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sDbNmResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class sDbNmResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string sDbNmResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string reData;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public string reMsg;
        
        public sDbNmResponse() {
        }
        
        public sDbNmResponse(string sDbNmResult, string reData, string reMsg) {
            this.sDbNmResult = sDbNmResult;
            this.reData = reData;
            this.reMsg = reMsg;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sSiteMenu", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class sSiteMenuRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string pDbNm;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string pSiteCd;
        
        public sSiteMenuRequest() {
        }
        
        public sSiteMenuRequest(string pDbNm, string pSiteCd) {
            this.pDbNm = pDbNm;
            this.pSiteCd = pSiteCd;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sSiteMenuResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class sSiteMenuResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string sSiteMenuResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public EldigmPlusApp.WsMHome.DataTopMenu[] reList;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public string reMsg;
        
        public sSiteMenuResponse() {
        }
        
        public sSiteMenuResponse(string sSiteMenuResult, EldigmPlusApp.WsMHome.DataTopMenu[] reList, string reMsg) {
            this.sSiteMenuResult = sSiteMenuResult;
            this.reList = reList;
            this.reMsg = reMsg;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sSiteSubMenu1", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class sSiteSubMenu1Request {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string pDbNm;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string pSiteCd;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public string pTopMenuCd;
        
        public sSiteSubMenu1Request() {
        }
        
        public sSiteSubMenu1Request(string pDbNm, string pSiteCd, string pTopMenuCd) {
            this.pDbNm = pDbNm;
            this.pSiteCd = pSiteCd;
            this.pTopMenuCd = pTopMenuCd;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sSiteSubMenu1Response", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class sSiteSubMenu1Response {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string sSiteSubMenu1Result;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public EldigmPlusApp.WsMHome.DataSubMenu1[] reList;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public string reMsg;
        
        public sSiteSubMenu1Response() {
        }
        
        public sSiteSubMenu1Response(string sSiteSubMenu1Result, EldigmPlusApp.WsMHome.DataSubMenu1[] reList, string reMsg) {
            this.sSiteSubMenu1Result = sSiteSubMenu1Result;
            this.reList = reList;
            this.reMsg = reMsg;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sSiteSubMenu2", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class sSiteSubMenu2Request {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string pDbNm;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string pSiteCd;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public string pTopMenuCd;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=3)]
        public string pSubMenuCd;
        
        public sSiteSubMenu2Request() {
        }
        
        public sSiteSubMenu2Request(string pDbNm, string pSiteCd, string pTopMenuCd, string pSubMenuCd) {
            this.pDbNm = pDbNm;
            this.pSiteCd = pSiteCd;
            this.pTopMenuCd = pTopMenuCd;
            this.pSubMenuCd = pSubMenuCd;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sSiteSubMenu2Response", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class sSiteSubMenu2Response {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string sSiteSubMenu2Result;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public EldigmPlusApp.WsMHome.DataSubMenu2[] reList;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public string reMsg;
        
        public sSiteSubMenu2Response() {
        }
        
        public sSiteSubMenu2Response(string sSiteSubMenu2Result, EldigmPlusApp.WsMHome.DataSubMenu2[] reList, string reMsg) {
            this.sSiteSubMenu2Result = sSiteSubMenu2Result;
            this.reList = reList;
            this.reMsg = reMsg;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWsMainHomeChannel : EldigmPlusApp.WsMHome.IWsMainHome, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WsMainHomeClient : System.ServiceModel.ClientBase<EldigmPlusApp.WsMHome.IWsMainHome>, EldigmPlusApp.WsMHome.IWsMainHome {
        
        public WsMainHomeClient() {
        }
        
        public WsMainHomeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WsMainHomeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WsMainHomeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WsMainHomeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        EldigmPlusApp.WsMHome.sDbNmResponse EldigmPlusApp.WsMHome.IWsMainHome.sDbNm(EldigmPlusApp.WsMHome.sDbNmRequest request) {
            return base.Channel.sDbNm(request);
        }
        
        public string sDbNm(string pMemcoCd, out string reData, out string reMsg) {
            EldigmPlusApp.WsMHome.sDbNmRequest inValue = new EldigmPlusApp.WsMHome.sDbNmRequest();
            inValue.pMemcoCd = pMemcoCd;
            EldigmPlusApp.WsMHome.sDbNmResponse retVal = ((EldigmPlusApp.WsMHome.IWsMainHome)(this)).sDbNm(inValue);
            reData = retVal.reData;
            reMsg = retVal.reMsg;
            return retVal.sDbNmResult;
        }
        
        public System.Threading.Tasks.Task<EldigmPlusApp.WsMHome.sDbNmResponse> sDbNmAsync(EldigmPlusApp.WsMHome.sDbNmRequest request) {
            return base.Channel.sDbNmAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        EldigmPlusApp.WsMHome.sSiteMenuResponse EldigmPlusApp.WsMHome.IWsMainHome.sSiteMenu(EldigmPlusApp.WsMHome.sSiteMenuRequest request) {
            return base.Channel.sSiteMenu(request);
        }
        
        public string sSiteMenu(string pDbNm, string pSiteCd, out EldigmPlusApp.WsMHome.DataTopMenu[] reList, out string reMsg) {
            EldigmPlusApp.WsMHome.sSiteMenuRequest inValue = new EldigmPlusApp.WsMHome.sSiteMenuRequest();
            inValue.pDbNm = pDbNm;
            inValue.pSiteCd = pSiteCd;
            EldigmPlusApp.WsMHome.sSiteMenuResponse retVal = ((EldigmPlusApp.WsMHome.IWsMainHome)(this)).sSiteMenu(inValue);
            reList = retVal.reList;
            reMsg = retVal.reMsg;
            return retVal.sSiteMenuResult;
        }
        
        public System.Threading.Tasks.Task<EldigmPlusApp.WsMHome.sSiteMenuResponse> sSiteMenuAsync(EldigmPlusApp.WsMHome.sSiteMenuRequest request) {
            return base.Channel.sSiteMenuAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        EldigmPlusApp.WsMHome.sSiteSubMenu1Response EldigmPlusApp.WsMHome.IWsMainHome.sSiteSubMenu1(EldigmPlusApp.WsMHome.sSiteSubMenu1Request request) {
            return base.Channel.sSiteSubMenu1(request);
        }
        
        public string sSiteSubMenu1(string pDbNm, string pSiteCd, string pTopMenuCd, out EldigmPlusApp.WsMHome.DataSubMenu1[] reList, out string reMsg) {
            EldigmPlusApp.WsMHome.sSiteSubMenu1Request inValue = new EldigmPlusApp.WsMHome.sSiteSubMenu1Request();
            inValue.pDbNm = pDbNm;
            inValue.pSiteCd = pSiteCd;
            inValue.pTopMenuCd = pTopMenuCd;
            EldigmPlusApp.WsMHome.sSiteSubMenu1Response retVal = ((EldigmPlusApp.WsMHome.IWsMainHome)(this)).sSiteSubMenu1(inValue);
            reList = retVal.reList;
            reMsg = retVal.reMsg;
            return retVal.sSiteSubMenu1Result;
        }
        
        public System.Threading.Tasks.Task<EldigmPlusApp.WsMHome.sSiteSubMenu1Response> sSiteSubMenu1Async(EldigmPlusApp.WsMHome.sSiteSubMenu1Request request) {
            return base.Channel.sSiteSubMenu1Async(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        EldigmPlusApp.WsMHome.sSiteSubMenu2Response EldigmPlusApp.WsMHome.IWsMainHome.sSiteSubMenu2(EldigmPlusApp.WsMHome.sSiteSubMenu2Request request) {
            return base.Channel.sSiteSubMenu2(request);
        }
        
        public string sSiteSubMenu2(string pDbNm, string pSiteCd, string pTopMenuCd, string pSubMenuCd, out EldigmPlusApp.WsMHome.DataSubMenu2[] reList, out string reMsg) {
            EldigmPlusApp.WsMHome.sSiteSubMenu2Request inValue = new EldigmPlusApp.WsMHome.sSiteSubMenu2Request();
            inValue.pDbNm = pDbNm;
            inValue.pSiteCd = pSiteCd;
            inValue.pTopMenuCd = pTopMenuCd;
            inValue.pSubMenuCd = pSubMenuCd;
            EldigmPlusApp.WsMHome.sSiteSubMenu2Response retVal = ((EldigmPlusApp.WsMHome.IWsMainHome)(this)).sSiteSubMenu2(inValue);
            reList = retVal.reList;
            reMsg = retVal.reMsg;
            return retVal.sSiteSubMenu2Result;
        }
        
        public System.Threading.Tasks.Task<EldigmPlusApp.WsMHome.sSiteSubMenu2Response> sSiteSubMenu2Async(EldigmPlusApp.WsMHome.sSiteSubMenu2Request request) {
            return base.Channel.sSiteSubMenu2Async(request);
        }
    }
}
