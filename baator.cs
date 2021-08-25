using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace baator
{
    [HarmonyPatch(typeof(Db), "Initialize")]
    public class baatorPatch
    {
        public static LocString BAATOR_WORLD_NAME = "Baator";
        public static LocString BAATOR_WORLD_DESCRIPTION = "Welcome to 10 Biomes of Hell. \n\nDuplicants will have to learn to cope with Scorching hot wastelands, Dense pockets of Gas and Liquid and icy Glaciers. Survival will be a challenge in this inhospitable Hell, even the Pips Don't like it!";

        public static LocString BAATOR_MOONLET_NAME = "Baator Moonlet";
        public static LocString BAATOR_MOONLET_DESCRIPTION = "Welcome to the 10 Biomes of Hell. \n\n Do not think that a smaller Asteroid will make Survival any more likely.";

        public static LocString BAATOR_DEBUG_WORLD_NAME = "Baator_Debug";
        public static LocString BAATOR_DEBUG_WORLD_DESCRIPTION = "Baator Debug world DEBUG ONLY";

        public static void Prefix()
        {
            // Add strings used in Baator Mod
            Strings.Add($"STRINGS.WORLDS.BAATOR.NAME", BAATOR_WORLD_NAME);
            Strings.Add($"STRINGS.WORLDS.BAATOR.DESCRIPTION", BAATOR_WORLD_DESCRIPTION);
            Strings.Add($"STRINGS.CLUSTER_NAMES.BAATOR.NAME", BAATOR_WORLD_NAME);
            Strings.Add($"STRINGS.CLUSTER_NAMES.BAATOR.DESCRIPTION", BAATOR_WORLD_DESCRIPTION);

            Strings.Add($"STRINGS.WORLDS.BAATORMOONLET.NAME", BAATOR_MOONLET_NAME);
            Strings.Add($"STRINGS.WORLDS.BAATORMOONLET.DESCRIPTION", BAATOR_MOONLET_DESCRIPTION);
            Strings.Add($"STRINGS.CLUSTER_NAMES.BAATORMOONLET.NAME", BAATOR_MOONLET_NAME);
            Strings.Add($"STRINGS.CLUSTER_NAMES.BAATORMOONLET.DESCRIPTION", BAATOR_MOONLET_DESCRIPTION);

            // Add strings used in Baator Mod
            Strings.Add($"STRINGS.WORLDS.BAATORDEBUG.NAME", BAATOR_DEBUG_WORLD_NAME);
            Strings.Add($"STRINGS.WORLDS.BAATORDEBUG.DESCRIPTION", BAATOR_DEBUG_WORLD_DESCRIPTION);
            Strings.Add($"STRINGS.CLUSTER_NAMES.BAATORDEBUG.NAME", BAATOR_DEBUG_WORLD_NAME);
            Strings.Add($"STRINGS.CLUSTER_NAMES.BAATORDEBUG.DESCRIPTION", BAATOR_DEBUG_WORLD_DESCRIPTION);

            // Generate a translation .pot 
            ModUtil.RegisterForTranslation(typeof(baatorPatch));

            //Doesnt work in Spaced out since the Merge down.
            // Load the sprite from asteroid_baator.dds and set "generation action" to incorporated ressources
            //Sprite baatorSprite = Utilities.Sprites.CreateSpriteDXT5(Assembly.GetExecutingAssembly().GetManifestResourceStream("baator.asteroid_baator.dds"), 350, 350);
            // Assets.Sprites.Add("Asteroid_Baator", baatorSprite);
        }
    }
}