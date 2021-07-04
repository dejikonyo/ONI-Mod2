using HarmonyLib;

namespace BuildableAETN
{
    [HarmonyPatch(typeof (MassiveHeatSinkConfig), "CreateBuildingDef")]
    internal class MassiveHeatSinkConfigTechMod
    {
        private static void Postfix(MassiveHeatSinkConfig __instance, ref BuildingDef __result)
        {
            __result.ViewMode = OverlayModes.GasConduits.ID;
            __result.MaterialCategory = new string[1]
            {
        "RefinedMetal"
            };
            __result.Mass = new float[1] { 4000f };
        }
    }
}
