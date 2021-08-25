// see https://github.com/Pholith/ONI-Mods - used with permission from @Pholith
using HarmonyLib;
using System;
using System.Collections.Generic;
using static ProcGen.Temperature;

namespace baator
{
    public class WorldGenPatches
    {
      
      public class HellHot_patch
        {
            public static Dictionary<Range, string> TemperatureTable = new Dictionary<Range, string>();
            public static Dictionary<string, object> TemperatureReverseTable = new Dictionary<string, object>();
            
            private static void AddHashToTable(Range hash, string id)
            {
                TemperatureTable.Add(hash, id);
                TemperatureReverseTable.Add(id, hash);
            }

            //changed from Onload to Prefix method
            [HarmonyPatch(typeof(Db), "Initialize")]
            public class Db_Initialize_Patch
            {
              public static void Prefix()
              {
                Debug.Log("Baator - Loaded WorldGenPatches / Temperature_patch");
                // Hash to be sure there is no other mod with this id
                Range hashedString1 = (Range)Hash.SDBMLower("HellHot");
                if (!TemperatureTable.ContainsKey(hashedString1))
                {
                  AddHashToTable(hashedString1, "HellHot");
                }

                Range hashedString2 = (Range)Hash.SDBMLower("CaniaCold");
                if (!TemperatureTable.ContainsKey(hashedString2))
                {
                  AddHashToTable(hashedString2, "CaniaCold");
                }

        }
            }

            [HarmonyPatch(typeof(Enum), nameof(Enum.ToString), new Type[] { })]
            public static class Temperatures_ToString_Patch
            {
                public static bool Prefix(ref Enum __instance, ref string __result)
                {
                    if (!(__instance is Range))
                      return true;
                    return !TemperatureTable.TryGetValue((Range)__instance, out __result);
                }
            }

            [HarmonyPatch(typeof(Enum), nameof(Enum.Parse), new Type[] { typeof(Type), typeof(string), typeof(bool) })]
            public static class Temperatures_Parse_Patch
            {
                public static bool Prefix(Type enumType, string value, ref object __result)
                {
                    if (!enumType.Equals(typeof(Range)))
                    {
                        return true;
                    }

                    return !TemperatureReverseTable.TryGetValue(value, out __result);
                }
            }
        }
    }
}