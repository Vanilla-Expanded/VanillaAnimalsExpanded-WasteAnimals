using HarmonyLib;
using RimWorld;
using RimWorld.Planet;
using Verse;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Verse.AI;



namespace VanillaAnimalsExpandedWaste
{


    [HarmonyPatch(typeof(InteractionWorker))]
    [HarmonyPatch("Interacted")]
    public static class VanillaAnimalsExpandedWaste_InteractionWorker_Interacted_Patch
    {
        [HarmonyPostfix]
        static void Toxflu(Pawn initiator, Pawn recipient)
        {
            if (initiator.health?.hediffSet?.HasHediff(InternalDefOf.VAEWaste_Toxflu)==true && recipient.health?.hediffSet?.HasHediff(InternalDefOf.VAEWaste_Toxflu)!=true)
            {
                float chance = 0.1f;
                if (initiator.health?.hediffSet?.GetFirstHediffOfDef(InternalDefOf.VAEWaste_Toxflu).Severity < 0.66)
                {
                    chance = 0.5f;
                }
                System.Random random = new System.Random();
                double randomChance = random.NextDouble();
                if (randomChance < chance)
                {
                    recipient.health.AddHediff(InternalDefOf.VAEWaste_Toxflu);
                }
            } else if (initiator.health?.hediffSet?.HasHediff(InternalDefOf.VAEWaste_Toxflu) !=true && recipient.health?.hediffSet?.HasHediff(InternalDefOf.VAEWaste_Toxflu) == true)
            {
                float chance = 0.1f;
                if (recipient.health?.hediffSet?.GetFirstHediffOfDef(InternalDefOf.VAEWaste_Toxflu).Severity < 0.66)
                {
                    chance = 0.5f;
                }
                System.Random random = new System.Random();
                double randomChance = random.NextDouble();
                if (randomChance < chance)
                {
                    initiator.health.AddHediff(InternalDefOf.VAEWaste_Toxflu);
                }
            }

        }
    }








}
