using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Unity.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomBloon.Display
{
    internal class CustomBloonDisplay : ModDisplay
    {
        public override string BaseDisplay => Ext.GetDisplay("Red", 0);


        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
                Set2DTexture(node, "CustomBloon");
        }
    }
}
