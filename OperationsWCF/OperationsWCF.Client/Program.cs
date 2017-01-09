using System;
using OperacionesWCF;

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
                IOperations operations = connection.Channel;

                Console.WriteLine(operations.Echo("Hello."));
                Console.WriteLine(operations.Plus(345, 23));
                Console.WriteLine(operations.Minus(433, 85));
            }
        }
    }
}
