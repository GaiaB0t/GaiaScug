using BepInEx;
//using SlugBase.Features;
//using MoreSlugcats;

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
            On.PlacedObject.FilterData.RefreshTimelineList += FilterData_RefreshTimelineList_TimelineFix;
            // On.PlacedObject.FilterData.Active += FilterData_Active;
            On.Player.IsCreatureLegalToHoldWithoutStun += Player_IsCreatureLegalToHoldWithoutStun;


        }
        // private bool FilterData_Active(On.PlacedObject.FilterData.orig_Active orig, PlacedObject.FilterData self, RoomSettings roomSettings, SlugcatStats.Timeline timelinePoint)
        // {
        //    Logger.LogDebug($"The current timeline is {timelinePoint}, while the allowed timelines are [{string.Join(",", self.availableOnTimelines)}]. Should the filter in {roomSettings.room.abstractRoom.name} : {self.handlePos} allow this ? {orig(self,roomSettings,timelinePoint)}");
        //
        //    return orig(self,roomSettings,timelinePoint);
        // }
        public const string GaiaID = "Gaia"; 
        public static SlugcatStats.Name GaiaEnumName {get; private set;} // making it somewhat read only but not really
        private bool Player_IsCreatureLegalToHoldWithoutStun(On.Player.orig_IsCreatureLegalToHoldWithoutStun orig, Player self, Creature grabCheck) // is this right?
        {
            if (self.SlugCatClass.value == GaiaID) 
            {
                if (grabCheck is Centipede)
                {
                    return true;
                }
            }

            return orig(self, grabCheck);
        }
        private static void FilterData_RefreshTimelineList_TimelineFix(On.PlacedObject.FilterData.orig_RefreshTimelineList orig, PlacedObject.FilterData self)
        {
            // removing Gaia's enum name off the list...
            if (self.availableToPlayers.Contains(GaiaEnumName)) // (Also, this doesn't need more check, if you're going to fully use the Gourmand's timeline. Let's just remove Gaia if it's there)
            {
                self.availableToPlayers.Remove(GaiaEnumName);
            }
    
            // ...before calling the function itself !
            orig(self);
        }
        
        
        // Load any resources, such as sprites or sounds
        private void LoadResources(RainWorld rainWorld)
        {
            GaiaEnumName = new SlugcatStats.Name(GaiaID, false); // would recommend to initiate it.
        }
        
        
        
        
        
        
        
    }
}