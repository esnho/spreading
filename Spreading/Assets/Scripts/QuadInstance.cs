using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spreading
{
    //[ExecuteInEditMode]
    public class QuadInstance : MonoBehaviour
    {

        public int instanceCount = 15;
        public Mesh instanceMesh;
        public Material instanceMaterial;

        public float posCenter = 0f;
        private float oldPosCenter = 0f;
        public float posWidth = 1f;
        private float oldPosWidth = 1f;

        public Vector3[] positions;
        public Renderable[] renderables;

        public LinearSpread xPositionSpread;
        
        void Start()
        {
            xPositionSpread = new LinearSpread(instanceCount, posWidth, posCenter);

            InitializePositions();
            InitializeRenderables();
        }
        
        void Update()
        {

            if (oldPosWidth != posWidth || oldPosCenter != posCenter)
            {
                xPositionSpread.width = posWidth;
                xPositionSpread.center = posCenter;
                UpdatePositions();
                SetRenderablesValues();
            }

            if (renderables == null || renderables.Length != instanceCount)
            {
                xPositionSpread.size = instanceCount;
                InitializePositions();
                InitializeRenderables();
            }
        }

        void InitializePositions()
        {
            positions = new Vector3[instanceCount];
            UpdatePositions();
        }
        void UpdatePositions()
        {
            for (int i = 0; i < instanceCount; i++)
            {
                positions[i].x = xPositionSpread.value[i];
            }
            oldPosCenter = posCenter;
            oldPosWidth = posWidth;
        }

        void InitializeRenderables()
        {
            if (renderables == null)
            {
                renderables = new Renderable[instanceCount];
            }

            if (renderables.Length < instanceCount)
            {
                Renderable[] tmp = new Renderable[instanceCount];
                renderables.CopyTo(tmp, 0);
                renderables = new Renderable[instanceCount];
                renderables = tmp;
            }

            if (renderables.Length > instanceCount)
            {
                Renderable[] tmp = new Renderable[instanceCount];
                for (int i = 0; i < tmp.Length; i++)
                {
                    tmp[i] = renderables[i];
                }
                for (int i = tmp.Length; i < renderables.Length; i++)
                {
                    Destroy(renderables[i].gameObject);
                }
                renderables = new Renderable[instanceCount];
                renderables = tmp;
            }

            SetRenderablesValues();
        }

        private void SetRenderablesValues()
        {
            for (int i = 0; i < instanceCount; i++)
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