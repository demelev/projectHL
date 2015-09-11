﻿namespace UnityEngine
{
    using System;
    using System.Reflection;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct Color
    {
        public float r;
        public float g;
        public float b;
        public float a;
        public Color(float r, float g, float b, float a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public Color(float r, float g, float b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = 1f;
        }

        public override string ToString()
        {
            object[] args = new object[] { this.r, this.g, this.b, this.a };
            return UnityString.Format("RGBA({0:F3}, {1:F3}, {2:F3}, {3:F3})", args);
        }

        public string ToString(string format)
        {
            object[] args = new object[] { this.r.ToString(format), this.g.ToString(format), this.b.ToString(format), this.a.ToString(format) };
            return UnityString.Format("RGBA({0}, {1}, {2}, {3})", args);
        }

        public override unsafe int GetHashCode()
        {
            Vector4 vector = *((Vector4*) this);
            return vector.GetHashCode();
        }

        public override bool Equals(object other)
        {
            if (!(other is Color))
            {
                return false;
            }
            Color color = (Color) other;
            return (((this.r.Equals(color.r) && this.g.Equals(color.g)) && this.b.Equals(color.b)) && this.a.Equals(color.a));
        }

        public static Color Lerp(Color a, Color b, float t)
        {
            t = Mathf.Clamp01(t);
            return new Color(a.r + ((b.r - a.r) * t), a.g + ((b.g - a.g) * t), a.b + ((b.b - a.b) * t), a.a + ((b.a - a.a) * t));
        }

        public static Color LerpUnclamped(Color a, Color b, float t)
        {
            return new Color(a.r + ((b.r - a.r) * t), a.g + ((b.g - a.g) * t), a.b + ((b.b - a.b) * t), a.a + ((b.a - a.a) * t));
        }

        internal Color RGBMultiplied(float multiplier)
        {
            return new Color(this.r * multiplier, this.g * multiplier, this.b * multiplier, this.a);
        }

        internal Color AlphaMultiplied(float multiplier)
        {
            return new Color(this.r, this.g, this.b, this.a * multiplier);
        }

        internal Color RGBMultiplied(Color multiplier)
        {
            return new Color(this.r * multiplier.r, this.g * multiplier.g, this.b * multiplier.b, this.a);
        }

        public static Color red
        {
            get
            {
                return new Color(1f, 0f, 0f, 1f);
            }
        }
        public static Color green
        {
            get
            {
                return new Color(0f, 1f, 0f, 1f);
            }
        }
        public static Color blue
        {
            get
            {
                return new Color(0f, 0f, 1f, 1f);
            }
        }
        public static Color white
        {
            get
            {
                return new Color(1f, 1f, 1f, 1f);
            }
        }
        public static Color black
        {
            get
            {
                return new Color(0f, 0f, 0f, 1f);
            }
        }
        public static Color yellow
        {
            get
            {
                return new Color(1f, 0.9215686f, 0.01568628f, 1f);
            }
        }
        public static Color cyan
        {
            get
            {
                return new Color(0f, 1f, 1f, 1f);
            }
        }
        public static Color magenta
        {
            get
            {
                return new Color(1f, 0f, 1f, 1f);
            }
        }
        public static Color gray
        {
            get
            {
                return new Color(0.5f, 0.5f, 0.5f, 1f);
            }
        }
        public static Color grey
        {
            get
            {
                return new Color(0.5f, 0.5f, 0.5f, 1f);
            }
        }
        public static Color clear
        {
            get
            {
                return new Color(0f, 0f, 0f, 0f);
            }
        }
        public float grayscale
        {
            get
            {
                return (((0.299f * this.r) + (0.587f * this.g)) + (0.114f * this.b));
            }
        }
        public Color linear
        {
            get
            {
                return new Color(Mathf.GammaToLinearSpace(this.r), Mathf.GammaToLinearSpace(this.g), Mathf.GammaToLinearSpace(this.b), this.a);
            }
        }
        public Color gamma
        {
            get
            {
                return new Color(Mathf.LinearToGammaSpace(this.r), Mathf.LinearToGammaSpace(this.g), Mathf.LinearToGammaSpace(this.b), this.a);
            }
        }
        public float maxColorComponent
        {
            get
            {
                return Mathf.Max(Mathf.Max(this.r, this.g), this.b);
            }
        }
        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return this.r;

                    case 1:
                        return this.g;

                    case 2:
                        return this.b;

                    case 3:
                        return this.a;
                }
                throw new IndexOutOfRangeException("Invalid Vector3 index!");
            }
            set
            {
                switch (index)
                {
                    case 0:
                        this.r = value;
                        break;

                    case 1:
                        this.g = value;
                        break;

                    case 2:
                        this.b = value;
                        break;

                    case 3:
                        this.a = value;
                        break;

                    default:
                        throw new IndexOutOfRangeException("Invalid Vector3 index!");
                }
            }
        }
        public static Color operator +(Color a, Color b)
        {
            return new Color(a.r + b.r, a.g + b.g, a.b + b.b, a.a + b.a);
        }

        public static Color operator -(Color a, Color b)
        {
            return new Color(a.r - b.r, a.g - b.g, a.b - b.b, a.a - b.a);
        }

        public static Color operator *(Color a, Color b)
        {
            return new Color(a.r * b.r, a.g * b.g, a.b * b.b, a.a * b.a);
        }

        public static Color operator *(Color a, float b)
        {
            return new Color(a.r * b, a.g * b, a.b * b, a.a * b);
        }

        public static Color operator *(float b, Color a)
        {
            return new Color(a.r * b, a.g * b, a.b * b, a.a * b);
        }

        public static Color operator /(Color a, float b)
        {
            return new Color(a.r / b, a.g / b, a.b / b, a.a / b);
        }

        public static bool operator ==(Color lhs, Color rhs)
        {
            return (lhs == rhs);
        }

        public static bool operator !=(Color lhs, Color rhs)
        {
            return !(lhs == rhs);
        }

        public static implicit operator Vector4(Color c)
        {
            return new Vector4(c.r, c.g, c.b, c.a);
        }

        public static implicit operator Color(Vector4 v)
        {
            return new Color(v.x, v.y, v.z, v.w);
        }
    }
}

