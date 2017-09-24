using BattleShip.BLL.Responses;
using BattleShip.BLL.Requests;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class BoardGrid
    {
        public string[,] Grid { get; private set; }

        public BoardGrid()
        {
            Grid = new string[10, 10];
        }

        public void DisplayGridTurn(Board board)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Coordinate coordinate = new Coordinate(i + 1, j + 1);
                    ShotHistory status = board.CheckCoordinate(coordinate);

                    switch (status)
                    {
                        case ShotHistory.Miss:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(" M ");
                            Console.ResetColor();
                            break;
                        case ShotHistory.Hit:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" H ");
                            Console.ResetColor();
                            break;
                        case ShotHistory.Unknown:
                            Console.Write(" . ");
                            break;
                    }
                }
                Console.WriteLine("");
            }
        }
    }
}
