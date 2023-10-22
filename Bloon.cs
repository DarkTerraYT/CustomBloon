using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Bloons;
using static Extension.CustomBloon;

namespace Extension
{
    internal class Bloon : ModBloon
    {
        public override string BaseBloon => BaseBloonType;

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

            if (CustomBloonDisplay)
            {
                bloonModel.ApplyDisplay<Display.CustomBloonDisplay>();
            }
            else
            {
                if (!TowerDisplay) { bloonModel.SetDisplayGUID(Ext.GetDisplay(DisplayFromWhat, 0)); }
                else { bloonModel.SetDisplayGUID(Ext.GetDisplay(DisplayFromWhat, 1)); }
            }

            if (Regrow)
            {
                bloonModel.isGrow = true;
                bloonModel.IsRegrowBloon();
                bloonModel.MakeChildrenRegrow();
            }
            if (Fortified)
            {
                bloonModel.isFortified = true;
                bloonModel.IsFortifiedBloon();
                bloonModel.MakeChildrenFortified();
            }
            if (Camo)
            {
                bloonModel.isCamo = true;
                bloonModel.IsCamoBloon();
                bloonModel.MakeChildrenCamo();
            }
            if (Moab)
            {
                bloonModel.isMoab = true;
                bloonModel.IsMoabBloon();
            }

            // LAST
            if(!KeepChildren)
            {
                bloonModel.RemoveAllChildren();
            }
        }
    }
}
