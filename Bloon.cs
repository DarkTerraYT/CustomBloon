using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2Cpp;
using static Extension.CustomBloon;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppSystem.Collections.Generic;
using static Il2CppFacepunch.Steamworks.Inventory;
using System;
using Il2CppAssets.Scripts;

namespace Extension
{
    internal class Bloon : ModBloon
    {
        public override bool Camo => CustomBloon.Camo;
        public override bool Fortified => CustomBloon.Fortified;
        public override bool Regrow => CustomBloon.Regrow;
        public override float RegrowRate => CustomBloon.RegrowRate;

        public override string BaseBloon => BaseBloonType;

        public override System.Collections.Generic.IEnumerable<string> DamageStates => new string[] { };

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
            bloonModel.GetBehavior<DistributeCashModel>().multiplier = CashPerPopMultiplier;

            if (CustomBloonDisplay)
            {
                bloonModel.ApplyDisplay<Display.CustomBloonDisplay>();
            }
            else
            {
                bloonModel.ApplyDisplay<Display.BloonDisplay>();
            }
            if (Moab)
            {
                bloonModel.AddTag("Moab");
                bloonModel.isMoab = true;
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

            if (!KeepOriginalChildren)
            {
                bloonModel.RemoveAllChildren();
            }

            bloonModel.AddToChildren(Ext.GetBloon(Child1Id).id, Child1Amount);
            bloonModel.AddToChildren(Ext.GetBloon(Child2Id).id, Child2Amount);
            bloonModel.AddToChildren(Ext.GetBloon(Child3Id).id, Child3Amount);
            bloonModel.AddToChildren(Ext.GetBloon(Child4Id).id, Child4Amount);
            bloonModel.AddToChildren(Ext.GetBloon(Child5Id).id, Child5Amount);
        }
    }
}
