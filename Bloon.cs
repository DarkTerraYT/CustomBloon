using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2Cpp;
using static Extension.CustomBloon;
using System.Collections.Generic;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;

namespace Extension
{
    internal class Bloon : ModBloon
    {
        public override bool Camo => CustomBloon.Camo;
        public override bool Fortified => CustomBloon.Fortified;
        public override bool Regrow => CustomBloon.Regrow;
        public override float RegrowRate => CustomBloon.RegrowRate;

        public override string BaseBloon => BaseBloonType;

        public override IEnumerable<string> DamageStates => new string[] { };

        public override string Icon => "BloonI";

        public override void ModifyBaseBloonModel(BloonModel bloonModel)
        {
            if(SetHealth)
            {
                bloonModel.maxHealth = Health;
            }
            if(SetSpeed)
            {
                bloonModel.speed = Speed;
            }
            if (SetLeakDamage)
            {
                bloonModel.leakDamage = LeakDamage;
            }

            bloonModel.GetBehavior<DistributeCashModel>().cash = CashPerPop;

            if (CustomBloonDisplay)
            {
                bloonModel.ApplyDisplay<Display.CustomBloonDisplay>();
            }
            else
            {
                if (!TowerDisplay) { bloonModel.SetDisplayGUID(Ext.GetDisplay(DisplayFromWhat, 0)); }
                else { bloonModel.SetDisplayGUID(Ext.GetDisplay(DisplayFromWhat, 1)); }
            }
            if (Moab)
            {
                bloonModel.AddTag("Moab");
                bloonModel.isMoab = true;
                bloonModel.IsMoabBloon();
            }
            if (Boss)
            {
                bloonModel.AddTag("Boss");
                bloonModel.isBoss = true;
            }
            if (Immune)
            {
                bloonModel.bloonProperties = BloonProperties.Immune;
            }
            else if(Lead & Purple & White & Black & Frozen)
            {
                bloonModel.bloonProperties = BloonProperties.Black | BloonProperties.Lead | BloonProperties.White | BloonProperties.Purple | BloonProperties.Frozen;
            }
            else if (Lead & Purple & White & Black)
            {
                bloonModel.bloonProperties = BloonProperties.Black | BloonProperties.Lead | BloonProperties.White | BloonProperties.Purple;
            }
            else if (Lead & Purple & White & Frozen)
            {
                bloonModel.bloonProperties = BloonProperties.Lead | BloonProperties.White | BloonProperties.Purple | BloonProperties.Frozen;
            }
            else if (Lead & Purple & Black & Frozen)
            {
                bloonModel.bloonProperties = BloonProperties.Black | BloonProperties.Lead | BloonProperties.Purple | BloonProperties.Frozen;
            }
            else if (Lead & White & Black & Frozen)
            {
                bloonModel.bloonProperties = BloonProperties.Black | BloonProperties.Lead | BloonProperties.White | BloonProperties.Frozen;
            }
            else if (Purple & White & Black & Frozen)
            {
                bloonModel.bloonProperties = BloonProperties.Black | BloonProperties.White | BloonProperties.Purple | BloonProperties.Frozen;
            }
            else if (Lead & Purple & White)
            {
                bloonModel.bloonProperties = BloonProperties.Lead | BloonProperties.White | BloonProperties.Purple;
            }
            else if (Lead & Purple & Frozen)
            {
                bloonModel.bloonProperties = BloonProperties.Lead | BloonProperties.Purple | BloonProperties.Frozen;
            }
            else if (Lead & Black & Frozen)
            {
                bloonModel.bloonProperties = BloonProperties.Black | BloonProperties.Lead | BloonProperties.Frozen;
            }
            else if (White & Black & Frozen)
            {
                bloonModel.bloonProperties = BloonProperties.Black | BloonProperties.White | BloonProperties.Frozen;
            }
            else if (Lead & White & Black)
            {
                bloonModel.bloonProperties = BloonProperties.Black | BloonProperties.Lead | BloonProperties.White;
            }
            else if (Purple & White & Frozen)
            {
                bloonModel.bloonProperties = BloonProperties.White | BloonProperties.Purple | BloonProperties.Frozen;
            }
            else if (Purple & Black & Frozen)
            {
                bloonModel.bloonProperties = BloonProperties.Black | BloonProperties.Purple | BloonProperties.Frozen;
            }
            else if (Lead & Purple & Black)
            {
                bloonModel.bloonProperties = BloonProperties.Black | BloonProperties.Lead | BloonProperties.Purple;
            }
            else if (Lead & White & Frozen)
            {
                bloonModel.bloonProperties = BloonProperties.Lead | BloonProperties.White | BloonProperties.Frozen;
            }
            else if (Lead & Purple)
            {
                bloonModel.bloonProperties = BloonProperties.Lead | BloonProperties.Purple;
            }
            else if (Lead & Frozen)
            {
                bloonModel.bloonProperties = BloonProperties.Lead | BloonProperties.Frozen;
            }
            else if (Black & Frozen)
            {
                bloonModel.bloonProperties = BloonProperties.Black | BloonProperties.Frozen;
            }
            else if (Purple & White)
            {
                bloonModel.bloonProperties = BloonProperties.White | BloonProperties.Purple;
            }
            else if (Lead & Black)
            {
                bloonModel.bloonProperties = BloonProperties.Black | BloonProperties.Lead;
            }
            else if (Purple & Frozen)
            {
                bloonModel.bloonProperties = BloonProperties.Purple | BloonProperties.Frozen;
            }
            else if (White & Frozen)
            {
                bloonModel.bloonProperties = BloonProperties.White | BloonProperties.Frozen;
            }
            else if (White & Black)
            {
                bloonModel.bloonProperties = BloonProperties.Black | BloonProperties.White;
            }
            else if (Lead & White)
            {
                bloonModel.bloonProperties = BloonProperties.Lead | BloonProperties.White;
            }
            else if(Black & Purple)
            {
                bloonModel.bloonProperties = BloonProperties.Black | BloonProperties.Purple;
            }
            else if (Lead)
            {
                bloonModel.bloonProperties = BloonProperties.Lead;
            }
            else if (Purple)
            {
                bloonModel.bloonProperties = BloonProperties.Purple;
            }
            else if (White)
            {
                bloonModel.bloonProperties = BloonProperties.White;
            }
            else if (Black)
            {
                bloonModel.bloonProperties = BloonProperties.Black;
            }
            else if (Frozen)
            {
                bloonModel.bloonProperties = BloonProperties.Frozen;
            }

            // KEEP LAST
            if (!KeepChildren)
            {
                bloonModel.RemoveAllChildren();
            }
        }
    }
}
