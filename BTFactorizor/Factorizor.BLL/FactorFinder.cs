using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.BLL
{
    public class FactorFinder
    {
        private List<int> factors = new List<int>();

        public void GenerateFactors(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                    factors.Add(i);
            }
        }

        public List<int> ReturnFactors()
        {
            return factors;
        }
    }

}
