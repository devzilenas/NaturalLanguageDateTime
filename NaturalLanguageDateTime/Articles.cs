using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaturalLanguageDateTime
{
    class Articles : IDetector
    {
        public static string[] m_Articles = new string[] { "the", "a", "an", /* "some" some is Adjective in NLDT */ };

        public static bool IsA(string article)
        {
            return m_Articles.Contains(article, StringComparer.OrdinalIgnoreCase);
        }
    }
}
