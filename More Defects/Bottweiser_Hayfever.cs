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
	internal class Bottweiser_Hayfever : BaseMutation
	{	
		public Bottweiser_Hotfeet()
		{
			this.Name = "Bottweiser_Hayfever";
			this.DisplayName = "Hay Fever (&rD&y)";
		}
	
		public override bool CanLevel()
		{
			return false;
		}
	
		public override void Register(GameObject Object)
		{
			Object.RegisterPartEvent((IPart) this, "EndTurn");
		}
	
		public override string GetDescription()
		{
			return "Sniffling, sneezing, itchy, runny eyes? You really weren't meant to survive. \n\nWhile outdoors, each turn you have a chance to be inflicted with negative effects.";
		}

		public override string GetLevelText(int Level)
		{
			return string.Empty;
		}
		
		// Look at GameObject.FlingBlood(), Flaming hands
		public override bool FireEvent(Event E)
		{
			// Check Wings to see whether your're outdoors or not
			else if (E.ID == "EndTurn") 
			{
				
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
