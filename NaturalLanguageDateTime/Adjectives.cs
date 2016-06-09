using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaturalLanguageDateTime.NLDT
{
    class Adjectives : IDetector
    {
        public static string[] m_Adjectives = new string[] { "some", "future", "past" };

        public static bool IsA(string adjective)
        {
            return m_Adjectives.Contains(adjective, StringComparer.OrdinalIgnoreCase);
        }
    }
}
