using FM.BLL;
using FM.BLL.Controllers;
using FM.BLL.Factories;
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


        public static void DisplayOrder(OrderLookupResponse response)
        {
            Console.Clear();
            DisplayHeader("ORDER LOOKUP");

            foreach (var order in response.Order)
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
        }

        public static void DisplayProducts(List<Product> products)
        {
            Console.Clear();
            Console.WriteLine("{0, -15} {1, -15} {2}",
                "Product Type", "Cost Per SqFoot", "Labor Cost Per SqFoot");

            foreach (var product in products)
            {
                Console.WriteLine("{0, -15} {1, -15} {2}",
                    product.ProductType, product.CostPerSquareFoot, product.LaborCostPerSquareFoot);
            }
        }

        public static void DisplayAddOrderSummary(Order order)
        {
            DisplayHeader("ADD ORDER");
            Console.WriteLine($"{UI.RowPrefix}Customer Name: {order.CustomerName}");
            Console.WriteLine($"{UI.RowPrefix}State: {order.State}");
            Console.WriteLine($"{UI.RowPrefix}Product: {order.ProductType}");
            Console.WriteLine($"{UI.RowPrefix}Material: {order.MaterialCost}");
            Console.WriteLine($"{UI.RowPrefix}Labor: {order.LaborCost}");
            Console.WriteLine($"{UI.RowPrefix}Tax: {order.Tax}");
            Console.WriteLine($"{UI.RowPrefix}Total: {order.Total}");
            Console.WriteLine($"{UI.BorderBottom}");
        }

        public static bool ConfirmOrder()
        {
            while (true)
            {
                Console.WriteLine("Confirm order (y/n)?: ");
                string answer = Console.ReadLine();
                switch (answer.ToUpper())
                {
                    case "Y":
                        return true;
                    case "N":
                        return false;
                    default:
                        break;
                }
            }
        }

        public static string RequestOrderDate()
        {
            DisplayHeader("ORDER LOOKUP");
            Console.Write($"\nEnter Order Date (DDMMYYYY): ");
            return Console.ReadLine();
        }

        public static string RequestCustomerName()
        {
            DisplayHeader("ADD ORDER");
            Console.Write($"\nEnter Customer Name: ");
            return Console.ReadLine();
        }

        public static string RequestState()
        {
            DisplayHeader("ADD ORDER");
            Console.Write($"\nEnter State: ");
            return Console.ReadLine();
        }

        public static string RequestProduct()
        {
            Console.Write($"\nEnter Product: ");
            return Console.ReadLine();
        }

        public static string RequestArea()
        {
            DisplayHeader("ADD ORDER");
            Console.Write($"Area: ");
            return Console.ReadLine();
        }

        public static void DisplayHeader(string header)
        {
            Console.Clear();
            Console.WriteLine($"{UI.BorderTop}");
            Console.WriteLine($"{UI.RowPrefix}{header}");
            Console.WriteLine($"{UI.BorderBottom}");
        }

        public static void DisplayMessage(string message)
        {
            Console.Clear();
            Console.WriteLine($"{UI.BorderTop}");
            Console.WriteLine($"{message}");
        }
        public static void PromptContinue()
        {
            Console.WriteLine("Press enter to continue...");

            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
        }
    }
}

