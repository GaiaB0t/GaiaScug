using BepInEx;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using SlugBase.Features;
using System;
using UnityEngine;
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
            


        }

        // Load any resources, such as sprites or sounds
        private void LoadResources(RainWorld rainWorld)
        {

        }
        
        
    }
}