﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReference1
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ParametryWyszukiwania", Namespace="http://CIS/BIR/PUBL/2014/07/DataContract")]
    public partial class ParametryWyszukiwania : object
    {
        
        private string KrsField;
        
        private string KrsyField;
        
        private string NipField;
        
        private string NipyField;
        
        private string RegonField;
        
        private string Regony14znField;
        
        private string Regony9znField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Krs
        {
            get
            {
                return this.KrsField;
            }
            set
            {
                this.KrsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Krsy
        {
            get
            {
                return this.KrsyField;
            }
            set
            {
                this.KrsyField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nip
        {
            get
            {
                return this.NipField;
            }
            set
            {
                this.NipField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nipy
        {
            get
            {
                return this.NipyField;
            }
            set
            {
                this.NipyField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Regon
        {
            get
            {
                return this.RegonField;
            }
            set
            {
                this.RegonField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Regony14zn
        {
            get
            {
                return this.Regony14znField;
            }
            set
            {
                this.Regony14znField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Regony9zn
        {
            get
            {
                return this.Regony9znField;
            }
            set
            {
                this.Regony9znField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IUslugaBIRzewnPubl")]
    public interface IUslugaBIRzewnPubl
    {
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://CIS/BIR/2014/07) of message GetValueRequest does not match the default value (http://tempuri.org/)
        [System.ServiceModel.OperationContractAttribute(Action="http://CIS/BIR/2014/07/IUslugaBIR/GetValue", ReplyAction="http://CIS/BIR/2014/07/IUslugaBIR/GetValueResponse")]
        ServiceReference1.GetValueResponse GetValue(ServiceReference1.GetValueRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://CIS/BIR/2014/07/IUslugaBIR/GetValue", ReplyAction="http://CIS/BIR/2014/07/IUslugaBIR/GetValueResponse")]
        System.Threading.Tasks.Task<ServiceReference1.GetValueResponse> GetValueAsync(ServiceReference1.GetValueRequest request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://CIS/BIR/PUBL/2014/07) of message ZalogujRequest does not match the default value (http://tempuri.org/)
        [System.ServiceModel.OperationContractAttribute(Action="http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/Zaloguj", ReplyAction="http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/ZalogujResponse")]
        ServiceReference1.ZalogujResponse Zaloguj(ServiceReference1.ZalogujRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/Zaloguj", ReplyAction="http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/ZalogujResponse")]
        System.Threading.Tasks.Task<ServiceReference1.ZalogujResponse> ZalogujAsync(ServiceReference1.ZalogujRequest request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://CIS/BIR/PUBL/2014/07) of message WylogujRequest does not match the default value (http://tempuri.org/)
        [System.ServiceModel.OperationContractAttribute(Action="http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/Wyloguj", ReplyAction="http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/WylogujResponse")]
        ServiceReference1.WylogujResponse Wyloguj(ServiceReference1.WylogujRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/Wyloguj", ReplyAction="http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/WylogujResponse")]
        System.Threading.Tasks.Task<ServiceReference1.WylogujResponse> WylogujAsync(ServiceReference1.WylogujRequest request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://CIS/BIR/PUBL/2014/07) of message DaneSzukajPodmiotyRequest does not match the default value (http://tempuri.org/)
        [System.ServiceModel.OperationContractAttribute(Action="http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/DaneSzukajPodmioty", ReplyAction="http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/DaneSzukajPodmiotyResponse")]
        ServiceReference1.DaneSzukajPodmiotyResponse DaneSzukajPodmioty(ServiceReference1.DaneSzukajPodmiotyRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/DaneSzukajPodmioty", ReplyAction="http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/DaneSzukajPodmiotyResponse")]
        System.Threading.Tasks.Task<ServiceReference1.DaneSzukajPodmiotyResponse> DaneSzukajPodmiotyAsync(ServiceReference1.DaneSzukajPodmiotyRequest request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://CIS/BIR/PUBL/2014/07) of message DanePobierzPelnyRaportRequest does not match the default value (http://tempuri.org/)
        [System.ServiceModel.OperationContractAttribute(Action="http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/DanePobierzPelnyRaport", ReplyAction="http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/DanePobierzPelnyRaportResponse")]
        ServiceReference1.DanePobierzPelnyRaportResponse DanePobierzPelnyRaport(ServiceReference1.DanePobierzPelnyRaportRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/DanePobierzPelnyRaport", ReplyAction="http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/DanePobierzPelnyRaportResponse")]
        System.Threading.Tasks.Task<ServiceReference1.DanePobierzPelnyRaportResponse> DanePobierzPelnyRaportAsync(ServiceReference1.DanePobierzPelnyRaportRequest request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://CIS/BIR/PUBL/2014/07) of message DanePobierzRaportZbiorczyRequest does not match the default value (http://tempuri.org/)
        [System.ServiceModel.OperationContractAttribute(Action="http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/DanePobierzRaportZbiorczy", ReplyAction="http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/DanePobierzRaportZbiorczyResponse")]
        ServiceReference1.DanePobierzRaportZbiorczyResponse DanePobierzRaportZbiorczy(ServiceReference1.DanePobierzRaportZbiorczyRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/DanePobierzRaportZbiorczy", ReplyAction="http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/DanePobierzRaportZbiorczyResponse")]
        System.Threading.Tasks.Task<ServiceReference1.DanePobierzRaportZbiorczyResponse> DanePobierzRaportZbiorczyAsync(ServiceReference1.DanePobierzRaportZbiorczyRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetValue", WrapperNamespace="http://CIS/BIR/2014/07", IsWrapped=true)]
    public partial class GetValueRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://CIS/BIR/2014/07", Order=0)]
        public string pNazwaParametru;
        
        public GetValueRequest()
        {
        }
        
        public GetValueRequest(string pNazwaParametru)
        {
            this.pNazwaParametru = pNazwaParametru;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetValueResponse", WrapperNamespace="http://CIS/BIR/2014/07", IsWrapped=true)]
    public partial class GetValueResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://CIS/BIR/2014/07", Order=0)]
        public string GetValueResult;
        
        public GetValueResponse()
        {
        }
        
        public GetValueResponse(string GetValueResult)
        {
            this.GetValueResult = GetValueResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Zaloguj", WrapperNamespace="http://CIS/BIR/PUBL/2014/07", IsWrapped=true)]
    public partial class ZalogujRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://CIS/BIR/PUBL/2014/07", Order=0)]
        public string pKluczUzytkownika;
        
        public ZalogujRequest()
        {
        }
        
        public ZalogujRequest(string pKluczUzytkownika)
        {
            this.pKluczUzytkownika = pKluczUzytkownika;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ZalogujResponse", WrapperNamespace="http://CIS/BIR/PUBL/2014/07", IsWrapped=true)]
    public partial class ZalogujResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://CIS/BIR/PUBL/2014/07", Order=0)]
        public string ZalogujResult;
        
        public ZalogujResponse()
        {
        }
        
        public ZalogujResponse(string ZalogujResult)
        {
            this.ZalogujResult = ZalogujResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Wyloguj", WrapperNamespace="http://CIS/BIR/PUBL/2014/07", IsWrapped=true)]
    public partial class WylogujRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://CIS/BIR/PUBL/2014/07", Order=0)]
        public string pIdentyfikatorSesji;
        
        public WylogujRequest()
        {
        }
        
        public WylogujRequest(string pIdentyfikatorSesji)
        {
            this.pIdentyfikatorSesji = pIdentyfikatorSesji;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="WylogujResponse", WrapperNamespace="http://CIS/BIR/PUBL/2014/07", IsWrapped=true)]
    public partial class WylogujResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://CIS/BIR/PUBL/2014/07", Order=0)]
        public bool WylogujResult;
        
        public WylogujResponse()
        {
        }
        
        public WylogujResponse(bool WylogujResult)
        {
            this.WylogujResult = WylogujResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DaneSzukajPodmioty", WrapperNamespace="http://CIS/BIR/PUBL/2014/07", IsWrapped=true)]
    public partial class DaneSzukajPodmiotyRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://CIS/BIR/PUBL/2014/07", Order=0)]
        public ServiceReference1.ParametryWyszukiwania pParametryWyszukiwania;
        
        public DaneSzukajPodmiotyRequest()
        {
        }
        
        public DaneSzukajPodmiotyRequest(ServiceReference1.ParametryWyszukiwania pParametryWyszukiwania)
        {
            this.pParametryWyszukiwania = pParametryWyszukiwania;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DaneSzukajPodmiotyResponse", WrapperNamespace="http://CIS/BIR/PUBL/2014/07", IsWrapped=true)]
    public partial class DaneSzukajPodmiotyResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://CIS/BIR/PUBL/2014/07", Order=0)]
        public string DaneSzukajPodmiotyResult;
        
        public DaneSzukajPodmiotyResponse()
        {
        }
        
        public DaneSzukajPodmiotyResponse(string DaneSzukajPodmiotyResult)
        {
            this.DaneSzukajPodmiotyResult = DaneSzukajPodmiotyResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DanePobierzPelnyRaport", WrapperNamespace="http://CIS/BIR/PUBL/2014/07", IsWrapped=true)]
    public partial class DanePobierzPelnyRaportRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://CIS/BIR/PUBL/2014/07", Order=0)]
        public string pRegon;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://CIS/BIR/PUBL/2014/07", Order=1)]
        public string pNazwaRaportu;
        
        public DanePobierzPelnyRaportRequest()
        {
        }
        
        public DanePobierzPelnyRaportRequest(string pRegon, string pNazwaRaportu)
        {
            this.pRegon = pRegon;
            this.pNazwaRaportu = pNazwaRaportu;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DanePobierzPelnyRaportResponse", WrapperNamespace="http://CIS/BIR/PUBL/2014/07", IsWrapped=true)]
    public partial class DanePobierzPelnyRaportResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://CIS/BIR/PUBL/2014/07", Order=0)]
        public string DanePobierzPelnyRaportResult;
        
        public DanePobierzPelnyRaportResponse()
        {
        }
        
        public DanePobierzPelnyRaportResponse(string DanePobierzPelnyRaportResult)
        {
            this.DanePobierzPelnyRaportResult = DanePobierzPelnyRaportResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DanePobierzRaportZbiorczy", WrapperNamespace="http://CIS/BIR/PUBL/2014/07", IsWrapped=true)]
    public partial class DanePobierzRaportZbiorczyRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://CIS/BIR/PUBL/2014/07", Order=0)]
        public string pDataRaportu;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://CIS/BIR/PUBL/2014/07", Order=1)]
        public string pNazwaRaportu;
        
        public DanePobierzRaportZbiorczyRequest()
        {
        }
        
        public DanePobierzRaportZbiorczyRequest(string pDataRaportu, string pNazwaRaportu)
        {
            this.pDataRaportu = pDataRaportu;
            this.pNazwaRaportu = pNazwaRaportu;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DanePobierzRaportZbiorczyResponse", WrapperNamespace="http://CIS/BIR/PUBL/2014/07", IsWrapped=true)]
    public partial class DanePobierzRaportZbiorczyResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://CIS/BIR/PUBL/2014/07", Order=0)]
        public string DanePobierzRaportZbiorczyResult;
        
        public DanePobierzRaportZbiorczyResponse()
        {
        }
        
        public DanePobierzRaportZbiorczyResponse(string DanePobierzRaportZbiorczyResult)
        {
            this.DanePobierzRaportZbiorczyResult = DanePobierzRaportZbiorczyResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public interface IUslugaBIRzewnPublChannel : ServiceReference1.IUslugaBIRzewnPubl, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public partial class UslugaBIRzewnPublClient : System.ServiceModel.ClientBase<ServiceReference1.IUslugaBIRzewnPubl>, ServiceReference1.IUslugaBIRzewnPubl
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public UslugaBIRzewnPublClient() : 
                base(UslugaBIRzewnPublClient.GetDefaultBinding(), UslugaBIRzewnPublClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.e3.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public UslugaBIRzewnPublClient(EndpointConfiguration endpointConfiguration) : 
                base(UslugaBIRzewnPublClient.GetBindingForEndpoint(endpointConfiguration), UslugaBIRzewnPublClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public UslugaBIRzewnPublClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(UslugaBIRzewnPublClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public UslugaBIRzewnPublClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(UslugaBIRzewnPublClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public UslugaBIRzewnPublClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ServiceReference1.GetValueResponse ServiceReference1.IUslugaBIRzewnPubl.GetValue(ServiceReference1.GetValueRequest request)
        {
            return base.Channel.GetValue(request);
        }
        
        public string GetValue(string pNazwaParametru)
        {
            ServiceReference1.GetValueRequest inValue = new ServiceReference1.GetValueRequest();
            inValue.pNazwaParametru = pNazwaParametru;
            ServiceReference1.GetValueResponse retVal = ((ServiceReference1.IUslugaBIRzewnPubl)(this)).GetValue(inValue);
            return retVal.GetValueResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.GetValueResponse> ServiceReference1.IUslugaBIRzewnPubl.GetValueAsync(ServiceReference1.GetValueRequest request)
        {
            return base.Channel.GetValueAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.GetValueResponse> GetValueAsync(string pNazwaParametru)
        {
            ServiceReference1.GetValueRequest inValue = new ServiceReference1.GetValueRequest();
            inValue.pNazwaParametru = pNazwaParametru;
            return ((ServiceReference1.IUslugaBIRzewnPubl)(this)).GetValueAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ServiceReference1.ZalogujResponse ServiceReference1.IUslugaBIRzewnPubl.Zaloguj(ServiceReference1.ZalogujRequest request)
        {
            return base.Channel.Zaloguj(request);
        }
        
        public string Zaloguj(string pKluczUzytkownika)
        {
            ServiceReference1.ZalogujRequest inValue = new ServiceReference1.ZalogujRequest();
            inValue.pKluczUzytkownika = pKluczUzytkownika;
            ServiceReference1.ZalogujResponse retVal = ((ServiceReference1.IUslugaBIRzewnPubl)(this)).Zaloguj(inValue);
            return retVal.ZalogujResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.ZalogujResponse> ServiceReference1.IUslugaBIRzewnPubl.ZalogujAsync(ServiceReference1.ZalogujRequest request)
        {
            return base.Channel.ZalogujAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.ZalogujResponse> ZalogujAsync(string pKluczUzytkownika)
        {
            ServiceReference1.ZalogujRequest inValue = new ServiceReference1.ZalogujRequest();
            inValue.pKluczUzytkownika = pKluczUzytkownika;
            return ((ServiceReference1.IUslugaBIRzewnPubl)(this)).ZalogujAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ServiceReference1.WylogujResponse ServiceReference1.IUslugaBIRzewnPubl.Wyloguj(ServiceReference1.WylogujRequest request)
        {
            return base.Channel.Wyloguj(request);
        }
        
        public bool Wyloguj(string pIdentyfikatorSesji)
        {
            ServiceReference1.WylogujRequest inValue = new ServiceReference1.WylogujRequest();
            inValue.pIdentyfikatorSesji = pIdentyfikatorSesji;
            ServiceReference1.WylogujResponse retVal = ((ServiceReference1.IUslugaBIRzewnPubl)(this)).Wyloguj(inValue);
            return retVal.WylogujResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.WylogujResponse> ServiceReference1.IUslugaBIRzewnPubl.WylogujAsync(ServiceReference1.WylogujRequest request)
        {
            return base.Channel.WylogujAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.WylogujResponse> WylogujAsync(string pIdentyfikatorSesji)
        {
            ServiceReference1.WylogujRequest inValue = new ServiceReference1.WylogujRequest();
            inValue.pIdentyfikatorSesji = pIdentyfikatorSesji;
            return ((ServiceReference1.IUslugaBIRzewnPubl)(this)).WylogujAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ServiceReference1.DaneSzukajPodmiotyResponse ServiceReference1.IUslugaBIRzewnPubl.DaneSzukajPodmioty(ServiceReference1.DaneSzukajPodmiotyRequest request)
        {
            return base.Channel.DaneSzukajPodmioty(request);
        }
        
        public string DaneSzukajPodmioty(ServiceReference1.ParametryWyszukiwania pParametryWyszukiwania)
        {
            ServiceReference1.DaneSzukajPodmiotyRequest inValue = new ServiceReference1.DaneSzukajPodmiotyRequest();
            inValue.pParametryWyszukiwania = pParametryWyszukiwania;
            ServiceReference1.DaneSzukajPodmiotyResponse retVal = ((ServiceReference1.IUslugaBIRzewnPubl)(this)).DaneSzukajPodmioty(inValue);
            return retVal.DaneSzukajPodmiotyResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.DaneSzukajPodmiotyResponse> ServiceReference1.IUslugaBIRzewnPubl.DaneSzukajPodmiotyAsync(ServiceReference1.DaneSzukajPodmiotyRequest request)
        {
            return base.Channel.DaneSzukajPodmiotyAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.DaneSzukajPodmiotyResponse> DaneSzukajPodmiotyAsync(ServiceReference1.ParametryWyszukiwania pParametryWyszukiwania)
        {
            ServiceReference1.DaneSzukajPodmiotyRequest inValue = new ServiceReference1.DaneSzukajPodmiotyRequest();
            inValue.pParametryWyszukiwania = pParametryWyszukiwania;
            return ((ServiceReference1.IUslugaBIRzewnPubl)(this)).DaneSzukajPodmiotyAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ServiceReference1.DanePobierzPelnyRaportResponse ServiceReference1.IUslugaBIRzewnPubl.DanePobierzPelnyRaport(ServiceReference1.DanePobierzPelnyRaportRequest request)
        {
            return base.Channel.DanePobierzPelnyRaport(request);
        }
        
        public string DanePobierzPelnyRaport(string pRegon, string pNazwaRaportu)
        {
            ServiceReference1.DanePobierzPelnyRaportRequest inValue = new ServiceReference1.DanePobierzPelnyRaportRequest();
            inValue.pRegon = pRegon;
            inValue.pNazwaRaportu = pNazwaRaportu;
            ServiceReference1.DanePobierzPelnyRaportResponse retVal = ((ServiceReference1.IUslugaBIRzewnPubl)(this)).DanePobierzPelnyRaport(inValue);
            return retVal.DanePobierzPelnyRaportResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.DanePobierzPelnyRaportResponse> ServiceReference1.IUslugaBIRzewnPubl.DanePobierzPelnyRaportAsync(ServiceReference1.DanePobierzPelnyRaportRequest request)
        {
            return base.Channel.DanePobierzPelnyRaportAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.DanePobierzPelnyRaportResponse> DanePobierzPelnyRaportAsync(string pRegon, string pNazwaRaportu)
        {
            ServiceReference1.DanePobierzPelnyRaportRequest inValue = new ServiceReference1.DanePobierzPelnyRaportRequest();
            inValue.pRegon = pRegon;
            inValue.pNazwaRaportu = pNazwaRaportu;
            return ((ServiceReference1.IUslugaBIRzewnPubl)(this)).DanePobierzPelnyRaportAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ServiceReference1.DanePobierzRaportZbiorczyResponse ServiceReference1.IUslugaBIRzewnPubl.DanePobierzRaportZbiorczy(ServiceReference1.DanePobierzRaportZbiorczyRequest request)
        {
            return base.Channel.DanePobierzRaportZbiorczy(request);
        }
        
        public string DanePobierzRaportZbiorczy(string pDataRaportu, string pNazwaRaportu)
        {
            ServiceReference1.DanePobierzRaportZbiorczyRequest inValue = new ServiceReference1.DanePobierzRaportZbiorczyRequest();
            inValue.pDataRaportu = pDataRaportu;
            inValue.pNazwaRaportu = pNazwaRaportu;
            ServiceReference1.DanePobierzRaportZbiorczyResponse retVal = ((ServiceReference1.IUslugaBIRzewnPubl)(this)).DanePobierzRaportZbiorczy(inValue);
            return retVal.DanePobierzRaportZbiorczyResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.DanePobierzRaportZbiorczyResponse> ServiceReference1.IUslugaBIRzewnPubl.DanePobierzRaportZbiorczyAsync(ServiceReference1.DanePobierzRaportZbiorczyRequest request)
        {
            return base.Channel.DanePobierzRaportZbiorczyAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.DanePobierzRaportZbiorczyResponse> DanePobierzRaportZbiorczyAsync(string pDataRaportu, string pNazwaRaportu)
        {
            ServiceReference1.DanePobierzRaportZbiorczyRequest inValue = new ServiceReference1.DanePobierzRaportZbiorczyRequest();
            inValue.pDataRaportu = pDataRaportu;
            inValue.pNazwaRaportu = pNazwaRaportu;
            return ((ServiceReference1.IUslugaBIRzewnPubl)(this)).DanePobierzRaportZbiorczyAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.e3))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpsTransportBindingElement httpsBindingElement = new System.ServiceModel.Channels.HttpsTransportBindingElement();
                httpsBindingElement.AllowCookies = true;
                httpsBindingElement.MaxBufferSize = int.MaxValue;
                httpsBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpsBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.e3))
            {
                return new System.ServiceModel.EndpointAddress("https://wyszukiwarkaregontest.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return UslugaBIRzewnPublClient.GetBindingForEndpoint(EndpointConfiguration.e3);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return UslugaBIRzewnPublClient.GetEndpointAddress(EndpointConfiguration.e3);
        }
        
        public enum EndpointConfiguration
        {
            
            e3,
        }
    }
}
