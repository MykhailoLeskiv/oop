using System;
using System.IO;

namespace Lab_8_10
{
    sealed class Lamp : Device, IPrintable
    {
        public Lamp(int index, int countCamera, int indexF, int indexR)
        {
            //(this).countCamera = countCamera;
            (this).indexL = index;
            (this).indexR = indexR;
            (this).indexF = indexF;
        }
        public int indexL;
        public bool _power = false;
        public void switchON()
        {
            FileInfo fi1 = new FileInfo("journal.txt");
            _power = true;
            Console.Write($"Light {indexL} in room {indexR} in floor {indexF} has switched on\n");
            using (StreamWriter sw = fi1.AppendText())
            {
                sw.Write(DateTime.Now);
                sw.WriteLine($" Light {indexL} in room {indexR} in floor {indexF} has switched on");
            }
        }
        public void switchOFF()
        {
            FileInfo fi1 = new FileInfo("journal.txt");
            _power = false;
            Console.Write($"Light {indexL} in room {indexR} in floor {indexF} has switched off\n");
            using (StreamWriter sw = fi1.AppendText())
            {
                sw.Write(DateTime.Now);
                sw.WriteLine($" Light {indexL} in room {indexR} in floor {indexF} has switched off");
            }
        }
        public override string ToString()
        {
                string str = "Lamp:\nNumber: " + indexL + "\nRoom: " + indexR + "\nFloor: " + indexF + "Power: " + (_power ? "ON" : "OFF") + "\n";
                return str;
        }
    }
}
