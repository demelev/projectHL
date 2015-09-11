namespace TreeEditor
{
    using System;
    using UnityEngine;

    public class FractalNoise
    {
        private float[] m_Exponent;
        private int m_IntOctaves;
        private float m_Lacunarity;
        private Perlin m_Noise;
        private float m_Octaves;

        public FractalNoise(float inH, float inLacunarity, float inOctaves) : this(inH, inLacunarity, inOctaves, null)
        {
        }

        public FractalNoise(float inH, float inLacunarity, float inOctaves, Perlin noise)
        {
            this.m_Lacunarity = inLacunarity;
            this.m_Octaves = inOctaves;
            this.m_IntOctaves = (int) inOctaves;
            this.m_Exponent = new float[this.m_IntOctaves + 1];
            float num = 1f;
            for (int i = 0; i < (this.m_IntOctaves + 1); i++)
            {
                this.m_Exponent[i] = (float) Math.Pow((double) this.m_Lacunarity, (double) -inH);
                num *= this.m_Lacunarity;
            }
            if (noise == null)
            {
                this.m_Noise = new Perlin();
            }
            else
            {
                this.m_Noise = noise;
            }
        }

        public float BrownianMotion(float x, float y)
        {
            float num = 0f;
            long num3 = 0L;
            while (num3 < this.m_IntOctaves)
            {
                num = this.m_Noise.Noise(x, y) * this.m_Exponent[(int) ((IntPtr) num3)];
                x *= this.m_Lacunarity;
                y *= this.m_Lacunarity;
                num3 += 1L;
            }
            float num2 = this.m_Octaves - this.m_IntOctaves;
            return (num + ((num2 * this.m_Noise.Noise(x, y)) * this.m_Exponent[(int) ((IntPtr) num3)]));
        }

        public float HybridMultifractal(float x, float y, float offset)
        {
            float num4 = (this.m_Noise.Noise(x, y) + offset) * this.m_Exponent[0];
            float num = num4;
            x *= this.m_Lacunarity;
            y *= this.m_Lacunarity;
            int index = 1;
            while (index < this.m_IntOctaves)
            {
                if (num > 1f)
                {
                    num = 1f;
                }
                float num2 = (this.m_Noise.Noise(x, y) + offset) * this.m_Exponent[index];
                num4 += num * num2;
                num *= num2;
                x *= this.m_Lacunarity;
                y *= this.m_Lacunarity;
                index++;
            }
            float num3 = this.m_Octaves - this.m_IntOctaves;
            return (num4 + ((num3 * this.m_Noise.Noise(x, y)) * this.m_Exponent[index]));
        }

        public float RidgedMultifractal(float x, float y, float offset, float gain)
        {
            float num2 = Mathf.Abs(this.m_Noise.Noise(x, y));
            num2 = offset - num2;
            num2 *= num2;
            float num3 = num2;
            float num = 1f;
            for (int i = 1; i < this.m_IntOctaves; i++)
            {
                x *= this.m_Lacunarity;
                y *= this.m_Lacunarity;
                num = num2 * gain;
                num = Mathf.Clamp01(num);
                num2 = Mathf.Abs(this.m_Noise.Noise(x, y));
                num2 = offset - num2;
                num2 *= num2;
                num2 *= num;
                num3 += num2 * this.m_Exponent[i];
            }
            return num3;
        }
    }
}

