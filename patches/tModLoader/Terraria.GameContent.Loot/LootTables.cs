using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria.GameContent.Loot.Conditions;
using Terraria.ID;
using Terraria.Utilities;

namespace Terraria.GameContent.Loot
{
	public static class LootTables
	{
		public static readonly Dictionary<int, List<LootInfo>> Loot = new Dictionary<int, List<LootInfo>>();
		public static readonly LuckBasedRandom Random = new LuckBasedRandom();

		public static int Luck => Random.Luck;

		private static bool _initialized;

		public static void InitLoot()
		{
			if (_initialized)
				return;
			_initialized = true;

			Loot[NPCID.GreenSlime] = new List<LootInfo>()
			{
				new LootInfo(ItemID.CrimsonKey, 10),
				new LootInfo(ItemID.Stinger, -1, new LootQuantity(1, 4)),
				new LootInfo(ItemID.Acorn, -1, new LootQuantity(2, 6), new LootConditionBiome(LootConditionBiome.EnumBiome.Snow))
			};
		}

		public static void DropLoot(NPC npc)
		{
			InitLoot();

			if (!Loot.ContainsKey(npc.netID))
				return;

			List<LootInfo> infoList = Loot[npc.netID];
			if (infoList == null)
				return;

			foreach (LootInfo info in infoList)
			{
				if (info.DropChance <= 0 || (info.AllowLuckModifier
					    ? (Random.NextBool(info.DropChance))
					    : (Main.rand.Next(info.DropChance) == 0)))
				{
					if (info.Conditions != null)
					{
						bool failed = false;
						foreach (LootCondition condition in info.Conditions)
						{
							if (!condition.CheckCondition(npc))
							{
								failed = true;
								break;
							}
						}
						if (failed)
							continue;
					}
					int quantity;
					if (info.Quantity.MinQuantity == info.Quantity.MaxQuantity)
						quantity = info.Quantity.MinQuantity;
					else
					{
						quantity = info.AllowLuckModifier
							? Random.NextInt(info.Quantity.MinQuantity, info.Quantity.MaxQuantity)
							: Main.rand.Next(info.Quantity.MinQuantity, info.Quantity.MaxQuantity);
					}
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, info.ItemID, quantity, false, 0, false, false);
				}
			}
		}
	}
}
