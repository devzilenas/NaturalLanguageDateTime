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

        public static Pronoun From(string pronoun)
        {
            return new Pronoun { Value = pronoun };
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

        public bool Takes(IPart part)
        {
            throw new NotImplementedException();
        }

        public IPart Take(IPart part)
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
