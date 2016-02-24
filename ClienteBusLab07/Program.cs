using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using ServiceBusLab07;

namespace ClienteBusLab07
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var cf = new ChannelFactory<IServicioSaludo>(
                new NetTcpRelayBinding(),
                new EndpointAddress(ServiceBusEnvironment.CreateServiceUri("sb", "namespacelab07",
                    "saludo")));
            cf.Endpoint.Behaviors.Add(new TransportClientEndpointBehavior
            {
                TokenProvider = TokenProvider.CreateSharedSecretTokenProvider("owner",
                    "Lkulzq9ddCEIT53k0cvGuE33+mFB2K5ppyyRivkww2E=")
            });
            var ch = cf.CreateChannel();
            
                Console.WriteLine(ch.GetSaludo("Ingles"));

            cf.Close();
            
            Console.Read();
        }

    }
}