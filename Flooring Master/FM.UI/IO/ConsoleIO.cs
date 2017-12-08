using FM.BLL;
using FM.Models;
using FM.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.UI.IO
{
    public class ConsoleIO
    {

        public static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine($"{UI.BorderTop}");
            Console.WriteLine($"{UI.RowPrefix}FLOORING PROGRAM");
            Console.WriteLine($"{UI.RowPrefix}");
            Console.WriteLine($"{UI.RowPrefix}1. Diplay Orders");
            Console.WriteLine($"{UI.RowPrefix}2. Add an Order");
            Console.WriteLine($"{UI.RowPrefix}3. Edit an Order");
            Console.WriteLine($"{UI.RowPrefix}4. Remove an Order");
            Console.WriteLine($"{UI.RowPrefix}5. Quit");
            Console.WriteLine($"{UI.RowPrefix}");
            Console.WriteLine($"{UI.BorderBottom}");
            Console.Write("Enter Choice: ");
        }

        public static void DisplayOrderbatch(OrderbatchLookupResponse response)
        {
            Console.Clear();
            Console.WriteLine($"{UI.BorderTop}");
            if (response.Success == false)
            {
                Console.WriteLine($"{UI.RowPrefix}{response.Message}");
                Console.WriteLine($"{UI.BorderBottom}");
                PromptContinue();
            }
            else
            {
                foreach (var order in response.Orderbatch)
                {
                    Console.WriteLine($"{UI.HR}");
                    Console.WriteLine($"{UI.RowPrefix}{order.OrderNumber} {order.OrderDate}");
                    Console.WriteLine($"{UI.RowPrefix}{order.CustomerName}");
                    Console.WriteLine($"{UI.RowPrefix}{order.State}");
                    Console.WriteLine($"{UI.RowPrefix}Product: {order.ProductType}");
                    Console.WriteLine($"{UI.RowPrefix}Materials: {order.MaterialCost}");
                    Console.WriteLine($"{UI.RowPrefix}Labor: {order.LaborCost}");
                    Console.WriteLine($"{UI.RowPrefix}Tax: {order.Tax}");
                    Console.WriteLine($"{UI.RowPrefix}Total: {order.Total}");
                    Console.WriteLine($"{UI.BorderBottom}");
                }
                PromptContinue();
            }
        }

        public static void DisplayOrderDateRequest()
        {

            Console.Clear();
            Console.WriteLine($"{UI.BorderTop}");
            Console.WriteLine($"{UI.RowPrefix}LOOKUP ORDER");
            Console.WriteLine($"{UI.BorderBottom}");
            Console.Write($"\nEnter Order Date (DDMMYYYY): ");
        }

        public static void PromptContinue()
        {
            Console.WriteLine("Press enter to continue...");
            
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
        }
    }
}

