using FM.BLL;
using FM.BLL.Managers;
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
            DisplayHeader();
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

        public static void DisplayOrder(OrderBatchResponse response)
        {
            DisplayHeader();
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
            DisplayHeader();
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
            DisplayHeader();
            Console.WriteLine($"{UI.RowPrefix}Customer Name: {order.CustomerName}");
            Console.WriteLine($"{UI.RowPrefix}State: {order.State}");
            Console.WriteLine($"{UI.RowPrefix}Product: {order.ProductType}");
            Console.WriteLine($"{UI.RowPrefix}Area: {order.Area}");
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
            DisplayHeader();
            Console.Write($"\nEnter Order Date (DDMMYYYY): ");
            return Console.ReadLine();
        }

        public static string RequestOrderNumber()
        {
            DisplayHeader();
            Console.Write($"\nEnter Order Number: ");
            return Console.ReadLine();
        }

        public static string RequestCustomerName()
        {
            DisplayHeader();
            Console.Write($"\nEnter Customer Name: ");
            return Console.ReadLine();
        }

        public static string RequestState()
        {
            DisplayHeader();
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
            DisplayHeader();
            Console.Write($"Area: ");
            return Console.ReadLine();
        }

        public static string EditState(string state)
        {
            DisplayHeader();
            Console.Write($"State ({state}): ");
            return Console.ReadLine();
        }

        public static string EditProductType(string product)
        {
            DisplayHeader();
            Console.Write($"Product ({product}): ");
            return Console.ReadLine();
        }

        public static string EditArea(decimal area)
        {
            DisplayHeader();
            Console.Write($"Area ({area}): ");
            return Console.ReadLine();
        }

        public static string EditCustomerName(string customerName)
        {
            DisplayHeader();
            Console.Write($"CustomerName ({customerName}): ");
            return Console.ReadLine();
        }

        public static void DisplayMessage(string message)
        {
            DisplayHeader();
            Console.WriteLine($"{message}");
        }

        public static void DisplayHeader()
        {
            Console.Clear();
            Console.WriteLine($"{UI.BorderTop}");
        }

        public static void PromptContinue()
        {
            Console.WriteLine("Press enter to continue...");

            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
        }
    }
}

