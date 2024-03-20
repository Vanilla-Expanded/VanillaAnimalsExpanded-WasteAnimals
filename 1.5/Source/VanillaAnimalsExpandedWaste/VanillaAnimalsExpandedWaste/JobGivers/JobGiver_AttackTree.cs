using System.Collections.Generic;
using RimWorld;
using Verse;
using Verse.AI;
using System.Linq;
using UnityEngine;

namespace VanillaAnimalsExpandedWaste
{
    public class JobGiver_AttackTree : ThinkNode_JobGiver
    {
        protected override Job TryGiveJob(Pawn pawn)
        {
            
            Thing thing = null;
            Plant plant = null;
            List<Thing> listTrees = (from c in pawn.Map.listerThings.ThingsInGroup(ThingRequestGroup.Plant)
                                     where ((plant= c as Plant) != null) && plant.def.plant.IsTree && pawn.CanReach(c,PathEndMode.Touch,Danger.Deadly)
                                     select c).ToList();
            if(listTrees.Count > 0)
            {
                thing = listTrees.RandomElement();
            }
            
            if (thing != null)
            {
                Job job = JobMaker.MakeJob(InternalDefOf.VAEWaste_AttackTree, thing);
              
                job.collideWithPawns = true;
                return job;
            }
            return null;
        }
    }
}
