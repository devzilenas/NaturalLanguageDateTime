using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaturalLanguageDateTime.NLDT
{
    public class Preposition : IPart
    {
        public string Value { get; set; }

        public static Preposition From(string preposition)
        {
            return new Preposition { Value = preposition };
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Preposition p = obj as Preposition;

            if ((System.Object)p == null)
                return false;

            return String.Equals(Value, p.Value, StringComparison.OrdinalIgnoreCase);
        }

        public bool Takes(IPart part)
        {
            throw new NotImplementedException();
        }

        public IPart Take(IPart part)
        {
            throw new NotImplementedException();
        }
    }
}
