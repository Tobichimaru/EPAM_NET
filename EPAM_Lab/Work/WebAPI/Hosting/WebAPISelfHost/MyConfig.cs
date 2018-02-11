using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http.SelfHost;
using System.ServiceModel.Channels;
using System.Web.Http.SelfHost.Channels;

namespace WebAPISelfHost
{
    public class MyConfig : HttpSelfHostConfiguration
    {
        public MyConfig(string ba) : base(ba)
        {
        }

        protected override BindingParameterCollection OnConfigureBinding(HttpBinding httpBinding)
        {
            httpBinding.Security.Mode = HttpBindingSecurityMode.TransportCredentialOnly;
            httpBinding.Security.Transport.ClientCredentialType = System.ServiceModel.HttpClientCredentialType.Windows;

            return base.OnConfigureBinding(httpBinding);
        }
    }
}
