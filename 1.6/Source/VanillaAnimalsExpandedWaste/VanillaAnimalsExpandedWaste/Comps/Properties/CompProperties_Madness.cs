using Verse;

namespace VanillaAnimalsExpandedWaste
{
    public class CompProperties_Madness : CompProperties
    {

        
        public IntRange ticksRange;
        public int ticksBetweenBerserkAndManhunter;
        public int ticksAfterManhunter;



        public CompProperties_Madness()
        {
            this.compClass = typeof(CompMadness);
        }


    }
}