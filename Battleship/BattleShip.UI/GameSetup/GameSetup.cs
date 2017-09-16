using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI.GameSetup
{
    public class CreateGame
    {
        public CreateGame()
        {
            SplashScreen splashScreen = new SplashScreen();
            Coin coin = new Coin();

            Player p1 = new Player(coin.FlipResult[0]);
            Player p2 = new Player(coin.FlipResult[1]);
            
            EndGame();
        }

        private void EndGame()
        {
            Console.WriteLine("Press a key to continue...");
            Console.ReadLine();
        }
    }
}
