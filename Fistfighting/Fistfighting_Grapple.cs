using System;
using System.Collections.Generic;
using XRL.Core;
using XRL.Messages;
using XRL.Rules;
using XRL.UI;

namespace XRL.World.Parts.Skill
{
    [Serializable]
    internal class Fistfighting_Grapple : BaseSkill
    {
        public Fistfighting_Grapple()
        {
            this.Name = "Fistfighting_Grapple";
            this.DisplayName = "Grapple";
        }
		// This is a passive, so its main effect is existing and being checked by the
		// main skill Pugilist
    }
}