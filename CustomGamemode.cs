using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Scenarios;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Difficulty;
using static CustomBloon.CustomBloon;

namespace CustomBloon
{
    internal class CustomGamemode : ModGameMode
    {
        public override string Difficulty => DifficultyType.Easy;

        public override string BaseGameMode =>GameModeType.None;

        public override string Icon => "Icon";
        public override string DisplayName => "Custom Bloon";

        public override void ModifyBaseGameModeModel(ModModel gameModeModel)
        {
            gameModeModel.UseRoundSet<CustomRoundSet>();

            gameModeModel.SetEndingRound(EndRound);
            gameModeModel.SetStartingRound(StartRound);
        }
    }
}
