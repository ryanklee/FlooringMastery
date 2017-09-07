using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.BLL
{
    public class PrimeChecker
    {
        public bool IsPrime(List<int> factors)
        {
            if (factors.Count == 2)
                return true;
            else return false;
        }
    }
}
