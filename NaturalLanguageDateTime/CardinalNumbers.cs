using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NaturalLanguageDateTime.NLDT
{
    public class CardinalNumbers// : IPart
    {
        public static string[] m_CardinalNumbers = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten" };
        public static int[] m_Numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        public static int AsNumber(string cardinal)
        {
            int i = Array.FindIndex(m_CardinalNumbers, n => n.Equals(cardinal));
            if (i >= 0 && i < m_Numbers.Length)
            {
                return m_Numbers[i];
            }
            else
            { 
                throw new ArgumentException(String.Format("Don't know how to translate cardinal {0} to a number!", cardinal));
            }
        }

        public static bool IsNumber(string str)
        {
            return Regex.IsMatch(str, "^\\d+$");
        }

        public static bool IsA(string cardinal)
        {
            return m_CardinalNumbers.Contains(cardinal) || IsNumber(cardinal);
        }

        //public bool Takes(IPart part)
        //{
        //    return false; //doesn't take anything :D
        //}

        //public IPart Take(IPart part)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
