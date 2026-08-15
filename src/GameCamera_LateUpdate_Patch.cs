using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ZoomCameraSpeedScaling;

namespace ZoomCameraSpeedScaling
{

    /// <summary>
    /// Changes the speed of the camera based on the state of the modifier key.
    /// </summary>
    [HarmonyPatch(typeof(GameCamera), nameof(GameCamera.LateUpdate))]
    public static class GameCamera_LateUpdate_Patch
    {
        public static float DefaultSpeed = -1;
        //public static float zoomscalefactor = 0.2f;

        static int Speed_Scaling = Plugin.ConfigGeneral.ModData.GetConfigValue<int>("Speed_Scaling", ModConfigGeneral.Speed_Scaling_Array[0]);
        static float Speed_Scaling_f = (float)(Speed_Scaling / 100.0);

        public static void Prefix(GameCamera __instance)
        {
            //ok zoom level is like, to 11 I assume. 
            float speed_mult = 1f;
            if (__instance._currentZoomIndex < 0)
            {
                speed_mult = 1f;
            }
            else 
            {
                speed_mult = 1f + ((float)__instance._currentZoomIndex * Speed_Scaling_f);
            }
            //Plugin.Logger.Log("Current speed is " + DefaultSpeed * speed_mult);
            //Plugin.Logger.Log("to be exact zoom is " + __instance._currentZoomIndex);
            //Plugin.Logger.Log("to be exact speed is " + speed_mult);
            __instance._moveOutsideBorderSpeed = DefaultSpeed * speed_mult;

        }
    }
}