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

        public Player()
        {
            UserInput userInput = new UserInput();
            Name = userInput.GetNameFromUser();
        }
    }
}
