using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class UserInput
    {
        public int x { get; private set; }
        public int y { get; private set; }

        public string GetNameFromUser()
        {
            Console.WriteLine("Enter player name: ");
            string nameInput = Console.ReadLine();
            return nameInput;
        }

        public string GetCoordsFromUser()
        {
            string inputCoords;

            while (true)
            {
                Console.WriteLine("Enter coordinates: ");
                inputCoords = Console.ReadLine();
                bool validForm = ValidateInputCoordForm(inputCoords);
                bool validType = ValidateInputCoordType(inputCoords.Substring(1));

                if (validForm == true && 
                    validType == true)
                {
                    break;
                }
                else
                {
                    InformUserOfInvalidInput();
                    continue;
                }
            }
            return inputCoords;
        }

        private void CreateXYCoordsFromValidInput(string inputCoords)
        {
            char xString = inputCoords[0];
            string yString = inputCoords.Substring(1);

            x = AlphaCoordinateToNumber(xString);
            Int32.TryParse(yString, out int y);
        }

        private void InformUserOfInvalidInput()
        {
            Console.WriteLine("Please enter valid coordinate...");
        }

        private bool ValidateInputCoordForm(string inputCoords)
        {
            Regex rgx = new Regex(@"^[a-jA-J]\d0?$");
            return rgx.IsMatch(inputCoords);
        }

        private bool ValidateInputCoordType(string inputCoord)
        {
            return Int32.TryParse(inputCoord, out int inputCoordInt);
        }

        private int AlphaCoordinateToNumber(char alphaCoord)
        {
            int numberCoord = char.ToUpper(alphaCoord) - 64;
            return numberCoord;
        }
    }
}
