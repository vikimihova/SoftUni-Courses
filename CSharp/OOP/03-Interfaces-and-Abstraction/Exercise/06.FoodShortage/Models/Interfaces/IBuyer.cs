﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FoodShortage.Models.Interfaces
{
    public interface IBuyer
    {
        string Name { get; init; }
        int Food { get; }

        void BuyFood();
    }
}
