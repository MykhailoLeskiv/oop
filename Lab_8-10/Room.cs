using System;
using System.Collections.Generic;

namespace Lab_8_10
{
    class Room : Floor, IPrintable
    {
        public Device _device;
        public Sensor _sensor;
        public Room()
        {

        }
        public Room(int height, int indexF, int width, int length, int countDoor, int countWindow, int volumePercent, int index)
        {
            (this).width = width;
            (this).length = length;
            (this).countDoor = countDoor;
            (this).countWindow = countWindow;
            (this).volumePercent = volumePercent;
            (this).indexR = index;
            (this).indexF = indexF;
            (this).height = height;
        }
        public void MakingDevices()
        {
            (this).CountDevicesQuantity();
            (this).CreateDevicesAndSensors();
        }
        protected void CreateDevicesAndSensors()
        {
            _device = new Device(height, indexF, indexR, square, countCamera, tempDevQuantity, countValv, movDevQuantity, lightDevQuantity);
            _sensor = new Sensor(height, indexF, indexR, countCamera, tempDevQuantity, countValv, movDevQuantity, lightDevQuantity);
        }
        protected void CountDevicesQuantity()
        {
            square = width * length;
            tempDevQuantity = (int)(square / 9) + 1;
            movDevQuantity = countDoor;
            countCamera = countDoor + (int)(square / 16);
            lightDevQuantity = countCamera;
            countValv = (int)(square / 4);
        }
        public int indexR { get; set; }
        public int width { get; set; }
        public int length { get; set; }
        public int countDoor { get; set; }
        public int countWindow { get; set; }
        public int volumePercent { get; set; }
        private int square;
        public int Square { get { return square; } }
        private int countCamera;
        public int CountCamera { get { return countCamera; } }
        private int tempDevQuantity;
        public int TempDevQuantity { get { return tempDevQuantity; } }
        private int countValv;
        public int CountValv { get { return countValv; } }
        private int movDevQuantity;
        public int MovDevQuantity { get { return movDevQuantity; } }
        private int lightDevQuantity;
        public int LightDevQuantity { get { return lightDevQuantity; } }
        public static List <Room> operator +(List <Room> arr, Room f2)
        {
            arr.Add(f2);
            return arr;
        }
        public static List<Room> operator -(List<Room> arr, Room f2)
        {
            arr.Remove(f2);
            return arr;
        }
        public override string ToString()
        {
                string str = "Room:\nNumber: " + indexR + "\nFloor: " + indexF + "\nWidth: " + width + "\nLength: " + length + "\nNumber of doors: " + countDoor + "\nNumber of windows: " + countWindow + "\nVolume percent: " + volumePercent + "\nSquare: " + square + "\nNumber of cameras: " + countCamera + "\nNumber of temperature devices: " + tempDevQuantity + "\nNumber of valves: " + countValv + "\nNumber of movement devices: " + movDevQuantity + "\nNumber of light devices: " + lightDevQuantity + "\n";
                return str;
        }
    }
}
