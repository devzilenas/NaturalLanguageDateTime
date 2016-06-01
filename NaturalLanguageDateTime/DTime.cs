using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaturalLanguageDateTime.NLDT
{
    //Wrapper around DateTime
    public class DTime : IPart, IDTime
    {
        public DateTime DateTime { get; set; }

        public bool Takes(IPart part)
        {
            throw new NotImplementedException();
        }

        public IPart Take(IPart part)
        {
            throw new NotImplementedException();
        }

        public DTime AsDTime()
        {
            return this;
        }
    }
}
