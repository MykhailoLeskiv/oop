using System;
using System.Collections.Generic;
namespace Lab_11
{
    class StNicholas
    {
        private static StNicholas instance;
        private StNicholas()
        { }
        public string Name { get; private set; }
        protected StNicholas(string name)
        {
            this.Name = name;
        }
        public static StNicholas getInstance(string name)
        {
            if (instance == null)
                instance = new StNicholas(name);
            return instance;
        }
        public static StNicholas getInstance()
        {
            if (instance == null)
                instance = new StNicholas();
            return instance;
        }
        public void NicholasSend(Child child)
        {
            child._gift = child.factory.CreateProduct();
            child._gift.Print();
        }
        public void NicholasChoice(Child child)
        {
            if (child.goodAct >= child.badAct)
            {
                child.factory = new GoodGiftFactory();
            }
            else
            {
                child.factory = new BadGiftFactory();
            }
        }
    }
}
