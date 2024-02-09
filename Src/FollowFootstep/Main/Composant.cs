// Composant

using Microsoft.Xna.Framework;
using System.Collections.Generic;

#nullable disable
namespace GameManager
{
  public class Composant : Element2D
  {
    protected string nom;
    protected Rectangle collision;
    private bool afficher = false;
    protected int typeSprite;
    protected bool solid;
    protected Type type;
    protected float hauteur;
    protected ATHComposite bouteilleImage;

    public Type Type
    {
      get => this.type;
      set => this.type = value;
    }

    public bool Solid
    {
      get => this.solid;
      set => this.solid = value;
    }

    public string Nom => this.nom;

    public Rectangle Collision
    {
      get => this.collision;
      set => this.collision = value;
    }

    public float Hauteur
    {
      get => this.hauteur;
      set => this.hauteur = value;
    }

    public int TypeSprite
    {
      get => this.typeSprite;
      set => this.typeSprite = value;
    }

    public bool Afficher
    {
      get => this.afficher;
      set => this.afficher = value;
    }

    public ATHComposite BouteilleImage
    {
      get => this.bouteilleImage;
      set => this.bouteilleImage = value;
    }

    public Composant(
      string nom,
      Vector2 position,
      Vector2 taille,
      string texture,
      Type typeComposant,
      string classe = "Composant")
      : base(position, taille, texture, classe)
    {
      this.sprites = new List<SimpleSprite>();
      classe = "Element2D";
      this.solid = true;
      this.nom = nom;
      this.collision = new Rectangle(0, 0, (int) this.taille.X, (int) this.taille.Y);
      this.type = typeComposant;
      this.AddSprite((SimpleSprite) new SpriteComposant(this, texture, taille, Vector2.Zero));
      this.typeSprite = 1;
    }

    public Composant(
      string nom,
      Vector2 position,
      Vector2 taille,
      string texture,
      Rectangle collision,
      Type typeComposant,
      string classe = "Composant")
      : base(position, taille, texture, classe)
    {
      this.sprites = new List<SimpleSprite>();
      classe = "Element2D";
      this.solid = true;
      this.nom = nom;
      this.collision = collision;
      this.type = typeComposant;
      this.AddSprite((SimpleSprite) new SpriteComposant(this, texture, taille, Vector2.Zero));
      this.typeSprite = 1;
    }

    public Composant(
      string nom,
      Vector2 position,
      Vector2 taille,
      string texture,
      Rectangle collision,
      Type typeComposant,
      int[,] indexSprite,
      Rectangle tailleSprite,
      string classe = "Composant")
      : base(position, taille, texture, classe)
    {
      this.sprites = new List<SimpleSprite>();
      classe = "Element2D";
      this.solid = true;
      this.nom = nom;
      this.collision = collision;
      this.type = typeComposant;
      this.AddSprite((SimpleSprite) new SpriteComposant(this, texture, taille, Vector2.Zero, tailleSprite, indexSprite));
      this.typeSprite = 1;
    }

    public Rectangle Hitbox()
    {
      return new Rectangle((int) ((double) this.position.X + (double) this.collision.X), (int) ((double) this.position.Y + (double) this.collision.Y), this.collision.Width, this.collision.Height);
    }

    public static List<Composant> TryCollision(Rectangle hitbox)
    {
      List<Composant> composantList = new List<Composant>();
      foreach (Composant composant in Game1.game.Carte.Composants)
      {
        if (composant.Afficher && hitbox.Intersects(composant.Hitbox()))
          composantList.Add(composant);
      }
      return composantList;
    }

    public virtual void BouteilleTexte(bool open)
    {
      if (this.nom == "bouteille1" & open)
      {
         this.bouteilleImage = (ATHComposite) new ATHCompositeImage((ATH) null, 
            new Vector2(0.0f, 0.0f), 
            new Vector2(700f, 300f), "map", Ancre.center);
        Game1.game.Components.Add((IGameComponent) this.bouteilleImage);
        this.bouteilleImage.add((ATH) new ATHFeuilleText((ATH) this.bouteilleImage, 
            new Vector2(0.0f, -100f), new Vector2(0.0f, 0.0f), "Hey honey, It's dad. I m seriously injured ", 
            new Color(0, 0, 0), 2f, Ancre.center));
        this.bouteilleImage.add((ATH) new ATHFeuilleText((ATH) this.bouteilleImage, 
            new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f), "somewhere dangerous and I need your help ! ", 
            new Color(0, 0, 0), 2f, Ancre.center));
        this.bouteilleImage.add((ATH) new ATHFeuilleText((ATH) this.bouteilleImage,
            new Vector2(0.0f, 100f), new Vector2(0.0f, 0.0f), "Please bring me the medkit and be careful !", 
            new Color(0, 0, 0), 2f, Ancre.center));
      }
      else
      {
        if (open)
          return;
        this.bouteilleImage.Remove();
        this.bouteilleImage = (ATHComposite) null;
      }
    }
  }
}
