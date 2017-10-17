using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {

        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();
            Exercise20();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
            List<Product> products = DataLoader.LoadProducts();

            ///Query syntax:
            //
            //var results = from product in products
            //              where product.UnitsInStock == 0
            //              select product;

            ///Method syntax

            var results = products.Where(product => product.UnitsInStock == 0);

            foreach (var product in results)
            {
                Console.WriteLine($"{product.ProductName}");
            }

        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            List<Product> products = DataLoader.LoadProducts();

            ///Method syntax
            //
            //var results = from product in products
            //              where product.unitsinstock != 0 && product.unitprice > 3
            //              select product;

            ///Quory syntax
            var results = products.Where(product => product.UnitsInStock != 0 && product.UnitPrice > 3);

            foreach (var product in results)
            {
                Console.WriteLine($"{product.ProductName}");
            }


        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {
            List<Customer> customers = DataLoader.LoadCustomers();

            var results = from customer in customers
                          where customer.Region == "WA"
                          select customer;

            foreach (var customer in results)
            {
                Console.WriteLine($"{customer.CustomerID}");

                foreach (var order in customer.Orders)
                {
                    Console.WriteLine($"{order.OrderID}\t\t{order.Total}\t\t{order.OrderDate}");
                }
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            List<Product> products = DataLoader.LoadProducts();

            var results = from product in products
                          select new
                          {
                              ProductName = product.ProductName
                          };

            foreach (var result in results)
            {
                Console.WriteLine($"{result.ProductName}");
            }

        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {
            List<Product> products = DataLoader.LoadProducts();

            var results = from product in products
                          select new
                          {
                              ProductName = product.ProductName,
                              ProductId = product.ProductID,
                              ProductCategory = product.Category,
                              UnitsInStock = product.UnitsInStock,
                              UnitPrice = Convert.ToDouble(product.UnitPrice) + (Convert.ToDouble(product.UnitPrice) * 0.25)
                          };

            foreach (var result in results)
            {
                Console.WriteLine("{0}\n{1}\t{2}\t{3}\t{4}\n",
                    result.ProductName, result.ProductId,
                    result.ProductCategory, result.UnitsInStock,
                    result.UnitPrice);
            }

        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
            List<Product> products = DataLoader.LoadProducts();

            var results = from product in products
                          select new
                          {
                              ProductName = product.ProductName.ToUpper(),
                              Category = product.Category.ToUpper()
                          };

            foreach (var result in results)
            {
                Console.WriteLine($"{result.ProductName}........{result.Category}");
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {
            List<Product> products = DataLoader.LoadProducts();


            var resultsNoReorder = from product in products
                                   where product.UnitsInStock >= 3
                                   select new
                                   {
                                       ProductName = product.ProductName,
                                       ProductId = product.ProductID,
                                       ProductCategory = product.Category,
                                       UnitsInStock = product.UnitsInStock,
                                       UnitPrice = product.UnitPrice,
                                       ReOrder = false
                                   };

            var resultsReorder = from product in products
                                 where product.UnitsInStock < 3
                                 select new
                                 {
                                     ProductName = product.ProductName,
                                     ProductId = product.ProductID,
                                     ProductCategory = product.Category,
                                     UnitsInStock = product.UnitsInStock,
                                     UnitPrice = product.UnitPrice,
                                     ReOrder = true
                                 };

            var resultsCombined = resultsNoReorder.Union(resultsReorder);

            foreach (var result in resultsCombined)
            {
                Console.WriteLine("{0}\n{1}\t{2}\t{3}\t{4}\t{5}\n",
                    result.ProductName, result.ProductId,
                    result.ProductCategory, result.UnitsInStock,
                    result.UnitPrice, result.ReOrder);

            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            List<Product> products = DataLoader.LoadProducts();

            var results = from product in products
                          select new
                          {
                              ProductName = product.ProductName,
                              ProductId = product.ProductID,
                              ProductCategory = product.Category,
                              UnitsInStock = product.UnitsInStock,
                              UnitPrice = product.UnitPrice,
                              StockValue = product.UnitPrice * product.UnitsInStock
                          };

            foreach (var result in results)
            {
                Console.WriteLine("{0}\n{1}\t{2}\t{3}\t{4}\t{5}\n",
                    result.ProductName, result.ProductId,
                    result.ProductCategory, result.UnitsInStock,
                    result.UnitPrice, result.StockValue);

            }


        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {
            int[] numbersA = DataLoader.NumbersA;

            foreach (int number in numbersA)
            {
                if (number % 2 == 0)
                {
                    Console.WriteLine(number);
                }
            }

        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {
            List<Customer> customers = DataLoader.LoadCustomers();

            var results = from customer in customers
                          select customer;

            foreach (var result in results)
            {
                foreach (var order in result.Orders)
                {
                    if (order.Total < 500)
                    {
                        Console.WriteLine($"{result.CompanyName}");
                        break;
                    }
                }
            }

        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            int[] numbers = DataLoader.NumbersC;

            int count = 0;

            foreach (int number in numbers)
            {
                if (number % 2 != 0)
                {
                    if (count <= 2)
                    {
                        Console.WriteLine($"{number}");
                        count++;
                    }
                    else break;
                }
            }
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            int[] numbers = DataLoader.NumbersB;
            
            int count = 0;

            foreach (int number in numbers)
            {
                if (count > 2)
                {
                    Console.WriteLine($"{number}");
                }
                count++;
            }
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
            //assuming below that Orders are LIFO. 

            List<Customer> customers = DataLoader.LoadCustomers();

            var results = from customer in customers
                          where customer.Orders.Length > 0
                          select new
                          {
                              CustomerName = customer.CompanyName,
                              MostRecentOrder = customer.Orders.Last().OrderID
                          };

            foreach (var result in results)
            {
                Console.WriteLine("{0}\t{1}", result.CustomerName, result.MostRecentOrder);
            }


        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
            //req ambiguous on whether to print >= 6 num or not, assuming no

            int[] numbers = DataLoader.NumbersC;

            foreach (int number in numbers)
            {
                if (number >= 6) break;
                else Console.WriteLine($"{number}");
            }

        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            int[] numbers = DataLoader.NumbersC;

            bool trigger = false;

            foreach (int number in numbers)
            {
                if (trigger == true)
                {
                    Console.WriteLine($"{number}");
                }
                else
                {
                    if (number % 3 == 0)
                    {
                        trigger = true;
                    }
                }
            }

        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {
            List<Product> products = DataLoader.LoadProducts();

            var results = from product in products
                          orderby product.ProductName
                          select product;

            foreach (var result in results)
            {
                Console.WriteLine($"{result.ProductName}");
            }
        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
            List<Product> products = DataLoader.LoadProducts();

            var results = from product in products
                          orderby product.UnitsInStock descending
                          select product;

            foreach (var result in results)
            {
                Console.WriteLine($"{result.ProductName}");
            }
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
            List<Product> products = DataLoader.LoadProducts();

            var results = from product in products
                          orderby product.Category, product.UnitPrice descending
                          group product by product.Category;

            foreach (var group in results)
            {
                Console.WriteLine($"{group.Key}");

                foreach (var product in group)
                {
                    Console.WriteLine($"\t{product.ProductName}");
                }
            }

        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            int[] numbers = DataLoader.NumbersB;

            var results = from number in numbers
                          orderby number descending
                          select number;

            foreach (var number in results)
            {
                Console.WriteLine($"{number}");
            }
        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {
            List<Product> products = DataLoader.LoadProducts();

            var results = from product in products
                          group product by product.Category;

            foreach (var group in results)
            {
                Console.WriteLine($"{group.Key}");

                foreach (var product in group)
                {
                    Console.WriteLine($"{product.ProductName}");
                }
                Console.WriteLine("");

            }
        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        static void Exercise21()
        {

        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {

        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {

        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {

        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {

        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {

        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {

        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {

        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {

        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {

        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {

        }
    }
}
