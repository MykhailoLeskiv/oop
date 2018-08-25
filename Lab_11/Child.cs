using System;
using System.Collections.Generic;

namespace Lab_11
{
    class Child
    {
        public int goodAct;
        public int badAct;
        public AbstractFactory factory;
        public Gift _gift;
        public Child(int countGood, int countBad)
        {
            goodAct = countGood;
            badAct = countBad;
        }
        public static implicit operator Child(List<Child> v)
        {
            throw new NotImplementedException();
        }
    }
}
