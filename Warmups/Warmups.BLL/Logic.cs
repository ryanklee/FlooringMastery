using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Logic
    {

        public bool GreatParty(int cigars, bool isWeekend)
        {
            if (cigars >= 40 && cigars <= 60 && isWeekend == false) return true;
            else if (cigars > 40 && isWeekend == true) return true;
            else return false;
        }
        
        public int CanHazTable(int yourStyle, int dateStyle)
        {
            if (yourStyle >= 8 || dateStyle >= 8) return 2;
            else if (yourStyle <= 2 || dateStyle <= 2) return 0;
            else return 1;
        }

        public bool PlayOutside(int temp, bool isSummer)
        {
            if (temp >= 60 && temp <= 90 && isSummer == false) return true;
            else if (temp >= 60 && temp <= 100 && isSummer == true) return true;
            else return false;
        }
        
        public int CaughtSpeeding(int speed, bool isBirthday)
        {
            int bdayBump = 0;

            if (isBirthday == true) bdayBump = 5;

            if (speed <= 60 + bdayBump) return 0;
            else if (speed >= 61 + bdayBump && speed <= 80 + bdayBump) return 1;
            else return 2;    
        }
        
        public int SkipSum(int a, int b)
        {
            if (a + b >= 10 && a + b <= 19) return 20;
            else return a + b;
        }
        
        public string AlarmClock(int day, bool vacation)
        {
            throw new NotImplementedException();
        }
        
        public bool LoveSix(int a, int b)
        {
            throw new NotImplementedException();
        }
        
        public bool InRange(int n, bool outsideMode)
        {
            throw new NotImplementedException();
        }
        
        public bool SpecialEleven(int n)
        {
            throw new NotImplementedException();
        }
        
        public bool Mod20(int n)
        {
            throw new NotImplementedException();
        }
        
        public bool Mod35(int n)
        {
            throw new NotImplementedException();
        }
        
        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            throw new NotImplementedException();
        }
        
        public bool TwoIsOne(int a, int b, int c)
        {
            throw new NotImplementedException();
        }
        
        public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            throw new NotImplementedException();
        }
        
        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            throw new NotImplementedException();
        }
        
        public bool LastDigit(int a, int b, int c)
        {
            throw new NotImplementedException();
        }
        
        public int RollDice(int die1, int die2, bool noDoubles)
        {
            throw new NotImplementedException();
        }

    }
}
