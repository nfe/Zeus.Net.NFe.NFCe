using System;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Channels;
using System.Xml;

namespace NFe.Wsdl.Evento.AN
{
    public class RecepcaoEvento4AN : NFeRecepcaoEvento4ANSoapClient, INfeServico
    {
        public RecepcaoEvento4AN(string url, X509Certificate certificado, int timeOut) : base(url)
        {
            base.ClientCredentials.ClientCertificate.Certificate = (X509Certificate2)certificado;
        }

        [Obsolete("Não utilizar na nfe 4.0")]
        public nfeCabecMsg nfeCabecMsg { get; set; }

        public XmlNode Execute(XmlNode nfeDadosMsg)
        {
            var result = base.nfeRecepcaoEventoAsync(nfeDadosMsg).Result;
            return result.nfeRecepcaoEventoResult;
        }
    }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class nfeRecepcaoEventoANRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeRecepcaoEvento4", Order = 0)]
        public System.Xml.XmlNode nfeDadosMsg;

        public nfeRecepcaoEventoANRequest()
        {
        }

        public nfeRecepcaoEventoANRequest(System.Xml.XmlNode nfeDadosMsg)
        {
            this.nfeDadosMsg = nfeDadosMsg;
        }
    }

    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class nfeRecepcaoEventoANResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeRecepcaoEvento4", Order = 0)]
        public System.Xml.XmlNode nfeRecepcaoEventoResult;

        public nfeRecepcaoEventoANResponse()
        {
        }

        public nfeRecepcaoEventoANResponse(System.Xml.XmlNode nfeRecepcaoEventoResult)
        {
            this.nfeRecepcaoEventoResult = nfeRecepcaoEventoResult;
        }
    }

    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/nfeRecepcaoEventoNF", ConfigurationName = "NFeRecepcaoEvento4Soap12")]
    public interface NFeRecepcaoEvento4ANSoap : IChannel
    {
        [System.ServiceModel.OperationContractAttribute(Action = "http://www.portalfiscal.inf.br/nfe/wsdl/NFeRecepcaoEvento4/nfeRecepcaoEventoNF", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        System.Threading.Tasks.Task<nfeRecepcaoEventoANResponse> nfeRecepcaoEventoAsync(nfeRecepcaoEventoANRequest request);
    }

    public partial class NFeRecepcaoEvento4ANSoapClient : SoapBindingClient<NFeRecepcaoEvento4ANSoap>
    {
        public NFeRecepcaoEvento4ANSoapClient(string endpointAddressUri) :
            base(endpointAddressUri)
        {
        }

        public System.Threading.Tasks.Task<nfeRecepcaoEventoANResponse> nfeRecepcaoEventoAsync(System.Xml.XmlNode nfeDadosMsg)
        {
            nfeRecepcaoEventoANRequest inValue = new nfeRecepcaoEventoANRequest();
            inValue.nfeDadosMsg = nfeDadosMsg;
            return this.Channel.nfeRecepcaoEventoAsync(inValue);
        }

    }
}