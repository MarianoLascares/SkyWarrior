﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Ships
{
    public interface ICheckLimits
    {
        void ClampFinalPosition();
    }
}
