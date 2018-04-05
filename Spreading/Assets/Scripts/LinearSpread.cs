using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spreading
{
    //[CreateAssetMenu(fileName = "spread", menuName = "Spreads/Linear", order = 1)]
    public class LinearSpread : Spread// : ScriptableObject
    {
        //public float[] value { get { return _spread; } }
        [SerializeField]
        private float _width;
        public float Width
        {
            get { return _width; }
            set
            {
                _width = value;
                FillSpread();
            }
        }
        [SerializeField]
        private float _center;
        public float Center
        {
            get { return _center; }
            set
            {
                _center = value;
                FillSpread();
            }
        }

        public LinearSpread(int initialSize, float width, float center = 0)
        {
            _width = width;
            _center = center;
            Size = initialSize;
        }

        public override void FillSpread()
        {
            float start = _center - (_width * 0.5f);
            float end = _center + (_width * 0.5f);
            for (int i = 0; i < Size; i++)
            {
                _spread[i] = Mathf.Lerp(start, end, (float)i / (float)(Size-1));
            }
        }

        /*public static LinearSpread operator +(LinearSpread b, Spread c)
        {
            Spread spread = new Spread(5);
            return (LinearSpread)spread;
        }*/
    }
}