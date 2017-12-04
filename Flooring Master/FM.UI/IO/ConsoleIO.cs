using FM.BLL;
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
            Console.WriteLine($"{uI.RowPrefix}FLOORING PROGRAM");
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
                Console.WriteLine($"{uI.BorderTop}");
                Console.WriteLine($"{uI.RowPrefix}{orderEntry.CustomerName}");
                Console.WriteLine($"{uI.RowPrefix}{orderEntry.State}");
                Console.WriteLine($"{uI.RowPrefix}Product: {orderEntry.ProductType}");
                Console.WriteLine($"{uI.RowPrefix}Materials: {orderEntry.MaterialCost} ");
                Console.WriteLine($"{uI.RowPrefix}Labor {orderEntry.LaborCost}");
                Console.WriteLine($"{uI.RowPrefix}Tax: {orderEntry.Tax}");
                Console.WriteLine($"{uI.RowPrefix}Total: {orderEntry.Total} ");
                Console.WriteLine($"{uI.RowPrefix}");
                Console.WriteLine($"{uI.BorderBottom}");
            }
            Console.WriteLine("Press any key to return to main menu...");
            Console.ReadLine();
        }

        public static void DisplayAddOrderMenu(Dictionary<string, string> orderInputs)
        {
            UIElements uI = new UIElements();

            Console.Clear();
            Console.WriteLine($"{uI.BorderTop}");
            Console.WriteLine($"{uI.RowPrefix}ADD ORDER");
            Console.WriteLine($"{uI.BorderBottom}");

            foreach (var entry in orderInputs)
            {
                Console.WriteLine($"{uI.RowPrefix}{entry.Key}: {entry.Value}");
            }
        }

        public static void DisplayEditOrderMenu()
        {
            UIElements uI = new UIElements();

            Console.Clear();
            Console.WriteLine($"{uI.BorderTop}");
            Console.WriteLine($"{uI.RowPrefix}EDIT ORDER");
            Console.WriteLine($"{uI.BorderBottom}");
        }

        public static void DisplayAddOrderFinalizeMenu(Dictionary<string, string> orderInputs)
        {
            UIElements uI = new UIElements();

            Console.Clear();
            Console.WriteLine($"{uI.BorderTop}");
            Console.WriteLine($"{uI.RowPrefix}FINALIZE ORDER");
            Console.WriteLine($"{uI.BorderBottom}");
            Console.WriteLine($"{uI.BorderTop}");
         
            foreach (var entry in orderInputs)
            {
                Console.WriteLine($"{uI.RowPrefix}{entry.Key}: {entry.Value}");
            }

            Console.WriteLine($"{uI.BorderBottom}");
            Console.WriteLine("Finalize order? (y/n): ");

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
            Console.WriteLine($"{uI.RowPrefix}LOOKUP ORDER");
            Console.WriteLine($"{uI.BorderBottom}");
            Console.Write($"\nEnter Order Date (DDMMYYYY): ");
        }

        public static string GetLineInput(string inputName)
        {
            Console.Write($"Enter {inputName}: ");
            string input = Console.ReadLine();
            return input;
        } 

        public static bool GetFinalOK()
        {
            bool finalized;
            if (Console.ReadLine() == "y") finalized = true;
            else finalized = false;

            return finalized;
        }

        public static string GetOrderDate()
        {
            string orderDate = Console.ReadLine();
            return orderDate;
        }
    }
}
     
