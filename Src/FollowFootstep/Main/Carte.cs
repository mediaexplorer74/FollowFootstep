// Decompiled with JetBrains decompiler
// Type: monogameJam.Carte
// Assembly: monogameJam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A56AFD03-F9CC-4354-BD49-E5DE8D292E54
// Assembly location: C:\Users\Admin\Desktop\RE\FootStep\monogameJam.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

#nullable disable
namespace monogameJam
{
  public class Carte : Element2D
  {
    private List<Composant> composants;
    public static Random aleatoire = new Random((int) DateTime.Now.Ticks);

    public List<Composant> Composants
    {
      get => this.composants;
      set => this.composants = value;
    }

    public Carte()
      : base()
    {
      this.composants = new List<Composant>();
    }

    public void DessinerCarte()
    {
    }

    public override void Update(GameTime gameTime) => base.Update(gameTime);

    public void add(Composant c)
    {
      this.composants.Add(c);
      Program.game.Components.Add((IGameComponent) c);
    }

    public void remove(Composant c) => this.composants.Remove(c);

    protected override void UnloadContent() => base.UnloadContent();

    public new void Remove()
    {
      foreach (Element2D composant in this.composants)
        composant.Remove();
      base.Remove();
    }
  }
}
