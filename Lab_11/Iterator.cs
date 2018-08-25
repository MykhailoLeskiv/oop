using System;
using System.Collections.Generic;

namespace Lab_11
{
    abstract class Iterator
    {
        public abstract Child First();
        public abstract Child Next();
        public abstract bool IsDone();
        public abstract int CurrentItem();
    }
}
