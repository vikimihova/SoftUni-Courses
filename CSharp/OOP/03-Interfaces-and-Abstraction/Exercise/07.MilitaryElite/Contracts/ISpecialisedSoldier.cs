﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MilitaryElite.Contracts
{
    public interface ISpecialisedSoldier : IPrivate
    {
        string Corps { get; }
    }
}
