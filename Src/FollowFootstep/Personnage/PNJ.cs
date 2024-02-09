// Decompiled with JetBrains decompiler
// Type: GameManager.PNJ
// Assembly: GameManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A56AFD03-F9CC-4354-BD49-E5DE8D292E54
// Assembly location: C:\Users\Admin\Desktop\RE\FootStep\GameManager.exe

using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;

#nullable disable
namespace GameManager
{
  internal class PNJ : Personnage
  {
    public PNJ(
      string nom,
      Vector2 position,
      Vector2 taille,
      string texture,
      Rectangle collision,
      Type typeComposant,
      string classe = "PNJ")
      : base(nom, position, taille, texture, collision, typeComposant, classe)
    {
    }

    public override void Update(GameTime gametime)
    {
      this.lastPosition = this.position;
      if (this.nom == "PapaRocher")
      {
        Debug.WriteLine("Test papa");
        Rectangle rectangle = new Rectangle(this.Hitbox().X - 800, 
            this.Hitbox().Y - 450, this.Hitbox().Width + 1600, this.Hitbox().Height + 900);

        if (Game1.game.Joueur.Hitbox().Intersects(rectangle))
          Game1.game.Joueur.Etat = (Etat) new Cinematique();
      }
      Composant.TryCollision(this.Hitbox());
      base.Update(gametime);
    }
  }
}
