using System;

namespace OpenTK3_StandardTemplate_WinForms.helpers
{
    public class Coords
    {
        public float X;
        public float Y;
        public float Z;

        public Coords(float _x, float _y, float _z)
        {
            X = _x;
            Y = _y;
            Z = _z;
        }

        public void DisplayCoords()
        {
            Console.Write("(" + X + ","+ Y + ","+ Z + ")");
        }
    }
}
