using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terraria.GameContent.Loot
{
	public abstract class LootCondition
	{
		public abstract bool CheckCondition(NPC npc);
	}
}
