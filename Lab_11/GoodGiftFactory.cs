using System;

namespace Lab_11
{
    class GoodGiftFactory : AbstractFactory
    {
        public GoodGiftFactory()
        {
        }

        public override Gift CreateProduct()
        {
            return new Eatable();
        }
    }
}
