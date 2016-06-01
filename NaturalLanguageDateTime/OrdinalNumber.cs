using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaturalLanguageDateTime.NLDT
{
    public class OrdinalNumber : IPart
    {
        public string Value { get; set; }
        public static OrdinalNumber From(string ordinalNumber)
        {
            return new OrdinalNumber { Value = ordinalNumber }; 
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
