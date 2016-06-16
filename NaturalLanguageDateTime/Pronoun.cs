using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NaturalLanguageDateTime;

namespace NaturalLanguageDateTime.NLDT
{
    public class Pronoun : IPart, IDTime
    {
        public string Value { get; set; }

        public class Ago : Pronoun
        {
            public Ago()
                : base("ago")
            {
            }

            public override bool Takes(IPart part)
            {
                return part is TSpan;
            }

            public override IPart Take(IPart part)
            {
                if (part is TSpan)
                {
                    TSpan ts = part as TSpan;
                    return new DTime { DateTime = DateTime.Now.AddTicks(-1*/*Using "-1" since ago is in past*/ ts.Multiplicator * ts.TimeSpan.Ticks) };
                }
                else
                {
                    return base.Take(part);
                }
            }
        }

        public Pronoun(string pronoun)
        {
            Value = pronoun;
        }

        public static Pronoun From(string pronoun)
        {
            //TODO add toLower to switches in other classes too
            switch (pronoun.ToLower())
            {
                case "ago":
                    return new Ago();
                default:
                    return new Pronoun(pronoun);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Pronoun p = obj as Pronoun;

            if ((System.Object)p == null)
                return false;

            return String.Equals(Value, p.Value, StringComparison.OrdinalIgnoreCase);
        }

        public DTime AsDTime()
        {
            return new DTime { DateTime = DateTime };
        }

        public virtual bool Takes(IPart part)
        {
            return false;
        }

        public virtual IPart Take(IPart part)
        {
            throw new NotImplementedException();
        }

        public DateTime DateTime
        {
            get
            {
                return Pronouns.AsDateTime(this);
            }
        }
    }
}
