using System;

namespace OperacionesWCF.Server
{
    public sealed class OperationsNetService : IOperations
    {
        public string Echo(string s)
        {
            Console.WriteLine("Echo {0}", s);
            return s;
        }

        public double Plus(double x, double y)
        {
            Console.WriteLine("{0} + {1} = {2}", x, y, x + y);
            return x + y;
        }

        public double Minus(double x, double y)
        {
            Console.WriteLine("{0} - {1} = {2}", x, y, x - y);

            return x - y;
        }
    }
}
