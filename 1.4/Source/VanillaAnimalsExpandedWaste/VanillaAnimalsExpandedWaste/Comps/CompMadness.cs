
using System.Collections.Generic;
using UnityEngine;
using Verse;
using System.Linq;
using RimWorld;
using static UnityEngine.Random;
using Verse.AI;

namespace VanillaAnimalsExpandedWaste
{
    public class CompMadness : ThingComp
    {

        public int tickCounter = 0;
        public int fixedPeriod = 0;
        public ToxbearState state = ToxbearState.Normal;


        public CompProperties_Madness Props
        {
            get
            {
                return (CompProperties_Madness)this.props;
            }
        }

        public override void PostSpawnSetup(bool respawningAfterLoad)
        {

            if (fixedPeriod == 0)
            {
                fixedPeriod = Props.ticksRange.RandomInRange;
            }

        }


        public override void PostExposeData()
        {
            base.PostExposeData();
            Scribe_Values.Look<int>(ref this.tickCounter, "tickCounter", 0, false);
            Scribe_Values.Look<int>(ref this.fixedPeriod, "fixedPeriod", 0, false);
            Scribe_Values.Look<ToxbearState>(ref this.state, "state", ToxbearState.Normal, false);
           


        }

        public override void CompTick()
        {

            tickCounter++;

            if (state== ToxbearState.Normal && tickCounter >= fixedPeriod)
            {
                state = ToxbearState.Berserk;
                tickCounter = 0;
                Pawn pawn = parent as Pawn;
                pawn.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.Berserk, null, true, false, null, false);

            }

            if (state == ToxbearState.Berserk && tickCounter >= Props.ticksBetweenBerserkAndManhunter)
            {
                state = ToxbearState.Manhunter;
                tickCounter = 0;
                Pawn pawn = parent as Pawn;
                pawn.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.Manhunter, null, true, false, null, false);

            }

            if (state == ToxbearState.Manhunter && tickCounter >= Props.ticksAfterManhunter)
            {
                state = ToxbearState.Terminal;
                tickCounter = 0;
                Pawn pawn = parent as Pawn;
                Job job = JobMaker.MakeJob(InternalDefOf.VAEWaste_AttackSelf, pawn);
                pawn.jobs.StartJob(job);

            }

            if (state == ToxbearState.Terminal && tickCounter >= 500)
            {
                
                tickCounter = 0;
                Pawn pawn = parent as Pawn;
                if(pawn.CurJobDef!= InternalDefOf.VAEWaste_AttackSelf)
                {
                    Job job = JobMaker.MakeJob(InternalDefOf.VAEWaste_AttackSelf, pawn);
                    pawn.jobs.StartJob(job);
                }
                

            }





        }


    }





}


