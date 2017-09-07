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
        List<int> factors;
        public int NumberToFactorize { get; private set; }
        public bool isPerfect;
        
        public void StartProgram()
        {
            FactorFinder factorFinder = new FactorFinder();
            PerfectChecker perfectChecker = new PerfectChecker();
            ConsoleInput consoleInput = new ConsoleInput();
            ConsoleOutput consoleOutput = new ConsoleOutput();

            NumberToFactorize = consoleInput.GetNumberFromUser();
            factorFinder.GenerateFactors(NumberToFactorize);
            factors = factorFinder.ReturnFactors();
            isPerfect = perfectChecker.IsPerfect(NumberToFactorize, factors);
            consoleOutput.OutputFactorsToConsole(NumberToFactorize, factors);
            consoleOutput.OutputIsPerfectToConsole(NumberToFactorize, isPerfect);
        }
    }
}
