using System;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace OperacionesWCF.Server
{
    public sealed class OperationsServiceHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new OperationsServiceHost(serviceType, baseAddresses);
        }
    }
}
