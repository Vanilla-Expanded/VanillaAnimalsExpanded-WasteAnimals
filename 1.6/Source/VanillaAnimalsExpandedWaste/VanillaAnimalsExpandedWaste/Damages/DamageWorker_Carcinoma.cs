using RimWorld;
using System;
using Verse;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VanillaAnimalsExpandedWaste
{
    public class DamageWorker_Carcinoma : DamageWorker_AddInjury
    {
        public override DamageWorker.DamageResult Apply(DamageInfo dinfo, Thing victim)
        {

            Pawn pawn = victim as Pawn;

            if (pawn != null && !pawn.RaceProps.IsMechanoid)
            {

                BodyPartRecord bodyPartRecord = ReflectionCache.GetExactPartFromDamageInfo(this, dinfo, pawn);

                if (bodyPartRecord != null)
                {

                    pawn.health.AddHediff(HediffDefOf.Carcinoma, bodyPartRecord);
                }
            }


            DamageWorker.DamageResult damageResult = base.Apply(dinfo, victim);


            return damageResult;
        }


    }
}

