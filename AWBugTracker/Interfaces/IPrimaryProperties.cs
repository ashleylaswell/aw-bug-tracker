﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWBugTracker.Interfaces
{
    public interface IPrimaryProperties
    {
        int Id { get; set; }
        string Title { get; set; }
    }
}
