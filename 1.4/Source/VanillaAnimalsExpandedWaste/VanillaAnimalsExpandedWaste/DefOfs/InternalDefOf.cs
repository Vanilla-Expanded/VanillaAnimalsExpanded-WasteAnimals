using System;
using RimWorld;
using Verse;
using System.Collections.Generic;

namespace VanillaAnimalsExpandedWaste
{
    [DefOf]
    public static class InternalDefOf
    {
        static InternalDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(InternalDefOf));
        }

       
        public static PawnKindDef VAEWaste_Wasteboar;
        public static PawnKindDef VAEWaste_Megatardi;
        public static PawnKindDef VAEWaste_Toxscorpion;
        public static PawnKindDef VAEWaste_Toxiguana;
        public static PawnKindDef VAEWaste_Toxlion;
        public static PawnKindDef VAEWaste_Toxbear;
        public static PawnKindDef VAEWaste_Toxafox;
        public static PawnKindDef VAEWaste_Pestigator;
        public static PawnKindDef VAEWaste_Hydra;
        public static PawnKindDef VAEWaste_Wasteffalo;
        public static PawnKindDef VAEWaste_Wastedeer;





        public static JobDef VAEWaste_AttackTree;
        public static JobDef VAEWaste_AttackSelf;
        public static JobDef VAEWaste_EatWastepack;
        public static HediffDef VAEWaste_LongToxflu;
        public static HediffDef VAEWaste_Toxflu;

    }
}
