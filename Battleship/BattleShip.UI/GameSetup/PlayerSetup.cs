using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class PlayerSetup
    {

        Random _rnd = new Random();
        private bool _coinFlipped;
        private int _flipResult;

        public PlayerSetup()
        {
            
        }
        
        public string GetName()
        {
            Console.WriteLine("Enter player name: ");
            string name = Console.ReadLine();
            return name;
        }

        public bool GetPosition()
        {
            if (_coinFlipped == false)
            {
                if (_flipResult == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (_flipResult == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
                
        }

        private void FlipCoin()
        {
            _flipResult = _rnd.Next(0,1);
            _coinFlipped = true;
        }
    }
}
