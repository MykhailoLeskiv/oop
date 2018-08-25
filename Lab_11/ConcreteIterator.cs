using System;
using System.Collections.Generic;

namespace Lab_11
{
    class ConcreteIterator : Iterator
    {
        private ConcreteAggregate _aggregate;
        private int _current = 0;
 
        // Constructor
        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            this._aggregate = aggregate;
        }
 
        // Gets first iteration item
        public override Child First()
        {
            return _aggregate[0];
        }
 
        // Gets next iteration item
        public override Child Next()
        {
            Child ret = null;
            if (_current < _aggregate.Count - 1)
            {
                ret = _aggregate[++_current];
            }
            return ret;
        }
 
        // Gets current iteration item
        public override int CurrentItem()
        {
            return _current;
        }
 
        // Gets whether iterations are complete
        public override bool IsDone()
        {
            return _current >= _aggregate.Count;
        }
    }

}
