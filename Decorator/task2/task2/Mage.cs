﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class Mage:Hero
    {
        public override string GetDescription() => "Маг";
        public override int GetPower() => 120;
        public override int GetHealth() => 80;
    }
}
