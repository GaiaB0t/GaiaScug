using System;
using BepInEx;
using UnityEngine;
using SlugBase.Features;
using static SlugBase.Features.FeatureTypes;

namespace SlugTemplate
    //none of this does anything right now I think so dont worry about this file 


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
     
        }
        
        // Load any resources, such as sprites or sounds
        private void LoadResources(RainWorld rainWorld)
        {
        }




    }
}