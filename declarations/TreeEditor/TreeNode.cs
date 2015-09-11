namespace TreeEditor
{
    using System;
    using System.Runtime.InteropServices;
    using UnityEngine;

    [Serializable]
    public class TreeNode
    {
        [SerializeField]
        private int _uniqueID = -1;
        public float angle;
        public float animSeed = 0f;
        public float baseAngle;
        public float breakOffset = 1f;
        public float capRange;
        [NonSerialized]
        internal TreeGroup group = null;
        public int groupID = 0;
        public Matrix4x4 matrix = Matrix4x4.identity;
        public float offset;
        [NonSerialized]
        internal TreeNode parent = null;
        public int parentID = 0;
        public float pitch;
        public Quaternion rotation = Quaternion.identity;
        public float scale = 1f;
        public int seed = 0x4d2;
        public float size;
        public TreeSpline spline = null;
        public int triEnd;
        public int triStart;
        public int vertEnd;
        public int vertStart;
        public bool visible = true;

        public Matrix4x4 GetLocalMatrixAtTime(float time)
        {
            Vector3 zero = Vector3.zero;
            Quaternion identity = Quaternion.identity;
            float rad = 0f;
            this.GetPropertiesAtTime(time, out zero, out identity, out rad);
            return Matrix4x4.TRS(zero, identity, Vector3.one);
        }

        public void GetPropertiesAtTime(float time, out Vector3 pos, out Quaternion rot, out float rad)
        {
            if (this.spline == null)
            {
                pos = Vector3.zero;
                rot = Quaternion.identity;
            }
            else
            {
                pos = this.spline.GetPositionAtTime(time);
                rot = this.spline.GetRotationAtTime(time);
            }
            rad = this.group.GetRadiusAtTime(this, time, false);
        }

        public float GetRadiusAtTime(float time)
        {
            return this.group.GetRadiusAtTime(this, time, false);
        }

        public float GetScale()
        {
            float scale = 1f;
            if (this.parent != null)
            {
                scale = this.parent.GetScale();
            }
            return (this.scale * scale);
        }

        public float GetSurfaceAngleAtTime(float time)
        {
            if (this.spline == null)
            {
                return 0f;
            }
            float num = 0f;
            Vector3 positionAtTime = this.spline.GetPositionAtTime(time);
            float num2 = this.group.GetRadiusAtTime(this, time, false);
            if (time < 0.5f)
            {
                Vector3 vector2 = this.spline.GetPositionAtTime(time + 0.01f) - positionAtTime;
                float magnitude = vector2.magnitude;
                float y = this.group.GetRadiusAtTime(this, time + 0.01f, false) - num2;
                num = Mathf.Atan2(y, magnitude);
            }
            else
            {
                Vector3 vector3 = positionAtTime - this.spline.GetPositionAtTime(time - 0.01f);
                float x = vector3.magnitude;
                float num6 = num2 - this.group.GetRadiusAtTime(this, time - 0.01f, false);
                num = Mathf.Atan2(num6, x);
            }
            return (num * 57.29578f);
        }

        public int uniqueID
        {
            get
            {
                return this._uniqueID;
            }
            set
            {
                if (this._uniqueID == -1)
                {
                    this._uniqueID = value;
                }
            }
        }
    }
}

