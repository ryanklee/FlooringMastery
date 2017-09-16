using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI.GameSetup
{
    public class Player
    {
        public string Name { get; private set; }
        public int TurnOrderPosition { get; private set; }

        public Player(int flipResult)
        {
            UserInput userNameInput = new UserInput();
            Name = userNameInput.GetNameFromUser();
            TurnOrderPosition = flipResult;
        }
    }
}
