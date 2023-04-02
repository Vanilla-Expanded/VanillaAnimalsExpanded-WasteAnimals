using System;
using Verse;
using System.Collections.Generic;

namespace VanillaAnimalsExpandedWaste
{
    public class HediffCompProperties_Toxflu : HediffCompProperties
    {
        public int rateInTicks = 100;

        public HediffCompProperties_Toxflu()
        {
            this.compClass = typeof(HediffComp_Toxflu);
        }
    }
}
