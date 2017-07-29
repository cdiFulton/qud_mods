using System;
using System.Collections.Generic;
using XRL.Rules;
using XRL.UI;
using XRL.Core;
using XRL.World.Parts.Effects;
using XRL.World.AI.GoalHandlers;

namespace XRL.World.Parts.Skill
{
	[Serializable]
	internal class Fistfighting_Hundredfists : BaseSkill
	{
		public Guid ActivatedAbilityID = Guid.Empty;
		public ActivatedAbilityEntry ActivatedAbility;

		public Pistol_EmptyTheClips()
		{
			this.Name = "Fistfighting_Hundredfists";
			this.DisplayName = "Hundred Fists";
		}

		public override void Register(GameObject Object)
		{
			Object.RegisterPartEvent((IPart) this, "CommandFistfightingHundredFists");
			Object.RegisterPartEvent((IPart) this, "BeginTakeAction");
		}

		public override bool FireEvent(Event E)
		{
			if (E.ID == "BeginTakeAction")
			{
				if (this.ParentObject == null || this.ActivatedAbility == null)
				{
					return true;
				}
				this.ActivatedAbility.Enabled = !this.ParentObject.HasEffect("HundredFists");
				return true;
			}
			if (E.ID == "CommandFistfightingHundredFists")
			{
				this.ParentObject.ApplyEffect((Effect) new HundredFists(6));
				this.ActivatedAbility.Cooldown = 100;
			}
			return base.FireEvent(E);
		}

		public override bool AddSkill(GameObject GO)
		{
			ActivatedAbilities part = GO.GetPart("ActivatedAbilities") as ActivatedAbilities;
			if (part != null)
			{
				this.ActivatedAbilityID = part.AddAbility("Hundred Fists", "CommandFistfightingHundredFists", "Skill", 0);
				this.ActivatedAbility = part.AbilityByGuid[this.ActivatedAbilityID];
				this.ActivatedAbility.Enabled = true;
			}
			return true;
		}

		public override bool RemoveSkill(GameObject GO)
		{
			if (this.ActivatedAbilityID != Guid.Empty)
			{
				(GO.GetPart("ActivatedAbilities") as ActivatedAbilities).RemoveAbility(this.ActivatedAbilityID);
			}
			return true;
		}
  }
}
