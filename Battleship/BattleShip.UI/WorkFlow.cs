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
        public bool Victory { get; private set; }

        public void NewGame()
        {
            while (true)
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

            while (Victory != true)
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

            if (EndGame() == true)
                break;
            else
                continue;

            }
        }

        private Board ProcessTurn(Board opponentBoard, Player player)
        {
            while (true)
            {
                UserInput userInput = new UserInput();
                BoardGrid boardGrid = new BoardGrid();

                boardGrid.DisplayGridTurn(opponentBoard);

                Validator validCoords = userInput.GetValidCoords();
                Coordinate coordinate = new Coordinate(validCoords.ValidX, validCoords.ValidY);

                FireShotResponse response = opponentBoard.FireShot(coordinate);
                if (ProcessShotStatusResponse(response) == true)
                {
                    Console.WriteLine("{0}", response.ShotStatus);
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    return opponentBoard;
                }
                else
                {
                    Console.WriteLine("{0}", response.ShotStatus);
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
            }
        }

        private bool ProcessShotStatusResponse(FireShotResponse response)
        {
            switch (response.ShotStatus)
            {
                case ShotStatus.Invalid:
                    return false;
                case ShotStatus.Duplicate:
                    return false;
                case ShotStatus.Hit:
                    return true;
                case ShotStatus.HitAndSunk:
                    return true;
                case ShotStatus.Miss:
                    return true;
                case ShotStatus.Victory:
                    Victory = true;
                    return true;
                default:
                    return true;
            }
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

        private bool EndGame()
        {
            Console.Clear();
            Console.WriteLine("Press [enter] to play again or [esc] to quit... ");
            ConsoleKey keyPress = Console.ReadKey(true).Key;
            while (true)
            {
                switch (keyPress)
                {
                    case ConsoleKey.Enter:
                        Victory = false;
                        return false;
                    case ConsoleKey.Escape:
                        return true;
                    default:
                        continue;
                }
            }
            Console.ReadLine();
        }
    }
}

