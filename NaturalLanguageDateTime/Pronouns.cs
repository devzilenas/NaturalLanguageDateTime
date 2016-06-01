using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaturalLanguageDateTime.NLDT
{
    class Pronouns
    {
        //http://english.stackexchange.com/a/16755/64825
        public static string[] m_Pronouns = new string[] { "ago" /* "... ago" */, "last"/* "last ..." */, "yesterday", "today", "now", "tonight", "this", "tomorrow", "next" /* "next ..." */ };
        public static bool IsA(string pronoun)
        {
            return m_Pronouns.Contains(pronoun); 
        }

        public static DateTime AsDateTime(Pronoun pronoun)
        { 
            switch(pronoun.Value.ToLower())
            {
                case "yesterday":
                    return NLDateTime.Evaluate("1 day before now").AsDTime().DateTime;
                case "tomorrow":
                    return NLDateTime.Evaluate("1 day after now").AsDTime().DateTime;
                case "today":
                case "now":
                case "tonight":
                    return DateTime.Now; 
                default :
                    throw new NotImplementedException(String.Format("Pronoun {0} not implemented.", pronoun.Value));
            };

        }
    }
}
