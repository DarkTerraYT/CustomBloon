using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Enums;
using static Extension.CustomBloon;
using Il2CppAssets.Scripts.Models.Rounds;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper;

namespace Extension
{
    internal class CustomRoundSet : ModRoundSet
    {
        int nextRound = FirstAppearance;
        public override string BaseRoundSet => RoundSetType.Default;
        public override int DefinedRounds => LastAppearance + 1;
        public override string Icon => "Icon";
        public override string DisplayName => RoundSetName;

        public override void ModifyRoundModels(RoundModel roundModel, int round)
        {
            if(nextRound <= round)
            {
                nextRound = round;
            }

            if (round == nextRound)
            {
                if (round >= FirstAppearance)
                {
                    if (OnlySpawnCustomBloon)
                    {
                        roundModel.ClearBloonGroups();
                    }
                    roundModel.AddBloonGroup(BloonID<Bloon>(), SpawnsPerRound, StartFrame, EndFrame);
                    AffectedRounds++;
                    if (round >= LastAppearance)
                    {
                        ModHelper.Msg<CustomBloon>("Modified " + AffectedRounds + " Rounds");
                    }
                }
                if (round > FirstAppearance)
                {
                    if (nextRound + RoundDelay > LastAppearance)
                    {
                        nextRound = LastAppearance;
                    }
                    else
                    {
                        nextRound += RoundDelay;
                    }
                }
            }
        }
    }
}
