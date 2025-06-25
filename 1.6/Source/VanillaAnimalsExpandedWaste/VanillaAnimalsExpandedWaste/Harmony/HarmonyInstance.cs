using HarmonyLib;

using System.Reflection;
using Verse;




namespace VanillaAnimalsExpandedWaste
{
    //Setting the Harmony instance
    [StaticConstructorOnStartup]
    public class Main
    {
        static Main()
        {
            var harmony = new Harmony("com.vanillaanimalsexpandedwaste");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }


    }















}
