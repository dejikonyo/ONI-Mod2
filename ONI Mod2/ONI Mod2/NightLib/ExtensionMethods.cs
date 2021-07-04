using UnityEngine;

namespace NightLib
{
    internal static class ExtensionMethods
    {
        internal static int GetConduitObjectLayer(this ConduitType conduitType)
        {
            switch (conduitType)
            {
                case ConduitType.Gas:
                    return 12;
                case ConduitType.Liquid:
                    return 16;
                case ConduitType.Solid:
                    return 20;
                default:
                    return 0;
            }
        }

        internal static int GetPortObjectLayer(this ConduitType conduitType)
        {
            switch (conduitType)
            {
                case ConduitType.Gas:
                    return 15;
                case ConduitType.Liquid:
                    return 19;
                case ConduitType.Solid:
                    return 23;
                default:
                    return 0;
            }
        }

        internal static bool IsConnected(this ConduitType conduitType, int cell) => (UnityEngine.Object)Grid.Objects[cell, conduitType.GetConduitObjectLayer()] != (UnityEngine.Object)null;

        internal static int GetCellWithOffset(this Building building, CellOffset offset) => Grid.OffsetCell(Grid.PosToCell(building.transform.GetPosition()), building.GetRotatedOffset(offset));

        internal static bool IsPreview(this GameObject go)
        {
            string name = go.PrefabID().Name;
            return name.Substring(name.Length - 7) == "Preview";
        }

        internal static void Subscribe(
          this KMonoBehaviour behavior,
          GameHashes hash,
          System.Action<object> handler)
        {
            behavior.Subscribe((int)hash, handler);
        }

        internal static void Trigger(this KMonoBehaviour behavior, int hash, object data = null) => behavior.Trigger(hash, data);
    }
}
