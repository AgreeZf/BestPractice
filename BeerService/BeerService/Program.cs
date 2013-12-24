using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
namespace Spd.Runtime
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing Service ....");
            using (ServiceHost host=new ServiceHost(typeof(BeerService)))
            {
                host.Open();
                Console.WriteLine("Service is ready for requests, press to quit");
                Console.Read();
                Console.WriteLine("Closing Service");
            }
        }
    }
}
