// Decompiled with JetBrains decompiler
// Type: monogameJam.Etat
// Assembly: monogameJam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A56AFD03-F9CC-4354-BD49-E5DE8D292E54
// Assembly location: C:\Users\Admin\Desktop\RE\FootStep\monogameJam.exe

using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;

#nullable disable
namespace monogameJam
{
  public abstract class Etat
  {
    protected Joueur joueur;
    public Direction direction;

    public Joueur Joueur
    {
      get => this.joueur;
      set => this.joueur = value;
    }

    public Etat()
    {
      this.joueur = Program.game.Joueur;
      this.Joueur.Vitesse = 4f;
      this.direction = Direction.Center;
    }

    public virtual void Deplacement(Direction direction)
    {
      this.direction = direction;
      switch (direction)
      {
        case Direction.Top:
          this.joueur.Position = new Vector2(this.joueur.Position.X, this.joueur.Position.Y - this.joueur.Velocite);
          break;
        case Direction.Bottom:
          this.joueur.Position = new Vector2(this.joueur.Position.X, this.joueur.Position.Y + this.joueur.Velocite);
          break;
        case Direction.Left:
          this.joueur.Position = new Vector2(this.joueur.Position.X - this.joueur.Velocite, this.joueur.Position.Y);
          break;
        case Direction.Right:
          this.joueur.Position = new Vector2(this.joueur.Position.X + this.joueur.Velocite, this.joueur.Position.Y);
          break;
        case Direction.LeftTop:
          this.joueur.Position = new Vector2(this.joueur.Position.X - 0.7f * this.joueur.Velocite, this.joueur.Position.Y - 0.7f * this.joueur.Velocite);
          break;
        case Direction.LeftBottom:
          this.joueur.Position = new Vector2(this.joueur.Position.X - 0.7f * this.joueur.Velocite, this.joueur.Position.Y + 0.7f * this.joueur.Velocite);
          break;
        case Direction.RightTop:
          this.joueur.Position = new Vector2(this.joueur.Position.X + 0.7f * this.joueur.Velocite, this.joueur.Position.Y - 0.7f * this.joueur.Velocite);
          break;
        case Direction.RightBottom:
          this.joueur.Position = new Vector2(this.joueur.Position.X + 0.7f * this.joueur.Velocite, this.joueur.Position.Y + 0.7f * this.joueur.Velocite);
          break;
      }
    }

    public virtual void Sauter(Direction direction)
    {
      this.Deplacement(direction);
      if (!this.joueur.PeutSauter)
        return;
      this.joueur.Etat = (Etat) new Saut();
      this.joueur.PeutSauter = false;
    }

    public virtual void Sauter(Direction direction, int nbSaut)
    {
      this.Deplacement(direction);
      this.joueur.Etat = (Etat) new Saut(nbSaut);
    }

    public virtual void ActionObjet()
    {
      Composant c = (Composant) null;
      Rectangle rectangle1 = new Rectangle(this.Joueur.Hitbox().X - 20, this.Joueur.Hitbox().Y - 20, this.Joueur.Hitbox().Width + 40, this.Joueur.Hitbox().Height + 40);
      for (int index = 0; c == null && index < Program.game.Carte.Composants.Count; ++index)
      {
        if ((Program.game.Carte.Composants[index].Type == Type.TPoussable || Program.game.Carte.Composants[index].Type == Type.TPortable || Program.game.Carte.Composants[index].Type == Type.TBouteille) && Program.game.Carte.Composants[index].Afficher && this.Joueur != Program.game.Carte.Composants[index] && rectangle1.Intersects(Program.game.Carte.Composants[index].Hitbox()))
          c = Program.game.Carte.Composants[index];
      }
      if (c != null && c.Type == Type.TPoussable)
      {
        Rectangle rectangle2 = Rectangle.Intersect(c.Hitbox(), rectangle1);
        if (rectangle2.Width <= c.Hitbox().Width * 80 / 100 && rectangle2.Height <= c.Hitbox().Height * 80 / 100)
          return;
        Debug.WriteLine((object) rectangle2);
        if (this.Joueur.Hitbox().X > c.Hitbox().X && rectangle2.Height > rectangle2.Width)
          this.Joueur.DirectionJoueur = DirectionJoueur.gauche;
        else if (this.Joueur.Hitbox().X < c.Hitbox().X && rectangle2.Height > rectangle2.Width)
          this.Joueur.DirectionJoueur = DirectionJoueur.droite;
        else if (this.Joueur.Hitbox().Y > c.Hitbox().Y && rectangle2.Height < rectangle2.Width)
          this.Joueur.DirectionJoueur = DirectionJoueur.haut;
        else if (this.Joueur.Hitbox().Y < c.Hitbox().Y && rectangle2.Height < rectangle2.Width)
          this.Joueur.DirectionJoueur = DirectionJoueur.bas;
        this.joueur.ActionObjet = true;
        this.Attraper(c);
      }
      else
      {
        if (c == null || c.Type != Type.TBouteille)
          return;
        this.Attraper(c);
      }
    }

    public virtual void Attraper(Composant c)
    {
      if (c.Type == Type.TPortable)
        this.Joueur.Etat = (Etat) new Porter(c);
      else if (c.Type == Type.TPoussable)
        this.Joueur.Etat = (Etat) new Pousser(c);
      else if (c.Type == Type.TBouteille && c.BouteilleImage == null && this is Standard)
      {
        c.BouteilleTexte(true);
        this.joueur.PeutBouger = -1;
      }
      else
      {
        if (c.Type != Type.TBouteille || c.BouteilleImage == null)
          return;
        c.BouteilleTexte(false);
        this.joueur.PeutBouger = 0;
      }
    }

    public virtual void Lacher() => this.joueur.Etat = (Etat) new Standard();

    public virtual void Jeter() => this.joueur.Etat = (Etat) new Standard();

    public virtual void Mourir() => this.joueur.Etat = (Etat) new Mort();

    public virtual void Restart()
    {
    }

    public virtual void test() => Debug.WriteLine("a test");

    public virtual void setReady() => this.joueur.Etat = (Etat) new Standard();

    public virtual void monMenu() => this.joueur.Etat = (Etat) new Menu();

    public void Reinitialiser() => this.joueur.Etat = (Etat) new Standard();

    public virtual void replacer(Composant c)
    {
      Vector2 vector2 = this.Joueur.Position - this.Joueur.LastPosition;
      this.joueur.Position = new Vector2(this.joueur.Position.X, this.joueur.Position.Y - vector2.Y);
      if (!this.joueur.Hitbox().Intersects(c.Hitbox()))
        return;
      this.joueur.Position = new Vector2(this.joueur.Position.X - vector2.X, this.joueur.Position.Y + vector2.Y);
    }
  }
}
