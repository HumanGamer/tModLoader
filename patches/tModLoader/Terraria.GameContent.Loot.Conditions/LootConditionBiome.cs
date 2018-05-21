using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria.World.Generation;

namespace Terraria.GameContent.Loot.Conditions
{
	public class LootConditionBiome : LootCondition
	{
		public enum EnumBiome
		{
			Other,
			Crimson,
			Corrupt,
			Hallow,
			Jungle,
			Snow
		}

		protected EnumBiome Biome;

		public LootConditionBiome(EnumBiome biome)
		{
			Biome = biome;
		}

		public override bool CheckCondition(NPC npc)
		{
			Player player = Main.player[(int) Player.FindClosest(npc.position, npc.width, npc.height)];

			switch (Biome)
			{
				case EnumBiome.Crimson:
					return player.ZoneCrimson;
				case EnumBiome.Corrupt:
					return player.ZoneCorrupt;
				case EnumBiome.Hallow:
					return player.ZoneHoly;
				case EnumBiome.Jungle:
					return player.ZoneJungle;
				case EnumBiome.Snow:
					return player.ZoneSnow;
				default:
					return !player.ZoneCorrupt && !player.ZoneCrimson && !player.ZoneHoly && !player.ZoneJungle && !player.ZoneSnow;
			}
		}
	}
}
