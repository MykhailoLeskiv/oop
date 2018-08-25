using System;

namespace Lab_8_10
{
    sealed class Temperature : Sensor, IPrintable
    {
        public Temperature()
        {
            HighTemp();
        }
        public Temperature(int temp, int index, int indexF, int indexR)
        {
            (this).indexR = indexR;
            (this).indexF = indexF;
            (this).indexT = index;
            _temp = temp;
            HighTemp();
        }
        public double _temp = 20;
        public int indexT;
        public void ChangeTemp()
        {
            Console.Write("Enter new temperature: ");
            _temp = Convert.ToDouble(Console.ReadLine());
            HighTemp();
        }
        public delegate void FireDelegate(int indexF, int indexR, int indexT);
        public delegate void FireDelegate2(int indexF, int indexR, int indexT);
        public event FireDelegate EventVeryHighTemp;
        public event FireDelegate2 EventHighTemp;
        public void HighTemp()
        {
            if (_temp > 45)
            {
                EventVeryHighTemp(indexF, indexR, indexT);
            }
            else if (_temp > 30)
            {
                EventHighTemp(indexF, indexR, indexT);
            }
        }
        public override string ToString()
        {
                string str = "Temperature sensor:\nNumber: " + indexT + "\nRoom: " + indexR + "\nFloor: " + indexF + "Temperature: " + _temp + "\n";
                return str;
        }
    }
}
