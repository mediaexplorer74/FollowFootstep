// Element2D

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

#nullable disable
namespace GameManager
{
  public class Element2D : DrawableGameComponent
  {
    private static List<Texture2D> texture2Ds = new List<Texture2D>();
    protected static SpriteBatch spriteBatch;
    protected List<SimpleSprite> sprites;
    protected Texture2D sprite;
    protected Vector2 position;
    protected Vector2 taille;
    protected string texture;
    protected string classe;

    public Vector2 Position
    {
      get => this.position;
      set => this.position = value;
    }

    public Vector2 Taille
    {
      get => this.taille;
      set => this.taille = value;
    }

    public List<SimpleSprite> Sprites
    {
      get => this.sprites;
      set => this.sprites = value;
    }

    public string Classe
    {
      get => this.classe;
      set => this.classe = value;
    }

    public Element2D(string classe = "Element2D")
      : base((Game) Game1.game)
    {
      this.classe = classe;
      this.position = new Vector2(0.0f, 0.0f);
      this.sprites = new List<SimpleSprite>();
      this.texture = "map";
      this.AddGame();
    }

    public Element2D(Vector2 taille, string texture, string classe = "Element2D")
      : base((Game) Game1.game)
    {
      this.classe = classe;
      this.position = new Vector2(0.0f, 0.0f);
      this.sprites = new List<SimpleSprite>();
      this.texture = texture;
      this.taille = taille;
      this.AddGame();
    }

    public Element2D(Vector2 position, Vector2 taille, string texture, string classe = "Element2D")
      : base((Game) Game1.game)
    {
      this.classe = classe;
      this.sprites = new List<SimpleSprite>();
      this.texture = texture;
      this.taille = taille;
      this.position = position;
      this.AddGame();
    }

    public Element2D(float x, float y, Vector2 taille, string texture, string classe = "Element2D")
      : base((Game) Game1.game)
    {
      this.classe = classe;
      this.sprites = new List<SimpleSprite>();
      this.texture = texture;
      this.taille = taille;
      this.position = new Vector2(x, y);
      this.AddGame();
    }

        public void AddSprite(SimpleSprite sprite)
        {
            this.sprites.Add(sprite);
        }

        public void RemoveSprite(SimpleSprite sprite)
        {
            this.sprites.Remove(sprite);
        }

        public override void Initialize() => base.Initialize();

    protected override void LoadContent()
    {
      if (Element2D.spriteBatch == null)
        Element2D.spriteBatch = new SpriteBatch(Game1.game.GraphicsDevice);
      this.sprite = Element2D.creerTexture(this.texture);
      base.LoadContent();
    }

    private static Texture2D creerTexture(string file)
    {
      for (int index = 0; index < Element2D.texture2Ds.Count; ++index)
      {
        if (Element2D.texture2Ds[index].Name == file)
          return Element2D.texture2Ds[index];
      }
      Texture2D texture2D = Game1.game.Content.Load<Texture2D>(file);
      Element2D.texture2Ds.Add(texture2D);
      return texture2D;
    }

    protected override void UnloadContent()
    {
      this.sprite.Dispose();
      base.UnloadContent();
    }

    protected void AddGame()
    {
            //
    }

    public virtual void Remove()
    {
      Game1.game.Components.Remove((IGameComponent) this);
      foreach (SimpleSprite sprite in this.sprites)
      {
        Game1.game.Components.Remove((IGameComponent)sprite);
      }
    }
  }
}
