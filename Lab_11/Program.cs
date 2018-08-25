using System;
using System.Collections.Generic;

namespace Lab_11
{
    class Program
    {
        static void Main(string[] args)
        {
            StNicholas.getInstance("Mykola");
            Console.WriteLine(StNicholas.getInstance().Name);
            //List<Child> _children;
            //_children = new List<Child>();
            ConcreteAggregate _children = new ConcreteAggregate();
            int choice = 0;
            while (choice != 4)
            {
                Console.Write("\n1. Add child\n2. Create factories\n3. St. Nicholas day XD\n4. Exit\n");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.Write("Enter number of good acts, then of bad:\n");
                            Child _child = new Child(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                            _children.Insert(_child);
                            break;
                        }
                    case 2:
                        {
                            Iterator i = _children.CreateIterator();
                            Child item = i.First();
                            while (item != null)
                            {
                                StNicholas.getInstance().NicholasChoice(item);
                                item = i.Next();
                            }
                            //StNicholas.getInstance().NicholasChoice(_children[0]);
                            break;
                        }
                    case 3:
                        {
                            Iterator i = _children.CreateIterator();
                            Child item = i.First();
                            while (item != null)
                            {
                                Console.Write("Children № " + (i.CurrentItem() + 1) + ": ");
                                StNicholas.getInstance().NicholasSend(item);
                                item = i.Next();
                            }
                            //StNicholas.getInstance().NicholasSend(_children[0]);
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Good bye:)");
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }
    }
}
