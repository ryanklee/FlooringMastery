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
            throw new NotImplementedException();
        }
        
        public bool HasEven(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public int[] KeepLast(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public bool Double23(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public int[] Fix23(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public bool Unlucky1(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public int[] Make2(int[] a, int[] b)
        {
            throw new NotImplementedException();
        }

    }
}
