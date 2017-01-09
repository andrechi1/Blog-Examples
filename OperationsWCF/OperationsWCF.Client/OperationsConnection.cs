using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using OperacionesWCF;

namespace OperationsWCF.Client
{
    public class OperationsConnection : IDisposable
    {
        private ChannelFactory<IOperations> mFactory = null;

        public ChannelFactory<IOperations> Factory
        {
            get { return mFactory; }
        }

        private IOperations mChannel;

        public IOperations Channel
        {
            get
            {
                if (mChannel == null)
                {
                    mChannel = Factory.CreateChannel();
                }
                return mChannel;
            }
        }

        public OperationsConnection(string service)
        {
            Binding binding;

            binding = new BasicHttpBinding();

            ContractDescription contract = ContractDescription.GetContract(typeof(IOperations));
            ServiceEndpoint endpoint = new ServiceEndpoint(
                    contract,
                    binding, new EndpointAddress(service));

            mFactory = new ChannelFactory<IOperations>(endpoint);
        }

        

        #region IDisposable
        public void Close()
        {
            if (mFactory != null)
            {
                mFactory.Close();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Close();
            }
        }
        #endregion
    }
}
