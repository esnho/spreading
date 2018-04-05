using UnityEngine;
using System;

namespace Spreading
{

    [Serializable]
    public class Renderable
    {
        private MeshRenderer _renderer;
        public MeshRenderer renderer
        {
            get { return _renderer; }
        }
        private MeshFilter _meshFilter;
        private GameObject _gameObject;
        public GameObject gameObject
        {
            get { return _gameObject; }
        }
        public string name
        {
            get { return _gameObject.name; }
            set { _gameObject.name = value; }
        }
        public Transform transform
        {
            get { return _gameObject.transform; }
        }
        public Mesh mesh
        {
            get { return _meshFilter.mesh; }
            set { _meshFilter.mesh = value; }
        }
        public Material material
        {
            get { return _renderer.material; }
            set { _renderer.material = value; }
        }

        public Renderable(Mesh mesh, Material mat, Transform parent = null)
        {
            _gameObject = new GameObject();
            _gameObject.transform.parent = parent;
            _meshFilter = _gameObject.AddComponent<MeshFilter>();
            _meshFilter.mesh = mesh;
            _renderer = _gameObject.AddComponent<MeshRenderer>();
            _renderer.material = mat;
        }

        public Renderable DeepCopy()
        {
            Renderable tmp = new Renderable(mesh, material, transform.parent);
            return tmp;
        }
    }
}
