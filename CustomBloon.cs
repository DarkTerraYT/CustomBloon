using MelonLoader;
using BTD_Mod_Helper;
using CustomBloon;
using BTD_Mod_Helper.Api.ModOptions;
using System.Collections.Generic;
using System.ComponentModel;
using HarmonyLib;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppAssets.Scripts.Unity;
using BTD_Mod_Helper.Api;
using Il2CppSystem.IO;
using BTD_Mod_Helper.Extensions;

[assembly: MelonInfo(typeof(CustomBloon.CustomBloon), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace CustomBloon;

public class CustomBloon : BloonsTD6Mod
{
    public static readonly string DisplayPath = @"Mods\BloonsTD6 Mod Helper\Custom Bloon";

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
        description = "Use The Custom Bloon Display? If the file is null then will be the one I made"
    };
    public static readonly ModSettingFile CustomBloonDisplayFile = new(DisplayPath + @"\CustomBloon")
    {
        requiresRestart = true,
        category = BloonSettings,
        description = "Used with Custom Bloon Display"
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
        description = "Which Bloon Should This Look Like? Used When Use Custom Bloon Display Isn't Used. ONLY PUT IN A TOWER ID IF TOWER DISPLAY IS ENABLED!"
    };
    public static readonly ModSettingBool Regrow = new(false)
    {
        requiresRestart = true,
        category = BloonSettings,
        description = "Is This a Regrow Bloon?"
    };
    public static readonly ModSettingBool Camo = new(false)
    {
        requiresRestart = true,
        category = BloonSettings,
        description = "Is This a Camo Bloon?"
    };
    public static readonly ModSettingBool Fortified = new(false)
    {
        requiresRestart = true,
        category = BloonSettings,
        description = "Is This Bloon Fortified?"
    };
    public static readonly ModSettingBool Moab = new(false)
    {
        requiresRestart = true,
        category = BloonSettings,
        description = "Is This a Moab Bloon?"
    };

    /* Might Be Added In The Future
    public static readonly ModSettingBool Boss = new(false)
    {
        requiresRestart = true,
        category = BloonSettings,
        description = "Bloonarius, Lych, Vortex, Dreadbloon, and Phayze"
    };
    */

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

    public override void OnApplicationStart()
    {
        string i = BaseBloonType;

        bool flag = i.Contains("Gold");

        if (flag)
        {
            ModHelper.Error<CustomBloon>("Illegal Bloon Type Was Used! BloonType Attemped Was: " + BaseBloonType);
            ModHelper.Msg<CustomBloon>("Bloon Type Reset to Red!");

            BaseBloonType.SetValue("Red");
        }
    }
}