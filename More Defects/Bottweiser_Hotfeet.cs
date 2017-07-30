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
	internal class Bottweiser_Hotfeet : BaseMutation
	{
		public GameObject HotfeetObject;
		
		public Bottweiser_Hotfeet()
		{
			this.Name = "Bottweiser_Hotfeet";
			this.DisplayName = "Hot Feet (&rD&y)";
		}
	
		public override bool CanLevel()
		{
			return false;
		}
	
		public override void Register(GameObject Object)
		{
			Object.RegisterPartEvent((IPart) this, "EndTurn");
			Object.RegisterPartEvent((IPart) this, "BeginEquip");
		}
	
		public override string GetDescription()
		{
			return "Each turn you act, the temperature of your surroundings increases an uncomfortable amount. \n\nYou can't wear anything on your feet. \n\nYou were never very good at dancing.";
		}

		public override string GetLevelText(int Level)
		{
			return string.Empty;
		}
		
		
		public override bool FireEvent(Event E)
		{
			if (E.ID == "BeginEquip") 
			{
				GameObject parameter = E.GetParameter("Object") as GameObject;
				if (E.GetParameter("BodyPartName") as string == "Feet")
				{
					if (this.IsPlayer()) return true;
						Popup.Show("Your burning feet prevent you from equipping " + parameter.DisplayName + "!", true); // 
					return false;
				}
			}
			
			else if (E.ID == "EndTurn") 
			{
				if (!(this.ParentObject.GetPart("Physics") as Physics).CurrentCell.ParentZone.IsWorldMap())
				{	
					this.ParentObject.FireEvent(Event.New("TemperatureChange", "Amount", 15 + Stat.Random(1, 5), "Owner", (object) this.ParentObject));
					if (this.ParentObject.IsPlayer())
						XRLCore.Core.PlayerWalking = string.Empty;
				}
				return true;
			}
		
			/**/
			return base.FireEvent(E);
		}/**/
		
		public override bool Mutate(GameObject GO, int Level) 
		{
			if (GO.GetPart("Body") is Body)
			{
				GO.FireEvent(Event.New("CommandForceUnequipObject", "BodyPartName", "Feet"));
				this.HotfeetObject = GameObjectFactory.Factory.CreateObject("Hot Feet");
				Event E = Event.New("CommandForceEquipObject");
				E.AddParameter("Object", (object) this.HotfeetObject);
				E.AddParameter("BodyPartName", "Feet");
				GO.FireEvent(E);
			}
			
			return true;
		}		
		
		public override bool Unmutate(GameObject GO) 
		{
			Body part2 = GO.GetPart("Body") as Body;
			if (part2 != null)
			{		
				BodyPart partByName = part2.GetPartByName("Feet");
				if (partByName != null && partByName.Equipped != null && partByName.Equipped.Blueprint == "Hot Feet")
				{
					partByName.Equipped.FireEvent(Event.New("Unequipped", "UnequippingObject", (object) this.ParentObject, "BodyPart", (object) partByName));
					partByName.Unequip();
				}
			}
			
			return true;
		}
	}	
}
