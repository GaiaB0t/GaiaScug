using BepInEx;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using SlugBase.Features;
using System;
using UnityEngine;
using MoreSlugcats;
using RWCustom;
using static SlugBase.Features.FeatureTypes;

namespace Gaia
{

    [BepInPlugin(MOD_ID, "Gaia Slugcat Real", "1.5.1")]
    [BepInDependency("slime-cubed.slugbase")]
    class Plugin : BaseUnityPlugin
    {
        private const string MOD_ID = "Gaia.GaiaScug";


        // Add hooks
        public void OnEnable()
        {
            On.RainWorld.OnModsInit += Extras.WrapInit(LoadResources);

            // Put your custom hooks here!
            On.PlacedObject.FilterData.FromString += FilterData_FromString_TimelineFix;


        }
        public const string GaiaID = "Gaia"; // whatever it's supposed to be
        public static SlugcatStats.Name GaiaEnumName {get; private set;} // making it somewhat read only but not really
        private static void FilterData_FromString_TimelineFix(On.PlacedObject.FilterData.orig_FromString orig, PlacedObject.FilterData self, string s)
        {
            orig(self, s);
    
            if (!self.availableToPlayers.Contains(MoreSlugcatsEnums.SlugcatStatsName.Gourmand) && self.availableToPlayers.Contains(GaiaEnumName))
            {
                self.availableToPlayers.Remove(GaiaEnumName); 
            }
        }
        
        // Load any resources, such as sprites or sounds
        private void LoadResources(RainWorld rainWorld)
        {
            GaiaEnumName = new SlugcatStats.Name(GaiaID, false); // would recommend to initiate it.
        }
        
        
        
        
        
        
        
    }
}