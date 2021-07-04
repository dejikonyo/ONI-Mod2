using Database;
using HarmonyLib;
using System.Collections.Generic;

namespace BuildableAETN
{
    [HarmonyPatch(typeof(Tech), MethodType.Constructor, new System.Type[] { typeof(string), typeof(List<string>), typeof(Techs), typeof(Dictionary<string, float>) })]
    public class Research_Patch
    {
        private static void Postfix(ref Tech __instance, string id)
        {
            if (!(id == "Catalytics"))
                return;
            __instance.unlockedItemIDs.Add("MassiveHeatSink");
        }
    }
}
