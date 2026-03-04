using System;
using BepInEx;
using UnityEngine;
using SlugBase.Features;
using static SlugBase.Features.FeatureTypes;

namespace SlugTemplate
{
    [BepInPlugin(MOD_ID, "Gaia Slugcat Real", "0.1.0")]
    [BepInDependency("slime-cubed.slugbase")]
    class Plugin : BaseUnityPlugin
    {
        private const string MOD_ID = "Gaia.GaiaScug";

     //   public static readonly PlayerFeature<float> SuperJump = PlayerFloat("GaiaScug/super_jump");
     //   public static readonly PlayerFeature<bool> ExplodeOnDeath = PlayerBool("GaiaScug/explode_on_death");


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