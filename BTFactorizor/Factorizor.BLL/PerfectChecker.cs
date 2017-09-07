using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.BLL
{
    public class PerfectChecker
    {
        public bool IsPerfect(int numberFromUser, List<int> factors)
        {
            int sum = 0 - numberFromUser;

            factors.ForEach(i => sum += i);

            if (sum == numberFromUser)
                return true;
            else
                return false;
        }
    }
}
