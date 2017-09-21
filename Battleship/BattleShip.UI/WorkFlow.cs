using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class WorkFlow
    {
        public void NewGame()
        {
            UserInput userInput = new UserInput();
            userInput.SplashScreen();

            Coin coin = new Coin();
            coin.FlipCoin();

            Player p1 = new Player(coin.FlipResult[0]);
            Player p2 = new Player(coin.FlipResult[1]);

            BoardSetup board = new BoardSetup();

            Board p1Board = board.Setup(p1);
            Board p2Board = board.Setup(p2);

            int i = p1.TurnOrderPosition;
            while (true)
            {
                if (i % 2 == 0)
                {
                    PlayerTurn(p1Board);
                }
                else
                {
                    PlayerTurn(p2Board);
                }
                i++;
            } 
            EndGame();
        }

        private Board PlayerTurn(Board opponentBoard)
        {
            UserInput userInput = new UserInput();
            BoardGrid boardGrid = new BoardGrid();
            boardGrid.DisplayGrid(opponentBoard);
            Console.WriteLine("");
            Validation validCoords = userInput.GetValidCoords();
            Coordinate coordinate = new Coordinate(validCoords.ValidX, validCoords.ValidY);
            FireShotResponse response = opponentBoard.FireShot(coordinate);
            Console.WriteLine("{0}", response.ShotStatus);
            Console.Clear();
            return opponentBoard;
        }

        private void EndGame()
        {
            Console.WriteLine("Press a key to continue...");
            Console.ReadLine();
        }
    }
}

