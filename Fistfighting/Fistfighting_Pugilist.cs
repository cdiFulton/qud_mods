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
    internal class Fistfighting_Pugilist : BaseSkill
    {
        public Fistfighting_Pugilist()
        {
            this.Name = "Fistfighting_Pugilist";
            this.DisplayName = "Pugilist";
        }

        public override void Register(GameObject Object)
        {
			
			Object.RegisterPartEvent((IPart) this, "AttackerRollMeleeToHit");
			Object.RegisterPartEvent((IPart) this, "GetAttackerHitDice");
			Object.RegisterPartEvent((IPart) this, "DealDamage");
			
        }

        public override bool FireEvent(Event E)
        {
			
			// Get our bonuses to penetration
            if (E.ID == "AttackerRollMeleeToHit") {
				GameObject weapon = E.GetParameter("Weapon") as GameObject;
				//if (weapon != null && weapon.HasPart("MeleeWeapon") && (weapon.GetPart("MeleeWeapon") as MeleeWeapon).Skill == "Fistfighting")
				int pen_bonus = 0;
				MessageQueue.AddPlayerMessage("You attack with a " + E.GetParameter("Skill") as string);
				
				if (weapon != null && weapon.HasPart("MeleeWeapon") && (weapon.GetPart("MeleeWeapon") as MeleeWeapon).Skill == "Fistfighting") 
				{
					MessageQueue.AddPlayerMessage("Er, I mean a ..." );
				}
					
					
				if (this.ParentObject.HasPart("Fistfighting_Pugilist")) {
					pen_bonus += 2;
				}
				
				if (this.ParentObject.HasPart("Fistfighting_Balancedcombatant")) {
					pen_bonus += 1;
				}
				
				if (this.ParentObject.HasPart("Fistfighting_Grapple")) {
					pen_bonus += 1;
				}
				
				if (this.ParentObject.HasPart("Fistfighting_Hardtopindown")) {
					pen_bonus += 3;
				}
				
				E.AddParameter("PenetrationBonus", E.GetIntParameter("PenetrationBonus", 0) + pen_bonus);
				
				MessageQueue.AddPlayerMessage("pen bonus: " + pen_bonus as string);
			}
			
			// Get our to-hit bonuses
			if (E.ID == "AttackerRollMeleeToHit") {
				GameObject weapon = E.GetParameter("Weapon") as GameObject;
				// if (weapon != null && weapon.HasPart("MeleeWeapon") && (weapon.GetPart("MeleeWeapon") as MeleeWeapon).Skill == "Fistfighting")
				int hit_bonus = 0;				
				
				if (this.ParentObject.HasPart("Fistfighting_Pugilist")) {
					hit_bonus += 2;
				}
				
				E.AddParameter("Result", (int) E.GetParameter("Result") + hit_bonus);
				
				MessageQueue.AddPlayerMessage("hit bonus: " + hit_bonus as string);
			}
			
			// Get our damage bonuses and apply grapple
			if (E.ID == "DealDamage") {
				GameObject weapon = E.GetParameter("Weapon") as GameObject;
				// if (weapon != null && weapon.HasPart("MeleeWeapon") && (weapon.GetPart("MeleeWeapon") as MeleeWeapon).Skill == "Fistfighting")
				
				Damage wpn_dmg = E.GetParameter("Damage") as Damage;
				
				int dmg_bonus = 0;
				
				if (this.ParentObject.HasPart("Fistfighting_Pugilist")) {
					dmg_bonus += 2;
				}
				
				if (this.ParentObject.HasPart("Fistfighting_Balancedcombatant")) {
					dmg_bonus += 1;
				}
				
				if (this.ParentObject.HasPart("Fistfighting_Grapple")) {
					dmg_bonus += 1;
				}
				
				if (this.ParentObject.HasPart("Fistfighting_Toughasnails")) {
					dmg_bonus += 3;
				}
				
				wpn_dmg.Amount += dmg_bonus;
				
				if (this.ParentObject.HasSkill("Cudgel_Bonecrusher")){
					wpn_dmg.Amount *= 2;
				}
				
				MessageQueue.AddPlayerMessage("dmg bonus: " + dmg_bonus as string);
				
				if (this.ParentObject.HasPart("Fistfighting_Grapple")) {
					// E.target.apply_grapple()
				}
			}
			
			return base.FireEvent(E);
        }
		
    }
}