using System;
using System.ServiceModel;


namespace ItemServiceHost
{
    class Program
    {
        static void Main()
        {
            using (ServiceHost host = new ServiceHost(typeof(ItemService.ItemService)))
            {
                host.Open();
                Console.WriteLine("Host Started @ " + DateTime.Now.ToString("MM/dd/yyyy"));
                Console.ReadLine();
            }
        }
    }
}
