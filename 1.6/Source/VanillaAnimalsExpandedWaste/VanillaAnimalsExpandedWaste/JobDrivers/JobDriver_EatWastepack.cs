
using System;
using System.Collections.Generic;
using RimWorld;
using RimWorld.Planet;
using UnityEngine;
using Verse;
using Verse.AI;
using Verse.AI.Group;
namespace VanillaAnimalsExpandedWaste
{
    public class JobDriver_EatWastepack : JobDriver
    {


        protected const TargetIndex Target = TargetIndex.A;

        protected Thing wastepack => job.targetA.Thing;

        public override bool TryMakePreToilReservations(bool errorOnFailed)
        {
            pawn.Map.pawnDestinationReservationManager.Reserve(pawn, job, job.targetA.Cell);
            return true;
        }

        protected override IEnumerable<Toil> MakeNewToils()
        {
            Toil toil = Toils_Goto.GotoThing(Target, PathEndMode.Touch).FailOnDespawnedNullOrForbidden(Target);

            yield return toil;

            Toil toil2 = ToilMaker.MakeToil("ChewWastepack");
            toil2.defaultDuration = 1000;
            toil2.WithEffect(EffecterDefOf.EatMeat,Target);
            toil2.WithProgressBarToilDelay(TargetIndex.A, true);
            toil2.PlaySustainerOrSound(SoundDefOf.RawMeat_Eat);
            toil2.defaultCompleteMode = ToilCompleteMode.Delay;
            toil2.FailOnDestroyedOrNull(Target);
            toil2.AddFinishAction(delegate
            {
                if (wastepack.stackCount == 1) { wastepack.Destroy(); } else { wastepack.stackCount--; }
                
                pawn.needs.food.CurLevel += 1;
            });
            toil2.handlingFacing = true;
           
            yield return toil2;


        }



    }
}