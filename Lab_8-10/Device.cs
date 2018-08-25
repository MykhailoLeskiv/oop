using System;

namespace Lab_8_10
{
    class Device : Room, IPrintable
    {
        public Camera[] _camera;
        public Valv[] _valv;
        public Lamp[] _lamp;
        public Device()
        {

        }
        public Device(int height, int indexF, int indexR, int square, int countCamera, int tempDevQuantity, int countValv, int movDevQuantity,int lightDevQuantity)
        {
            (this).indexR = indexR;
            (this).indexF = indexF;
            (this).height = height;
            _camera = new Camera[countCamera];
            for (int i = 0; i < countCamera; i++)
            {
                _camera[i] = new Camera(i + 1, countCamera, indexF, indexR);
            }
            _valv = new Valv[countValv];
            for (int i = 0; i < countValv; i++)
            {
                _valv[i] = new Valv(i + 1, countValv, indexF, indexR);
            }
            _lamp = new Lamp[countCamera];
            for (int i = 0; i < countCamera; i++)
            {
                _lamp[i] = new Lamp(i + 1, countCamera, indexF, indexR);
            }
        }
        public void CreateClasses(int countCamera, int tempDevQuantity, int countValv, int movDevQuantity, int lightDevQuantity)
        {
            _camera = new Camera[countCamera];
            for (int i = 0; i < countCamera; i++)
            {
                _camera[i] = new Camera(i + 1, countCamera, indexF, indexR);
            }
            _valv = new Valv[countValv];
            for (int i = 0; i < countValv; i++)
            {
                _valv[i] = new Valv(i + 1, countValv, indexF, indexR);
            }
            _lamp = new Lamp[countCamera];
            for (int i = 0; i < countValv; i++)
            {
                _lamp[i] = new Lamp(i + 1, countCamera, indexF, indexR);
            }
        }
        public override string ToString()
        {
            string str = "Device:\nRoom: " + indexR + "\nNumber of devices: " + (2 * CountCamera + CountValv) + "\n";
            return str;
        }
    }
}
