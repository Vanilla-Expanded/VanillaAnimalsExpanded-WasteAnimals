
using System;
using System.Collections.Generic;
using RimWorld;
using RimWorld.Planet;
using Verse;
using Verse.AI;
using Verse.AI.Group;
namespace VanillaAnimalsExpandedWaste
{
    public class JobDriver_AttackTree : JobDriver
    {


        protected const TargetIndex PlantInd = TargetIndex.A;

        protected Plant Plant => (Plant)job.targetA.Thing;

        public override bool TryMakePreToilReservations(bool errorOnFailed)
        {
            pawn.Map.pawnDestinationReservationManager.Reserve(pawn, job, job.targetA.Cell);
            return true;
        }

        protected override IEnumerable<Toil> MakeNewToils()
        {
            Toil toil = Toils_Goto.GotoThing(PlantInd, PathEndMode.Touch).FailOnDespawnedNullOrForbidden(PlantInd);

            yield return toil;

            this.EndOnDespawnedOrNull(TargetIndex.A, JobCondition.Succeeded);
            yield return Toils_Combat.TrySetJobToUseAttackVerb(TargetIndex.A);
            Toil gotoCastPos = Toils_Combat.GotoCastPosition(TargetIndex.A, TargetIndex.None, closeIfDowned: false, 0.95f);
            yield return gotoCastPos;
            Toil jumpIfCannotHit = Toils_Jump.JumpIfTargetNotHittable(TargetIndex.A, gotoCastPos);
            yield return jumpIfCannotHit;
            yield return Toils_Combat.CastVerb(TargetIndex.A);
            yield return Toils_Jump.Jump(jumpIfCannotHit);




        }

       

    }
}