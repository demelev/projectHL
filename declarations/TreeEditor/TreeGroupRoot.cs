namespace TreeEditor
{
    using System;
    using UnityEditor;
    using UnityEngine;

    [Serializable]
    public class TreeGroupRoot : TreeGroup
    {
        public float adaptiveLODQuality = 0.8f;
        public float aoDensity = 1f;
        public bool enableAmbientOcclusion = true;
        public bool enableMaterialOptimize = true;
        public bool enableWelding = true;
        public float groundOffset;
        private static string groupSeedString = LocalizationDatabase.GetLocalizedString("Tree Seed|The global seed that affects the entire tree. Use it to randomize your tree, while keeping the general structure of it.");
        public Matrix4x4 rootMatrix = Matrix4x4.identity;
        public float rootSpread = 5f;
        public int shadowTextureQuality = 3;

        public override bool CanHaveSubGroups()
        {
            return true;
        }

        public void SetRootMatrix(Matrix4x4 m)
        {
            this.rootMatrix = m;
            this.rootMatrix.m03 = 0f;
            this.rootMatrix.m13 = 0f;
            this.rootMatrix.m23 = 0f;
            this.rootMatrix = MathUtils.OrthogonalizeMatrix(this.rootMatrix);
            base.nodes[0].matrix = this.rootMatrix;
        }

        public override void UpdateParameters()
        {
            Profiler.BeginSample("UpdateParameters");
            base.nodes[0].size = this.rootSpread;
            base.nodes[0].matrix = this.rootMatrix;
            base.UpdateParameters();
            Profiler.EndSample();
        }

        internal override string DistributionModeString
        {
            get
            {
                return null;
            }
        }

        internal override string EdgeTurbulenceString
        {
            get
            {
                return null;
            }
        }

        internal override string FrequencyString
        {
            get
            {
                return null;
            }
        }

        internal override string GroupSeedString
        {
            get
            {
                return groupSeedString;
            }
        }

        internal override string GrowthAngleString
        {
            get
            {
                return null;
            }
        }

        internal override string GrowthScaleString
        {
            get
            {
                return null;
            }
        }

        internal override string MainTurbulenceString
        {
            get
            {
                return null;
            }
        }

        internal override string MainWindString
        {
            get
            {
                return null;
            }
        }

        internal override string TwirlString
        {
            get
            {
                return null;
            }
        }

        internal override string WhorledStepString
        {
            get
            {
                return null;
            }
        }
    }
}

