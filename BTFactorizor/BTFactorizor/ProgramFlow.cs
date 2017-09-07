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
            Number number = new Number();

            number.NumberFromUser = GetNumberFromUser();

            CalculateNeededOutputs(number);

            OutputResults(number);
        }

        private int GetNumberFromUser()
        {
            ConsoleInput consoleInput = new ConsoleInput();
            return consoleInput.GetNumberFromUser();
        }

        private void CalculateNeededOutputs(Number number)
        {
            FactorFinder factorFinder = new FactorFinder();
            number.Factors = factorFinder.GenerateFactors(number.NumberFromUser);

            PerfectChecker perfectChecker = new PerfectChecker();
            number.IsPerfect = perfectChecker.IsPerfect(number.NumberFromUser, number.Factors);

            PrimeChecker primeChecker = new PrimeChecker();
            number.IsPrime = primeChecker.IsPrime(number.Factors);
        }

        private void OutputResults(Number number)
        {
            ConsoleOutput consoleOutput = new ConsoleOutput();
            consoleOutput.Outputs(number);
        }
    }
}
