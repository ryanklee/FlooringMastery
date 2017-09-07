using System;
using Factorizor.BLL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTFactorizor
{
    class ConsoleOutput
    {

        public void Outputs(Number number)
        {
            OutputFactorsToConsole(number.NumberFromUser, number.Factors);
            OutputIsPerfectToConsole(number.NumberFromUser, number.IsPerfect);
            OutputIsPrimeToConsole(number.NumberFromUser, number.IsPrime);
            WaitForUserInputToQuit();
        }

        private void OutputFactorsToConsole(int numberFromUser, List<int> factors)
        {
            Console.Write("The factors of {0} are: ", numberFromUser);
            factors.ForEach(i => Console.Write("{0} ", i));
            Console.WriteLine();
        }

        private void OutputIsPerfectToConsole(int numberFromUser, bool isPerfect)
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

        private void OutputIsPrimeToConsole(int numberFromUser, bool isPrime)
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

        private void WaitForUserInputToQuit()
        {
            Console.WriteLine("Press any key to quit program...");
            Console.Read();
        }
    }
}
