using System;
using Verse;
using Verse.AI;
using RimWorld;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace VanillaAnimalsExpandedWaste
{
	public class IncidentWorker_WasteAnimalsWanderIn : IncidentWorker
	{
		protected override bool CanFireNowSub(IncidentParms parms)
		{
			Map map = (Map)parms.target;
			if (map.pollutionGrid.TotalPollutionPercent < 0.025f && map.listerThings.ThingsOfDef(ThingDefOf.Wastepack).Count==0)
			{
				return false;
			}
			if (map.pollutionGrid.TotalPollutionPercent>0.8f)
			{
				return false;
			}
			IntVec3 cell;
			return TryFindEntryCell(map, out cell);
		}

		

		public static List<PawnKindDef> wasteAnimals = new List<PawnKindDef>(){
			InternalDefOf.VAEWaste_Wasteboar,InternalDefOf.VAEWaste_Megatardi,InternalDefOf.VAEWaste_Toxscorpion,InternalDefOf.VAEWaste_Toxiguana
			,InternalDefOf.VAEWaste_Toxlion,InternalDefOf.VAEWaste_Toxbear,InternalDefOf.VAEWaste_Toxafox,InternalDefOf.VAEWaste_Pestigator,
			InternalDefOf.VAEWaste_Hydra,InternalDefOf.VAEWaste_Wasteffalo,InternalDefOf.VAEWaste_Wastedeer
		};

		protected override bool TryExecuteWorker(IncidentParms parms)
		{
			Map map = (Map)parms.target;
			if (!TryFindEntryCell(map, out IntVec3 cell))
			{
				return false;
			}
			var candidates = wasteAnimals.Where(x => map.mapTemperature.SeasonAndOutdoorTemperatureAcceptableFor(x.race)&&map.Biome.CommonalityOfPollutionAnimal(x)>0);
			if (candidates.Count()==0)
			{
				return false;
			}

			PawnKindDef animal = candidates.RandomElement();
		
			IntVec3 result = IntVec3.Invalid;
			if (!RCellFinder.TryFindRandomCellOutsideColonyNearTheCenterOfTheMap(cell, map, 10f, out result))
			{
				result = IntVec3.Invalid;
			}

			int numWastepacks = map.listerThings.ThingsOfDef(ThingDefOf.Wastepack).Count();
			//Log.Message(numWastepacks.ToString());
			int numAnimals = (int)Math.Round((float)numWastepacks / 10f);
			//Log.Message(numAnimals.ToString());
			if(numAnimals == 0)
            {
				numAnimals = 1;
			}
			if (numAnimals > 10)
			{
				numAnimals = 10;
			}
			IntVec3 loc;
			Pawn animalMade;

			loc = CellFinder.RandomClosewalkCellNear(cell, map, 10);
			animalMade = PawnGenerator.GeneratePawn(new PawnGenerationRequest(animal));
			GenSpawn.Spawn(animalMade, loc, map, Rot4.Random);
			if (result.IsValid)
			{
				animalMade.mindState.forcedGotoPosition = CellFinder.RandomClosewalkCellNear(result, map, 10);
			}
			for (int i = 0; i < numAnimals-1; i++)
            {
				loc = CellFinder.RandomClosewalkCellNear(cell, map, 10);
				animalMade = PawnGenerator.GeneratePawn(new PawnGenerationRequest(animal));
				GenSpawn.Spawn(animalMade, loc, map, Rot4.Random);
				if (result.IsValid)
				{
					animalMade.mindState.forcedGotoPosition = CellFinder.RandomClosewalkCellNear(result, map, 10);
				}
			}


			
			SendStandardLetter("VAEWaste_WasteAnimalsWanderInLabel".Translate(animal.label).CapitalizeFirst(), "VAEWaste_WasteAnimalsWanderInText".Translate(animal.label),
				LetterDefOf.NegativeEvent, parms, animalMade);
			return true;
		}

		private bool TryFindEntryCell(Map map, out IntVec3 cell)
		{
			return RCellFinder.TryFindRandomPawnEntryCell(out cell, map, CellFinder.EdgeRoadChance_Animal + 0.2f);
		}
	}
}

