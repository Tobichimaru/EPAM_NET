using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace CalculatorService
{
    [ServiceContract]
    public interface ICalculatorService
    {
        [OperationContract]
        [WebGet]
        double Add(double a, double b);

        [OperationContract]
        [WebGet]
        double Substract(double a, double b);

        [OperationContract]
        [WebGet]
        double Multiply(double a, double b);

        [OperationContract]
        [WebGet]
        double Divide(double a, double b);

        [OperationContract]
        [WebGet]
        double PI();
    }
}
