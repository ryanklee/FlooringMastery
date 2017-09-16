using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI.GameSetup
{
    public class SplashScreen
    {

        public SplashScreen()
        {
            Greeting();
            WaitForUserKeyPress();
            ClearSplashScreen();
        }
        
        private void Greeting()
        {
            Console.WriteLine("Welcome to Battleship!");
        }

        private void WaitForUserKeyPress()
        {
            Console.ReadLine();
        }

        private void ClearSplashScreen()
        {
            Console.Clear();
        }
    }
}
