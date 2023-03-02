using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfCoreMtomEncoder;
using ServiceReference1;

namespace CEIDGREGON
{
    internal class GetErrorFromGus
    {
        private readonly UslugaBIRzewnPublClient _gusServices;
        private string _sessionId;
        private readonly ProgramGeneralData AllData;
        public GetErrorFromGus()
        {
            AllData = new ProgramGeneralData();
            _gusServices = new UslugaBIRzewnPublClient();

            SetupBinding();
            Login(AllData.GusToken);
        }
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
        internal string GetErrorMessage(string ErrorTitle)
            =>
            _gusServices.GetValue(ErrorTitle);
    }
}
