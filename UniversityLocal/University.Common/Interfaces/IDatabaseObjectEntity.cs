﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Common
{
    public interface IDatabaseObjectEntity
    {
        Guid Id { get; set; }
    }
}
