using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ZoomCameraSpeedScaling
{
    /// <summary>
    /// Gets the game's default speed of the camera border movement.
    /// </summary>
    [HarmonyPatch(typeof(GameCamera), nameof(GameCamera.Awake))]
    public static class Camera_Awake_Patch
    {
        public static void Prefix(GameCamera __instance)
        {

            //Plugin.Logger.Log("Current speed is AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            if (GameCamera_LateUpdate_Patch.DefaultSpeed == -1)
            {
                GameCamera_LateUpdate_Patch.DefaultSpeed = __instance._moveOutsideBorderSpeed;
            }
        }
    }
}