﻿// Decompiled with JetBrains decompiler
// Type: monogameJam.SimpleSprite
// Assembly: monogameJam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A56AFD03-F9CC-4354-BD49-E5DE8D292E54
// Assembly location: C:\Users\Admin\Desktop\RE\FootStep\monogameJam.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

#nullable disable
namespace monogameJam
{
  public class SimpleSprite : DrawableGameComponent
  {
    protected Element2D parent;
    protected SpriteBatch spriteBatch;
    protected Texture2D sprite;
    protected string texture;
    protected Vector2 position;
    protected Vector2 taille;
    protected Rectangle tailleSprite;
    protected int order;
    protected bool toXML = true;

    public Element2D Parent
    {
      get => this.parent;
      set => this.parent = value;
    }

    public SpriteBatch SpriteBatch
    {
      get => this.spriteBatch;
      set => this.spriteBatch = value;
    }

    public Texture2D Sprite
    {
      get => this.sprite;
      set => this.sprite = value;
    }

    public string Texture
    {
      get => this.texture;
      set => this.texture = value;
    }

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

    public int Order
    {
      get => this.order;
      set => this.order = value;
    }

    public bool ToXML
    {
      get => this.toXML;
      set => this.toXML = value;
    }

    public SimpleSprite(
      Element2D parent,
      string texture,
      Vector2 taille,
      Vector2 position,
      int order = 1)
      : base((Game) Program.game)
    {
      this.parent = parent;
      this.texture = texture;
      this.taille = taille;
      this.order = 1;
      this.AddGame();
    }

    public override void Initialize() => base.Initialize();

    protected override void LoadContent()
    {
      this.spriteBatch = new SpriteBatch(Program.game.GraphicsDevice);
      this.sprite = Program.game.Content.Load<Texture2D>(this.texture);
      base.LoadContent();
      if (!(this.tailleSprite == Rectangle.Empty))
        return;
      this.tailleSprite = new Rectangle(0, 0, this.sprite.Width, this.sprite.Height);
    }

    public override void Draw(GameTime gameTime)
    {
      this.spriteBatch.Begin();
      this.spriteBatch.Draw(this.sprite, new Rectangle((int) ((double) this.position.X + (double) this.parent.Position.X - (double) Program.game.Joueur.Position.X - (double) Program.game.Joueur.Taille.X / 2.0 + (double) (this.Game.GraphicsDevice.PresentationParameters.BackBufferWidth / 2)), (int) ((double) this.position.Y + (double) this.parent.Position.Y - (double) Program.game.Joueur.Position.Y - (double) Program.game.Joueur.Taille.Y / 2.0 + (double) (this.Game.GraphicsDevice.PresentationParameters.BackBufferHeight / 2)), (int) this.taille.X, (int) this.taille.Y), new Rectangle?(this.tailleSprite), Color.White);
      this.spriteBatch.End();
      base.Draw(gameTime);
    }

    protected void AddGame() => Program.game.Components.Add((IGameComponent) this);

    public virtual void Remove()
    {
      this.Dispose();
      Program.game.Components.Remove((IGameComponent) this);
    }
  }
}