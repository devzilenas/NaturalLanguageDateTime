using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NaturalLanguageDateTime;

namespace NaturalLanguageDateTime.NLDT
{
    //Used to refer to a person or thing that is not known, named or specified.
    class Adjective : IDetector, IPart, IEvaluatable
    {
        public string Value;

        public class Past : Adjective
        {
            public Past() : base("past")
            { 
            }

            public override IPart Evaluate()
            {
                return NLDateTime.Evaluate("some day before now").AsDTime();
            }
        }

        public class Future : Adjective
        {
            public Future() : base("future")
            { 
            }

            override public IPart Evaluate()
            {
                return NLDateTime.Evaluate("some day after now").AsDTime();
            }
        }

        public class Some : Adjective, IRange
        {
            public const int RANGE_START = 3;
            public const int RANGE_END = 9;

            public Some()
                : base("some")
            {
            }

            public int From()
            {
                return RANGE_START;
            }

            public int To()
            {
                return RANGE_END;
            }

            public override IPart Take(IPart part)
            {
                if (part is Noun)
                {
                    Noun noun = part as Noun;
                    return noun.Take(AsCardinalNumber());
                }
                else
                {
                    return base.Take(part);
                }
            }

            public override bool Takes(IPart part)
            {
                if (part is Noun)
                {
                    return true;
                }
                else
                {
                    return base.Takes(part);
                }
            }

            public CardinalNumber AsCardinalNumber()
            {
                return new CardinalNumber(new Random().Next(From(), To())); 
            }

            override public IPart Evaluate()
            {
                return AsCardinalNumber();
            }
        }

        public Adjective()
        {
        }
        public Adjective(string adjective)
        {
            Value = adjective;
        }

        public static Adjective From(string value)
        {
            switch (value)
            {
                case "some":
                    return new Some();
                case "future":
                    return new Future();
                case "past":
                    return new Past();
                default:
                    return new Adjective { Value = value };
            }
        }

        public bool IsA(string adjective)
        {
            return Adjectives.IsA(adjective);
        }

        public virtual bool Takes(IPart part)
        {
            return false;
        }

        public virtual IPart Take(IPart part)
        {
            throw new NotImplementedException();
        }

        public virtual IPart Evaluate()
        {
            if (this is IRange)
            {
                return CardinalNumber.From(new Random().Next());
            }
            else
            {
                throw new InvalidOperationException("Does not know how to evaluate Adjective: " + Value);
            }
        }
    }
}
