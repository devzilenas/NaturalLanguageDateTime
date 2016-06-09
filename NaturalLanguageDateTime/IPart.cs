﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace NaturalLanguageDateTime.NLDT
{
    public interface IPart
    {
        bool Takes(IPart part);
        IPart Take(IPart part);
    }
}
