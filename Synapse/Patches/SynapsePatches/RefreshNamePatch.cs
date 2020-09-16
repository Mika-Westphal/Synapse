﻿using Harmony;

// ReSharper disable All
namespace Synapse.Patches.SynapsePatches
{
    [HarmonyPatch(typeof(ServerConsole), nameof(ServerConsole.ReloadServerName))]
    public static class ServerNamePatch
    {
        public static void Postfix()
        {
            if (!Server.Get.Configs.SynapseConfiguration.NameTracking) return;

            ServerConsole._serverName += $" <color=#00000000><size=1>Synapse {SynapseController.SynapseVersion}</size></color>";
        }
    }
}
