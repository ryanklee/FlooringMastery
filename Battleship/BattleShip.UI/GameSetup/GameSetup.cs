using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class GameSetup
    {
        public GameSetup()
        {
            PlayerSetup playerSetup = new PlayerSetup();
            Player p1 = new Player(playerSetup);
            Player p2 = new Player(playerSetup);

            StartMenu startMenu = new StartMenu();
            startMenu.Menu(p1, p2);

        }
    }
}
