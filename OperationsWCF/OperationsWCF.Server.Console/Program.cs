using System;
using System.Globalization;
using System.Threading;
using OperacionesWCF.Server;

namespace OperationsWCF.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var operationsService = new OperationsServiceHost(
                new Uri("http://localhost:9085/OperationsService.svc")))
            {
                operationsService.Open();

                Console.ReadLine();
            }
        }
    }
}
