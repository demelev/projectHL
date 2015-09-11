namespace TreeEditor
{
    using System;
    using UnityEditor;
    using UnityEngine;

    [Serializable]
    public class TreeSpline
    {
        public SplineNode[] nodes;
        public float tension;

        public TreeSpline()
        {
            this.nodes = new SplineNode[0];
            this.tension = 0.5f;
        }

        public TreeSpline(TreeSpline o)
        {
            this.nodes = new SplineNode[0];
            this.tension = 0.5f;
            this.nodes = new SplineNode[o.nodes.Length];
            for (int i = 0; i < o.nodes.Length; i++)
            {
                this.nodes[i] = new SplineNode(o.nodes[i]);
            }
            this.tension = o.tension;
        }

        public void AddPoint(Vector3 pos, float timeInSeconds)
        {
            SplineNode[] nodeArray = new SplineNode[this.nodes.Length + 1];
            for (int i = 0; i < this.nodes.Length; i++)
            {
                nodeArray[i] = this.nodes[i];
            }
            this.nodes = nodeArray;
            SplineNode node = new SplineNode(pos, timeInSeconds);
            this.nodes[this.nodes.Length - 1] = node;
        }

        public float GetApproximateLength()
        {
            if (this.nodes.Length < 2)
            {
                return 0f;
            }
            float num = 0f;
            for (int i = 1; i < this.nodes.Length; i++)
            {
                Vector3 vector = this.nodes[i - 1].point - this.nodes[i].point;
                float magnitude = vector.magnitude;
                num += magnitude;
            }
            return num;
        }

        public int GetNodeCount()
        {
            return this.nodes.Length;
        }

        public SplineNode[] GetNodes()
        {
            return this.nodes;
        }

        public Vector3 GetPositionAtTime(float timeParam)
        {
            if (this.nodes.Length < 2)
            {
                return Vector3.zero;
            }
            if (timeParam <= this.nodes[0].time)
            {
                return this.nodes[0].point;
            }
            if (timeParam >= this.nodes[this.nodes.Length - 1].time)
            {
                return this.nodes[this.nodes.Length - 1].point;
            }
            int index = 1;
            while (index < this.nodes.Length)
            {
                if (this.nodes[index].time > timeParam)
                {
                    break;
                }
                index++;
            }
            int num2 = index - 1;
            float t = (timeParam - this.nodes[num2].time) / (this.nodes[num2 + 1].time - this.nodes[num2].time);
            return this.GetPositionInternal(num2, t);
        }

        private Vector3 GetPositionInternal(int idxFirstpoint, float t)
        {
            float num = t * t;
            float num2 = num * t;
            Vector3 point = this.nodes[Mathf.Max(idxFirstpoint - 1, 0)].point;
            Vector3 vector2 = this.nodes[idxFirstpoint].point;
            Vector3 vector3 = this.nodes[idxFirstpoint + 1].point;
            Vector3 vector4 = this.nodes[Mathf.Min((int) (idxFirstpoint + 2), (int) (this.nodes.Length - 1))].point;
            Vector3 vector5 = (Vector3) (this.tension * (vector3 - point));
            Vector3 vector6 = (Vector3) (this.tension * (vector4 - vector2));
            float num3 = ((2f * num2) - (3f * num)) + 1f;
            float num4 = (-2f * num2) + (3f * num);
            float num5 = (num2 - (2f * num)) + t;
            float num6 = num2 - num;
            return (Vector3) ((((num3 * vector2) + (num4 * vector3)) + (num5 * vector5)) + (num6 * vector6));
        }

        public Quaternion GetRotationAtTime(float timeParam)
        {
            if (this.nodes.Length < 2)
            {
                return Quaternion.identity;
            }
            if (timeParam <= this.nodes[0].time)
            {
                return this.nodes[0].rot;
            }
            if (timeParam >= this.nodes[this.nodes.Length - 1].time)
            {
                return this.nodes[this.nodes.Length - 1].rot;
            }
            int index = 1;
            while (index < this.nodes.Length)
            {
                if (this.nodes[index].time > timeParam)
                {
                    break;
                }
                index++;
            }
            int num2 = index - 1;
            float t = (timeParam - this.nodes[num2].time) / (this.nodes[num2 + 1].time - this.nodes[num2].time);
            return this.GetRotationInternal(num2, t);
        }

        private Quaternion GetRotationInternal(int idxFirstpoint, float t)
        {
            float num = t * t;
            float num2 = num * t;
            Quaternion rot = this.nodes[Mathf.Max(idxFirstpoint - 1, 0)].rot;
            Quaternion quaternion2 = this.nodes[idxFirstpoint].rot;
            Quaternion quaternion3 = this.nodes[idxFirstpoint + 1].rot;
            Quaternion quaternion4 = this.nodes[Mathf.Min((int) (idxFirstpoint + 2), (int) (this.nodes.Length - 1))].rot;
            Quaternion quaternion5 = new Quaternion(this.tension * (quaternion3.x - rot.x), this.tension * (quaternion3.y - rot.y), this.tension * (quaternion3.z - rot.z), this.tension * (quaternion3.w - rot.w));
            Quaternion quaternion6 = new Quaternion(this.tension * (quaternion4.x - quaternion2.x), this.tension * (quaternion4.y - quaternion2.y), this.tension * (quaternion4.z - quaternion2.z), this.tension * (quaternion4.w - quaternion2.w));
            float num3 = ((2f * num2) - (3f * num)) + 1f;
            float num4 = (-2f * num2) + (3f * num);
            float num5 = (num2 - (2f * num)) + t;
            float num6 = num2 - num;
            Quaternion quaternion7 = new Quaternion {
                x = (((num3 * quaternion2.x) + (num4 * quaternion3.x)) + (num5 * quaternion5.x)) + (num6 * quaternion6.x),
                y = (((num3 * quaternion2.y) + (num4 * quaternion3.y)) + (num5 * quaternion5.y)) + (num6 * quaternion6.y),
                z = (((num3 * quaternion2.z) + (num4 * quaternion3.z)) + (num5 * quaternion5.z)) + (num6 * quaternion6.z),
                w = (((num3 * quaternion2.w) + (num4 * quaternion3.w)) + (num5 * quaternion5.w)) + (num6 * quaternion6.w)
            };
            float num7 = Mathf.Sqrt((((quaternion7.x * quaternion7.x) + (quaternion7.y * quaternion7.y)) + (quaternion7.z * quaternion7.z)) + (quaternion7.w * quaternion7.w));
            quaternion7.x /= num7;
            quaternion7.y /= num7;
            quaternion7.z /= num7;
            quaternion7.w /= num7;
            return quaternion7;
        }

        private void OnDisable()
        {
            for (int i = 0; i < this.nodes.Length; i++)
            {
            }
        }

        public void RemoveNode(int c)
        {
            if ((c >= 0) && (c < this.nodes.Length))
            {
                SplineNode[] nodeArray = new SplineNode[this.nodes.Length - 1];
                int index = 0;
                for (int i = 0; i < this.nodes.Length; i++)
                {
                    if (i != c)
                    {
                        nodeArray[index] = this.nodes[i];
                        index++;
                    }
                }
                this.nodes = nodeArray;
            }
        }

        public void Reset()
        {
            for (int i = 0; i < this.nodes.Length; i++)
            {
            }
            this.nodes = new SplineNode[0];
        }

        public void SetNodeCount(int c)
        {
            if (c < this.nodes.Length)
            {
                SplineNode[] nodeArray = new SplineNode[c];
                for (int i = 0; i < c; i++)
                {
                    nodeArray[i] = this.nodes[i];
                }
                for (int j = c; j < this.nodes.Length; j++)
                {
                }
                this.nodes = nodeArray;
            }
        }

        public void UpdateRotations()
        {
            if (this.nodes.Length >= 2)
            {
                Matrix4x4 identity = Matrix4x4.identity;
                this.nodes[0].rot = Quaternion.identity;
                this.nodes[0].tangent = new Vector3(0f, 1f, 0f);
                this.nodes[0].normal = new Vector3(0f, 0f, 1f);
                for (int i = 1; i < this.nodes.Length; i++)
                {
                    Vector3 vector;
                    if (i == (this.nodes.Length - 1))
                    {
                        vector = this.nodes[i].point - this.nodes[i - 1].point;
                    }
                    else
                    {
                        float num2 = Vector3.Distance(this.nodes[i].point, this.nodes[i - 1].point);
                        float num3 = Vector3.Distance(this.nodes[i].point, this.nodes[i + 1].point);
                        vector = (Vector3) (((this.nodes[i].point - this.nodes[i - 1].point) / num2) + ((this.nodes[i + 1].point - this.nodes[i].point) / num3));
                    }
                    vector.Normalize();
                    identity.SetColumn(1, vector);
                    if (Mathf.Abs(Vector3.Dot(vector, (Vector3) identity.GetColumn(0))) > 0.9999f)
                    {
                        identity.SetColumn(0, new Vector3(0f, 1f, 0f));
                    }
                    Vector3 normalized = Vector3.Cross((Vector3) identity.GetColumn(0), vector).normalized;
                    identity.SetColumn(2, normalized);
                    identity = MathUtils.OrthogonalizeMatrix(identity);
                    this.nodes[i].rot = MathUtils.QuaternionFromMatrix(identity);
                    this.nodes[i].normal = (Vector3) identity.GetColumn(2);
                    this.nodes[i].tangent = (Vector3) identity.GetColumn(1);
                    if (Quaternion.Dot(this.nodes[i].rot, this.nodes[i - 1].rot) < 0f)
                    {
                        this.nodes[i].rot.x = -this.nodes[i].rot.x;
                        this.nodes[i].rot.y = -this.nodes[i].rot.y;
                        this.nodes[i].rot.z = -this.nodes[i].rot.z;
                        this.nodes[i].rot.w = -this.nodes[i].rot.w;
                    }
                }
            }
        }

        public void UpdateTime()
        {
            if (this.nodes.Length >= 2)
            {
                float approximateLength = this.GetApproximateLength();
                float num2 = 0f;
                this.nodes[0].time = num2;
                for (int i = 1; i < this.nodes.Length; i++)
                {
                    Vector3 vector = this.nodes[i - 1].point - this.nodes[i].point;
                    float magnitude = vector.magnitude;
                    num2 += magnitude;
                    this.nodes[i].time = num2 / approximateLength;
                }
            }
        }
    }
}

