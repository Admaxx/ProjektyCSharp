using System.ServiceModel.Channels;
using System.ServiceModel;
using ServiceReference1;
using WcfCoreMtomEncoder;

namespace CEIDGREGON
{
    internal class GetRequests : ProgramGeneralData
    {
        private readonly UslugaBIRzewnPublClient _gusServices;
        private string _sessionId;
        public GetRequests()
        {
            _gusServices = new UslugaBIRzewnPublClient();
            SetupBinding();
            Login(GusToken);
        }
        public string GetValuesForDanePodmiotu(ParametryWyszukiwania SearchParameter)
            =>  
            Convert.ToString(new StringReader(_gusServices.DaneSzukajPodmioty(SearchParameter)).ReadToEnd());

        public string GetValuesForPelnyRaport(string pRegon, string pNazwaRaportu)
            => 
            Convert.ToString(new StringReader(_gusServices.DanePobierzPelnyRaport(pRegon, pNazwaRaportu)).ReadToEnd());

        public string GetValuesForZbiorczyRaport(string pDataRaportu, string pNazwaRaportu)
            => 
            Convert.ToString(new StringReader(_gusServices.DanePobierzRaportZbiorczy(pDataRaportu, pNazwaRaportu)).ReadToEnd());

        internal string Login(string apiKey)
        {
            _sessionId = _gusServices.Zaloguj(apiKey);

            OperationContextScope scope = new OperationContextScope(_gusServices.InnerChannel);
            HttpRequestMessageProperty requestProperties = new HttpRequestMessageProperty();

            requestProperties.Headers.Add("sid", _sessionId);
            OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestProperties;

            return _sessionId;
        }
        internal void SetupBinding()
        {

            var encoding = new MtomMessageEncoderBindingElement(new TextMessageEncodingBindingElement());
            var transport = new HttpsTransportBindingElement();

            _gusServices.Endpoint.Binding = new CustomBinding(encoding, transport);
        }
    }
}
