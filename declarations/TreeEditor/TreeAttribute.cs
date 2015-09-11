namespace TreeEditor
{
    using System;
    using UnityEngine;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class TreeAttribute : Attribute
    {
        public string uiCurve;
        public float uiCurveMax;
        public float uiCurveMin;
        public string uiGadget;
        public string uiLabel;
        public float uiMax;
        public float uiMin;
        public GUIContent[] uiOptions;
        public string uiRequirement;

        public TreeAttribute(string uiLabel, string uiGadget, string uiOptions)
        {
            char[] separator = new char[] { ',' };
            this.uiLabel = uiLabel;
            this.uiGadget = uiGadget;
            this.uiRequirement = uiOptions;
            string[] strArray = uiOptions.Split(separator);
            this.uiOptions = new GUIContent[strArray.Length];
            for (int i = 0; i < strArray.Length; i++)
            {
                this.uiOptions[i] = new GUIContent(strArray[i]);
            }
        }

        public TreeAttribute(string uiLabel, string uiGadget, float uiMin, float uiMax)
        {
            this.uiLabel = uiLabel;
            this.uiGadget = uiGadget;
            this.uiMin = uiMin;
            this.uiMax = uiMax;
            this.uiCurve = string.Empty;
            this.uiRequirement = string.Empty;
        }

        public TreeAttribute(string uiLabel, string uiGadget, float uiMin, float uiMax, string uiRequirement)
        {
            this.uiLabel = uiLabel;
            this.uiGadget = uiGadget;
            this.uiMin = uiMin;
            this.uiMax = uiMax;
            this.uiCurve = string.Empty;
            this.uiRequirement = uiRequirement;
        }

        public TreeAttribute(string uiLabel, string uiGadget, float uiMin, float uiMax, string uiCurve, float uiCurveMin, float uiCurveMax)
        {
            this.uiLabel = uiLabel;
            this.uiGadget = uiGadget;
            this.uiMin = uiMin;
            this.uiMax = uiMax;
            this.uiCurve = uiCurve;
            this.uiCurveMin = uiCurveMin;
            this.uiCurveMax = uiCurveMax;
            this.uiRequirement = string.Empty;
        }

        public TreeAttribute(string uiLabel, string uiGadget, string uiOptions, string uiCurve, float uiCurveMin, float uiCurveMax, string uiRequirement)
        {
            char[] separator = new char[] { ',' };
            this.uiLabel = uiLabel;
            this.uiGadget = uiGadget;
            this.uiRequirement = uiRequirement;
            this.uiCurve = uiCurve;
            this.uiCurveMin = uiCurveMin;
            this.uiCurveMax = uiCurveMax;
            string[] strArray = uiOptions.Split(separator);
            this.uiOptions = new GUIContent[strArray.Length];
            for (int i = 0; i < strArray.Length; i++)
            {
                this.uiOptions[i] = new GUIContent(strArray[i]);
            }
        }

        public TreeAttribute(string uiLabel, string uiGadget, float uiMin, float uiMax, string uiCurve, float uiCurveMin, float uiCurveMax, string uiRequirement)
        {
            this.uiLabel = uiLabel;
            this.uiGadget = uiGadget;
            this.uiMin = uiMin;
            this.uiMax = uiMax;
            this.uiCurve = uiCurve;
            this.uiCurveMin = uiCurveMin;
            this.uiCurveMax = uiCurveMax;
            this.uiRequirement = uiRequirement;
        }

        public override string ToString()
        {
            object[] objArray1 = new object[] { "uiLabel: ", this.uiLabel, ", uiGadget: ", this.uiGadget, ", uiMin: ", this.uiMin, ", uiMax: ", this.uiMax };
            string str = string.Concat(objArray1);
            if (this.uiCurve != string.Empty)
            {
                str = str + ", uiCurve: " + this.uiCurve;
            }
            return str;
        }
    }
}

