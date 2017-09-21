using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Ships;
using BattleShip.BLL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class BoardSetup
    {
        public Board Setup(Player player)
        {
            Board board = new Board();
            board = PopulateBoard(board, player);

            return board;
        }

        private Board PopulateBoard(Board board, Player player)
        {
            UserInput userInput = new UserInput();

            foreach (ShipType ship in Enum.GetValues(typeof(ShipType)))
            {
                while (true)
                {
                    Console.WriteLine("{0}, Enter coordinates to place your {1}", player.Name, ship);
                    Validation validatedCoords = userInput.GetValidCoords();
                    Console.Clear();
                    int x = validatedCoords.ValidX;
                    int y = validatedCoords.ValidY;

                    Console.WriteLine("{0}, Choose direction <Up>, <Down>, <Left>, <Right>", player.Name);
                    ShipDirection direction = userInput.GetDirectionFromUser();
                    Console.Clear();

                    PlaceShipRequest request = new PlaceShipRequest()
                    {
                        Coordinate = new Coordinate(x, y),
                        Direction = direction,
                        ShipType = ship
                    };

                    var response = board.PlaceShip(request);

                    if (response == ShipPlacement.Ok)
                    {
                        Console.WriteLine("Ship placement succeeded");
                        userInput.EnterToContinue();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("{0}", response);
                        continue;
                    }
                }
            }
            return board;
        }
    }
}
