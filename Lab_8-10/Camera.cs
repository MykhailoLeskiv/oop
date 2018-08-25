using System;
using System.IO;

namespace Lab_8_10
{
    sealed class Camera : Device, IPrintable
    {
        public Camera(int index, int countValv, int indexF, int indexR)
        {
            (this).indexC = index;
            (this).indexR = indexR;
            (this).indexF = indexF;
        }
        public int indexC;
        public void TakePhoto()
        {
            FileInfo fi1 = new FileInfo("journal.txt");
            Console.Write($"A photo from camera {indexC} in room {indexR} in floor {indexF} has taken\n");
            using (StreamWriter sw = fi1.AppendText())
            {
                sw.Write(DateTime.Now);
                sw.WriteLine($" A photo from camera {indexC} in room {indexR} in floor {indexF} has taken");
            }
        }
        public override string ToString()
        {
                string str = "Camera:\nNumber: " + indexC + "\nRoom: " + indexR + "\nFloor: " + indexF + "\n";
                return str;
        }
    }
}
