using System.Collections.Generic;
using RimWorld;
using Verse;
using Verse.AI;
using System.Linq;
using UnityEngine;

namespace VanillaAnimalsExpandedWaste
{
    public class JobGiver_EatWastepacks : ThinkNode_JobGiver
    {
        protected override Job TryGiveJob(Pawn pawn)
        {

            Thing thing = null;
            
            List<Thing> listWastepacks = (from c in pawn.Map.listerThings.ThingsOfDef(ThingDefOf.Wastepack)
                                     where !c.IsForbidden(pawn)
                                     select c).ToList();

            if (listWastepacks.Count > 0)
            {
                thing = listWastepacks.RandomElement();
            }
            if (thing != null)
            {
                Job job = JobMaker.MakeJob(InternalDefOf.VAEWaste_EatWastepack, thing);

                
                return job;
            }
            return null;
        }
    }
}
