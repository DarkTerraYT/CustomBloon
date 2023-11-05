using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Scenarios;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Difficulty;
using static Extension.CustomBloon;

namespace Extension
{
    internal class CustomGamemode : ModGameMode
    {
        public override string Difficulty => DifficultyType.Easy;

        public override string BaseGameMode =>GameModeType.None;

        public override string Icon => "Icon";
        public override string DisplayName => GameModeName;

        public override void ModifyBaseGameModeModel(ModModel gameModeModel)
        {
            gameModeModel.UseRoundSet<CustomRoundSet>();

            gameModeModel.SetEndingRound(EndRound);
            gameModeModel.SetStartingRound(StartRound);
        }
    }
}
