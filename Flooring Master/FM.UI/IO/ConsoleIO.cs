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

        public static void DisplayMenu()
        {
            UIElements uI = new UIElements();

            Console.Clear();
            Console.WriteLine($"{uI.BorderTop}");
            Console.WriteLine($"{uI.RowPrefix}Flooring Program");
            Console.WriteLine($"{uI.RowPrefix}");
            Console.WriteLine($"{uI.RowPrefix}1. Diplay Orders");
            Console.WriteLine($"{uI.RowPrefix}2. Add an Order");
            Console.WriteLine($"{uI.RowPrefix}3. Edit an Order");
            Console.WriteLine($"{uI.RowPrefix}4. Remove an Order");
            Console.WriteLine($"{uI.RowPrefix}5. Quit");
            Console.WriteLine($"{uI.RowPrefix}");
            Console.WriteLine($"{uI.BorderBottom}");
            Console.Write("Enter Choice: ");
        }

        public static void DisplayOrderDetails(List<Order> orderBatch, string orderDate)
        {
            UIElements uI = new UIElements();

            Console.Clear();
            foreach (var orderEntry in orderBatch)
            {
                Console.WriteLine($"{uI.BorderTop}");
                Console.WriteLine($"{uI.RowPrefix}{orderEntry.OrderNumber} {orderDate.ToString()}");
                Console.WriteLine($"{uI.BorderBottom}");
                Console.WriteLine($"{uI.RowPrefix}{orderEntry.CustomerName}");
                Console.WriteLine($"{uI.RowPrefix}{orderEntry.State}");
                Console.WriteLine($"{uI.RowPrefix}Product: {orderEntry.ProductType}");
                Console.WriteLine($"{uI.RowPrefix}Materials: {orderEntry.MaterialCost} ");
                Console.WriteLine($"{uI.RowPrefix}Labor {orderEntry.LaborCost}");
                Console.WriteLine($"{uI.RowPrefix}Tax: {orderEntry.Tax}");
                Console.WriteLine($"{uI.RowPrefix}Total: {orderEntry.Total} ");
            }
            Console.WriteLine("Press any key to return to main menu...");
            Console.ReadLine();
        }

        public static void DisplayAddOrderMenu()
        {
            UIElements uI = new UIElements();

            Console.Clear();
            Console.WriteLine($"{uI.BorderTop}");
            Console.WriteLine($"{uI.RowPrefix}Add Order");
            Console.WriteLine($"{uI.BorderBottom}");
            Console.WriteLine($"{uI.BorderTop}");
            Console.WriteLine($"{uI.RowPrefix}Order Date: ");
            Console.WriteLine($"{uI.RowPrefix}Customer Name: ");
            Console.WriteLine($"{uI.RowPrefix}State: ");
            Console.WriteLine($"{uI.RowPrefix}Product Type: ");
            Console.WriteLine($"{uI.RowPrefix}Area: ");
            Console.WriteLine($"{uI.BorderBottom}");
            Console.SetCursorPosition(14, 5);

            Console.ReadLine();

        }

        public static void DisplayInvalidOrderDateError(string orderDate)
        {
            UIElements uI = new UIElements();
            Console.Clear();
            Console.WriteLine($"{uI.BorderTop}");
            Console.WriteLine($"{uI.RowPrefix}");
            Console.Write($"{uI.RowPrefix}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{orderDate} is an invalid order date!");
            Console.ResetColor();
            Console.WriteLine($"{uI.RowPrefix}");
            Console.WriteLine($"{uI.BorderBottom}");
            Console.WriteLine("Press any key to return to main menu...");
            Console.ReadLine();
        }

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
    }
}
