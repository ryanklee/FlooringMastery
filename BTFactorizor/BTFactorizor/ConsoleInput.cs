using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTFactorizor
{
    public class ConsoleInput
    {

        public int GetNumberFromUser()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter integer to factorize: ");
                string input = Console.ReadLine();

                if (Int32.TryParse(input, out int number))
                    return number;
                else
                {
                    Console.WriteLine("That was not an integer! Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
}
