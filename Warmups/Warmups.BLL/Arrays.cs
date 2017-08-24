using System;

namespace Warmups.BLL
{
    public class Arrays
    {

        public bool FirstLast6(int[] numbers)
        {
            if (numbers[0] == 6 || numbers[numbers.Length - 1] == 6) return true;
            else return false;
        }

        public bool SameFirstLast(int[] numbers)
        {
            if (numbers.Length > 0 && numbers[0] == numbers[numbers.Length - 1]) return true;
            else return false;
        }
        public int[] MakePi(int n)
        {
            int[] pi = new int[n];

            double piOG = Math.PI;

            string stringPIWithDecimal = piOG.ToString();

            string stringPIWithoutDecimal = stringPIWithDecimal.Substring(0, 1) + stringPIWithDecimal.Substring(2);
            
            for (int i = 0; i < n; i++)
            {
                pi[i] = Convert.ToInt32(stringPIWithoutDecimal.Substring(i, 1));
            }
            return pi;

        }
        
        public bool CommonEnd(int[] a, int[] b)
        {
            if (a[0] == b[0] || a[a.Length - 1] == b[b.Length - 1]) return true;
            else return false;
        }
        
        public int Sum(int[] numbers)
        {
            int sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }

            return sum;
        }
        
        public int[] RotateLeft(int[] numbers)
        {
            int[] rotatedNums = new int[] { numbers[1], numbers[2], numbers[0] };
            return rotatedNums;
        }
        
        public int[] Reverse(int[] numbers)
        {
            int[] reversedNums = new int[] { numbers[2], numbers[1], numbers[0] };
            return reversedNums;
        }
        
        public int[] HigherWins(int[] numbers)
        {

            int highestNumber = 0;

            if (numbers[0] > numbers[numbers.Length - 1]) highestNumber = numbers[0];
            else highestNumber = numbers[numbers.Length - 1];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = highestNumber;
            }

            return numbers;
        }
        
        public int[] GetMiddle(int[] a, int[] b)
        {
            int[] middles = new int[] { a[1], b[1] };

            return middles;
        }
        
        public bool HasEven(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0) return true;
            }
            return false;
        }
        
        public int[] KeepLast(int[] numbers)
        {
            int[] doubled = new int[numbers.Length * 2];

            doubled[doubled.Length - 1] = numbers[numbers.Length - 1];

            return doubled;
        }
        
        public bool Double23(int[] numbers)
        {
            int countTwos = 0;
            int countThrees = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 2) countTwos += 1;
                else if (numbers[i] == 3) countThrees += 1;
            }

            if (countTwos == 2 || countThrees == 2) return true;
            else return false;
        }
        
        public int[] Fix23(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == 2 && numbers[i + 1] == 3) numbers[i + 1] = 0;
            }
            return numbers;
        }
        
        public bool Unlucky1(int[] numbers)
        {
            int FirstPos = numbers[0];
            int SecondPos = numbers[1];
            int ThirdPos = numbers[2];
            int PenultPos = numbers[numbers.Length - 2];
            int LastPos = numbers[numbers.Length - 1];

            if ((FirstPos == 1 && SecondPos == 3) ||
                (SecondPos == 1 && ThirdPos == 3) ||
                (PenultPos == 1 && LastPos == 3))
            {
                return true;
            }
            else return false;


        }
        
        public int[] Make2(int[] a, int[] b)
        {
            int[] twoSlot = new int[2];

            for (int i = 0; i < twoSlot.Length; i++)
            {
                if (i < a.Length)
                {
                    twoSlot[i] = a[i];
                }
                else twoSlot[i] = b[i - a.Length];
            }
            return twoSlot;
        }

    }
}
