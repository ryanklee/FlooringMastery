using System; 

namespace Warmups.BLL
{
    public class Conditionals
    {
        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            if (aSmile == false && bSmile == false) return true;
            else if (aSmile == true && bSmile == true) return true;
            else return false;
        }

        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
            if (isVacation == true || isWeekday == false) return true;
            else return false;
        }

        public int SumDouble(int a, int b)
        {
            if (a == b) return (a + b) * 2;
            else return a + b;
        }
        
        public int Diff21(int n)
        {
            if (n > 21) return (n - 21) * 2;
            else return 21 - n;
        }
        
        public bool ParrotTrouble(bool isTalking, int hour)
        {
            if (isTalking == true && hour < 7 || hour > 20) return true;
            else return false;
        }
        
        public bool Makes10(int a, int b)
        {
            if (a == 10 || b == 10 || a + b == 10) return true;
            else return false;
        }
        
        public bool NearHundred(int n)
        {
            if (Math.Abs(100 - n) <= 10 || Math.Abs(200 - n) <= 10) return true;
            else return false;
        }
        
        public bool PosNeg(int a, int b, bool negative)
        {
            if (negative != true && (a < 0 && b > 0) || (a > 0 && b < 0)) return true;
            else if (negative == true && (a < 0 & b < 0)) return true;
            else return false;
        }
        
        public string NotString(string s)
        {
            if (s.IndexOf("not") == 1) return s;
            else return "not " + s;
        }
        
        public string MissingChar(string str, int n)
        {
            if (n == 0) return (str.Substring(1));
            else return str.Substring(0, n) + str.Substring(n + 1);
        }
        
        public string FrontBack(string str)
        {
            if (str.Length == 1) return str;
            else return str.Substring(str.Length - 1) + str.Substring(1, str.Length - 2) + str.Substring(0, 1);
        }
        
        public string Front3(string str)
        {
            if (str.Length < 3) return str + str + str;
            else return str.Substring(0, 3) + str.Substring(0, 3) + str.Substring(0, 3);
        }
        
        public string BackAround(string str)
        {
            if (str.Length == 1) return str + str + str;
            else return str.Substring(str.Length - 1, 1) + str.Substring(0, str.Length) + str.Substring(str.Length - 1, 1);
        }
        
        public bool Multiple3or5(int number)
        {
            if (number % 3 == 0 || number % 5 == 0) return true;
            else return false;
        }
        
        public bool StartHi(string str)
        {
            if (str.Length > 2 
                && str.IndexOf("hi") == 0 
                && str.Substring(2, 1) != " " 
                && str.Substring(2, 1) != ",")
                return false;
            else if (str.IndexOf("hi") == 0) return true;
            else return false;
        }
        
        public bool IcyHot(int temp1, int temp2)
        {
            if ((temp1 < 0 && temp2 > 100) || (temp1 > 100 && temp2 < 0)) return true;
            else return false;
        }
        
        public bool Between10and20(int a, int b)
        {
            if ((a >= 10 && a <= 20) || (b >= 10 && b <= 20)) return true;
            else return false;
        }
        
        public bool HasTeen(int a, int b, int c)
        {
            if ((a >= 13 && a <= 19) || (b >= 13 && b <= 19) || (c >= 13 && c <= 19)) return true;
            else return false;
        }
        
        public bool SoAlone(int a, int b)
        {
            if ((a >= 13 && a <= 19) && (b >= 13 && b <= 19)) return false;
            else if (a >= 13 && a <= 19) return true;
            else if (b >= 13 && b <= 19) return true;
            else return false;
        }
        
        public string RemoveDel(string str)
        {
            if (str.IndexOf("del") == 1) return str.Substring(0, 1) + str.Substring(4);
            else return str;
        }
        
        public bool IxStart(string str)
        {
            if (str.IndexOf("ix") == 1) return true;
            else return false;
        }
        
        public string StartOz(string str)
        {
            if (str.IndexOf("o") == 0 && str.IndexOf("z") == 1) return "oz";
            else if (str.IndexOf("o") == 0) return "o";
            else if (str.IndexOf("z") == 1) return "z";
            else return "";
        }
        
        public int Max(int a, int b, int c)
        {
            if (a > b && b > c) return a;
            else if (a < b && b < c) return c;
            else return b;
        }
        
        public int Closer(int a, int b)
        {
            if (Math.Abs(a - 10) > Math.Abs(b - 10)) return b;
            else if (Math.Abs(a - 10) < Math.Abs(b - 10)) return a;
            else return 0;
        }
        
        public bool GotE(string str)
        {
            int eCount = 0;

            for (int i = 0; i <= str.Length - 1; i++)
            {
                if (str.Substring(i, 1) == "e") eCount++;
            }

            if (eCount >= 1 && eCount <= 3) return true;
            else return false;
        }
        
        public string EndUp(string str)
        {
            if (str.Length < 3) return str.ToUpper();
            else
            {
                string strToConvert = str.Substring(str.Length - 3);
                return str.Substring(0, str.Length - 3) + strToConvert.ToUpper();
            }
        }
        
        public string EveryNth(string str, int n)
        {
            string newString = "";

            for (int i = 0; i <= str.Length - 1; i++)
            {
                if (i % n == 0) newString = newString + str[i];
            }

            return newString;
        }
    }
}
