using System;
using System.ServiceModel.Web;
using CommondLib.Encryption;

namespace ResetServer
{
    class Program
    {
        static void Main(string[] args)
        {
            WebServiceHost host = new WebServiceHost(typeof(JsonService));
            host.Open();

            foreach (var channel in host.ChannelDispatchers)
            {
                Console.WriteLine("Service is running on address: " + channel.Listener.Uri.ToString() + "\r\n");
            }

            Console.ReadLine();
        }
    }
}
