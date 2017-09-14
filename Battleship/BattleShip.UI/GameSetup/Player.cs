using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class Player
    {
        public string Name { get; private set; }
        public bool FirstPlayer { get; private set; }

        public Player(PlayerSetup playerSetup)
        {
            Name = playerSetup.GetName();
            FirstPlayer = playerSetup.GetPosition();
        }
    }
}
