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
            if (vacation == false)
            {
                if (day == 6 || day == 0)
                {
                    return "10:00";
                }
                else return "7:00";
            }
            else
            {
                if (day == 6 || day == 0)
                {
                    return "10:00";
                }
                else return "off";
                    
            }
        }
        
        public bool LoveSix(int a, int b)
        {
            if (a == 6 || b == 6 || Math.Abs(a - b) == 6 || Math.Abs(b - a) == 6 || a + b == 6)
                return true;
            else return false;
        }
        
        public bool InRange(int n, bool outsideMode)
        {
            if (n >= 1 && n <= 10 && outsideMode == false) return true;
            else if (n >= 1 && n >= 10 && outsideMode == true) return true;
            else return false;
        }
        
        public bool SpecialEleven(int n)
        {
            if (n % 11 == 0 || (n - 1) % 11 == 0) return true;
            else return false;
        }
        
        public bool Mod20(int n)
        {
            if ((n - 1) % 20 == 0 || (n - 2) % 20 == 0) return true;
            else return false;
        }
        
        public bool Mod35(int n)
        {
            if (n % 3 == 0 && n % 5 != 0) return true;
            else if (n % 5 == 0 && n % 3 != 0) return true;
            else return false;
        }
        
        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            if (isMorning == true && isMom == true) return true;
            else if (isAsleep == true) return false;
            else if (isMorning == true) return false;
            else return true;
        }
        
        public bool TwoIsOne(int a, int b, int c)
        {
            if (a + b == c || b + c == a || c + a == b) return true;
            else return false;
        }
        
        public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            if (a < b && b < c) return true;
            else if (bOk == true && a < c) return true;
            else return false;
        }
        
        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            if (a < b && b < c) return true;
            else if (equalOk == true && 
                (a < b && b < c) || 
                (a == b && b < c ) || 
                (a < b && b == c))
                return true;
            else return false;
        }
        
        public bool LastDigit(int a, int b, int c)
        {
            if (a % 10 == b % 10 ||
                a % 10 == c % 10 ||
                b % 10 == c % 10) return true;
            else return false;
        }
        
        public int RollDice(int die1, int die2, bool noDoubles)
        {
            if (noDoubles == true && die1 == die2)
            {
                if (die1 == 6) die1 = 1;
                else die1++;
                return die1 + die2;
            }
            else return die1 + die2;
        }

    }
}
