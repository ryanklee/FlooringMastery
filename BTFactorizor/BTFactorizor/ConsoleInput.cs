using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTFactorizor
{
    class ConsoleInput
    {
        public int NumberToFactorize { get; private set; }

        private int GetNumber()
        {
            int number;

            while (true)
            {
                Console.WriteLine("Enter integer to factorize: ");
                string input = Console.ReadLine();

                if (Int32.TryParse(input, out number))
                    break;
                else
                    Console.WriteLine("That was not an integer!");
            }

            return number;
        }

    }
}
