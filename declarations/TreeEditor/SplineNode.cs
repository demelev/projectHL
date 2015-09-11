namespace TreeEditor
{
    using System;
    using UnityEngine;

    [Serializable]
    public class SplineNode
    {
        public Vector3 normal;
        public Vector3 point;
        public Quaternion rot;
        public Vector3 tangent;
        public float time;

        public SplineNode(SplineNode o)
        {
            this.point = Vector3.zero;
            this.rot = Quaternion.identity;
            this.normal = Vector3.zero;
            this.tangent = Vector3.zero;
            this.point = o.point;
            this.rot = o.rot;
            this.normal = o.normal;
            this.tangent = o.tangent;
            this.time = o.time;
        }

        public SplineNode(Vector3 p, float t)
        {
            this.point = Vector3.zero;
            this.rot = Quaternion.identity;
            this.normal = Vector3.zero;
            this.tangent = Vector3.zero;
            this.point = p;
            this.time = t;
        }
    }
}

