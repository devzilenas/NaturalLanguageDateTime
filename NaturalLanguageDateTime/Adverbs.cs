using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaturalLanguageDateTime.NLDT
{
    class Adverbs : IDetector
    {
        public static string[] m_Adverbs = new string[] { "someday" };
        public static bool IsA(string adverb)
        {
            return m_Adverbs.Contains(adverb, StringComparer.OrdinalIgnoreCase);
        }
    }
}
