
using RimWorld;
using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;
namespace VanillaAnimalsExpandedWaste
{
    public class IngestionOutcomeDoer_Toxic : IngestionOutcomeDoer
    {
       
        public float severity = -1f;

        public ChemicalDef toleranceChemical;

        private bool divideByBodySize;

        public bool multiplyByGeneToleranceFactors;

        protected override void DoIngestionOutcomeSpecial(Pawn pawn, Thing ingested)
        {
            Hediff hediff = HediffMaker.MakeHediff(HediffDefOf.ToxicBuildup, pawn);
            float effect = (!(severity > 0f)) ? HediffDefOf.ToxicBuildup.initialSeverity : severity;
            if (divideByBodySize)
            {
                effect /= pawn.BodySize;
            }
            effect *= Mathf.Max(1f - pawn.GetStatValue(StatDefOf.ToxicResistance), 0f);
            hediff.Severity = effect;
            pawn.health.AddHediff(hediff);
        }

        public override IEnumerable<StatDrawEntry> SpecialDisplayStats(ThingDef parentDef)
        {
            if (parentDef.IsDrug && chance >= 1f)
            {
                foreach (StatDrawEntry item in HediffDefOf.ToxicBuildup.SpecialDisplayStats(StatRequest.ForEmpty()))
                {
                    yield return item;
                }
            }
        }
    }
}