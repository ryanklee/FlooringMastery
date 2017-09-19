using BattleShip.BLL.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class WorkFlow
    {
        public int PlayerTurn { get; private set; }

        public void NewGame()
        {
            UserInput userInput = new UserInput();
            userInput.SplashScreen();

            Coin coin = new Coin();

            Player p1 = new Player(coin.FlipResult[0]);
            Player p2 = new Player(coin.FlipResult[1]);
            
            BoardSetup board = new BoardSetup();

            Board p1Board = board.Setup();
            Board p2Board = board.Setup();

            EndGame();
        }


        private void EndGame()
        {
            Console.WriteLine("Press a key to continue...");
            Console.ReadLine();
        }
    }

}

