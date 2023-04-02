

using RimWorld;
using System.Collections.Generic;
using Verse;
using System.Linq;
using Verse.Sound;
using UnityEngine;

namespace VanillaAnimalsExpandedWaste
{
    class HediffComp_Toxflu : HediffComp
    {
        public HediffCompProperties_Toxflu Props
        {
            get
            {
                return (HediffCompProperties_Toxflu)this.props;
            }
        }




        public override void CompPostPostRemoved()
        {
          
            Pawn pawn = this.parent.pawn as Pawn;
            List<BodyPartRecord> parts = pawn.RaceProps.body.GetPartsWithDef(BodyPartDefOf.Lung);
            foreach(BodyPartRecord part in parts)
            {
                pawn.health.AddHediff(InternalDefOf.VAEWaste_LongToxflu, part);
            }
            
        }

    }
}
