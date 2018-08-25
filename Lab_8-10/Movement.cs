using System;

namespace Lab_8_10
{
    sealed class Movement : Sensor, IPrintable
    {
        public Movement(int index, int indexF, int indexR)
        {
            (this).indexM = index;
            (this).indexR = indexR;
            (this).indexF = indexF;
        }
        public int indexM;
        public bool movement = false;
        public delegate void MoveDelegate(int indexF, int indexR, int indexM);
        public event MoveDelegate EventMovement;
        public void Move()
        {
            EventMovement(indexF, indexR, indexM);
            movement = true;
        }
        public override string ToString()
        {
                string str = "Movement sensor:\nNumber: " + indexM + "\nRoom: " + indexR + "\nFloor: " + indexF + "Movement: " + (movement ? "YES" : "NO") + "\n";
                return str;
        }
    }
}
