﻿namespace UnityEngine.EventSystems
{
    using System;
    using System.Collections.Generic;

    internal static class RaycasterManager
    {
        private static readonly List<BaseRaycaster> s_Raycasters = new List<BaseRaycaster>();

        public static void AddRaycaster(BaseRaycaster baseRaycaster)
        {
            if (!s_Raycasters.Contains(baseRaycaster))
            {
                s_Raycasters.Add(baseRaycaster);
            }
        }

        public static List<BaseRaycaster> GetRaycasters()
        {
            return s_Raycasters;
        }

        public static void RemoveRaycasters(BaseRaycaster baseRaycaster)
        {
            if (s_Raycasters.Contains(baseRaycaster))
            {
                s_Raycasters.Remove(baseRaycaster);
            }
        }
    }
}

