using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTFactorizor
{
    class ConsoleOutput
    {
                
        public void OutputFactorsToConsole(int numberFromUser, List<int> factors)
        {
            Console.Write("The factors of {0} are: ", numberFromUser);
            factors.ForEach(i => Console.Write("{0} ", i));
            Console.WriteLine();
        }

        public void OutputIsPerfectToConsole(int numberFromUser, bool isPerfect)
        {
            if (isPerfect)
            {
                Console.WriteLine("{0} is perfect", numberFromUser);
            }
            else
            {
                Console.WriteLine("{0} is not perfect", numberFromUser);
            }
                
        }

        public void OutputIsPrimeToConsole(int numberFromUser, bool isPrime)
        {
            if (isPrime)
            {
                Console.WriteLine("{0} is prime", numberFromUser);
            }
            else
            {
                Console.WriteLine("{0} is not prime", numberFromUser);
            }
        }

        public void WaitForUserInput()
        {
            Console.ReadLine();
        }
    }
}
