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

		public LootInfo(int itemID, LootQuantity quantity, int dropChance, bool allowLuckModifier, params LootCondition[] conditions)
		{
			ItemID = itemID;
			Quantity = quantity;
			DropChance = dropChance;
			AllowLuckModifier = allowLuckModifier;
			Conditions = conditions.ToList();
		}

		public LootInfo(int itemID, LootQuantity quantity, int dropChance, params LootCondition[] conditions) : this(itemID, quantity, dropChance, true, conditions) { }

		public LootInfo(int itemID, LootQuantity quantity, params LootCondition[] conditions) : this(itemID, quantity, -1, conditions) { }

		public LootInfo(int itemID, params LootCondition[] conditions) : this(itemID, new LootQuantity(1), conditions) { }
	}
}
