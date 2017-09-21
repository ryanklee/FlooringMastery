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
            Console.Clear();
            return nameInput;
        }

        public Validation GetValidCoords()
        {
            Validation validation = new Validation();

            string validStringCoords = GetCoordsFromUser();

            validation.ConvertValidCoords(validStringCoords);

            return validation;
        }

        private string GetCoordsFromUser()
        {
            Validation validation = new Validation();

            string inputCoords;

            while (true)
            {
                inputCoords = Console.ReadLine();
                
                if (validation.CheckForm(inputCoords) && 
                    validation.CheckType(inputCoords.Substring(1)))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter valid coordinate..."); continue;
                }
            }
            return inputCoords;
        }

        public ShipDirection GetDirectionFromUser()
        {
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
                        Console.Clear();
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
