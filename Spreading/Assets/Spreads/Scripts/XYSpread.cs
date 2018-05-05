using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spreading
{
    [Serializable]
    public class XYSpread : Spread
    {
        private Spread xIn;
        private Spread yIn;
        public Spread XinCold { set { xIn = value; } }
        public Spread YinCold { set { yIn = value; } }
        public Spread Xin
        {
            set
            {
                xIn = value;
                Size = xIn.Size * yIn.Size * 2;
                update();
            }
        }
        public Spread Yin
        {
            set
            {
                yIn = value;
                Size = xIn.Size * yIn.Size * 2;
                update();
            }
        }
        
        private Vector2[] vector;
        public Vector2[] Vector { get { return vector; } }

        private void update()
        {
            int totalSize = xIn.Size * yIn.Size;
            vector = new Vector2[totalSize];
            for (int i = 0; i < totalSize; i++)
            {
                int xIndex = i % xIn.Size;
                int yIndex = i % yIn.Size;
                vector[i] = new Vector2(xIn[xIndex], yIn[yIndex]);

                int spreadXIndex = i * 2;
                int spreadYIndex = spreadXIndex + 1;
                _spread[spreadXIndex] = xIn[xIndex];
                _spread[spreadYIndex] = yIn[yIndex];
            }
        }

        public XYSpread() { }
        public XYSpread(Spread x, Spread y)
        {
            Size = x.Size * y.Size * 2;
            xIn = x;
            yIn = y;
            update();
        }
    }
}