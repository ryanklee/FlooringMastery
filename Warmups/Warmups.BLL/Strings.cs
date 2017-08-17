﻿using System;

namespace Warmups.BLL
{
    public class Strings
    {

        public string SayHi(string name)
        {
            return "Hello " + name + "!";
        }

        public string Abba(string a, string b)
        {
            return a + b + b + a;
        }

        public string MakeTags(string tag, string content)
        {
            return $"<{tag}>{content}</{tag}>";
        }

        public string InsertWord(string container, string word)
        {
            return container.Substring(0, 2) + word + container.Substring(2, 2);
        }

        public string MultipleEndings(string str)
        {
            string multipleEndings = str.Substring((str.Length - 2), 2);
            return multipleEndings + multipleEndings + multipleEndings;
        }

        public string FirstHalf(string str)
        {
            return str.Substring(0, str.Length / 2);
        }

        public string TrimOne(string str)
        {
            return str.Substring(1, str.Length - 2);
        }

        public string LongInMiddle(string a, string b)
        {
            if (a.Length > b.Length)
            {
                return b + a + b;
            }
            else
            {
                return a + b + a;
            }
        }

        public string RotateLeft2(string str)
        {
            return str.Substring(2) + str.Substring(0, 2);
        }

        public string RotateRight2(string str)
        {
            return str.Substring(str.Length - 2, 2) + str.Substring(0, str.Length - 2);
        }

        public string TakeOne(string str, bool fromFront)
        {
            if (fromFront)
            {
                return str.Substring(0, 1);
            }
            else
            {
                return str.Substring(str.Length - 1);
            }
        }

        public string MiddleTwo(string str)
        {
            return str.Substring(str.Length / 2 - 1, 1) + str.Substring(str.Length / 2, 1);

        }

        public bool EndsWithLy(string str)
        {
            if (str.IndexOf("ly") == str.Length - 2 && str.IndexOf("ly") != -1)
            {
                return true;
            }
            else return false;

        }

        public string FrontAndBack(string str, int n)
        {
            return str.Substring(0, n) + str.Substring(str.Length - n);
        }

        public string TakeTwoFromPosition(string str, int n)
        {
            if (n + 2 > str.Length)
            {
                return str.Substring(0, 2);
            }
            else return str.Substring(n, 2);
        }

        public bool HasBad(string str)
        {
            if (str.IndexOf("bad") == 0 || str.IndexOf("bad") == 1)
            {
                return true;
            }
            else return false;
        }

        public string AtFirst(string str)
        {
            if (str.Length == 0)
            {
                return "@@";
            }
            else if (str.Length == 1)
            {
                return str + "@";
            }
            else return str.Substring(0, 5);
        }

        public string LastChars(string a, string b)
        {
            return "German";
        }

        public string ConCat(string a, string b)
        {
            throw new NotImplementedException();
        }

        public string SwapLast(string str)
        {
            throw new NotImplementedException();
        }

        public bool FrontAgain(string str)
        {
            throw new NotImplementedException();
        }

        public string MinCat(string a, string b)
        {
            throw new NotImplementedException();
        }

        public string TweakFront(string str)
        {
            throw new NotImplementedException();
        }

        public string StripX(string str)
        {
            throw new NotImplementedException();
        }
    }
}
