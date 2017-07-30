using System;
using XRL.Core;
using XRL.Messages;
using XRL.Rules;

namespace XRL.World.Parts.Mutation
{
	[Serializable]
	internal class Bottweiser_Dimwitted : BaseMutation
	{
		public Bottweiser_Dimwitted()
		{
		  this.Name = "Bottweiser_Dimwitted";
		  this.DisplayName = "Dimwitted (&rD&y)";
		}
		
		public override bool CanLevel()
		{
		  return false;
		}
		

		public override string GetDescription()
		{
		  return "The other kids teased you in school. Unsurprisingly. \n\n -10 Intelligence";
		}
    
		public override string GetLevelText(int Level)
		{
			return string.Empty;
		}

		
		public override bool Mutate(GameObject GO, int level)
		{
			this.ParentObject.Statistics["Intelligence"].BaseValue -= 10;
			return true;
		}
		
		public override bool Unmutate(GameObject GO)
		{
			GO.Statistics["Intelligence"].BaseValue += 10;
			return true;
		}
		/**/
	}
}
