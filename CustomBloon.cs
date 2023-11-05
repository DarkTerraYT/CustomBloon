using MelonLoader;
using BTD_Mod_Helper;
using Extension;
using BTD_Mod_Helper.Api.ModOptions;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Unity;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using HarmonyLib;
using Il2CppSystem.Collections.Generic;
using BTD_Mod_Helper.Api;

[assembly: MelonInfo(typeof(Extension.CustomBloon), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace Extension;

public class CustomBloon : BloonsTD6Mod
{
    public static int AffectedRounds = 0;

    public static readonly ModSettingCategory BloonStats = new("Bloon Stats");

    public static readonly ModSettingBool SetHealth = new(true)
    {
        requiresRestart = true,
        category = BloonStats,
        description = "Set The Bloon's Health to The One in This Menu?"
    };
    public static readonly ModSettingInt Health = new(1)
    {
        requiresRestart = true,
        category = BloonStats
    };
    public static readonly ModSettingBool SetSpeed = new(true)
    {
        requiresRestart = true,
        category = BloonStats,
        description = "Set The Bloon's Speed to The One in This Menu?"
    };
    public static readonly ModSettingDouble Speed = new(1)
    {
        requiresRestart = true,
        category = BloonStats,
        description = "The speed of a red bloon is 25"
    };
    public static readonly ModSettingBool SetLeakDamage = new(true)
    {
        requiresRestart = true,
        category = BloonStats,
        description = "Set The Bloon's Leak Damage to The One in This Menu?"
    };
    public static readonly ModSettingDouble LeakDamage = new(1)
    {
        requiresRestart = true,
        category = BloonStats,
        description = "How much health the bloon takes away when it reaches the end"
    };

    public static readonly ModSettingCategory BloonSettings = new("Bloon Settings");

    public static readonly ModSettingString BaseBloonType = new("Red")
    {
        requiresRestart = true,
        category = BloonSettings,
        description = "What the default bloon is"
    };
    public static readonly ModSettingBool CustomBloonDisplay = new(true)
    {
        requiresRestart = true,
        category = BloonSettings,
        description = "Use The Custom Bloon Display?"
    };
    public static readonly ModSettingBool TowerDisplay = new(false)
    {
        requiresRestart = true,
        category = BloonSettings,
        description = "Does it Use a Tower Display?"
    };
    public static readonly ModSettingString DisplayFromWhat = new("Red")
    {
        requiresRestart = true,
        category = BloonSettings,
        description = "Which Bloon Should This Look Like? Used When Use Custom Bloon Display Isn't Used. ONLY PUT IN A TOWER ID IF TOWER DISPLAY IS ENABLED! IDs are like this -> NinjaMonkey for the 000 abd NinjaMonkey-402 when it has upgrades. For Heros it's HeroName or HeroName Level. This could look like Geraldo or Geraldo 12. IDs for bloons is just the name like Ddt"
    };
    public static readonly ModSettingInt CashPerPop = new(1)
    {
        requiresRestart = true,
        category = BloonSettings,
        description = "How much cash is awarded per pop. Warning if you make this too big, you will reach the 32 bit integer (signed integer) limit"
    };
    public static readonly ModSettingDouble CashPerPopMultiplier = new(1)
    {
        requiresRestart = true,
        category = BloonSettings,
        description = "The multiplier for how much cash you get. 0.5 is half and 2 is double. Warning if you make this too big, you will reach the 32 bit integer (signed integer) limit",
        min = 0
    };

    public static readonly ModSettingCategory RoundSetSettings = new("Round Set Settings");

    public static readonly ModSettingInt EndRound = new(40)
    {
        requiresRestart = true,
        category = RoundSetSettings,
        description = "What round before free-play"
    };
    public static readonly ModSettingInt StartRound = new(1)
    {
        requiresRestart = true,
        category = RoundSetSettings,
        description = "What round the game will start on"
    };
    public static readonly ModSettingInt FirstAppearance = new(1)
    {
        requiresRestart = true,
        category = RoundSetSettings,
        description = "What round the bloon will first appear on",
        min = StartRound,
    };
    public static readonly ModSettingInt LastAppearance = new(40)
    {
        requiresRestart = true,
        category = RoundSetSettings,
        description = "What round the bloon will last appear"
    };
    public static readonly ModSettingInt SpawnsPerRound = new(1)
    {
        requiresRestart = true,
        category = RoundSetSettings,
        description = "How many times the bloon spawns per round",
        min = 1
    };
    public static readonly ModSettingBool OnlySpawnCustomBloon = new(false)
    {
        requiresRestart = true,
        category = RoundSetSettings,
        description = "Only set this to true if you want only the custom bloon to spawn"
    };
    public static readonly ModSettingInt RoundDelay = new(0)
    {
        requiresRestart = true,
        category = RoundSetSettings,
        description = "How many rounds until the round the bloon spawns",
        min = 0
    };
    public static readonly ModSettingString RoundSetName = new("Custom Bloon")
    {
        requiresRestart = true,
        category = RoundSetSettings,
        description = "Custom Bloon Round Set Name"
    };
    public static readonly ModSettingString GameModeName = new("Custom Bloon")
    {
        requiresRestart = true,
        category = RoundSetSettings,
        description = "Custom Bloon Game Mode Name"
    };

    static readonly ModSettingCategory BloonProperties = new("Bloon Properites");

    public static readonly ModSettingBool Lead = new(false)
    {
        requiresRestart = true,
        category = BloonProperties,
        description = "Can't be popped by towers that can't pop leads"
    };
    public static readonly ModSettingBool Purple = new(false)
    {
        requiresRestart = true,
        category = BloonProperties,
        description = "Can't be popped by towers that use magic attacks"
    };
    public static readonly ModSettingBool Black = new(false)
    {
        requiresRestart = true,
        category = BloonProperties,
        description = "Can't be popped by towers that use explosions"
    };
    public static readonly ModSettingBool White = new(false)
    {
        requiresRestart = true,
        category = BloonProperties,
        description = "Can't be popped by towers that use ice attacks"
    };
    public static readonly ModSettingBool Frozen = new(false)
    {
        requiresRestart = true,
        category = BloonProperties,
        description = "Can't be popped by towers that can't pop frozen bloons (lead but weaker)"
    };
    public static readonly ModSettingBool Immune = new(false)
    {
        requiresRestart = true,
        category = BloonProperties,
        description = "Can't be popped at all"
    };
    public static readonly ModSettingBool Regrow = new(false)
    {
        requiresRestart = true,
        category = BloonProperties,
        description = "Is This a Regrow Bloon?"
    };
    public static readonly ModSettingDouble RegrowRate = new(1)
    {
        requiresRestart = true,
        category = BloonProperties,
        description = "How many layers regrow per second"
    };
    public static readonly ModSettingBool Camo = new(false)
    {
        requiresRestart = true,
        category = BloonProperties,
        description = "Is This a Camo Bloon?"
    };
    public static readonly ModSettingBool Fortified = new(false)
    {
        requiresRestart = true,
        category = BloonProperties,
        description = "Is This Bloon Fortified?"
    };
    public static readonly ModSettingBool Moab = new(false)
    {
        requiresRestart = true,
        category = BloonProperties,
        description = "Is This a Moab Bloon?"
    };
    public static readonly ModSettingBool Boss = new(false)
    {
        requiresRestart = true,
        category = BloonProperties,
        description = "Makes the bloon a boss bloon. "
    };

    public static readonly ModSettingCategory Children = new("Bloon's Children");

    public static readonly ModSettingBool KeepOriginalChildren = new(false)
    {
        requiresRestart = true,
        category = Children,
        description = "Does The Bloon Keep it's original Children? (Yellow's is 1 Green, Moab's is 4 Ceramics)"
    };
    public static readonly ModSettingString Child1Id = new("Red")
    {
        requiresRestart = true,
        category = Children,
        description = "What bloon this child is"
    };
    public static readonly ModSettingInt Child1Amount = new(0)
    {
        requiresRestart = true,
        category = Children,
        description = "How many children spawn of this bloon type",
        min = 0
    };
    public static readonly ModSettingString Child2Id = new("Blue")
    {
        requiresRestart = true,
        category = Children,
        description = "What bloon this child is"
    };
    public static readonly ModSettingInt Child2Amount = new(0)
    {
        requiresRestart = true,
        category = Children,
        description = "How many children spawn of this bloon type",
        min = 0
    };
    public static readonly ModSettingString Child3Id = new("Green")
    {
        requiresRestart = true,
        category = Children,
        description = "What bloon this child is"
    };
    public static readonly ModSettingInt Child3Amount = new(0)
    {
        requiresRestart = true,
        category = Children,
        description = "How many children spawn of this bloon type",
        min = 0
    };
    public static readonly ModSettingString Child4Id = new("Yellow")
    {
        requiresRestart = true,
        category = Children,
        description = "What bloon this child is"
    };
    public static readonly ModSettingInt Child4Amount = new(0)
    {
        requiresRestart = true,
        category = Children,
        description = "How many children spawn of this bloon type",
        min = 0
    };
    public static readonly ModSettingString Child5Id = new("Pink")
    {
        requiresRestart = true,
        category = Children,
        description = "What bloon this child is"
    };
    public static readonly ModSettingInt Child5Amount = new(0)
    {
        requiresRestart = true,
        category = Children,
        description = "How many children spawn of this bloon type",
        min = 0
    };

    public override void OnApplicationStart()
    {
        string i = BaseBloonType;
        string ii = Child1Id;
        string iii = Child2Id;
        string iiii = Child3Id;
        string iiiii = Child4Id;
        string iiiiii = Child5Id;

        bool flag = i.Contains("Gold");
        bool flag2 = ii.Contains("Gold");
        bool flag3 = iii.Contains("Gold");
        bool flag4 = iiii.Contains("Gold");
        bool flag5 = iiiii.Contains("Gold");
        bool flag6 = iiiiii.Contains("Gold");

        if (flag)
        {
            ModHelper.Error<CustomBloon>("Illegal BloonType Was Used! BloonType Attemped Was: " + BaseBloonType);
            ModHelper.Msg<CustomBloon>("Bloon Type Reset to Red!");

            BaseBloonType.SetValue("Red");
        }
        if (flag2)
        {
            ModHelper.Error<CustomBloon>("Illegal BloonType For a Child Was Used! BloonType Attemped Was: " + Child1Id);
            ModHelper.Msg<CustomBloon>("Bloon Type Reset to Red!");
        }
        if (flag3)
        {
            ModHelper.Error<CustomBloon>("Illegal BloonType For a Child Was Used! BloonType Attemped Was: " + Child2Id);
            ModHelper.Msg<CustomBloon>("Bloon Type Reset to Red!");
        }
        if (flag4)
        {
            ModHelper.Error<CustomBloon>("Illegal BloonType For a Child Was Used! BloonType Attemped Was: " + Child3Id);
            ModHelper.Msg<CustomBloon>("Bloon Type Reset to Red!");
        }
        if (flag5)
        {
            ModHelper.Error<CustomBloon>("Illegal BloonType For a Child Was Used! BloonType Attemped Was: " + Child4Id);
            ModHelper.Msg<CustomBloon>("Bloon Type Reset to Red!");
        }
        if (flag6)
        {
            ModHelper.Error<CustomBloon>("Illegal BloonType For a Child Was Used! BloonType Attemped Was: " + Child5Id);
            ModHelper.Msg<CustomBloon>("Bloon Type Reset to Red!");
        }
    }
    [HarmonyPatch(typeof(Il2CppAssets.Scripts.Unity.UI_New.InGame.BloonMenu.BloonMenu), "CreateBloonButtons")]
    public class MapLoader_Patch
    {
        [HarmonyPrefix]
        public static bool Prefix(List<BloonModel> sortedBloons)
        {
            foreach (BloonModel bloon in (Il2CppArrayBase<BloonModel>)Game.instance.model.bloons)
            {
                if (bloon.baseId == ModContent.BloonID<Bloon>())
                    sortedBloons.Add(bloon);
            }
            return true;
        }
    }
}