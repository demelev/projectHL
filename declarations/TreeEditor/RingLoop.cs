namespace TreeEditor
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    public class RingLoop
    {
        private Vector4 animParams;
        public float baseOffset;
        private float flareNoise;
        private float flareRadius;
        private Matrix4x4 matrix;
        private float noiseScale;
        private float noiseScaleU = 1f;
        private float noiseScaleV = 1f;
        private static int noiseSeed = -1;
        private static Perlin perlin = new Perlin();
        public float radius;
        private int segments;
        private float spreadBot;
        private float spreadTop;
        private float surfAngleCos;
        private float surfAngleSin;
        private int vertOffset;

        public void BuildVertices(List<TreeVertex> verts)
        {
            this.vertOffset = verts.Count;
            for (int i = 0; i <= this.segments; i++)
            {
                float f = ((i * 3.141593f) * 2f) / ((float) this.segments);
                TreeVertex item = new TreeVertex();
                float radius = this.radius;
                float x = 1f - (((float) i) / ((float) this.segments));
                float baseOffset = this.baseOffset;
                float num6 = x;
                float num7 = baseOffset;
                if (i == this.segments)
                {
                    num6 = 1f;
                }
                float num8 = Mathf.Cos(f);
                float num9 = 0f;
                if (num8 > 0f)
                {
                    num9 = (Mathf.Pow(num8, 3f) * this.radius) * this.spreadBot;
                }
                else
                {
                    num9 = (Mathf.Pow(Mathf.Abs(num8), 3f) * this.radius) * this.spreadTop;
                }
                float num10 = num6 * this.noiseScaleU;
                float y = num7 * this.noiseScaleV;
                radius += this.radius * (perlin.Noise(num10, y) * this.noiseScale);
                num10 = num6 * this.flareNoise;
                radius += this.flareRadius * Mathf.Abs(perlin.Noise(num10, 0.12932f));
                item.pos = this.matrix.MultiplyPoint(new Vector3(Mathf.Sin(f) * (radius + (num9 * 0.25f)), 0f, Mathf.Cos(f) * (radius + num9)));
                item.uv0 = new Vector2(x, baseOffset);
                item.SetAnimationProperties(this.animParams.x, this.animParams.y, this.animParams.z, this.animParams.w);
                verts.Add(item);
            }
            if (this.radius == 0f)
            {
                for (int j = 0; j <= this.segments; j++)
                {
                    TreeVertex vertex2 = verts[j + this.vertOffset];
                    float num13 = ((j * 3.141593f) * 2f) / ((float) this.segments);
                    float num14 = num13 - 1.570796f;
                    Vector3 zero = Vector3.zero;
                    zero.x = Mathf.Sin(num13) * this.surfAngleCos;
                    zero.y = this.surfAngleSin;
                    zero.z = Mathf.Cos(num13) * this.surfAngleCos;
                    vertex2.nor = Vector3.Normalize(this.matrix.MultiplyVector(zero));
                    Vector3 v = Vector3.zero;
                    v.x = Mathf.Sin(num14);
                    v.y = 0f;
                    v.z = Mathf.Cos(num14);
                    v = Vector3.Normalize(this.matrix.MultiplyVector(v));
                    vertex2.tangent = new Vector4(v.x, v.y, v.z, -1f);
                }
            }
            else
            {
                Matrix4x4 inverse = this.matrix.inverse;
                for (int k = 0; k <= this.segments; k++)
                {
                    int num16 = k - 1;
                    if (num16 < 0)
                    {
                        num16 = this.segments - 1;
                    }
                    int num17 = k + 1;
                    if (num17 > this.segments)
                    {
                        num17 = 1;
                    }
                    TreeVertex vertex3 = verts[num16 + this.vertOffset];
                    TreeVertex vertex4 = verts[num17 + this.vertOffset];
                    TreeVertex vertex5 = verts[k + this.vertOffset];
                    Vector3 vector3 = Vector3.Normalize(vertex3.pos - vertex4.pos);
                    Vector3 vector4 = inverse.MultiplyVector(vertex3.pos - vertex4.pos);
                    vector4.y = vector4.x;
                    vector4.x = vector4.z;
                    vector4.z = -vector4.y;
                    vector4.y = 0f;
                    vector4.Normalize();
                    vector4.x = this.surfAngleCos * vector4.x;
                    vector4.y = this.surfAngleSin;
                    vector4.z = this.surfAngleCos * vector4.z;
                    vertex5.nor = Vector3.Normalize(this.matrix.MultiplyVector(vector4));
                    vertex5.tangent.x = vector3.x;
                    vertex5.tangent.y = vector3.y;
                    vertex5.tangent.z = vector3.z;
                    vertex5.tangent.w = -1f;
                }
            }
        }

        public void Cap(float sphereFactor, float noise, int mappingMode, float mappingScale, List<TreeVertex> verts, List<TreeTriangle> tris, int materialIndex)
        {
            TreeVertex vertex;
            int num = Mathf.Max(1, (int) ((this.segments / 2) * Mathf.Clamp01(sphereFactor)));
            int segments = this.segments;
            int num3 = num;
            if (mappingMode == 1)
            {
                segments++;
                num3++;
                mappingScale /= Mathf.Max(1f, sphereFactor);
            }
            int count = verts.Count;
            Vector3 vector = Vector3.Normalize(this.matrix.MultiplyVector(Vector3.up));
            Vector3 vector2 = this.matrix.MultiplyPoint(Vector3.zero);
            vertex = new TreeVertex {
                nor = vector,
                pos = vector2 + ((Vector3) ((vertex.nor * sphereFactor) * this.radius))
            };
            Vector3 vector3 = Vector3.Normalize(this.matrix.MultiplyVector(Vector3.right));
            vertex.tangent = new Vector4(vector3.x, vector3.y, vector3.z, -1f);
            vertex.SetAnimationProperties(this.animParams.x, this.animParams.y, this.animParams.z, this.animParams.w);
            if (mappingMode == 0)
            {
                vertex.uv0 = new Vector2(0.5f, 0.5f);
            }
            else
            {
                vertex.uv0 = new Vector2(0.5f, this.baseOffset + (sphereFactor * mappingScale));
            }
            verts.Add(vertex);
            int num5 = verts.Count;
            Matrix4x4 inverse = this.matrix.inverse;
            for (int i = 0; i < num3; i++)
            {
                float f = ((1f - (((float) i) / ((float) num))) * 3.141593f) * 0.5f;
                float num8 = Mathf.Sin(f);
                float num9 = num8;
                float num10 = (num8 * Mathf.Clamp01(sphereFactor)) + ((num8 * 0.5f) * Mathf.Clamp01(1f - sphereFactor));
                float num11 = Mathf.Cos(f);
                for (int m = 0; m < segments; m++)
                {
                    TreeVertex vertex2 = verts[this.vertOffset + m];
                    Vector3 vector4 = (Vector3) ((inverse.MultiplyPoint(vertex2.pos).normalized * 0.5f) * num8);
                    TreeVertex item = new TreeVertex {
                        pos = (Vector3) (((vertex2.pos * num9) + (vector2 * (1f - num9))) + (((vector * num11) * sphereFactor) * this.radius))
                    };
                    Vector3 vector6 = (Vector3) ((vertex2.nor * num10) + (vector * (1f - num10)));
                    item.nor = vector6.normalized;
                    item.SetAnimationProperties(this.animParams.x, this.animParams.y, this.animParams.z, this.animParams.w);
                    if (mappingMode == 0)
                    {
                        item.tangent = vertex.tangent;
                        item.uv0 = new Vector2(0.5f + vector4.x, 0.5f + vector4.z);
                    }
                    else
                    {
                        item.tangent = vertex2.tangent;
                        item.uv0 = new Vector2(((float) m) / ((float) this.segments), this.baseOffset + ((sphereFactor * num11) * mappingScale));
                    }
                    verts.Add(item);
                }
            }
            float num13 = 3f;
            for (int j = this.vertOffset; j < verts.Count; j++)
            {
                float x = verts[j].pos.x * num13;
                float y = verts[j].pos.z * num13;
                float num17 = this.radius * (perlin.Noise(x, y) * noise);
                TreeVertex local1 = verts[j];
                local1.pos += (Vector3) (vertex.nor * num17);
            }
            for (int k = 0; k < num; k++)
            {
                for (int n = 0; n < segments; n++)
                {
                    if (k == (num3 - 1))
                    {
                        int num20 = (n + num5) + (segments * k);
                        int num21 = num20 + 1;
                        if (n == (segments - 1))
                        {
                            num21 = num5 + (segments * k);
                        }
                        tris.Add(new TreeTriangle(materialIndex, count, num20, num21, false, false, false));
                    }
                    else
                    {
                        int num22 = (n + num5) + (segments * k);
                        int num23 = num22 + 1;
                        int num24 = (n + num5) + (segments * (k + 1));
                        int num25 = num24 + 1;
                        if (n == (segments - 1))
                        {
                            num23 = num5 + (segments * k);
                            num25 = num5 + (segments * (k + 1));
                        }
                        tris.Add(new TreeTriangle(materialIndex, num22, num23, num25, false, false, false));
                        tris.Add(new TreeTriangle(materialIndex, num22, num25, num24, false, false, false));
                    }
                }
            }
        }

        public RingLoop Clone()
        {
            return new RingLoop { radius = this.radius, matrix = this.matrix, segments = this.segments, baseOffset = this.baseOffset, animParams = this.animParams, spreadTop = this.spreadTop, spreadBot = this.spreadBot, noiseScale = this.noiseScale, noiseScaleU = this.noiseScaleU, noiseScaleV = this.noiseScaleV, flareRadius = this.flareRadius, flareNoise = this.flareNoise, surfAngleCos = this.surfAngleCos, surfAngleSin = this.surfAngleSin };
        }

        public void Connect(RingLoop other, List<TreeTriangle> tris, int materialIndex, bool flipTris, bool lowres)
        {
            if (other.segments > this.segments)
            {
                other.Connect(this, tris, materialIndex, true, lowres);
            }
            else if (lowres)
            {
                for (int i = 0; i < (this.segments / 2); i++)
                {
                    int num2 = (0 + i) + other.vertOffset;
                    int num3 = ((other.segments / 2) + i) + other.vertOffset;
                    int num4 = (0 + i) + this.vertOffset;
                    int num5 = ((this.segments / 2) + i) + this.vertOffset;
                    if (flipTris)
                    {
                        int num6 = num2;
                        num2 = num3;
                        num3 = num6;
                        num6 = num4;
                        num4 = num5;
                        num5 = num6;
                    }
                    tris.Add(new TreeTriangle(materialIndex, num2, num3, num4, false, true, false));
                    tris.Add(new TreeTriangle(materialIndex, num3, num5, num4, false, true, false));
                }
            }
            else
            {
                for (int j = 0; j < this.segments; j++)
                {
                    int num8 = Mathf.Min((int) Mathf.Round((((float) j) / ((float) this.segments)) * other.segments), other.segments);
                    int num9 = Mathf.Min((int) Mathf.Round((((float) (j + 1)) / ((float) this.segments)) * other.segments), other.segments);
                    int num10 = Mathf.Min(j + 1, this.segments);
                    int num11 = num8 + other.vertOffset;
                    int num12 = j + this.vertOffset;
                    int num13 = num9 + other.vertOffset;
                    int num14 = j + this.vertOffset;
                    int num15 = num10 + this.vertOffset;
                    int num16 = num9 + other.vertOffset;
                    if (flipTris)
                    {
                        int num17 = num12;
                        num12 = num11;
                        num11 = num17;
                        num17 = num15;
                        num15 = num14;
                        num14 = num17;
                    }
                    tris.Add(new TreeTriangle(materialIndex, num11, num12, num13, false, true, false));
                    tris.Add(new TreeTriangle(materialIndex, num14, num15, num16, false, true, false));
                }
            }
        }

        public void Reset(float r, Matrix4x4 m, float bOffset, int segs)
        {
            this.radius = r;
            this.matrix = m;
            this.baseOffset = bOffset;
            this.segments = segs;
            this.vertOffset = 0;
        }

        public void SetAnimationProperties(float primaryFactor, float secondaryFactor, float edgeFactor, float phase)
        {
            this.animParams = new Vector4(primaryFactor, secondaryFactor, edgeFactor, phase);
        }

        public void SetFlares(float radius, float noise)
        {
            this.flareRadius = radius;
            this.flareNoise = noise;
        }

        public void SetNoise(float scale, float scaleU, float scaleV)
        {
            this.noiseScale = scale;
            this.noiseScaleU = scaleU;
            this.noiseScaleV = scaleV;
        }

        public static void SetNoiseSeed(int seed)
        {
            if (noiseSeed != seed)
            {
                perlin.SetSeed(seed);
            }
        }

        public void SetSpread(float top, float bottom)
        {
            this.spreadTop = top;
            this.spreadBot = bottom;
        }

        public void SetSurfaceAngle(float angleDeg)
        {
            this.surfAngleCos = Mathf.Cos(angleDeg * 0.01745329f);
            this.surfAngleSin = -Mathf.Sin(angleDeg * 0.01745329f);
        }
    }
}

