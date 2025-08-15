using RimWorld;
using UnityEngine;
using Verse;

namespace VanillaAnimalsExpandedWaste
{


    public class VanillaAnimalsExpandedWaste_Mod : Mod
    {
       
        public VanillaAnimalsExpandedWaste_Mod(ModContentPack content) : base(content)
        {
           GetSettings<VanillaAnimalsExpandedWaste_Settings>();
        }
        public override string SettingsCategory() => "VAE - Waste";

        public override void DoSettingsWindowContents(Rect inRect)
        {
            VanillaAnimalsExpandedWaste_Settings.DoWindowContents(inRect);
        }
    }
}



