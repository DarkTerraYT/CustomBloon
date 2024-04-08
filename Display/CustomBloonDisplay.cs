using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using static Extension.CustomBloon;

namespace Extension.Display
{
    internal class CustomBloonDisplay : ModDisplay
    {
        public override string BaseDisplay => Ext.GetDisplay("Red", 0);


        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
                Set2DTexture(node, "CustomBloon");
        }
    }

    internal class BloonDisplay : ModDisplay
    {
        public override string BaseDisplay => GetDaDisplay();

        string GetDaDisplay()
        {
            if (TowerDisplay)
            {
                return Game.instance.model.GetTowerFromId(DisplayFromWhat).display.GUID;
            }
            else
            {
                return GetBloonDisplay(DisplayFromWhat);
            }
        }
    }
}
