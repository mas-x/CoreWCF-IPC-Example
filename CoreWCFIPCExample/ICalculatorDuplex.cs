using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CoreWCFIPCExample
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(ICalculatorDuplexCallback))]
    public interface ICalculatorDuplex
    {
        [OperationContract()]
        void Clear();
        [OperationContract()]
        void AddTo(double n);
        [OperationContract()]
        void SubtractFrom(double n);
        [OperationContract()]
        void MultiplyBy(double n);
        [OperationContract()]
        void DivideBy(double n);
    }
}
