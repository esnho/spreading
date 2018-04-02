using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spreading
{
    //[CreateAssetMenu(fileName = "spread", menuName = "Spreads/Linear", order = 1)]
    public class LinearSpread// : ScriptableObject
    {
        private float[] _spread;
        public float[] value { get { return _spread; } }
        [SerializeField]
        private float _width;
        public float width
        {
            get { return _width; }
            set
            {
                _width = value;
                CalculateSpread();
            }
        }
        [SerializeField]
        private float _center;
        public float center
        {
            get { return _center; }
            set
            {
                _center = value;
                CalculateSpread();
            }
        }
        public int size
        {
            get { return _spread.Length; }
            set
            {
                _spread = new float[value];
                CalculateSpread();
            }
        }

        public LinearSpread(int initialSize, float width, float center = 0)
        {
            _width = width;
            _center = center;
            size = initialSize;
        }

        private void CalculateSpread()
        {
            float start = _center - (_width * 0.5f);
            float end = _center + (_width * 0.5f);
            for (int i = 0; i < size; i++)
            {
                _spread[i] = Mathf.Lerp(start, end, (float)i / (float)(size-1));
            }
        }
    }
}