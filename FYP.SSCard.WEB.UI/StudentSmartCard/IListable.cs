﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSmartCard
{
    public interface IListable
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
