using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terraria.GameContent.Loot
{
	public struct LootQuantity
	{
		public int MinQuantity
		{
			get;
			set;
		}

		public int MaxQuantity
		{
			get;
			set;
		}

		public LootQuantity(int min, int max)
		{
			MinQuantity = min;
			MaxQuantity = max;
		}

		public LootQuantity(int amount) : this(amount, amount) { }
	}
}
