using System;

namespace Warmups.BLL
{
    public class Loops
    {

        public string StringTimes(string str, int n)
        {
            string newStr = "";

            for (int i = 0; i < n; i++)
            {
                newStr = newStr + str;
            }
            return newStr;
        }

        public string FrontTimes(string str, int n)
        {
            string chunk = "";
            string nChunk = "";

            if (str.Length < 3) chunk = str.Substring(0);
            else chunk = str.Substring(0, 3);

            for (int i = 0; i < n; i++)
            {
                nChunk += chunk;
            }

            return nChunk;
        }

        public int CountXX(string str)
        {
            int xCount = 0;
            int nextX = 0;

            while (true)
            {
                if (str.IndexOf("xx", nextX) != -1)
                {
                    str.IndexOf("xx", nextX);
                    nextX = str.IndexOf("xx", nextX) + 1;
                    xCount++;
                }
                else return xCount;
            }
        }

        public bool DoubleX(string str)
        {
            int firstX = str.IndexOf("x");
            if (str.IndexOf("x") + 1 == str.IndexOf("x", firstX + 1)) return true;
            else return false;
        }

        public string EveryOther(string str)
        {
            string newString = "";

            for (int i = 0; i <= str.Length - 1; i++)
            {
                if (i % 2 == 0)
                {
                    newString = newString + str[i];
                }
            }
            return newString;
        }

        public string StringSplosion(string str)
        {
            int numOfChars = 1;
            string newString = "";

            for (int i = 0; i <= str.Length - 1; i++)
            {
                newString = newString + str.Substring(0, numOfChars);
                numOfChars++;
            }
            return newString;
        }

        public int CountLast2(string str)
        {
            string endTwoChars = str.Substring(str.Length - 2, 2);

            int xCount = 0;
            int nextX = 0;

            while (true)
            {
                if (str.IndexOf(endTwoChars, nextX) != str.Length - 2)
                {
                    str.IndexOf(endTwoChars, nextX);
                    nextX = str.IndexOf(endTwoChars, nextX) + 1;
                    xCount++;
                }
                else return xCount;
            }
        }

        public int Count9(int[] numbers)
        {
            int nineCount = 0;

            for (int i = 0; i <= numbers.Length - 1; i++)
            {
                if (numbers[i] == 9) nineCount++;
            }

            return nineCount;
        }

        public bool ArrayFront9(int[] numbers)
        {

            int searchLimit;

            if (numbers.Length < 4) searchLimit = numbers.Length;
            else searchLimit = 4;

            for (int i = 0; i <= searchLimit - 1; i++)
            {
                if (numbers[i] == 9) return true;
            }

            return false;
        }

        public bool Array123(int[] numbers)
        {
            for (int i = 1; i <= numbers.Length - 1; i++)
            {
                if (numbers[i - 1] == 1 && 
                    numbers[i] == 2 && 
                    numbers[i + 1] == 3) return true; 
            }
            return false;
        }

        public int SubStringMatch(string a, string b)
        {

            int minLength;
            int twoLengthSubStrings = 0;

            if (a.Length < b.Length) minLength = a.Length;
            else minLength = b.Length;

            for (int i = 0; i <= minLength - 2; i++)
            {
                if (a[i] == b[i] && 
                    a[i + 1] == b[i + 1])
                {
                    twoLengthSubStrings++;
                }
            }
            return twoLengthSubStrings;
        }

        public string StringX(string str)
        {
            string newString = "";

            for (int i = 0; i <= str.Length - 1; i++)
            {
                if (str.Substring(i, 1) != "x")
                    newString = newString + str[i];
                else if (i == 0 || i == str.Length - 1)
                    newString = newString + str[i];
                else continue;
            }
            return newString;
        }

        public string AltPairs(string str)
        {
            string newString = "";

            for (int i = 0; i <= str.Length - 1; i++)
            {
                if (i == 0 || 
                    i == 1 ||
                    i == 4 || 
                    i == 5 || 
                    i == 8 || 
                    i == 9)
                {
                    newString = newString + str[i];
                }
            }
            return newString;
        }

        public string DoNotYak(string str)
        {
            string newString = "";
            int yakIndex = str.IndexOf("yak");
        
            for (int i = 0; i <= str.Length - 1; i++)
            {
                if (i < yakIndex || i >= yakIndex + 3)
                {
                    newString = newString + str.Substring(i, 1);
                }
            }

            return newString;
        }

        public int Array667(int[] numbers)
        {
            int pairCount = 0;

            for (int i = 1; i < numbers.Length; i++)
            {
                if ((numbers[i - 1] == 6 && numbers[i] == 6) ||
                    (numbers[i - 1] == 6 && numbers[i] == 7))
                    pairCount++;
            }
            return pairCount;
        }

        public bool NoTriples(int[] numbers)
        {
            for (int i = 1; i < numbers.Length - 1; i++)
            {
                if (numbers[i - 1] == numbers[i] && 
                    numbers[i] == numbers[i + 1])
                    return false;
            }
            return true;
        }

        public bool Pattern51(int[] numbers)
        {
            for (int i = 0; i <= numbers.Length - 3; i++)
            {
                if (numbers[i + 1] == numbers[i] + 5 &&
                    numbers[i + 2] == numbers[i] - 1) return true;
            }
            return false;
        }

    }
}
