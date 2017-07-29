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
    internal class Bottweiser_Fistfighting : BaseSkill
    {
        public Bottweiser_Fistfighting()
        {
            this.Name = "Bottweiser_Fistfighting";
            this.DisplayName = "Fistfighting";
        }
	}   
}