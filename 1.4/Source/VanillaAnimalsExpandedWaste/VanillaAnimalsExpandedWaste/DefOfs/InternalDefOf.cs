﻿using System;
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

       
        public static ThingDef VAEWaste_Wasteboar;
        public static JobDef VAEWaste_AttackTree;
    }
}
