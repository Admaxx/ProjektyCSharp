using ServiceReference1;
using System.ServiceModel.Channels;
using System.ServiceModel;
using WcfCoreMtomEncoder;
using CEIDGREGON;

namespace CEIDGASPNetCore.Services.CEIDG
{
    internal class Handling : ProgramGeneralData
    {
        private readonly UslugaBIRzewnPublClient _gusServices;
        private string _sessionId;
        public Handling()
        {
            _gusServices = new UslugaBIRzewnPublClient();
            SetupBinding();
            Login(GusToken);

        }
        public string GetErrorMessage(string ErrorTitle)
            =>
            _gusServices.GetValue(ErrorTitle);

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
