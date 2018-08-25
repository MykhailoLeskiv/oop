using System;
using System.IO;
using System.Collections.Generic;

namespace Lab_8_10
{
    class Building : Pult, IPrintable, ILogable
    {
        public List <Floor> _floor;
        private static int countF;
        public Building()
        {
        }
        static Building()
        {
            Console.WriteLine("The building was created");
        }
        public override bool SignUp
        {
            get
            {
                bool checkPassword = false;
                Console.Write("Enter password: ");
                string password = "";
                while (true)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter) break;
                    Console.Write("*");
                    password += key.KeyChar;
                }
                if (password == "admin")
                {
                    checkPassword = true;
                }
                else Console.Write("\nThe password is incorrect\n");
                return checkPassword;
            }
        }
        internal protected void Inizialize(int count)
        {
            CountF = count;
            _floor = new List <Floor>();
            for (int i = 0; i < count; i++)
            {
                Console.Write("Enter number of rooms, then height of floor number " + (i + 1) + " :(or press 'c' to copy from last one)\n");
                string symbol = Console.ReadLine();
                if ("c" == symbol)
                {
                    Floor temp = new Floor(_floor[i - 1]);
                    _floor.Add(temp);
                }
                else
                {
                    Floor temp = new Floor(Convert.ToInt32(symbol), Convert.ToInt32(Console.ReadLine()), i + 1);
                    _floor.Add(temp);
                }
            }
            for (int i = 0; i < CountF; i++)
            {
                for (int j = 0; j < CountF; j++)
                {
                    (this)._floor[i]._room[j].MakingDevices();
                    for (int k = 0; k < (this)._floor[i]._room[j].TempDevQuantity; k++)
                    {
                        (this)._floor[i]._room[j]._sensor._temperature[k].EventHighTemp += (this).DoHighTemp;
                        (this)._floor[i]._room[j]._sensor._temperature[k].EventVeryHighTemp += (this).DoVeryHighTemp;
                    }
                    for (int k = 0; k < (this)._floor[i]._room[j].MovDevQuantity; k++)
                    {
                        (this)._floor[i]._room[j]._sensor._movement[k].EventMovement += (this).DoMovement;
                    }
                }
            }
        }
        internal protected void Inizialize()
        {
            using (StreamReader sr = new StreamReader("init.txt"))
            {
                int count = Convert.ToInt32(sr.ReadLine());
                CountF = count;
                _floor = new List <Floor>();
                for (int i = 0; i < count; i++)
                {
                    Floor temp = new Floor(Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()), i + 1, sr);
                    _floor.Add(temp);
                }
                for (int i = 0; i < CountF; i++)
                {
                    for (int j = 0; j < CountF; j++)
                    {
                        (this)._floor[i]._room[j].MakingDevices();
                        for (int k = 0; k < (this)._floor[i]._room[j].TempDevQuantity; k++)
                        {
                            (this)._floor[i]._room[j]._sensor._temperature[k].EventHighTemp += (this).DoHighTemp;
                            (this)._floor[i]._room[j]._sensor._temperature[k].EventVeryHighTemp += (this).DoVeryHighTemp;
                        }
                        for (int k = 0; k < (this)._floor[i]._room[j].MovDevQuantity; k++)
                        {
                            (this)._floor[i]._room[j]._sensor._movement[k].EventMovement += (this).DoMovement;
                        }
                    }
                }
            }
        }
        public Building(int count)
        {
            CountF = count;
            _floor = new List <Floor>();
            for (int i = 0; i < count; i++)
            {
                Console.Write("Enter number of rooms, then height of floor number " + (i + 1) + " :(or press 'c' to copy from last one)\n");
                string symbol = Console.ReadLine();
                if ("c" == symbol)
                {
                    Floor temp = new Floor(_floor[i - 1]);
                    _floor.Add(temp);
                }
                else
                {
                    Floor temp = new Floor(Convert.ToInt32(symbol), Convert.ToInt32(Console.ReadLine()), i + 1);
                    _floor.Add(temp);
                }
            }
        }
        FileInfo fi1 = new FileInfo("journal.txt");
        public static int CountF { get => countF; set => countF = value; }
        public void DoHighTemp(int indexF, int indexR, int indexT)
        {
            Console.Write($"High temperature alert!\nFloor: {indexF}\nRoom: {indexR}\nSensor: {indexT}\n");
            LogTo($" High temperature alert! Floor: {indexF} Room: {indexR} Sensor: {indexT}");
            foreach (Lamp i in _floor[indexF - 1]._room[indexR - 1]._device._lamp)
            {
                i.switchON();
            }
            System.Threading.Thread.Sleep(2000);
            foreach (Camera i in _floor[indexF - 1]._room[indexR - 1]._device._camera)
            {
                i.TakePhoto();
            }
            System.Threading.Thread.Sleep(2000);
            foreach (Lamp i in _floor[indexF - 1]._room[indexR - 1]._device._lamp)
            {
                i.switchOFF();
            }
        }
        public void DoVeryHighTemp(int indexF, int indexR, int indexT)
        {
            Console.Write($"FIRE ALERT!!!\nFloor: {indexF}\nRoom: {indexR}\nSensor: {indexT}\n");
            LogTo($" FIRE ALERT!!! Floor: {indexF} Room: {indexR} Sensor: {indexT} ");
            foreach (Lamp i in _floor[indexF - 1]._room[indexR - 1]._device._lamp)
            {
                i.switchOFF();
            }
            foreach (Valv i in _floor[indexF - 1]._room[indexR - 1]._device._valv)
            {
                i.switchON();
            }
            System.Threading.Thread.Sleep(5000);
            foreach (Valv i in _floor[indexF - 1]._room[indexR - 1]._device._valv)
            {
                i.switchOFF();
            }
        }
        public void DoMovement(int indexF, int indexR, int indexM)
        {
            Console.Write($"Movement in exit {indexM} in room {indexR} in floor {indexF} has switched on\n");
            LogTo($" Movement in exit {indexM} in room {indexR} in floor {indexF} has switched on ");
            foreach (Lamp i in _floor[indexF - 1]._room[indexR - 1]._device._lamp)
            {
                i.switchON();
            }
            foreach (Camera i in _floor[indexF - 1]._room[indexR - 1]._device._camera)
            {
                i.TakePhoto();
            }
            System.Threading.Thread.Sleep(2000);
            foreach (Lamp i in _floor[indexF - 1]._room[indexR - 1]._device._lamp)
            {
                i.switchOFF();
            }
        }
        public override string ToString()
        {
                string str = "Building:\nNumber of floors: " + CountF + "\n";
                return str;
        }
        public void LogTo(string str)
        {
            using (StreamWriter sw = fi1.AppendText())
            {
                sw.Write(DateTime.Now);
                sw.WriteLine(str);
            }
        }
    }
}
