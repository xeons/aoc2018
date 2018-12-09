using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2018.Solutions
{
    public abstract class Solution
    {
        public abstract string Title { get; }
        public abstract int Day { get; }
        public abstract void Run();
    }
}
