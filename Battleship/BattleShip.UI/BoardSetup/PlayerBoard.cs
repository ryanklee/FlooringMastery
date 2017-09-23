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
    public class PlayerBoard
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
                    Console.Write("{0}: Enter coordinates to place your {1}: ", player.Name, ship);
                    Validator validatedCoords = userInput.GetValidCoords();
                    int x = validatedCoords.ValidX;
                    int y = validatedCoords.ValidY;

                    Console.Write("{0}: Choose direction <Up>, <Down>, <Left>, <Right>", player.Name);
                    ShipDirection direction = userInput.GetDirectionFromUser();
                    Console.Clear();

                    PlaceShipRequest request = new PlaceShipRequest()
                    {
                        Coordinate = new Coordinate(y, x),
                        Direction = direction,
                        ShipType = ship
                    };

                    ShipPlacement response = board.PlaceShip(request);

                    if (response == ShipPlacement.Ok)
                    {
                        Console.WriteLine("Ship placement succeeded");
                        Console.ReadLine();
                        Console.Clear();
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
