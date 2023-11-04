using MelonLoader;
using BTD_Mod_Helper;
using Extension;
using BTD_Mod_Helper.Api.ModOptions;
using Il2CppAssets.Scripts.Models;

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
        category = BloonStats
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
    public static readonly ModSettingBool KeepChildren = new(false)
    {
        requiresRestart = true,
        category = BloonSettings,
        description = "Does The Bloon Keep it's Children? (Yellow's is 1 Green, Moab's is 4 Ceramics)"
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
        description = "How much cash is awarded per pop. Warning if you make this too big, you will reach the 32 bit integer (signed integer) limit\""
    };
    public static readonly ModSettingDouble CashPerPopMultiplier = new(1)
    {
        requiresRestart = true,
        category = BloonSettings,
        description = "The multiplier for how much cash you get. 0.5 is half and 2 is double. Warning if you make this too big, you will reach the 32 bit integer (signed integer) limit"
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

    public override void OnApplicationStart()
    {
        string i = BaseBloonType;

        bool flag = i.Contains("Gold");

        if (flag)
        {
            ModHelper.Error<CustomBloon>("Illegal BloonType Was Used! BloonType Attemped Was: " + BaseBloonType);
            ModHelper.Msg<CustomBloon>("Bloon Type Reset to Red!");

            BaseBloonType.SetValue("Red");
        }
    }
}