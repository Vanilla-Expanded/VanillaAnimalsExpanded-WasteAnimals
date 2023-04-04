using RimWorld;
using System;
using Verse;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VanillaAnimalsExpandedWaste
{
    public class DamageWorker_RipPart : DamageWorker_AddInjury
    {
        public override DamageWorker.DamageResult Apply(DamageInfo dinfo, Thing victim)
        {
           
            Pawn pawn = victim as Pawn;
           
            if (pawn != null)
            {

                BodyPartRecord bodyPartRecord = ReflectionCache.GetExactPartFromDamageInfo(this,dinfo,pawn);
               
                if (bodyPartRecord != null)
                {
                   
                    int num = (int)pawn.health.hediffSet.GetPartHealth(bodyPartRecord) + 1000;
                    DamageInfo damageInfo = new DamageInfo(DamageDefOf.Cut, (float)num, 999f, -1f, dinfo.Instigator, bodyPartRecord, null, DamageInfo.SourceCategory.ThingOrUnknown, null, true, true);
                    damageInfo.SetAllowDamagePropagation(false);
                    pawn.TakeDamage(damageInfo);
                    if (pawn.Faction != null && pawn.Faction.IsPlayer)
                    {
                        Messages.Message("VAEWaste_PestigatorRips".Translate(pawn.LabelShortCap, bodyPartRecord.Label), pawn, MessageTypeDefOf.NegativeEvent);

                    }
                }
            }

               
            DamageWorker.DamageResult damageResult = base.Apply(dinfo, victim);


            return damageResult;
        }


    }
}

