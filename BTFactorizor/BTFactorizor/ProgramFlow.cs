using Factorizor.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTFactorizor
{
    public class ProgramFlow
    {
        public void StartProgram()
        {
            List<int> factors = new List<int>();
            ConsoleInput consoleInput = new ConsoleInput();
            ConsoleOutput consoleOutput = new ConsoleOutput();
            FactorFinder factorFinder = new FactorFinder();
            PerfectChecker perfectChecker = new PerfectChecker();
            PrimeChecker primeChecker = new PrimeChecker();
            NumberFromUser numberFromUser = new NumberFromUser();

            numberFromUser.NumberToFactorize = consoleInput.GetNumberFromUser();
            factors = numberFromUser.factors = factorFinder.GenerateFactors(numberFromUser.NumberToFactorize);
            numberFromUser.isPerfect = perfectChecker.IsPerfect(numberFromUser.NumberToFactorize, numberFromUser.factors);
            numberFromUser.isPrime = primeChecker.IsPrime(numberFromUser.factors);
            consoleOutput.OutputFactorsToConsole(numberFromUser.NumberToFactorize, numberFromUser.factors);
            consoleOutput.OutputIsPerfectToConsole(numberFromUser.NumberToFactorize, numberFromUser.isPerfect);
            consoleOutput.OutputIsPrimeToConsole(numberFromUser.NumberToFactorize, numberFromUser.isPrime);
            consoleOutput.WaitForUserInput();
        }
    }
}
