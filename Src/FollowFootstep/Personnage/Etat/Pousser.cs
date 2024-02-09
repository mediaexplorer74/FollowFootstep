// Decompiled with JetBrains decompiler
// Type: GameManager.Pousser
// Assembly: GameManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A56AFD03-F9CC-4354-BD49-E5DE8D292E54
// Assembly location: C:\Users\Admin\Desktop\RE\FootStep\GameManager.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;

#nullable disable
namespace GameManager
{
  internal class Pousser : Etat
  {
    private Composant objet;
    private bool end = false;

    public Pousser(Composant c)
    {
      this.joueur.Vitesse = 2f;
      this.objet = c;
      this.objet.Solid = false;
    }

    public override void Deplacement(Direction direction)
    {
      if (this.end)
        return;
      base.Deplacement(direction);
      this.objet.Position = this.objet.Position + (this.Joueur.Position - this.Joueur.LastPosition);
      List<Composant> composantList = Composant.TryCollision(Rectangle.Union(this.joueur.Hitbox(), this.objet.Hitbox()));
      float num = 0.0f;
      foreach (Composant c in composantList)
      {
        if (c != this.joueur && c != this.objet)
        {
          if (c.Solid)
          {
            if (Rectangle.Union(this.joueur.Hitbox(), this.objet.Hitbox()).Intersects(c.Hitbox()))
              this.replacerGroupe(c);
          }
          else if ((object) c.Type is Type.Trou)
            num += (float) (Rectangle.Intersect(this.objet.Hitbox(), c.Hitbox()).Width * Rectangle.Intersect(this.objet.Hitbox(), c.Hitbox()).Height);
        }
        if ((double) num * 2.0 > (double) (this.objet.Hitbox().Width * this.objet.Hitbox().Height))
        {
          this.end = true;
          this.joueur.StopAnimation();
          this.objet.Remove();
          this.objet.Solid = true;
          Game1.game.Carte.remove(this.objet);
        }
      }
    }

    public void replacerGroupe(Composant c)
    {
      Vector2 vector2 = this.Joueur.Position - this.Joueur.LastPosition;
      this.joueur.Position = new Vector2(this.joueur.Position.X, this.joueur.Position.Y - vector2.Y);
      this.objet.Position = new Vector2(this.objet.Position.X, this.objet.Position.Y - vector2.Y);
      if (!Rectangle.Union(this.joueur.Hitbox(), this.objet.Hitbox()).Intersects(c.Hitbox()))
        return;
      this.joueur.Position = new Vector2(this.joueur.Position.X - vector2.X, this.joueur.Position.Y + vector2.Y);
      this.objet.Position = new Vector2(this.objet.Position.X - vector2.X, this.objet.Position.Y + vector2.Y);
    }

    public override void replacer(Composant c)
    {
    }

    public override void Lacher() => this.objet.Solid = true;

    public override void Sauter(Direction direction, int nbSaut)
    {
    }

    public override void ActionObjet()
    {
    }

    public override void Attraper(Composant c)
    {
    }
  }
}
