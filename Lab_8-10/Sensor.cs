using System;

namespace Lab_8_10
{
    class Sensor : Room, IPrintable
    {
        public Temperature[] _temperature;
        public Movement[] _movement;
        public Lighting[] _lighting;
        public Sensor()
        {
        }
        public Sensor(int height, int indexF, int indexR, int countCamera, int tempDevQuantity, int countValv, int movDevQuantity, int lightDevQuantity)
        {
            //(this).countCamera = countCamera;
            //(this).tempDevQuantity = tempDevQuantity;
            //(this).countValv = countValv;
            //(this).movDevQuantity = movDevQuantity;
            //(this).lightDevQuantity = lightDevQuantity;
            (this).indexR = indexR;
            (this).indexF = indexF;
            (this).height = height;
            _temperature = new Temperature[tempDevQuantity];
            for (int i = 0; i < tempDevQuantity; i++)
            {
                _temperature[i] = new Temperature(20, i + 1, indexF, indexR);
            }
            _movement = new Movement[movDevQuantity];
            for (int i = 0; i < movDevQuantity; i++)
            {
                _movement[i] = new Movement(i + 1, indexF, indexR);
            }
            _lighting = new Lighting[lightDevQuantity];
            for (int i = 0; i < lightDevQuantity; i++)
            {
                _lighting[i] = new Lighting(i + 1, height, indexF, indexR, width, length, countDoor, countWindow, volumePercent);
            }
        }
        public void CreateClasses(int countCamera, int tempDevQuantity, int countValv, int movDevQuantity, int lightDevQuantity)
        {
            _temperature = new Temperature[tempDevQuantity];
            for (int i = 0; i < tempDevQuantity; i++)
            {
                _temperature[i] = new Temperature(20, i + 1, indexF, indexR);
            }
            _movement = new Movement[movDevQuantity];
            for (int i = 0; i < movDevQuantity; i++)
            {
                _movement[i] = new Movement(i + 1, indexF, indexR);
            }
            _lighting = new Lighting[lightDevQuantity];
            for (int i = 0; i < lightDevQuantity; i++)
            {
                _lighting[i] = new Lighting(i + 1, height, indexF, indexR, width, length, countDoor, countWindow, volumePercent);
            }
        }
        public override string ToString()
        {
            string str = "Sensor:\nRoom: " + indexR + "\nNumber of devices: " + (TempDevQuantity + MovDevQuantity + LightDevQuantity) + "\n";
            return str;
        }
    }
}