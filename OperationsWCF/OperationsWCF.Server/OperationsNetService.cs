using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacionesWCF.Server
{
    public sealed class OperationsNetService : IOperations
    {
        public double Plus(double x, double y)
        {
            return x + y;
        }

        public double Minus(double x, double y)
        {
            return x - y;
        }
    }
}
