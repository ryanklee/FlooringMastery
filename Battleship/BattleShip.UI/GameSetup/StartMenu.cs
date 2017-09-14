using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class StartMenu
    {
        public void Menu(Player p1, Player p2)
        {
            Greeting();
            InformPlayersOfPositions(p1, p2);
            Console.ReadLine();
        }

        private void MenuIntro()
        {
            Console.WriteLine("MAIN MENU");
        }
           
               
        private void Greeting()
        {
            Console.WriteLine("Wecome to Battleship!");
        }

        private void InformPlayersOfPositions(Player p1, Player p2)
        {
            string firstPlayer;
            string secondPlayer;

            if (p1.FirstPlayer == true)
            {
                firstPlayer = p1.Name;
                secondPlayer = p2.Name;
            }
            else
            {
                firstPlayer = p2.Name;
                secondPlayer = p1.Name;
            }
                
            Console.WriteLine($"{ firstPlayer }, you are the first player!");
        }
    }
}
