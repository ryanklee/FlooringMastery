using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class Coin
    {
        public int[] FlipResult { get; private set; }

        public void FlipCoin()
        {
            Random rnd = new Random();
            double result = rnd.NextDouble();

            if (result <= 0.5)
            {
                FlipResult = new int[2] { 0, 1 };
            }
            else
            {
                FlipResult = new int[2] { 1, 0 };
            }
        }
    }
}