// Decompiled with JetBrains decompiler
// Type: monogameJam.Personnage
// Assembly: monogameJam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A56AFD03-F9CC-4354-BD49-E5DE8D292E54
// Assembly location: C:\Users\Admin\Desktop\RE\FootStep\monogameJam.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;

#nullable disable
namespace monogameJam
{
  public abstract class Personnage : Composant
  {
    private int nbpas;
    protected float vitesse;
    protected float velocite;
    protected Vector2 lastPosition;
    protected string modeleEmpreinte;
    protected List<Empreinte> souvenir;
    protected DirectionJoueur directionJoueur;
    protected bool deplacer = false;

    public float Vitesse
    {
      get => this.vitesse;
      set => this.vitesse = value;
    }

    public Vector2 LastPosition
    {
      get => this.lastPosition;
      set => this.lastPosition = value;
    }

    public string ModeleEmpreinte => this.modeleEmpreinte;

    public List<Empreinte> Souvenir
    {
      get => this.souvenir;
      set => this.souvenir = value;
    }

    public int Nbpas
    {
      get => this.nbpas;
      set => this.nbpas = value;
    }

    public DirectionJoueur DirectionJoueur
    {
      get => this.directionJoueur;
      set => this.directionJoueur = value;
    }

    public float Velocite
    {
      get => this.velocite;
      set => this.velocite = value;
    }

    public bool Deplacer
    {
      get => this.deplacer;
      set => this.deplacer = value;
    }

    public Personnage(
      string nom,
      Vector2 position,
      Vector2 taille,
      string texture,
      Rectangle collision,
      Type typeComposant,
      string classe = "Personnage")
      : base(nom, position, taille, texture, collision, typeComposant, classe)
    {
      this.nbpas = 0;
      this.sprites.Add((SimpleSprite) new SpriteComposant((Composant) this, "ombre", new Vector2((float) collision.Width, (float) collision.Height), new Vector2((float) collision.X, (float) collision.Y), 0, 0.3f));
      this.souvenir = new List<Empreinte>();
      this.vitesse = 1f;
      this.modeleEmpreinte = "empreinte";
      this.lastPosition = this.position;
      this.velocite = 0.0f;
    }

    public Personnage(
      string nom,
      Vector2 position,
      Vector2 taille,
      string texture,
      Rectangle collision,
      Type typeComposant,
      int[,] indexSprite,
      Rectangle tailleSprite,
      string classe = "Personnage")
      : base(nom, position, taille, texture, collision, typeComposant, indexSprite, tailleSprite, classe)
    {
      this.nbpas = 0;
      this.sprites.Add((SimpleSprite) new SpriteComposant((Composant) this, "ombre", new Vector2((float) collision.Width, (float) collision.Height), new Vector2((float) collision.X, (float) collision.Y), 0, 0.3f));
      this.souvenir = new List<Empreinte>();
      this.vitesse = 1f;
      this.modeleEmpreinte = "empreinte";
      this.lastPosition = this.position;
      this.velocite = 0.0f;
    }

    public override void Update(GameTime gametime)
    {
      if (this.Afficher || this is Joueur)
        this.ActionCollision(Composant.TryCollision(this.Hitbox()));
      base.Update(gametime);
      if (this.nbpas >= 3)
      {
        this.nbpas = 0;
        this.AddEmpreinte(new Empreinte(this));
        if (Program.game.Joueur.Etat is DelaiSaut)
          ((DelaiSaut) Program.game.Joueur.Etat).Waiting();
      }
      this.lastPosition = this.position;
    }

    public void AddEmpreinte(Empreinte e)
    {
      this.souvenir.Add(e);
      Program.game.Components.Add((IGameComponent) e);
    }

    public virtual void ActionCollision(List<Composant> touchent)
    {
      bool flag = false;
      float num = 0.0f;
      foreach (Composant c in touchent)
      {
        if (c != this)
        {
          if (c.Solid && this.Solid)
          {
            if (this.Hitbox().Intersects(c.Hitbox()))
              this.replacer(c);
          }
          else if ((object) c.Type is Type.Trou)
          {
            if ((double) this.hauteur == 0.0)
              num += (float) (Rectangle.Intersect(this.Hitbox(), c.Hitbox()).Width * Rectangle.Intersect(this.Hitbox(), c.Hitbox()).Height);
          }
          else if ((object) c.Type is Type.TIllot)
            flag = true;
        }
      }
      if (flag || (double) num * 2.0 <= (double) (this.Hitbox().Width * this.Hitbox().Height))
        return;
      this.tomber();
    }

    protected virtual void replacer(Composant c)
    {
      Vector2 vector2 = this.position - this.lastPosition;
      this.position.Y -= vector2.Y;
      if (!this.Hitbox().Intersects(c.Hitbox()))
        return;
      this.position.Y += vector2.Y;
      this.position.X -= vector2.X;
    }

    protected virtual void tomber() => this.Remove();

    public override void Remove()
    {
      while (this.souvenir.Count > 0)
      {
        this.souvenir[0].Remove();
        this.souvenir.Remove(this.souvenir[0]);
      }
      base.Remove();
    }
  }
}
