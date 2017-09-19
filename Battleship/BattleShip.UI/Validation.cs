using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class Validation
    {
        public int ValidX { get; private set; }
        public int ValidY { get; private set; }

        public void ConvertValidCoords(string inputCoords)
        {
            char xString = inputCoords[0];
            string yString = inputCoords.Substring(1);

            ValidX = AlphaCoordinateToNumber(xString);
            Int32.TryParse(yString, out int y);
            ValidY = y;
        }

        public bool CheckForm(string inputCoords)
        {
            Regex rgx = new Regex(@"^[a-jA-J]\d0?$");
            return rgx.IsMatch(inputCoords);
        }

        public bool CheckType(string inputCoord)
        {
            return Int32.TryParse(inputCoord, out int inputCoordInt);
        }

        private int AlphaCoordinateToNumber(char alphaCoord)
        {
            int numberCoord = char.ToUpper(alphaCoord) - 64;
            return numberCoord;
        }

        public void AlertInvalidInput()
        {
            Console.WriteLine("Please enter valid coordinate...");
        }
    }
}
