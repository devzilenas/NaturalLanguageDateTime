using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaturalLanguageDateTime.NLDT
{
    public class Noun : IPart
    {
        public string Value { get; set; }

        public static Noun From(string noun)
        {
            return new Noun { Value = noun };
        }

        public bool Takes(IPart part)
        { 
            if (part.GetType() == typeof(CardinalNumber))
            {
                return true;
            }

            return false; 
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Noun n = obj as Noun;
            if ((System.Object)n == null)
            {
                return false;
            }

            return String.Equals(Value, n.Value, StringComparison.OrdinalIgnoreCase);
        }


        public IPart Take(IPart part)
        {
            if (part.GetType() == typeof(CardinalNumber))
            {
                CardinalNumber cn = part as CardinalNumber;
                return new TSpan {Multiplicator =  cn.Number, TimeSpan = Nouns.AsTimeSpan(this)};
            }
            else
            {
                throw new ArgumentException("Noun doesn't take " + part.GetType()); 
            } 
        }
    }
}
