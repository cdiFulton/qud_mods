// Decompiled with JetBrains decompiler
// Type: XRL.World.Parts.Mutation.SpontaneousCombustion
// Assembly: Assembly-CSharp, Version=2.0.6419.22086, Culture=neutral, PublicKeyToken=null
// MVID: B6D631CF-A0FE-409A-84DF-CC5FC703A670
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Caves of Qud\CoQ_Data\Managed\Assembly-CSharp.dll

using ConsoleLib.Console;
using System;
using System.Collections.Generic;
using System.Threading;
using XRL.Core;
using XRL.Rules;
using XRL.UI;
using XRL.World.AI.GoalHandlers;

namespace XRL.World.Parts.Mutation
{
	[Serializable]
	internal class Bottweiser_Haemophobia : BaseMutation
	{
		public Bottweiser_Haemophobia()
		{
			this.Name = "Bottweiser_Hotfeet";
			this.DisplayName = "Haemophobia (&rD&y)";
		}
	
		public override bool CanLevel()
		{
			return false;
		}
	
		public override void Register(GameObject Object)
		{
			Object.RegisterPartEvent((IPart) this, "EndTurn"); // probably want this to check currently equipped, current tile(s)
			Object.RegisterPartEvent((IPart) this, "BeginEquip"); // Want this to stop you from equipping stuff
		}
	
		public override string GetDescription()
		{
			return "You're terrified by the sight of blood.";
		}

		public override string GetLevelText(int Level)
		{
			return string.Empty;
		}
		
		
		public override bool FireEvent(Event E)
		{
			// Can't equip bloody items
			if (E.ID == "BeginEquip") 
			{
				GameObject item = E.GetParameter("Object") as GameObject;
				if (item.HasEffect("bloody"))
				{
					if (this.IsPlayer()) return true;
						Popup.Show(item.DisplayName + " is covered in blood! You can't bring yourself to touch it!", true); // 
					return false;
				}
			}
			
			// Check each turn if the haemophobe is standing on a square that has blood, and if so, apply a fear effect
			else if (E.ID == "EndTurn") 
			{
				// Don't try to check objects in the current tile if on the world map
				if (!(this.ParentObject.GetPart("Physics") as Physics).CurrentCell.ParentZone.IsWorldMap())
				{	
					foreach (GameObject gameObject in (this.ParentObject.GetPart("Physics") as Physics).CurrentCell.GetObjectsInCell())
					{
						if (gameObject.HasEffect("Bloody"))
						{
							// Apply 4-turn fear with very high dice so it can't (shouldn't) be resisted 
							Fear.ApplyFearToObject("d100", 4, this.ParentObject, this.ParentObject);
						}
					}
				}
				return true;
			}
		
			/**/
			return base.FireEvent(E);
		}/**/
		
		public override bool Mutate(GameObject GO, int Level) 
		{
			return true;
		}		
		
		public override bool Unmutate(GameObject GO) 
		{
			return true;
		}
	}	
}
