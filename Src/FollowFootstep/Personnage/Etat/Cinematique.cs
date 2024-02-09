// Cinematique

using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;

#nullable disable
namespace GameManager
{
  internal class Cinematique : Etat
  {
    public void sansLesMains()
    {
      if (!this.joueur.ReachFather)
      {
        if ((double) this.Joueur.Position.X > 5090.0)
        {
          this.joueur.DirectionJoueur = DirectionJoueur.gauche;
          this.joueur.TypeSprite = 2;
          this.joueur.Position = new Vector2(this.joueur.Position.X - this.joueur.Velocite,
              this.joueur.Position.Y);
        }
        else if ((double) this.Joueur.Position.X < 5080.0)
        {
          this.joueur.DirectionJoueur = DirectionJoueur.droite;
          this.joueur.TypeSprite = 4;
          this.joueur.Position = new Vector2(this.joueur.Position.X + this.joueur.Velocite, 
              this.joueur.Position.Y);
        }
        else if ((double) this.joueur.Position.Y > 5200.0)
        {
          this.joueur.DirectionJoueur = DirectionJoueur.haut;
          this.joueur.TypeSprite = 1;
          this.joueur.Velocite = 5f;
          this.joueur.Position = new Vector2(this.joueur.Position.X,
              this.joueur.Position.Y - this.joueur.Velocite);
        }
        else
        {
          if ((double) this.joueur.Position.Y <= 4819.0)
            return;
          this.joueur.DirectionJoueur = DirectionJoueur.haut;
          this.joueur.TypeSprite = 1;
          this.joueur.Velocite = 2f;
          this.joueur.Position = new Vector2(this.joueur.Position.X,
              this.joueur.Position.Y - this.joueur.Velocite);
        }
      }
      else if ((double) this.joueur.Position.Y < 5600.0)
      {
        this.joueur.DirectionJoueur = DirectionJoueur.haut;
        this.joueur.TypeSprite = 3;
        this.joueur.Velocite = 4f;
        this.joueur.Position = new Vector2(this.joueur.Position.X, 
            this.joueur.Position.Y + this.joueur.Velocite);
        Debug.WriteLine(this.joueur.Velocite);
      }
    }

    public override void Deplacement(Direction direction)
    {
    }

    public override void Sauter(Direction direction)
    {
    }

    public override void Sauter(Direction direction, int nbSaut)
    {
    }

    public override void ActionObjet()
    {
    }

    public override void Attraper(Composant c)
    {
    }

    public override void replacer(Composant c)
    {
    }
  }
}
