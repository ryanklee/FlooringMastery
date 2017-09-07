using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTFactorizor
{
    class ConsoleOutput
    {
                
        public void OutputFactorsToConsole(int numberToFactorize, List<int> factors)
        {
            Console.Write("The factors of {0} are: ", numberToFactorize);
            factors.ForEach(i => Console.Write("{0} ", i));
            Console.WriteLine();
        }

        public void OutputIsPerfectToConsole(int numberToFactorize, bool isPerfect)
        {
            if (isPerfect)
            {
                Console.WriteLine("{0} is perfect", numberToFactorize);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("{0} is not perfect", numberToFactorize);
                Console.ReadLine();
            }
                
        }
    }
}
