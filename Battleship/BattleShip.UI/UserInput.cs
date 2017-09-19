using BattleShip.BLL.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class UserInput
    {
        public void SplashScreen()
        {
            Console.WriteLine("Welcome to Battleship!");
            EnterToContinue();
        }

        public string GetNameFromUser()
        {
            Console.WriteLine("Enter player name: ");
            string nameInput = Console.ReadLine();
            EnterToContinue();
            return nameInput;
        }

        public Validation GetValidCoords()
        {
            Validation validation = new Validation();

            string validStringCoords = GetCoordsFromUser();

            validation.ConvertValidCoords(validStringCoords);

            return validation;
        }

        public string GetCoordsFromUser()
        {
            Validation validation = new Validation();

            string inputCoords;

            while (true)
            {
                Console.WriteLine("Enter coordinates: ");
                inputCoords = Console.ReadLine();
                bool validForm = validation.CheckForm(inputCoords);
                bool validType = validation.CheckType(inputCoords.Substring(1));

                if (validForm == true &&
                    validType == true)
                {
                    break;
                }
                else
                {
                    validation.AlertInvalidInput();
                    continue;
                }
            }
            return inputCoords;
        }

        public ShipDirection GetDirectionFromUser()
        {
            Console.WriteLine("To choose direction, press arrow key: <Up>, <Down>, <Left>, <Right>");
            while (true)
            {
                ConsoleKey keyPress = Console.ReadKey(true).Key;
                switch (keyPress)
                {
                    case ConsoleKey.UpArrow:
                        return ShipDirection.Up;
                    case ConsoleKey.DownArrow:
                        return ShipDirection.Down;
                    case ConsoleKey.RightArrow:
                        return ShipDirection.Right;
                    case ConsoleKey.LeftArrow:
                        return ShipDirection.Left;
                    default:
                        Console.WriteLine("Please enter valid direction...");
                        EnterToContinue();
                        break;
                }
            }
        }

        public void EnterToContinue()
        {
            Console.WriteLine("\nPress <enter> to continue..");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
            Console.Clear();
        }
    }
}
