namespace TreeEditor
{
    using System;
    using System.Runtime.InteropServices;

    public class Perlin
    {
        private const int B = 0x100;
        private const int BM = 0xff;
        private float[] g1 = new float[0x202];
        private float[,] g2 = new float[0x202, 2];
        private float[,] g3 = new float[0x202, 3];
        private const int N = 0x1000;
        private int[] p = new int[0x202];

        public Perlin()
        {
            this.SetSeed(0);
        }

        private float at2(float rx, float ry, float x, float y)
        {
            return ((rx * x) + (ry * y));
        }

        private float at3(float rx, float ry, float rz, float x, float y, float z)
        {
            return (((rx * x) + (ry * y)) + (rz * z));
        }

        private float lerp(float t, float a, float b)
        {
            return (a + (t * (b - a)));
        }

        public float Noise(float arg)
        {
            int num;
            int num2;
            float num3;
            float num4;
            this.setup(arg, out num, out num2, out num3, out num4);
            float t = this.s_curve(num3);
            float a = num3 * this.g1[this.p[num]];
            float b = num4 * this.g1[this.p[num2]];
            return this.lerp(t, a, b);
        }

        public float Noise(float x, float y)
        {
            int num;
            int num2;
            int num3;
            int num4;
            float num9;
            float num10;
            float num11;
            float num12;
            this.setup(x, out num, out num2, out num9, out num10);
            this.setup(y, out num3, out num4, out num11, out num12);
            int num19 = this.p[num];
            int num20 = this.p[num2];
            int num5 = this.p[num19 + num3];
            int num6 = this.p[num20 + num3];
            int num7 = this.p[num19 + num4];
            int num8 = this.p[num20 + num4];
            float t = this.s_curve(num9);
            float num14 = this.s_curve(num11);
            float a = this.at2(num9, num11, this.g2[num5, 0], this.g2[num5, 1]);
            float b = this.at2(num10, num11, this.g2[num6, 0], this.g2[num6, 1]);
            float num15 = this.lerp(t, a, b);
            a = this.at2(num9, num12, this.g2[num7, 0], this.g2[num7, 1]);
            b = this.at2(num10, num12, this.g2[num8, 0], this.g2[num8, 1]);
            float num16 = this.lerp(t, a, b);
            return this.lerp(num14, num15, num16);
        }

        public float Noise(float x, float y, float z)
        {
            int num;
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            float num11;
            float num12;
            float num13;
            float num14;
            float num15;
            float num16;
            this.setup(x, out num, out num2, out num11, out num12);
            this.setup(y, out num3, out num4, out num13, out num14);
            this.setup(z, out num5, out num6, out num15, out num16);
            int num26 = this.p[num];
            int num27 = this.p[num2];
            int num7 = this.p[num26 + num3];
            int num8 = this.p[num27 + num3];
            int num9 = this.p[num26 + num4];
            int num10 = this.p[num27 + num4];
            float t = this.s_curve(num11);
            float num17 = this.s_curve(num13);
            float num18 = this.s_curve(num15);
            float a = this.at3(num11, num13, num15, this.g3[num7 + num5, 0], this.g3[num7 + num5, 1], this.g3[num7 + num5, 2]);
            float b = this.at3(num12, num13, num15, this.g3[num8 + num5, 0], this.g3[num8 + num5, 1], this.g3[num8 + num5, 2]);
            float num19 = this.lerp(t, a, b);
            a = this.at3(num11, num14, num15, this.g3[num9 + num5, 0], this.g3[num9 + num5, 1], this.g3[num9 + num5, 2]);
            b = this.at3(num12, num14, num15, this.g3[num10 + num5, 0], this.g3[num10 + num5, 1], this.g3[num10 + num5, 2]);
            float num20 = this.lerp(t, a, b);
            float num21 = this.lerp(num17, num19, num20);
            a = this.at3(num11, num13, num16, this.g3[num7 + num6, 0], this.g3[num7 + num6, 2], this.g3[num7 + num6, 2]);
            b = this.at3(num12, num13, num16, this.g3[num8 + num6, 0], this.g3[num8 + num6, 1], this.g3[num8 + num6, 2]);
            num19 = this.lerp(t, a, b);
            a = this.at3(num11, num14, num16, this.g3[num9 + num6, 0], this.g3[num9 + num6, 1], this.g3[num9 + num6, 2]);
            b = this.at3(num12, num14, num16, this.g3[num10 + num6, 0], this.g3[num10 + num6, 1], this.g3[num10 + num6, 2]);
            num20 = this.lerp(t, a, b);
            float num22 = this.lerp(num17, num19, num20);
            return this.lerp(num18, num21, num22);
        }

        private void normalize2(ref float x, ref float y)
        {
            float num = (float) Math.Sqrt((double) ((x * x) + (y * y)));
            x = y / num;
            y /= num;
        }

        private void normalize3(ref float x, ref float y, ref float z)
        {
            float num = (float) Math.Sqrt((double) (((x * x) + (y * y)) + (z * z)));
            x = y / num;
            y /= num;
            z /= num;
        }

        private float s_curve(float t)
        {
            return ((t * t) * (3f - (2f * t)));
        }

        public void SetSeed(int seed)
        {
            int num2;
            Random random = new Random(seed);
            int index = 0;
            while (index < 0x100)
            {
                this.p[index] = index;
                this.g1[index] = ((float) (random.Next(0x200) - 0x100)) / 256f;
                num2 = 0;
                while (num2 < 2)
                {
                    this.g2[index, num2] = ((float) (random.Next(0x200) - 0x100)) / 256f;
                    num2++;
                }
                this.normalize2(ref this.g2[index, 0], ref this.g2[index, 1]);
                num2 = 0;
                while (num2 < 3)
                {
                    this.g3[index, num2] = ((float) (random.Next(0x200) - 0x100)) / 256f;
                    num2++;
                }
                this.normalize3(ref this.g3[index, 0], ref this.g3[index, 1], ref this.g3[index, 2]);
                index++;
            }
            while (--index != 0)
            {
                int num3 = this.p[index];
                this.p[index] = this.p[num2 = random.Next(0x100)];
                this.p[num2] = num3;
            }
            for (index = 0; index < 0x102; index++)
            {
                this.p[0x100 + index] = this.p[index];
                this.g1[0x100 + index] = this.g1[index];
                num2 = 0;
                while (num2 < 2)
                {
                    this.g2[0x100 + index, num2] = this.g2[index, num2];
                    num2++;
                }
                for (num2 = 0; num2 < 3; num2++)
                {
                    this.g3[0x100 + index, num2] = this.g3[index, num2];
                }
            }
        }

        private void setup(float value, out int b0, out int b1, out float r0, out float r1)
        {
            float num = value + 4096f;
            b0 = ((int) num) & 0xff;
            b1 = (b0 + 1) & 0xff;
            r0 = num - ((int) num);
            r1 = r0 - 1f;
        }
    }
}

