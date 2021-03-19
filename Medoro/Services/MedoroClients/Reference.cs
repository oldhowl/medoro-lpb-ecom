using System;
using System.ServiceModel;

namespace ServiceReference1
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="urn:Gateway", ConfigurationName="ServiceReference1.EcomPortType")]
    public interface EcomPortType
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:Payment", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<ServiceReference1.PaymentResponse> PaymentAsync(ServiceReference1.PaymentRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:Authenticate", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<ServiceReference1.AuthenticateResponse> AuthenticateAsync(ServiceReference1.AuthenticateRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:Deposit", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<ServiceReference1.DepositResponse> DepositAsync(ServiceReference1.DepositRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:Reverse", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<ServiceReference1.ReverseResponse> ReverseAsync(ServiceReference1.ReverseRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:Close", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<ServiceReference1.CloseResponse> CloseAsync(ServiceReference1.CloseRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:GetPayment", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<ServiceReference1.GetPaymentResponse> GetPaymentAsync(ServiceReference1.GetPaymentRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:RegisterToken", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<ServiceReference1.RegisterTokenResponse> RegisterTokenAsync(ServiceReference1.RegisterTokenRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:Gateway")]
    public partial class ecomPaymentType
    {
        
        private string iNTERFACEField;
        
        private string kEY_INDEXField;
        
        private string kEYField;
        
        private string dATAField;
        
        private string sIGNATUREField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string INTERFACE
        {
            get
            {
                return this.iNTERFACEField;
            }
            set
            {
                this.iNTERFACEField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="integer", Order=1)]
        public string KEY_INDEX
        {
            get
            {
                return this.kEY_INDEXField;
            }
            set
            {
                this.kEY_INDEXField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string KEY
        {
            get
            {
                return this.kEYField;
            }
            set
            {
                this.kEYField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string DATA
        {
            get
            {
                return this.dATAField;
            }
            set
            {
                this.dATAField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public string SIGNATURE
        {
            get
            {
                return this.sIGNATUREField;
            }
            set
            {
                this.sIGNATUREField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PaymentRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="PaymentRequest", Namespace="urn:Gateway", Order=0)]
        public ServiceReference1.ecomPaymentType PaymentRequest1;
        
        public PaymentRequest()
        {
        }
        
        public PaymentRequest(ServiceReference1.ecomPaymentType PaymentRequest1)
        {
            this.PaymentRequest1 = PaymentRequest1;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PaymentResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="PaymentResponse", Namespace="urn:Gateway", Order=0)]
        public ServiceReference1.ecomPaymentType PaymentResponse1;
        
        public PaymentResponse()
        {
        }
        
        public PaymentResponse(ServiceReference1.ecomPaymentType PaymentResponse1)
        {
            this.PaymentResponse1 = PaymentResponse1;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AuthenticateRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AuthenticateRequest", Namespace="urn:Gateway", Order=0)]
        public ServiceReference1.ecomPaymentType AuthenticateRequest1;
        
        public AuthenticateRequest()
        {
        }
        
        public AuthenticateRequest(ServiceReference1.ecomPaymentType AuthenticateRequest1)
        {
            this.AuthenticateRequest1 = AuthenticateRequest1;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AuthenticateResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AuthenticateResponse", Namespace="urn:Gateway", Order=0)]
        public ServiceReference1.ecomPaymentType AuthenticateResponse1;
        
        public AuthenticateResponse()
        {
        }
        
        public AuthenticateResponse(ServiceReference1.ecomPaymentType AuthenticateResponse1)
        {
            this.AuthenticateResponse1 = AuthenticateResponse1;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class DepositRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="DepositRequest", Namespace="urn:Gateway", Order=0)]
        public ServiceReference1.ecomPaymentType DepositRequest1;
        
        public DepositRequest()
        {
        }
        
        public DepositRequest(ServiceReference1.ecomPaymentType DepositRequest1)
        {
            this.DepositRequest1 = DepositRequest1;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class DepositResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="DepositResponse", Namespace="urn:Gateway", Order=0)]
        public ServiceReference1.ecomPaymentType DepositResponse1;
        
        public DepositResponse()
        {
        }
        
        public DepositResponse(ServiceReference1.ecomPaymentType DepositResponse1)
        {
            this.DepositResponse1 = DepositResponse1;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ReverseRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ReverseRequest", Namespace="urn:Gateway", Order=0)]
        public ServiceReference1.ecomPaymentType ReverseRequest1;
        
        public ReverseRequest()
        {
        }
        
        public ReverseRequest(ServiceReference1.ecomPaymentType ReverseRequest1)
        {
            this.ReverseRequest1 = ReverseRequest1;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ReverseResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ReverseResponse", Namespace="urn:Gateway", Order=0)]
        public ServiceReference1.ecomPaymentType ReverseResponse1;
        
        public ReverseResponse()
        {
        }
        
        public ReverseResponse(ServiceReference1.ecomPaymentType ReverseResponse1)
        {
            this.ReverseResponse1 = ReverseResponse1;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CloseRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CloseRequest", Namespace="urn:Gateway", Order=0)]
        public ServiceReference1.ecomPaymentType CloseRequest1;
        
        public CloseRequest()
        {
        }
        
        public CloseRequest(ServiceReference1.ecomPaymentType CloseRequest1)
        {
            this.CloseRequest1 = CloseRequest1;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CloseResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CloseResponse", Namespace="urn:Gateway", Order=0)]
        public ServiceReference1.ecomPaymentType CloseResponse1;
        
        public CloseResponse()
        {
        }
        
        public CloseResponse(ServiceReference1.ecomPaymentType CloseResponse1)
        {
            this.CloseResponse1 = CloseResponse1;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetPaymentRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetPaymentRequest", Namespace="urn:Gateway", Order=0)]
        public ServiceReference1.ecomPaymentType GetPaymentRequest1;
        
        public GetPaymentRequest()
        {
        }
        
        public GetPaymentRequest(ServiceReference1.ecomPaymentType GetPaymentRequest1)
        {
            this.GetPaymentRequest1 = GetPaymentRequest1;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetPaymentResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetPaymentResponse", Namespace="urn:Gateway", Order=0)]
        public ServiceReference1.ecomPaymentType GetPaymentResponse1;
        
        public GetPaymentResponse()
        {
        }
        
        public GetPaymentResponse(ServiceReference1.ecomPaymentType GetPaymentResponse1)
        {
            this.GetPaymentResponse1 = GetPaymentResponse1;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class RegisterTokenRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="RegisterTokenRequest", Namespace="urn:Gateway", Order=0)]
        public ServiceReference1.ecomPaymentType RegisterTokenRequest1;
        
        public RegisterTokenRequest()
        {
        }
        
        public RegisterTokenRequest(ServiceReference1.ecomPaymentType RegisterTokenRequest1)
        {
            this.RegisterTokenRequest1 = RegisterTokenRequest1;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class RegisterTokenResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="RegisterTokenResponse", Namespace="urn:Gateway", Order=0)]
        public ServiceReference1.ecomPaymentType RegisterTokenResponse1;
        
        public RegisterTokenResponse()
        {
        }
        
        public RegisterTokenResponse(ServiceReference1.ecomPaymentType RegisterTokenResponse1)
        {
            this.RegisterTokenResponse1 = RegisterTokenResponse1;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface EcomPortTypeChannel : ServiceReference1.EcomPortType, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    internal partial class EcomClient : System.ServiceModel.ClientBase<ServiceReference1.EcomPortType>, ServiceReference1.EcomPortType
    {
        
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);

        internal EcomClient(string endpointUrl, TimeSpan timeout) :
 base(EcomClient.GetBindingForEndpoint(timeout), EcomClient.GetEndpointAddress(endpointUrl))
        {
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public EcomClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
         base(binding, remoteAddress)
        {
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.PaymentResponse> ServiceReference1.EcomPortType.PaymentAsync(ServiceReference1.PaymentRequest request)
        {
            return base.Channel.PaymentAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.PaymentResponse> PaymentAsync(ServiceReference1.ecomPaymentType PaymentRequest1)
        {
            ServiceReference1.PaymentRequest inValue = new ServiceReference1.PaymentRequest();
            inValue.PaymentRequest1 = PaymentRequest1;
            return ((ServiceReference1.EcomPortType)(this)).PaymentAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.AuthenticateResponse> ServiceReference1.EcomPortType.AuthenticateAsync(ServiceReference1.AuthenticateRequest request)
        {
            return base.Channel.AuthenticateAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.AuthenticateResponse> AuthenticateAsync(ServiceReference1.ecomPaymentType AuthenticateRequest1)
        {
            ServiceReference1.AuthenticateRequest inValue = new ServiceReference1.AuthenticateRequest();
            inValue.AuthenticateRequest1 = AuthenticateRequest1;
            return ((ServiceReference1.EcomPortType)(this)).AuthenticateAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.DepositResponse> ServiceReference1.EcomPortType.DepositAsync(ServiceReference1.DepositRequest request)
        {
            return base.Channel.DepositAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.DepositResponse> DepositAsync(ServiceReference1.ecomPaymentType DepositRequest1)
        {
            ServiceReference1.DepositRequest inValue = new ServiceReference1.DepositRequest();
            inValue.DepositRequest1 = DepositRequest1;
            return ((ServiceReference1.EcomPortType)(this)).DepositAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.ReverseResponse> ServiceReference1.EcomPortType.ReverseAsync(ServiceReference1.ReverseRequest request)
        {
            return base.Channel.ReverseAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.ReverseResponse> ReverseAsync(ServiceReference1.ecomPaymentType ReverseRequest1)
        {
            ServiceReference1.ReverseRequest inValue = new ServiceReference1.ReverseRequest();
            inValue.ReverseRequest1 = ReverseRequest1;
            return ((ServiceReference1.EcomPortType)(this)).ReverseAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.CloseResponse> ServiceReference1.EcomPortType.CloseAsync(ServiceReference1.CloseRequest request)
        {
            return base.Channel.CloseAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.CloseResponse> CloseAsync(ServiceReference1.ecomPaymentType CloseRequest1)
        {
            ServiceReference1.CloseRequest inValue = new ServiceReference1.CloseRequest();
            inValue.CloseRequest1 = CloseRequest1;
            return ((ServiceReference1.EcomPortType)(this)).CloseAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.GetPaymentResponse> ServiceReference1.EcomPortType.GetPaymentAsync(ServiceReference1.GetPaymentRequest request)
        {
            return base.Channel.GetPaymentAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.GetPaymentResponse> GetPaymentAsync(ServiceReference1.ecomPaymentType GetPaymentRequest1)
        {
            ServiceReference1.GetPaymentRequest inValue = new ServiceReference1.GetPaymentRequest();
            inValue.GetPaymentRequest1 = GetPaymentRequest1;
            return ((ServiceReference1.EcomPortType)(this)).GetPaymentAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.RegisterTokenResponse> ServiceReference1.EcomPortType.RegisterTokenAsync(ServiceReference1.RegisterTokenRequest request)
        {
            return base.Channel.RegisterTokenAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.RegisterTokenResponse> RegisterTokenAsync(ServiceReference1.ecomPaymentType RegisterTokenRequest1)
        {
            ServiceReference1.RegisterTokenRequest inValue = new ServiceReference1.RegisterTokenRequest();
            inValue.RegisterTokenRequest1 = RegisterTokenRequest1;
            return ((ServiceReference1.EcomPortType)(this)).RegisterTokenAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync1()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }

        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(TimeSpan timeout)
        {
            var httpsBinding = new BasicHttpsBinding();
            httpsBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
            httpsBinding.Security.Mode = BasicHttpsSecurityMode.Transport;

            var integerMaxValue = int.MaxValue;
            httpsBinding.MaxBufferSize = integerMaxValue;
            httpsBinding.MaxReceivedMessageSize = integerMaxValue;
            httpsBinding.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
            httpsBinding.AllowCookies = true;

            httpsBinding.ReceiveTimeout = timeout;
            httpsBinding.SendTimeout = timeout;
            httpsBinding.OpenTimeout = timeout;
            httpsBinding.CloseTimeout = timeout;

            return httpsBinding;
        }

        private static System.ServiceModel.EndpointAddress GetEndpointAddress(string endpointUrl)
        {
            if (!endpointUrl.StartsWith("https://"))
            {
                throw new UriFormatException("The endpoint URL must start with https://.");
            }
            return new System.ServiceModel.EndpointAddress(endpointUrl);
        }
    }
}
