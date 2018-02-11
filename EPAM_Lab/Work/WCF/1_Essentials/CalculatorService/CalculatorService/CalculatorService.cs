using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService
{
    public class CalculatorService : ICalculatorService
    {
        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Substract(double a, double b)
        {
            return a - b;
        }

        public double Multiply(double a, double b)
        {
            return a * b;
        }

        public double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException();
            return a / b;
        }

        public double PI()
        {
            return Math.PI;
        }
    }
}
