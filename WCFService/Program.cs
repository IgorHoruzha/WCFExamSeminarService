using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary;

namespace WCFService
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(SeminarService));

            host.Open();

            Console.WriteLine("Service running!");

            Console.ReadKey();

            host.Close();

            Console.WriteLine("Service closed!");

            Console.ReadKey();
        }
    }
}
