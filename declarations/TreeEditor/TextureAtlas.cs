namespace TreeEditor
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using UnityEngine;

    public class TextureAtlas
    {
        [CompilerGenerated]
        private static Comparison<TextureNode> <>f__am$cache4;
        public int atlasHeight;
        public int atlasPadding;
        public int atlasWidth;
        public List<TextureNode> nodes = new List<TextureNode>();

        public void AddTexture(string name, Texture2D diffuse, Color diffuseColor, Texture2D normal, Texture2D gloss, Texture2D transtex, Texture2D shadowOffsetTex, float shininess, Vector2 scale, bool tileV, Vector2 uvTiling)
        {
            TextureNode item = new TextureNode {
                name = name,
                diffuseTexture = diffuse,
                diffuseColor = diffuseColor,
                normalTexture = normal,
                glossTexture = gloss,
                translucencyTexture = transtex,
                shadowOffsetTexture = shadowOffsetTex,
                shininess = shininess,
                scale = scale,
                tileV = tileV,
                uvTiling = uvTiling
            };
            if (diffuse != null)
            {
                item.sourceRect.width = diffuse.width;
                item.sourceRect.height = diffuse.height;
            }
            else
            {
                item.sourceRect.width = 64f;
                item.sourceRect.height = 64f;
                item.scale = new Vector2(1f, 1f);
            }
            this.nodes.Add(item);
        }

        public override int GetHashCode()
        {
            int num = 0;
            for (int i = 0; i < this.nodes.Count; i++)
            {
                num ^= this.nodes[i].uvRect.GetHashCode();
            }
            return num;
        }

        public Vector2 GetTexTiling(string name)
        {
            for (int i = 0; i < this.nodes.Count; i++)
            {
                if (this.nodes[i].name == name)
                {
                    return this.nodes[i].uvTiling;
                }
            }
            return new Vector2(1f, 1f);
        }

        public Rect GetUVRect(string name)
        {
            for (int i = 0; i < this.nodes.Count; i++)
            {
                if (this.nodes[i].name == name)
                {
                    return this.nodes[i].uvRect;
                }
            }
            return new Rect(0f, 0f, 0f, 0f);
        }

        public void Pack(ref int targetWidth, int targetHeight, int padding, bool correctPow2)
        {
            if ((padding % 2) != 0)
            {
                Debug.LogWarning("Padding not an even number");
                padding++;
            }
            int num = targetHeight;
            for (int i = 0; i < this.nodes.Count; i++)
            {
                TextureNode node = this.nodes[i];
                node.packedRect.x = 0f;
                node.packedRect.y = 0f;
                node.packedRect.width = Mathf.Round(node.sourceRect.width * node.scale.x);
                node.packedRect.height = Mathf.Min((float) num, Mathf.Round(node.sourceRect.height * node.scale.y));
                if (node.tileV)
                {
                    node.packedRect.height = num;
                }
                if (correctPow2)
                {
                    node.packedRect.width = Mathf.ClosestPowerOfTwo((int) node.packedRect.width);
                    node.packedRect.height = Mathf.ClosestPowerOfTwo((int) node.packedRect.height);
                }
            }
            if (<>f__am$cache4 == null)
            {
                <>f__am$cache4 = (a, b) => a.CompareTo(b);
            }
            this.nodes.Sort(<>f__am$cache4);
            int num3 = 0;
            int num4 = 0;
            for (int j = 0; j < this.nodes.Count; j++)
            {
                TextureNode node2 = this.nodes[j];
                bool flag = false;
                for (int m = 0; m < num3; m++)
                {
                    node2.packedRect.x = m;
                    node2.packedRect.y = 0f;
                    flag = true;
                    for (int n = 0; n <= num4; n++)
                    {
                        flag = true;
                        node2.packedRect.y = n;
                        for (int num8 = 0; num8 < j; num8++)
                        {
                            TextureNode node3 = this.nodes[num8];
                            if (TextureNode.Overlap(node2, node3))
                            {
                                flag = false;
                                if (node3.tileV)
                                {
                                    n = num4;
                                }
                                else
                                {
                                    n = (int) (node3.packedRect.y + node3.packedRect.height);
                                }
                                break;
                            }
                        }
                        if (flag)
                        {
                            break;
                        }
                    }
                    if (flag)
                    {
                        break;
                    }
                }
                if (!flag)
                {
                    node2.packedRect.x = num3;
                    node2.packedRect.y = 0f;
                }
                num3 = Mathf.Max(num3, (int) (node2.packedRect.x + node2.packedRect.width));
                num4 = Mathf.Max(num4, (int) (node2.packedRect.y + node2.packedRect.height));
            }
            int min = Mathf.Max(Mathf.ClosestPowerOfTwo(padding * 2), 0x40);
            int num10 = Mathf.Clamp(Mathf.ClosestPowerOfTwo(num3), min, targetWidth);
            targetWidth = num10;
            this.atlasWidth = targetWidth;
            this.atlasHeight = targetHeight;
            this.atlasPadding = padding;
            float num11 = ((float) targetWidth) / ((float) num3);
            float num12 = ((float) targetHeight) / ((float) num4);
            for (int k = 0; k < this.nodes.Count; k++)
            {
                TextureNode node4 = this.nodes[k];
                node4.packedRect.x *= num11;
                node4.packedRect.y *= num12;
                node4.packedRect.width *= num11;
                node4.packedRect.height *= num12;
                if (node4.tileV)
                {
                    node4.packedRect.y = 0f;
                    node4.packedRect.height = targetHeight;
                    node4.packedRect.x += padding / 2;
                    node4.packedRect.width -= padding;
                }
                else
                {
                    node4.packedRect.x += padding / 2;
                    node4.packedRect.y += padding / 2;
                    node4.packedRect.width -= padding;
                    node4.packedRect.height -= padding;
                }
                if (node4.packedRect.width < 1f)
                {
                    node4.packedRect.width = 1f;
                }
                if (node4.packedRect.height < 1f)
                {
                    node4.packedRect.height = 1f;
                }
                node4.packedRect.x = Mathf.Round(node4.packedRect.x);
                node4.packedRect.y = Mathf.Round(node4.packedRect.y);
                node4.packedRect.width = Mathf.Round(node4.packedRect.width);
                node4.packedRect.height = Mathf.Round(node4.packedRect.height);
                node4.uvRect.x = node4.packedRect.x / ((float) targetWidth);
                node4.uvRect.y = node4.packedRect.y / ((float) targetHeight);
                node4.uvRect.width = node4.packedRect.width / ((float) targetWidth);
                node4.uvRect.height = node4.packedRect.height / ((float) targetHeight);
            }
        }

        public class TextureNode
        {
            public Color diffuseColor;
            public Texture2D diffuseTexture;
            public Texture2D glossTexture;
            public string name;
            public Texture2D normalTexture;
            public Rect packedRect = new Rect(0f, 0f, 0f, 0f);
            public Vector2 scale = new Vector2(1f, 1f);
            public Texture2D shadowOffsetTexture;
            public float shininess;
            public Rect sourceRect = new Rect(0f, 0f, 0f, 0f);
            public bool tileV;
            public Texture2D translucencyTexture;
            public Rect uvRect = new Rect(0f, 0f, 0f, 0f);
            public Vector2 uvTiling;

            public int CompareTo(TextureAtlas.TextureNode b)
            {
                if (this.tileV && b.tileV)
                {
                    return -this.packedRect.width.CompareTo(b.packedRect.width);
                }
                if (this.tileV)
                {
                    return -1;
                }
                if (b.tileV)
                {
                    return 1;
                }
                return -this.packedRect.height.CompareTo(b.packedRect.height);
            }

            public static bool Overlap(TextureAtlas.TextureNode a, TextureAtlas.TextureNode b)
            {
                if (a.tileV || b.tileV)
                {
                    return ((a.packedRect.x <= (b.packedRect.x + b.packedRect.width)) && ((a.packedRect.x + a.packedRect.width) >= b.packedRect.x));
                }
                return ((((a.packedRect.x <= (b.packedRect.x + b.packedRect.width)) && ((a.packedRect.x + a.packedRect.width) >= b.packedRect.x)) && (a.packedRect.y <= (b.packedRect.y + b.packedRect.height))) && ((a.packedRect.y + a.packedRect.height) >= b.packedRect.y));
            }
        }
    }
}

