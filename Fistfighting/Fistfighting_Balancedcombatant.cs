using System;
using System.Collections.Generic;
using XRL.Core;
using XRL.Messages;
using XRL.Rules;
using XRL.UI;
using XRL.World.AI.GoalHandlers;
using XRL.World.Parts.Effects;

namespace XRL.World.Parts.Skill
{
    [Serializable]
    internal class Fistfighting_Balancedcombatant : BaseSkill
    {
        public Fistfighting_Balancedcombatant()
        {
            this.Name = "Fistfighting_Balancedcombatant";
            this.DisplayName = "Balanced Combatant";
        }
		// This is a passive, so its main effect is existing and being checked by the 
		// main skill Pugilist

		// Add the quickness and DV
		public override bool AddSkill(GameObject GO) 
		{
			GO.Statistics["Speed"].Bonus += 5;
			GO.Statistics["DV"].BaseValue += 1;
			return true;
		}
		
		public override bool RemoveSkill(GameObject GO) 
		{
			GO.Statistics["Speed"].Bonus -= 5;
			GO.Statistics["DV"].BaseValue -= 1;
			return true;
		}
    }
}