// Decompiled with JetBrains decompiler
// Type: monogameJam.ATHComposite
// Assembly: monogameJam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A56AFD03-F9CC-4354-BD49-E5DE8D292E54
// Assembly location: C:\Users\Admin\Desktop\RE\FootStep\monogameJam.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;

#nullable disable
namespace monogameJam
{
  public class ATHComposite : ATH
  {
    protected List<ATH> children;

    public ATHComposite(ATH parent, Vector2 position, Vector2 taille, Ancre ancre = Ancre.topleft)
      : base(parent, position, taille, ancre)
    {
      this.children = new List<ATH>();
    }

    public List<ATH> Children
    {
      get => this.children;
      set => this.children = value;
    }

    public void add(ATH ath)
    {
      this.children.Add(ath);
      Program.game.Components.Add((IGameComponent) ath);
    }

    public void remove(ATH ath) => this.children.Remove(ath);

    public override void Remove()
    {
      while (this.Children.Count > 0)
      {
        this.Children[0].Remove();
        this.remove(this.Children[0]);
      }
      Program.game.Components.Remove((IGameComponent) this);
      base.Remove();
    }
  }
}
