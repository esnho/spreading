using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spreading
{
    public class Spread
    {

        internal float[] _spread;
        public float this[int index]
        {
            get { return _spread[index]; }
            set { _spread[index] = value; }
        }

        public int Size
        {
            get { return _spread.Length; }
            set
            {
                _spread = new float[value];
                FillSpread();
            }
        }

        public Spread() { }

        public Spread(int initialSize)
        {
            Size = initialSize;
        }

        public Spread(int initialSize, float initialValue)
        {
            Size = initialSize;
            for (int i = 0; i < Size; i++)
            {
                _spread[i] = initialValue;
            }
        }

        public virtual void FillSpread(){}

        public static Spread operator +(Spread a, Spread b)
        {
            int newSpreadSize = Math.Max(a.Size, b.Size);
            Spread spread;
            if (a.Size == newSpreadSize)
            {
                spread = Sum(a, b);
            } else
            {
                spread = Sum(b, a);
            }

            return spread;
        }

        private static Spread Sum(Spread a, Spread b)
        {
            Spread spread = new Spread(a.Size);
            for(int i = 0; i < spread.Size; i++)
            {
                spread[i] = a[i] + b[i % b.Size];
            }
            return spread;
        }
    }
}