namespace TreeEditor
{
    using System;
    using UnityEngine;

    public class TreeAOSphere
    {
        public float area;
        public float density = 1f;
        public bool flag;
        public Vector3 position;
        public float radius;

        public TreeAOSphere(Vector3 pos, float radius, float density)
        {
            this.position = pos;
            this.radius = radius;
            this.area = radius * radius;
            this.density = density;
        }

        public float PointOcclusion(Vector3 pos, Vector3 nor)
        {
            Vector3 rhs = this.position - pos;
            float sqrMagnitude = rhs.sqrMagnitude;
            float num2 = Mathf.Max((float) 0f, (float) (sqrMagnitude - this.area));
            if (sqrMagnitude > Mathf.Epsilon)
            {
                rhs.Normalize();
            }
            return ((1f - (1f / Mathf.Sqrt((this.area / num2) + 1f))) * Mathf.Clamp01(4f * Vector3.Dot(nor, rhs)));
        }
    }
}

