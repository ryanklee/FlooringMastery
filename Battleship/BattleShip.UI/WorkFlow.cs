using BattleShip.UI.GameSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class WorkFlow
    {
        public void StartGame()
        {
            CreateGame createGame = new CreateGame();
            UserInput userInput = new UserInput();

            userInput.GetCoordinatesFromUser();
        }
    }
}
