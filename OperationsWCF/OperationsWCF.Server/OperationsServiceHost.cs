using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace OperacionesWCF.Server
{
    public sealed class OperationsServiceHost : ServiceHost
    {
        public OperationsServiceHost()
        {
            
        }

        protected override void InitializeRuntime()
        {
            base.InitializeRuntime();
        }
    }
}
