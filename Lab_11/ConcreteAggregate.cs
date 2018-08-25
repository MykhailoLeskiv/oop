using System;
using System.Collections.Generic;

namespace Lab_11
{
    class ConcreteAggregate : Aggregate
    {
        //public ArrayList _items = new ArrayList();
        List<Child> _children = new List<Child>();
        //_children = new List<Child>();
        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        // Gets item count
        public int Count
        {
            get { return _children.Count; }
        }

        //Indexer
        public Child this[int index]
        {
            get { return _children[index]; }
        }
        public void Insert(Child obj)
        {
            _children.Add(obj);
        }
    }
}
