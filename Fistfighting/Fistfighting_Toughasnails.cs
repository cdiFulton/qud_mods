using System;
using System.Collections.Generic;
using XRL.Core;
using XRL.Messages;
using XRL.Rules;
using XRL.UI;

namespace XRL.World.Parts.Skill
{
    [Serializable]
    internal class Fistfighting_Toughasnails : BaseSkill
    {
        public Fistfighting_Toughasnails()
        {
            this.Name = "Fistfighting_Toughasnails";
            this.DisplayName = "Tough as Nails";
        }
		// This is a passive, so its main effect is existing and being checked by the
		// main skill Pugilist		
		
		// Add the AV
		public override bool AddSkill(GameObject GO) 
		{
			GO.Statistics["AV"].BaseValue += 1;
		}
		
		public override bool RemoveSkill(GameObject GO) 
		{
			GO.Statistics["AV"].BaseValue -= 1;
		}
    }
}