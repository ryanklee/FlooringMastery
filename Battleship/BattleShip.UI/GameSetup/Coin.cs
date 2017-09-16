using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI.GameSetup
{
    public class Coin
    {
        public int[] FlipResult { get; private set; }

        public Coin()
        {
            FlipResult = new int[2];
            FlipCoin();
        }

        public void FlipCoin()
        {
            Random rnd = new Random();
            double result = rnd.NextDouble();

            if (result <= 0.5)
            {
                FlipResult[0] = 0;
                FlipResult[1] = 1;
            }
            else
            {
                FlipResult[0] = 1;
                FlipResult[1] = 0;
            }
        }
    }

}