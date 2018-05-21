using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terraria.GameContent.Loot
{
	public struct LootInfo
	{
		public int ItemID { get; set; }

		public int DropChance { get; set; }

		public LootQuantity Quantity { get; set; }

		public List<LootCondition> Conditions { get; set; }

		public bool AllowLuckModifier { get; set; }

		public LootInfo(int itemID, int dropChance, LootQuantity quantity, bool allowLuckModifier, params LootCondition[] conditions)
		{
			ItemID = itemID;
			DropChance = dropChance;
			Quantity = quantity;
			AllowLuckModifier = allowLuckModifier;
			Conditions = conditions.ToList();
		}

		public LootInfo(int itemID, int dropChance, LootQuantity quantity, params LootCondition[] conditions) : this(itemID, dropChance, quantity, true, conditions) { }

		public LootInfo(int itemID, int dropChance, params LootCondition[] conditions) : this(itemID, dropChance, new LootQuantity(1), conditions) { }

		public LootInfo(int itemID, params LootCondition[] conditions) : this(itemID, -1, conditions) { }
	}
}
