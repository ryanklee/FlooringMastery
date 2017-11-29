using FM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.UI.IO
{
    public class ConsoleIO
    {

        public static void DisplayOrderDateRequest()
        {
            UIElements uI = new UIElements();

            Console.Clear();
            Console.WriteLine($"{uI.BorderTop}");
            Console.WriteLine($"{uI.RowPrefix}Lookup Order");
            Console.WriteLine($"{uI.BorderBottom}");
            Console.Write($"\nEnter order date (DDMMYYYY): ");
        }

        public static string GetOrderDate()
        {
            string orderDate = Console.ReadLine();
            return orderDate;
        }

        public static void DisplayOrderDetails(Order order, string orderDate)
        {
            UIElements uI = new UIElements();

            Console.Clear();
            Console.WriteLine($"{uI.BorderTop}");
            Console.WriteLine($"{uI.RowPrefix}{order.OrderNumber} {orderDate.ToString()}");
            Console.WriteLine($"{uI.BorderBottom}");
            Console.WriteLine($"{uI.RowPrefix}{order.CustomerName}");
            Console.WriteLine($"{uI.RowPrefix}{order.State}");
            Console.WriteLine($"{uI.RowPrefix}Product: {order.ProductType}");
            Console.WriteLine($"{uI.RowPrefix}Materials: {order.MaterialCost} ");
            Console.WriteLine($"{uI.RowPrefix}Labor {order.LaborCost}");
            Console.WriteLine($"{uI.RowPrefix}Tax: {order.Tax}");
            Console.WriteLine($"{uI.RowPrefix}Total: {order.Total} ");
            Console.WriteLine("\nPress any key to return to main menu...");
        }

        public static void DisplayMenu()
        {
            UIElements uI = new UIElements();

            Console.Clear();
            Console.WriteLine($"{uI.BorderTop}");
            Console.WriteLine($"{uI.RowPrefix} Flooring Program");
            Console.WriteLine($"{uI.RowPrefix}");
            Console.WriteLine($"{uI.RowPrefix} 1. Diplay Orders");
            Console.WriteLine($"{uI.RowPrefix} 2. Add an Order");
            Console.WriteLine($"{uI.RowPrefix} 3. Edit an Order");
            Console.WriteLine($"{uI.RowPrefix} 4. Remove an Order");
            Console.WriteLine($"{uI.RowPrefix} 5. Quit");
            Console.WriteLine($"{uI.RowPrefix}");
            Console.WriteLine($"{uI.BorderBottom}");
            Console.Write("\nEnter Choice: ");
        }
    }
}
