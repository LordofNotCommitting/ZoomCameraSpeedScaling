using MGSC;
using ModConfigMenu.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ZoomCameraSpeedScaling
{
    // Token: 0x02000006 RID: 6
    public class ModConfigGeneral
    {

        // ====== combined ======
        // default, min, max value respectively
        public static int[] Speed_Scaling_Array = new int[] { 15, 0, 100 };

        public ModConfigGeneral(string ModName, string ConfigPath)
        {
            //note: remove "STRING:" later.
            this.ModName = ModName;
            this.ModData = new ModConfigData(ConfigPath);
            this.ModData.AddConfigHeader("General Settings", "general");
            this.ModData.AddConfigValue("general", "Speed_Scaling", Speed_Scaling_Array[0], Speed_Scaling_Array[1], Speed_Scaling_Array[2], "Zoom Level Scale", "Higher means you move faster the more you are zoomed out");

            this.ModData.AddConfigValue("general", "about_final", "<color=#f51b1b>The game must be restarted after setting then saving this config to take effect.</color>\n");
            this.ModData.RegisterModConfigData(ModName);
        }

        private string ModName;

        public ModConfigData ModData;

    }
}
