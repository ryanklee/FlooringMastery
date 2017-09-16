using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class UserInput
    {
        private string _alphaCoordinates = "abcdefghijABCDEFGHIJ";

        public string GetNameFromUser()
        {
            string nameInput;
            Console.WriteLine("Enter player name: ");
            nameInput = Console.ReadLine();
            return nameInput;
        }

        public string GetUserCoordinate()
        {
            string inputCoords;
            Console.WriteLine("Enter coordinates: ");
            inputCoords = Console.ReadLine();
            if (ValidateLength(inputCoords) == true)
            {
                string firstTerm = GetFirstTerm(inputCoords);
                string secondTerm = GetSecondTerm(inputCoords);
            }


            return inputCoords;
        }

        private bool ValidateCoordinateInput(string inputCoords)
        {
            //check length <= 3
            //check first char is in _alphacoordinates
            //check char[1,2] is an int
            //check char[1,2] <= 10
            //pass all condistions return true
            //else return false

            

            
            else 
            else if (Int32.TryParse(secondCoordinateTerm, out int secondCoordinateTermParsed) == false)
            {
                Console.WriteLine("Input invalid.");
                Console.ReadLine();
                return false;
            }
            else if (secondCoordinateTermParsed > 10 || secondCoordinateTermParsed < 0)
            {
                Console.WriteLine("Input invalid.");
                Console.ReadLine();
                return false;
            }
            else
            {
                Console.WriteLine("Input valid.");
                Console.ReadLine();
                return true;
            }
        }

        private bool ValidateLength(string inputCoords)
        {
            if (inputCoords.Length != 2 || inputCoords.Length != 3)
                return false;
            else
                return true;
        }

        private string GetFirstTerm(string inputCoords)
        {
            return inputCoords.Substring(0, 1);
        }

        private string GetSecondTerm(string inputCoords)
        {
            return inputCoords.Substring(2);
        }

        private bool ValidateInKey(string inputCoords)
        {
            if (_alphaCoordinates.Contains(inputCoords) == false)
                return false;
            else
                return true;
        }

        private bool Validate
    }
}
