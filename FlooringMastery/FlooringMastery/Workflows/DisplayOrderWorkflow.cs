using FlooringMastery.BLL;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Workflows
{
    public class DisplayOrderWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Lookup an order");
            Console.WriteLine("--------------------");
            Console.WriteLine("Enter order date: ");

            int orderDate = int.Parse(Console.ReadLine());

            OrderLookupResponse response = manager.LookupOrder(orderDate);

            if (response.Success)
            {
                ConsoleIO.DisplayOrderDetails(response.Order);
            }
            else
            {
                Console.WriteLine(response.Message);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
    }
}
