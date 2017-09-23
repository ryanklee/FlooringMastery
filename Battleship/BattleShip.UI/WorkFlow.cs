using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
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
            Console.WriteLine("Welcome to Battleship!");
            Console.Write("Press enter to continue...");
            Console.ReadLine();
            Console.Clear();

            Player p1 = new Player();
            Player p2 = new Player();

            PlayerBoard board = new PlayerBoard();

            Board p1Board = board.Setup(p1);
            Board p2Board = board.Setup(p2);

            int playerTurn = DetermineFirstPlayer();

            while (true)
            {
                if (playerTurn % 2 == 0)
                {
                    ProcessTurn(p1Board, p2);
                }
                else
                {
                    ProcessTurn(p2Board, p1);
                }
                playerTurn++;
            }
            EndGame();
        }

        private Board ProcessTurn(Board opponentBoard, Player player)
        {
            UserInput userInput = new UserInput();
            BoardGrid boardGrid = new BoardGrid();

            boardGrid.DisplayGridTurn(opponentBoard);

            Validator validCoords = userInput.GetValidCoords();
            Coordinate coordinate = new Coordinate(validCoords.ValidX, validCoords.ValidY);

            FireShotResponse response = opponentBoard.FireShot(coordinate);
            Console.WriteLine("{0}", response.ShotStatus);
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            Console.Clear();
            return opponentBoard;
        }

        private int DetermineFirstPlayer()
        {

            Random rnd = new Random();
            double result = rnd.NextDouble();

            if (result <= 0.5)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        private void EndGame()
        {
            Console.WriteLine("Press a key to continue...");
            Console.ReadLine();
        }
    }
}

