namespace TreeEditor
{
    using System;

    public class TreeTriangle
    {
        public bool isBillboard;
        public bool isCutout;
        public int materialIndex;
        public bool tileV;
        public int[] v;

        public TreeTriangle(int material, int v0, int v1, int v2)
        {
            this.isCutout = true;
            this.materialIndex = -1;
            this.v = new int[3];
            this.materialIndex = material;
            this.v[0] = v0;
            this.v[1] = v1;
            this.v[2] = v2;
        }

        public TreeTriangle(int material, int v0, int v1, int v2, bool isBillboard)
        {
            this.isCutout = true;
            this.materialIndex = -1;
            this.v = new int[3];
            this.isBillboard = isBillboard;
            this.materialIndex = material;
            this.v[0] = v0;
            this.v[1] = v1;
            this.v[2] = v2;
        }

        public TreeTriangle(int material, int v0, int v1, int v2, bool isBillboard, bool tileV, bool isCutout)
        {
            this.isCutout = true;
            this.materialIndex = -1;
            this.v = new int[3];
            this.tileV = tileV;
            this.isBillboard = isBillboard;
            this.isCutout = isCutout;
            this.materialIndex = material;
            this.v[0] = v0;
            this.v[1] = v1;
            this.v[2] = v2;
        }

        public void flip()
        {
            int num = this.v[0];
            this.v[0] = this.v[1];
            this.v[1] = num;
        }
    }
}

