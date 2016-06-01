using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//first
//second
//third
//fourth
//fifth
//tenth
//thirteenth

namespace NaturalLanguageDateTime.NLDT
{
    class OrdinalNumbers 
    {
        public static string[] m_OrdinalNumbers = new string[] { "first", "second", "third", "fourth", "fifth", "sixth", "seventh", "eight", "ninenth", "tenth"};
        public static bool IsA(string ordinalNumber)
        {
            return m_OrdinalNumbers.Contains(ordinalNumber);
        }
    }
}
