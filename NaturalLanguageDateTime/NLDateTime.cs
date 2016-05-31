using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageDateTime
{
    public class NLDateTime
    {
        public DateTime DateTime { get; set; }
        public DateTime Date { get { return DateTime.Date; } }

        public override string ToString()
        {
            return DateTime.ToString();
        }
             
        public NLDateTime()
        { 
            DateTime = new DateTime();
        }

        public static NLDateTime ParseString(string str)
        {
            return new NLDateTime().Parse(str);
        }

        public NLDateTime Parse(string str)
        {
            foreach (string word in str.Split('.'))
            { 
                switch (word.ToLower())
                {
                    case "yesterday" :
                        DateTime = DateTime.Now.AddDays(-1);
                        break;
                    case "tomorrow":
                        DateTime = DateTime.Now.AddDays(+1);
                        break;
                    case "today":
                        DateTime = DateTime.Now; 
                        break;
                    case "plus" :
                        throw new NotImplementedException();
                    case "minus" :
                        throw new NotImplementedException();
                    case "next" :
                        throw new NotImplementedException();
                    case "last" :
                        throw new NotImplementedException();
                }
            }
            return this;
        }
    }
}
