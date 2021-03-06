﻿using System.ServiceModel;

namespace OperacionesWCF
{
    [ServiceContract]
    public interface IOperations
    {
        [OperationContract]
        string Echo(string s);

        [OperationContract]
        double Plus(double x, double y);

        [OperationContract]
        double Minus(double x, double y);
    }
}
