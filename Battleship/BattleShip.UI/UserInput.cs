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
            return inputCoords;
        }

        public void InformUserOfInvalidInput()
        {
            Console.WriteLine("Please enter valid coordinate...");
        }

        private bool ValidateInputCoordForm(string inputCoords)
        {
            Regex rgx = new Regex(@"^[a-jA-J]\d0?$"); 
            return rgx.IsMatch(inputCoords);
        }

        private int ValidateInputCoordType(string inputCoord)
        {
            Int32.TryParse(inputCoord, out int inputCoordInt);
            return inputCoordInt;
        }

        private int AplhaCoordinateToNumber(char alphaCoord)
        {
            int numberCoord = char.ToUpper(alphaCoord) - 64;
            return numberCoord;
        }
    }
}
