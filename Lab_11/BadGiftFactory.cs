using System;

namespace Lab_11
{
    class BadGiftFactory : AbstractFactory
    {
        public BadGiftFactory()
        {
        }
        public override Gift CreateProduct()
        {
            return new Ineatable();
        }
    }
}
