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

        public string InsertWord(string container, string word) {
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
            else return str.Substring(0, 2);
        }

        public string LastChars(string a, string b)
        {
            if (a.Length == 0 && b.Length != 0)
            {
                return "@" + b.Substring(b.Length - 1);
            }
            else if (b.Length == 0 && a.Length != 0)
            {
                return a.Substring(0, 1) + "@";
            }
            else if (a.Length == 0 && a.Length == 0)
            {
                return "@" + "@";
            }

            else return a.Substring(0, 1) + b.Substring(b.Length - 1);
        }

        public string ConCat(string a, string b)
        {
            if (a == "" || b == "")
            {
                return a + b;
            }
            else if (a.Substring(a.Length - 1) == b.Substring(0, 1))
            {
                return a + b.Substring(1);
            }
            else return a + b;
        }

        public string SwapLast(string str)
        {
            if (str.Length == 0 || str.Length == 1) return str;
            else
            {
                return str.Substring(0, str.Length - 2) + str.Substring(str.Length - 1) + str.Substring(str.Length - 2, 1);
            }
        }

        public bool FrontAgain(string str)
        {
            if (str.IndexOf(str.Substring(0, 2), 2) == str.Length - 2 || str.Length == 2)
            {
                return true;
            }
            else return false;
        }

        public string MinCat(string a, string b)
        {
            if (a.Length < b.Length)
            {
                int stringLengthDiff = b.Length - a.Length;
                return a + b.Substring(stringLengthDiff);
            }
            else if (a.Length > b.Length)
            {
                int stringLengthDiff = a.Length - b.Length;
                return a.Substring(stringLengthDiff) + b;
            }
            else
                return a + b;
        }

        public string TweakFront(string str)
        {
            if (str.Length == 0) return str;
            else if (str.IndexOf("a") == 0)
            {
                return "a" + str.Substring(2);
            }
            else if (str.IndexOf("b") == 1)
            {
                return str.Substring(1);

            }
            else return str.Substring(2);
        }

        public string StripX(string str)
        {
            if (str.Length == 0) return str;
            else if (str.Length == 1 && str == "x") return "";
            else if (str.Substring(0, 1) == "x" && str.Substring(str.Length - 1) == "x")
            {
                return str.Substring(1, str.Length - 2);
            }
            else if (str.Substring(0, 1) == "x")
            {
                return str.Substring(1);
            }
            else if (str.Substring(str.Length - 1) == "x")
            {
                return str.Substring(0, str.Length - 1);
            }
            else return str;
        }
    }
}
