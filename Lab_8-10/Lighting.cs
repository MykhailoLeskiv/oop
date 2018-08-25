using System;

namespace Lab_8_10
{
    sealed class Lighting : Sensor, IPrintable
    {
        public Lighting(int index, int height, int indexF, int indexR, int width, int length, int countDoor, int countWindow, int volumePercent)
        {
            (this).width = width;
            (this).length = length;
            (this).countDoor = countDoor;
            (this).countWindow = countWindow;
            (this).volumePercent = volumePercent;
            (this).indexR = indexR;
            (this).indexF = indexF;
            (this).height = height;
        }
        public override string ToString()
        {
                string str = "Lighting sensor:\nNumber: " + "\nRoom: " + indexR + "\nFloor: " + indexF + "Power: " + "\n";
                return str;
        }
    }
}
