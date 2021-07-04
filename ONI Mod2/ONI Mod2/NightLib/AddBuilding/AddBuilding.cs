using Database;
using System;
using System.Collections.Generic;
using TUNING;
using HarmonyLib;

namespace NightLib.AddBuilding
{
    internal static class AddBuilding
    {
        internal static void AddBuildingToPlanScreen(
          HashedString category,
          string buildingId,
          string parentId)
        {
            int categoryIndex = NightLib.AddBuilding.AddBuilding.GetCategoryIndex(category, buildingId);
            if (categoryIndex == -1)
                return;
            int? index = new int?();
            if (!parentId.IsNullOrWhiteSpace())
            {
                index = BUILDINGS.PLANORDER[categoryIndex].data is IList<string> data2 ? new int?(data2.IndexOf(parentId)) : new int?();
                if (index.HasValue)
                {
                    int? nullable = index;
                    index = nullable.HasValue ? new int?(nullable.GetValueOrDefault() + 1) : new int?();
                }
            }
            if (!index.HasValue)
                Console.WriteLine("ERROR: building \"" + parentId + "\" not found in category " + (object)category + ". Placing " + buildingId + " at the end of the list");
            NightLib.AddBuilding.AddBuilding.AddBuildingToPlanScreen(category, buildingId, index);
        }

        internal static void AddBuildingToPlanScreen(
          HashedString category,
          string buildingId,
          int? index = null)
        {
            int categoryIndex = NightLib.AddBuilding.AddBuilding.GetCategoryIndex(category, buildingId);
            if (categoryIndex == -1)
                return;
            if (index.HasValue)
            {
                int? nullable1 = index;
                int num = 0;
                if (nullable1.GetValueOrDefault() >= num & nullable1.HasValue)
                {
                    nullable1 = index;
                    int? nullable2 = BUILDINGS.PLANORDER[categoryIndex].data is IList<string> data11 ? new int?(data11.Count) : new int?();
                    if (nullable1.GetValueOrDefault() < nullable2.GetValueOrDefault() & (nullable1.HasValue & nullable2.HasValue))
                    {
                        if (!(BUILDINGS.PLANORDER[categoryIndex].data is IList<string> data12))
                            return;
                        data12.Insert(index.Value, buildingId);
                        return;
                    }
                }
            }
            if (!(BUILDINGS.PLANORDER[categoryIndex].data is IList<string> data13))
                return;
            data13.Add(buildingId);
        }

        internal static void ReplaceBuildingInPlanScreen(
          HashedString category,
          string buildingId,
          string parentId)
        {
            int categoryIndex = NightLib.AddBuilding.AddBuilding.GetCategoryIndex(category, buildingId);
            if (categoryIndex == -1)
                return;
            int? nullable = new int?();
            int? index = BUILDINGS.PLANORDER[categoryIndex].data is IList<string> data1 ? new int?(data1.IndexOf(parentId)) : new int?();
            if (index.HasValue)
            {
                if (BUILDINGS.PLANORDER[categoryIndex].data is IList<string> data6)
                    data6.Remove(parentId);
                if (!(BUILDINGS.PLANORDER[categoryIndex].data is IList<string> data7))
                    return;
                data7.Insert(index.Value, buildingId);
            }
            else
            {
                if (!index.HasValue)
                    Console.WriteLine("ERROR: building \"" + parentId + "\" not found in category " + (object)category + ". Placing " + buildingId + " at the end of the list");
                NightLib.AddBuilding.AddBuilding.AddBuildingToPlanScreen(category, buildingId, index);
            }
        }

        private static int GetCategoryIndex(HashedString category, string buildingId)
        {
            int index = BUILDINGS.PLANORDER.FindIndex((Predicate<PlanScreen.PlanInfo>)(x => x.category == category));
            if (index == -1)
                Console.WriteLine("ERROR: can't add building " + buildingId + " to non-existing category " + (object)category);
            return index;
        }

        internal static void IntoTechTree(string Tech, string BuildingID)
        {
            List<string> stringList = new List<string>((IEnumerable<string>)Techs.TECH_GROUPING[Tech]);
            stringList.Insert(1, BuildingID);
            Techs.TECH_GROUPING[Tech] = stringList.ToArray();
        }

        internal static void ReplaceInTechTree(string Tech, string BuildingID, string old)
        {
            List<string> stringList = new List<string>((IEnumerable<string>)Techs.TECH_GROUPING[Tech]);
            int index = stringList.FindIndex((Predicate<string>)(x => x == old));
            if (index != -1)
            {
                stringList[index] = BuildingID;
                Techs.TECH_GROUPING[Tech] = stringList.ToArray();
            }
            else
                NightLib.AddBuilding.AddBuilding.IntoTechTree(Tech, BuildingID);
        }

        private static int GetTechCategoryIndex(HashedString category, string buildingId)
        {
            int index = BUILDINGS.PLANORDER.FindIndex((Predicate<PlanScreen.PlanInfo>)(x => x.category == category));
            if (index == -1)
                Console.WriteLine("ERROR: can't add building " + buildingId + " to non-existing category " + (object)category);
            return index;
        }

        internal static void AddStrings(string ID, string Name, string Description, string Effect)
        {
            Strings.Add("STRINGS.BUILDINGS.PREFABS." + ID.ToUpperInvariant() + ".NAME", "<link=\"" + ID + "\">" + Name + "</link>");
            Strings.Add("STRINGS.BUILDINGS.PREFABS." + ID.ToUpperInvariant() + ".DESC", Description);
            Strings.Add("STRINGS.BUILDINGS.PREFABS." + ID.ToUpperInvariant() + ".EFFECT", Effect);
        }
    }
}
