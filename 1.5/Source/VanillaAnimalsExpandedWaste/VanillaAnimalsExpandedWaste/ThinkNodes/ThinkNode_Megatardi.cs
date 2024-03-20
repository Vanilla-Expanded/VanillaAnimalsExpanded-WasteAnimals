
using System.Collections.Generic;
using Verse;
using Verse.AI;

namespace VanillaAnimalsExpandedWaste
{
    public class ThinkNode_Megatardi : ThinkNode_Conditional
    {


        protected override bool Satisfied(Pawn pawn)
        {
            if (pawn.kindDef == InternalDefOf.VAEWaste_Megatardi)
            {
                return true;
            }
            return false;
        }
    }
}
