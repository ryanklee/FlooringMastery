using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.BLL
{
    public class Number
    {
        public int NumberFromUser { get; set; }

        private List<int> factors;
        public List<int> Factors
        {
            get { return factors; }
            set { factors = value; }
        }

        public bool IsPerfect { get; set; }
        public bool IsPrime { get; set; }
    }
}
