using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class StartMenu
    {
        public string P1Name { get; private set; }
        public string P2Name { get; private set; }

        public void Menu()
        {
            MenuIntro();
            GetP1Name();
            GetP2Name();
            Greeting();
            Console.ReadLine();
        }

        private void MenuIntro()
        {
            Console.WriteLine("MAIN MENU");
        }

        private void GetP1Name()
        {
            Console.WriteLine("Enter P1 Name: ");
            P1Name = Console.ReadLine();
        }

        private void GetP2Name()
        {
            Console.WriteLine("Enter P2 Name: ");
            P2Name = Console.ReadLine();
        }

        private void Greeting()
        {
            Console.WriteLine("Hello {0} and {1}. Wecome to Battleship!", P1Name, P2Name);
        }
    }
}
