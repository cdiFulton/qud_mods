// Decompiled with JetBrains decompiler
// Type: XRL.World.Parts.Effects.EmptyTheClips
// Assembly: Assembly-CSharp, Version=2.0.6418.36746, Culture=neutral, PublicKeyToken=null
// MVID: 725A3C01-28B8-4D4A-819C-CDDCD7556A88
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Caves of Qud\CoQ_Data\Managed\Assembly-CSharp.dll

using System;
using XRL.Core;
using XRL.Messages;

namespace XRL.World.Parts.Effects
{
  [Serializable]
  public class HundredFists : Effect
  {
    public HundredFists()
    {
    }

    public HundredFists(int _Duration)
    {
      this.Duration = _Duration;
      this.DisplayName = "Hundred Fists";
    }

    public override string GetDescription()
    {
      return "Hundred Fists";
    }

    public override bool Apply(GameObject Object)
    {
      if (Object.HasEffect(ModManager.ResolveType("XRL.World.Parts.Effects.HundredFists")) || !Object.FireEvent(Event.New("ApplyRunning", "Effect", (object) this)))
        return false;
      if (Object.IsPlayer())
        MessageQueue.AddPlayerMessage("Your fists flow like a mighty river.");
      return true;
    }

    public override void Remove(GameObject Object)
    {
    }

    public override void Register(GameObject Object)
    {
      Object.RegisterEffectEvent((Effect) this, "EnteredCell");
      //Object.RegisterEffectEvent((Effect) this, "FiredMissileWeapon");
	  // Find one for melee attack
	  // Actually, we'll probably do this by using the "SpendEnergy" hook
      Object.RegisterEffectEvent((Effect) this, "BeforeTakeAction");
    }

    public override void Unregister(GameObject Object)
    {
      Object.UnregisterEffectEvent((Effect) this, "EnteredCell");
      Object.UnregisterEffectEvent((Effect) this, "FiredMissileWeapon");
      Object.UnregisterEffectEvent((Effect) this, "BeforeTakeAction");
    }

    public override bool Render(Cell.RenderEvent E)
    {
      if (this.Duration > 0)
      {
        int num = XRLCore.CurrentFrame % 60;
        if (num > 45 && num < 55)
        {
          E.Tile = (string) null;
          E.AddParameter("RenderString", string.Empty + (object) '\x001A');
          E.AddParameter("ColorString", "&B");
        }
      }
      return true;
    }

    public override bool FireEvent(Event E)
    {
		// Change to only tick duration down on actual turns
		if (!(E.ID == "BeforeTakeAction"))
			return true;
		--this.Duration;
		return true;
    }
  }
}
