using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.BLL
{
    public class NumberFromUser
    {
        public int NumberToFactorize { get; set; }

        public List<int> factors;

        public bool isPerfect;

        public bool isPrime;
    }
}
