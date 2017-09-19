using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class BoardSetup
    {
        public Board Setup()
        {
            Board board = new Board();
            board = PopulateBoard(board);
            
            return board;
        }

        private Board PopulateBoard(Board board)
        {

            foreach (ShipType ship in Enum.GetValues(typeof(ShipType)))
            {
                UserInput userInput = new UserInput();
                Validation validatedCoords = userInput.GetValidCoords();
                int x = validatedCoords.ValidX;
                int y = validatedCoords.ValidY;


                ShipDirection direction = userInput.GetDirectionFromUser();

                PlaceShipRequest request = new PlaceShipRequest()
                {
                    Coordinate = new Coordinate(x, y),
                    Direction = direction,
                    ShipType = ship
                };

                var response = board.PlaceShip(request);
            }



            return board;
        }
    }
}
