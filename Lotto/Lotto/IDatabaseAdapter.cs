﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lotto
{
    public interface IDatabaseAdapter
    {
        Lottoschein LeseAusDB(); 
    }
}
