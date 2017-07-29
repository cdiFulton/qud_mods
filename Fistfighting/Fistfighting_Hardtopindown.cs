using System;
using System.Collections.Generic;
using XRL.Core;
using XRL.Messages;
using XRL.Rules;
using XRL.UI;

namespace XRL.World.Parts.Skill
{
    [Serializable]
    internal class Fistfighting_Hardtopindown : BaseSkill
    {
        public Fistfighting_Hardtopindown()
        {
            this.Name = "Fistfighting_Hardtopindown";
            this.DisplayName = "Hard to Pin Down";
        }
		// This is a passive, so its main effect is existing and being checked by the
		// main skill Pugilist
		
		public override bool AddSkill(GameObject GO) 
		{
			GO.Statistics["DV"].BaseValue += 1;
			return true;
		}
		
		public override bool RemoveSkill(GameObject GO) 
		{
			GO.Statistics["DV"].BaseValue -= 1;
			return true;
		}
    }
}