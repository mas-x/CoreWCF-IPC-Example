using System.ServiceModel;

namespace CoreWCFIPCExample.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client started...");

            InstanceContext context = new InstanceContext(new CalculatorDuplexCallback());
            DuplexChannelFactory<ICalculatorDuplex> factory = new DuplexChannelFactory<ICalculatorDuplex>(
                context, 
                new NetNamedPipeBinding(), 
                new EndpointAddress("net.pipe://localhost/PipedService"));

            ICalculatorDuplex service = factory.CreateChannel();

            service.AddTo(5);
            service.MultiplyBy(5);
            service.Clear();

            Console.ReadKey();
        }
    }
}