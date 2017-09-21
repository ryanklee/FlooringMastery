using BattleShip.BLL.Responses;
using BattleShip.BLL.Requests;
using BattleShip.BLL.GameLogic;
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

        public void DisplayGrid(Board board)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Coordinate coordinate = new Coordinate(j + 1, i + 1);
                    ShotHistory status = board.CheckCoordinate(coordinate);

                    switch (status)
                    {
                        case ShotHistory.Miss:
                            Console.Write(" M ");
                            break;
                        case ShotHistory.Hit:
                            Console.Write(" H ");
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
