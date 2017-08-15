using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = GetNumberFromUser();

            Calculator.PrintFactors(number);
            Calculator.IsPerfectNumber(number);
            Calculator.IsPrimeNumber(number);

            Console.WriteLine("Press any key to quit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Prompt the user for an integer.  Make sure they enter a valid integer!
        /// 
        /// See the String Input lesson for TryParse() examples
        /// </summary>
        /// <returns>the user input as an integer</returns>
        static int GetNumberFromUser()
        {
            while (true)
            {
                Console.Write("What number would you like to factor?: ");
                string input = Console.ReadLine();
                int output;

                if (int.TryParse(input, out output))
                {
                    return output;
                }
                else
                {
                    Console.WriteLine("Number must be an integer... ");
                }
            }
        }
    }

    class Calculator
    {
        /// <summary>
        /// Given a number, print the factors per the specification
        /// </summary>
        public static void PrintFactors(int number)
        {
            Console.Write($"The factors of { number } are: ");

            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    Console.Write($"{ i } ");
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Given a number, print if it is perfect or not
        /// </summary>
        public static void IsPerfectNumber(int number)
        {
            int sum = 0;

            for (int i = 1; i < number; i++)
            {
                if (number % i == 0)
                {
                    sum = sum + i;
                }
            }

            if (sum == number)
            {
                Console.WriteLine($"{ number } is a perfect number.");
            }
            else
            {
                Console.WriteLine($"{ number } is not a perfect number.");
            }
        }

        /// <summary>
        /// Given a number, print if it is prime or not
        /// </summary>
        public static void IsPrimeNumber(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    if (i != 1 && i != number)
                    {
                        Console.WriteLine($"{ number } is not a prime number.");
                        return;
                    }
                }
            }
            Console.WriteLine($"{ number } is a prime number.");
        }
    }
}
