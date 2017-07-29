using System;
using System.Collections.Generic;
using XRL.Core;
using XRL.Messages;
using XRL.Rules;
using XRL.UI;

namespace XRL.World.Parts.Skill
{
    [Serializable]
    internal class Fistfighting_Bonecrusher : BaseSkill
    {
        public Fistfighting_Bonecrusher()
        {
            this.Name = "Fistfighting_Bonecrusher";
            this.DisplayName = "Bonecrusher";
        }
		// This is a passive, so its main effect is existing and being checked by the
		// main skill Pugilist
    }
}