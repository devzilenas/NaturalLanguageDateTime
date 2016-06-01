using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NaturalLanguageDateTime;

namespace NaturalLanguageDateTime.NLDT
{
    //Wrapper class for TimeSpan
    public class TSpan : IPart
    {
        public TimeSpan TimeSpan { get; set; }
        public int Multiplicator { get; set; }
 
        public bool Takes(IPart part)
        {
            if (part.GetType() == typeof(Preposition))
            {
                return true;
            }

            if (part.GetType() == typeof(Pronoun))
                return true;

            return false;
        }

        public IPart Take(IPart part)
        {
            if (part.GetType() == typeof(Preposition))
                return Take(part as Preposition);
            if (part.GetType() == typeof(Pronoun))
                return Take(part as Pronoun);
            throw new ArgumentException(String.Format("TSpan doesn't take {0}", part.GetType()));
        }
        
        public IPart Take(Pronoun pronoun)
        {
            return new DTime { DateTime = Pronouns.AsDateTime(pronoun).AddTicks(Multiplicator * TimeSpan.Ticks) };
        }

        public IPart Take(Preposition preposition)
        {
            int op = 0;
            switch (Prepositions.GetOperator(preposition))
            {
                case "+": 
                    op = +1;
                    break;
                case "-":
                    op = -1;
                    break;
                default:
                    throw new ArgumentException(String.Format("TimeSpan doesn't take operator {0}.", Prepositions.GetOperator(preposition)));
            }
            Multiplicator = Multiplicator * op;

            return this;
        }

    }
}
