using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.BLL
{
    public class FactorFinder
    {
        private List<int> _factors = new List<int>();

        private void GetFactors(int number)
        {
            for (int i = 0; i < number; i++)
            {
                if (number % i == 0)
                    _factors.Add(i);
            }
        }

        public List<int> ReturnFactors()
        {
            return _factors;
        }
    }
}
