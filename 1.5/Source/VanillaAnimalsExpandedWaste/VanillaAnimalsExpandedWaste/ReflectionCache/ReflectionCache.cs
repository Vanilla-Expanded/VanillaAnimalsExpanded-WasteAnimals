using HarmonyLib;
using RimWorld;
using Verse;
using System;
using System.Collections.Generic;



namespace VanillaAnimalsExpandedWaste
{
    public class ReflectionCache
    {
        

        public static readonly Func<DamageWorker_AddInjury, DamageInfo ,Pawn, BodyPartRecord> GetExactPartFromDamageInfo =
            (Func<DamageWorker_AddInjury, DamageInfo, Pawn, BodyPartRecord>)Delegate.CreateDelegate(typeof(Func<DamageWorker_AddInjury, DamageInfo, Pawn, BodyPartRecord>),
            AccessTools.Method(typeof(DamageWorker_AddInjury), "GetExactPartFromDamageInfo"));
    }
}
