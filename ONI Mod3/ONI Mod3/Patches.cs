namespace BuildableAETN
{
    public class Patches
    {
        public static void OnLoad() => ModUtil.AddBuildingToPlanScreen((HashedString)"Utilities", "MassiveHeatSink");
    }
}
