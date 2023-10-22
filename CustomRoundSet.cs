using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Enums;
using static CustomBloon.CustomBloon;
using System.Collections.Generic;
using Il2CppAssets.Scripts.Models.Rounds;
using System.Linq;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models;
using BTD_Mod_Helper;

namespace CustomBloon
{
    internal class CustomRoundSet : ModRoundSet
    {
        public override string BaseRoundSet => RoundSetType.Default;
        public override int DefinedRounds => LastAppearance + 1;
        public override string Icon => "Icon";
        public override string DisplayName => "Custom Bloon";

        public override void ModifyRoundModels(RoundModel roundModel, int round)
        {
            if (round >= FirstAppearance)
            {
                if (OnlySpawnCustomBloon)
                {
                    roundModel.ClearBloonGroups();
                }
                roundModel.AddBloonGroup(BloonID<Bloon>(), SpawnsPerRound);
                ModHelper.Msg<CustomBloon>("Modified Round " + round);
                AffectedRounds++;
                if (round >= LastAppearance)
                {
                    ModHelper.Msg<CustomBloon>("Modified " + AffectedRounds + " Rounds");
                }
            }
        }
    }
}
