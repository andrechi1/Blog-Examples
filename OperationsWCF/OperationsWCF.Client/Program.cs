using System;
using System.Globalization;
using System.Threading;

namespace OperationsWCF.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(500);
            //string url = "http://localhost:9085/OperationsService.svc";
            string url = "http://localhost:62872/OperationsService.svc";

            using (OperationsConnection connection =
                new OperationsConnection(url))
            {
                Console.WriteLine(connection.Channel.Echo("Hello."));

                Console.WriteLine(connection.Channel.Plus(345, 23));

                Console.WriteLine(connection.Channel.Minus(433, 85));
            }
        }
    }
}
