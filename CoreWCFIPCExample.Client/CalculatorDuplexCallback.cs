using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWCFIPCExample.Client
{
    public class CalculatorDuplexCallback : ICalculatorDuplexCallback
    {
        public void Equals(double result)
        {
            Console.WriteLine(result);
        }

        public void Equation(string eqn)
        {
            Console.WriteLine(eqn);
        }
    }
}
