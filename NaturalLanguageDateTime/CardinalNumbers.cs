using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaturalLanguageDateTime.NLDT
{
    public class CardinalNumbers : IPart
    {
        public static string[] m_CardinalNumbers = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten" };


        public static bool IsA(string cardinal)
        {
            return m_CardinalNumbers.Contains(cardinal);
        }

        public bool Takes(IPart part)
        {
            return false; //doesn't take anything :D
        }

        public IPart Take(IPart part)
        {
            throw new NotImplementedException();
        }
    }
}
