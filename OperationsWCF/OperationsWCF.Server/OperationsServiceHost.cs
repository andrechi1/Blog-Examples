using System;
using System.ServiceModel;
using System.ServiceModel.Channels;


namespace OperacionesWCF.Server
{
    public sealed class OperationsServiceHost : ServiceHost
    {
        public OperationsServiceHost(Uri baseAddresses) 
            :this(typeof(OperationsNetService), baseAddresses)
        {
        }

        public OperationsServiceHost(Type serviceType, params Uri[] baseAddresses) 
            :base(serviceType, baseAddresses)
        {
            CreateBinding();
        }

        private void CreateBinding()
        {
            Binding binding = new BasicHttpBinding();

            base.AddServiceEndpoint(typeof(IOperations), binding, string.Empty);
        }
    }
}
