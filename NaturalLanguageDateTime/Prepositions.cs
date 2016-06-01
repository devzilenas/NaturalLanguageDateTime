using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaturalLanguageDateTime.NLDT
{
    class Prepositions
    {
        public static string[] m_Prepositions = new string[] { "after", "at", "before", "from", "in", "minus", "off", "over", "past", "plus", "since" };//http://grammarpatterns.com/wp-content/uploads/2015/12/2_list-of-prepositions.jpg

        public static bool Is(string str)
        { 
            return m_Prepositions.Contains(str);
        }

        public static string GetOperator(Preposition p)
        { 
            switch(p.Value)
            {
                case "after":
                case "plus":
                case "past":
                case "since":
                    return "+";
                case "before":
                case "minus": 
                    return "-";
                default:
                    throw new ArgumentException(String.Format("Preposition {0} has no operator.", p.Value));
            }
        }
    }
}
