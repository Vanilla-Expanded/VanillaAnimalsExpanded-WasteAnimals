
using System.Collections.Generic;
using Verse;
using Verse.AI;

namespace VanillaAnimalsExpandedWaste
{
    public class ThinkNode_Wasteboar : ThinkNode_Conditional
    {


        protected override bool Satisfied(Pawn pawn)
        {
            if (pawn.kindDef == InternalDefOf.VAEWaste_Wasteboar)
            {
                return true;
            }
            return false;
        }
    }
}
