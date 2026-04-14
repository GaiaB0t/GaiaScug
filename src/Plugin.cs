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
            
            // IL.Player.Grabability += Player_Grabability1;

        }

        // Load any resources, such as sprites or sounds
        private void LoadResources(RainWorld rainWorld)
        {

        }

        // private void Player_Grabability1(ILContext il)
        // {
        //     ILCursor c = new(il);
        //     for (int i = 0; i < 2; i++) c.GotoNext(MoveType.After, x => x.MatchIsinst(nameof(Centipede)));
        //     c.GotoNext(MoveType.After, x => x.MatchCallvirt(typeof(Centipede).GetMethod("get_Small")));
        //     c.Emit(OpCodes.Ldarg_0);
        //     c.EmitDelegate(CentiGrab);
        // }
        // private static bool CentiGrab(bool can, Player self)
        // {
        //     return can || self.SlugCatClass == SlugcatStats.Name.Gaia;  // replace with slugcats name
        // }

        // ^that aint complete and was just a snippet I got from someone else, need help to actually make this work
        // intended to let me grab centipedes even when they are unstunned/moving


    }
}