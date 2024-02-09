// Decompiled with JetBrains decompiler
// Type: monogameJam.ATH
// Assembly: monogameJam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A56AFD03-F9CC-4354-BD49-E5DE8D292E54
// Assembly location: C:\Users\Admin\Desktop\RE\FootStep\monogameJam.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

#nullable disable
namespace monogameJam
{
  public class ATH : DrawableGameComponent
  {
    protected ATH parent;
    protected Vector2 position;
    protected Vector2 taille;
    protected Ancre ancre;
    protected SpriteBatch spriteBatch;
    protected int order;

    public ATH(ATH parent, Vector2 position, Vector2 taille, Ancre ancre = Ancre.topleft)
      : base((Game) Program.game)
    {
      this.parent = parent;
      this.position = position;
      this.taille = taille;
      this.ancre = ancre;
      if ((double) taille.X != 0.0 && (double) taille.Y != 0.0)
        return;
      this.taille = parent == null ? new Vector2((float) Program.game.GraphicsDevice.PresentationParameters.BackBufferWidth, (float) Program.game.GraphicsDevice.PresentationParameters.BackBufferHeight) : parent.taille;
    }

    protected override void LoadContent()
    {
      base.LoadContent();
      this.order = this.parent != null ? this.parent.order + 1 : 0;
      Debug.WriteLine((object) this.ancre);
      this.spriteBatch = new SpriteBatch(this.Game.GraphicsDevice);
      this.DrawOrder = Program.game.GraphicsDevice.PresentationParameters.BackBufferHeight * 10 + this.order * 10;
      if (this.parent == null)
        return;
      Debug.WriteLine(this.parent.ToString() + " " + (object) this.parent.order + " " + (object) this + " " + (object) this.DrawOrder);
    }

    public Rectangle realPos()
    {
      Rectangle rectangle1 = this.parent == null ? new Rectangle(0, 0, Program.game.GraphicsDevice.PresentationParameters.BackBufferWidth, Program.game.GraphicsDevice.PresentationParameters.BackBufferHeight) : this.parent.realPos();
      Rectangle rectangle2;
      switch (this.ancre)
      {
        case Ancre.top:
          rectangle2 = new Rectangle((int) ((double) (rectangle1.X + rectangle1.Width / 2) - (double) this.taille.X / 2.0 + (double) this.position.X), (int) ((double) rectangle1.Y + (double) this.position.Y), (int) this.taille.X, (int) this.taille.Y);
          break;
        case Ancre.left:
          rectangle2 = new Rectangle((int) ((double) rectangle1.X + (double) this.position.X), (int) ((double) (rectangle1.Y + rectangle1.Height / 2) - (double) this.taille.Y / 2.0 + (double) this.position.Y), (int) this.taille.X, (int) this.taille.Y);
          break;
        case Ancre.right:
          rectangle2 = new Rectangle((int) ((double) (rectangle1.X + rectangle1.Width) - (double) this.taille.X + (double) this.position.X), (int) ((double) (rectangle1.Y + rectangle1.Height / 2) - (double) this.taille.Y / 2.0 + (double) this.position.Y), (int) this.taille.X, (int) this.taille.Y);
          break;
        case Ancre.bottom:
          rectangle2 = new Rectangle((int) ((double) (rectangle1.X + rectangle1.Width / 2) - (double) this.taille.X / 2.0 + (double) this.position.X), (int) ((double) (rectangle1.Y + rectangle1.Height) - (double) this.taille.Y + (double) this.position.Y), (int) this.taille.X, (int) this.taille.Y);
          break;
        case Ancre.topright:
          rectangle2 = new Rectangle((int) ((double) (rectangle1.X + rectangle1.Width) - (double) this.taille.X + (double) this.position.X), (int) ((double) rectangle1.Y + (double) this.position.Y), (int) this.taille.X, (int) this.taille.Y);
          break;
        case Ancre.bottomleft:
          rectangle2 = new Rectangle((int) ((double) rectangle1.X + (double) this.position.X), (int) ((double) (rectangle1.Y + rectangle1.Height) - (double) this.taille.Y + (double) this.position.Y), (int) this.taille.X, (int) this.taille.Y);
          break;
        case Ancre.bottomright:
          rectangle2 = new Rectangle((int) ((double) (rectangle1.X + rectangle1.Width) - (double) this.taille.X + (double) this.position.X), (int) ((double) (rectangle1.Y + rectangle1.Height) - (double) this.taille.Y + (double) this.position.Y), (int) this.taille.X, (int) this.taille.Y);
          break;
        case Ancre.center:
          rectangle2 = new Rectangle((int) ((double) (rectangle1.X + rectangle1.Width / 2) - (double) this.taille.X / 2.0 + (double) this.position.X), (int) ((double) (rectangle1.Y + rectangle1.Height / 2) - (double) this.taille.Y / 2.0 + (double) this.position.Y), (int) this.taille.X, (int) this.taille.Y);
          break;
        default:
          rectangle2 = new Rectangle((int) ((double) rectangle1.X + (double) this.position.X), (int) ((double) rectangle1.Y + (double) this.position.Y), (int) this.taille.X, (int) this.taille.Y);
          break;
      }
      return rectangle2;
    }

    protected void AddGame() => Program.game.Components.Add((IGameComponent) this);

    public virtual void Remove() => Program.game.Components.Remove((IGameComponent) this);
  }
}
