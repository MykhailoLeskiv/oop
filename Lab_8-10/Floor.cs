using System;
using System.IO;
using System.Collections.Generic;

namespace Lab_8_10
{
    class Floor : Building, IPrintable
    {
        public List <Room> _room;
        public int height;
        public int indexF;
        public int countR;
        public Floor()
        {
        }
        public Floor(Floor clone)
        {
            _room = clone._room;
            height = clone.height;
            indexF = clone.indexF + 1;
            countR = clone.countR;
        }
        public Floor(int count, int height, int index)
        {
            countR = count;
            (this).height = height;
            (this).indexF = index;
            _room = new List <Room>();
            for (int i = 0; i < count; i++)
            {
                Console.Write("Enter data of room " + (i + 1) + "(volumePercent, countWindow, countDoor, length, width)\n");
                Room temp = new Room(height, index, Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), i + 1);
                _room.Add(temp);
            }
        }
        public Floor(int count, int height, int index, StreamReader sr)
        {
            countR = count;
            (this).height = height;
            (this).indexF = index;
            _room = new List<Room>();
            for (int i = 0; i < count; i++)
            {
                Room temp = new Room(height, index, Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()), i + 1);
                _room.Add(temp);
            }
        }
        public override string ToString()
        {
                string str = "Floor:\nNumber: " + indexF + "\nNumber of rooms: " + countR + "\nHeight: " + height + "\n";
                return str;
        }
    }
}
