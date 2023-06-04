using CoreWCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWCFIPCExample.Server
{
    public class CalculatorService : ICalculatorDuplex
    {
        double result;
        string equation;

        public CalculatorService()
        {
            result = 0.0D;
            equation = result.ToString();
        }

        public void Clear()
        {
            Callback.Equation(equation + " = " + result.ToString());
            result = 0.0D;
            equation = result.ToString();
        }

        public void AddTo(double n)
        {
            result += n;
            equation += " + " + n.ToString();
            Callback.Equals(result);
        }

        public void SubtractFrom(double n)
        {
            result -= n;
            equation += " - " + n.ToString();
            Callback.Equals(result);
        }

        public void MultiplyBy(double n)
        {
            result *= n;
            equation += " * " + n.ToString();
            Callback.Equals(result);
        }

        public void DivideBy(double n)
        {
            result /= n;
            equation += " / " + n.ToString();
            Callback.Equals(result);
        }

        public ICalculatorDuplexCallback Callback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<ICalculatorDuplexCallback>();
            }
        }
    }
}
