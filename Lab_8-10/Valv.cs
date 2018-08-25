using System;
using System.IO;

namespace Lab_8_10
{
    sealed class Valv : Device, IPrintable
    {
        public Valv(int index, int countValv, int indexF, int indexR)
        {
            //(this).countValv = countValv;
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
            Console.Write($"A valve {indexL} in room {indexR} in floor {indexF} has switched on\n");
            using (StreamWriter sw = fi1.AppendText())
            {
                sw.Write(DateTime.Now);
                sw.WriteLine($" A valve {indexL} in room {indexR} in floor {indexF} has switched on");
            }
        }
        public void switchOFF()
        {
            FileInfo fi1 = new FileInfo("journal.txt");
            _power = false;
            Console.Write($"A valve {indexL} in room {indexR} in floor {indexF} has switched off\n");
            using (StreamWriter sw = fi1.AppendText())
            {
                sw.Write(DateTime.Now);
                sw.WriteLine($" A valve {indexL} in room {indexR} in floor {indexF} has switched off");
            }
        }
        public override string ToString()
        {
                string str = "Valv:\nNumber: " + indexL + "\nRoom: " + indexR + "\nFloor: " + indexF + "Power: " + (_power ? "ON" : "OFF") + "\n";
                return str;
        }
    }
}
