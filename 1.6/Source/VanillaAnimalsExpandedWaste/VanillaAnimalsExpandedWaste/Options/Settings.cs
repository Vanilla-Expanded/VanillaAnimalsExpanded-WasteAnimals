using RimWorld;
using System;
using System.Linq;
using UnityEngine;
using Verse;

namespace VanillaAnimalsExpandedWaste
{
    public class VanillaAnimalsExpandedWaste_Settings : ModSettings

    {


        public static bool VAEW_DisableToxfluSpread = false;
       

        public override void ExposeData()
        {
            base.ExposeData();

            Scribe_Values.Look(ref VAEW_DisableToxfluSpread, "VAEW_DisableToxfluSpread", false, true);
           

        }

        public static void DoWindowContents(Rect inRect)
        {
            Listing_Standard ls = new Listing_Standard();

           
            ls.Begin(inRect);

            ls.CheckboxLabeled("VAEW_DisableToxfluSpread".Translate(), ref VAEW_DisableToxfluSpread, "VAEW_DisableToxfluSpreadDesc".Translate());
           
            ls.End();
          
        }



    }










}
