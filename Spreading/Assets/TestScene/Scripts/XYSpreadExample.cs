using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spreading
{
    //[ExecuteInEditMode]
    public class XYSpreadExample : MonoBehaviour
    {

        public int xCount = 15;
        private int oldXCount = 0;
        public int yCount = 4;
        private int oldYCount = 0;

        public Mesh instanceMesh;
        public Material instanceMaterial;

        public float xCenter = 0f;
        private float oldXCenter = 0f;
        public float xWidth = 1f;
        private float oldXWidth = 1f;

        public float yCenter = 0f;
        private float oldYCenter = 0f;
        public float yWidth = 1f;
        private float oldYWidth = 1f;

        public Vector3[] positions;
        public Renderable[] renderables;

        public LinearSpread xSpread;
        public LinearSpread ySpread;
        public XYSpread xySpread;

        void Start()
        {
            xSpread = new LinearSpread(xCount, xWidth, xCenter);
            ySpread = new LinearSpread(yCount, yWidth, yCenter);
            xySpread = new XYSpread(xSpread, ySpread);

            InitializePositions();
            InitializeRenderables();
        }
        
        void Update()
        {

            if (oldXWidth != xWidth || oldXCenter != xCenter)
            {
                xSpread.Width = xWidth;
                xSpread.Center = xCenter;
                xySpread.Xin = xSpread;
                UpdatePositions();
                SetRenderablesValues();
            }
            if (oldYWidth != yWidth || oldYCenter != yCenter)
            {
                ySpread.Width = yWidth;
                ySpread.Center = yCenter;
                xySpread.Yin = ySpread;
                UpdatePositions();
                SetRenderablesValues();
            }

            if (oldXCount != xCount)
            {
                xSpread.Size = xCount;
                xySpread.Xin = xSpread;
                InitializePositions();
                InitializeRenderables();
                oldXCount = xCount;
            }
            if (oldYCount != yCount)
            {
                ySpread.Size = yCount;
                xySpread.Yin = ySpread;
                InitializePositions();
                InitializeRenderables();
                oldYCount = yCount;
            }


            if (renderables == null || renderables.Length != xySpread.Vector.Length)
            {
                //xSpread.Size = xCount;
                InitializePositions();
                InitializeRenderables();
            }
        }

        void InitializePositions()
        {
            positions = new Vector3[xySpread.Vector.Length];
            UpdatePositions();
        }
        void UpdatePositions()
        {
            for (int i = 0; i < xySpread.Vector.Length; i++)
            {
                positions[i] = xySpread.Vector[i];
            }
            oldXCenter = xCenter;
            oldXWidth = xWidth;
        }

        void InitializeRenderables()
        {
            if (renderables == null)
            {
                renderables = new Renderable[xySpread.Vector.Length];
            }

            if (renderables.Length < xySpread.Vector.Length)
            {
                Renderable[] tmp = new Renderable[xySpread.Vector.Length];
                renderables.CopyTo(tmp, 0);
                renderables = new Renderable[xySpread.Vector.Length];
                renderables = tmp;
            }

            if (renderables.Length > xySpread.Vector.Length)
            {
                Renderable[] tmp = new Renderable[xySpread.Vector.Length];
                for (int i = 0; i < tmp.Length; i++)
                {
                    tmp[i] = renderables[i];
                }
                for (int i = tmp.Length; i < renderables.Length; i++)
                {
                    Destroy(renderables[i].gameObject);
                }
                renderables = new Renderable[xySpread.Vector.Length];
                renderables = tmp;
            }

            SetRenderablesValues();
        }

        private void SetRenderablesValues()
        {
            for (int i = 0; i < xySpread.Vector.Length; i++)
            {
                if (renderables[i] == null)
                {
                    renderables[i] = new Renderable(instanceMesh, instanceMaterial, transform);
                }
                renderables[i].mesh = instanceMesh;
                renderables[i].renderer.material = instanceMaterial;
                renderables[i].transform.position = positions[i];
                renderables[i].name = i.ToString("D3");
            }
        }

    }
}