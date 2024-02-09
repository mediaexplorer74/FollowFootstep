// ATH

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

#nullable disable
namespace GameManager
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
      : base((Game) Game1.game)
    {
      this.parent = parent;
      this.position = position;
      this.taille = taille;
      this.ancre = ancre;
      
      if ((double) taille.X != 0.0 && (double) taille.Y != 0.0)
        return;

      //RnD
      //  this.taille = parent == null ? new Vector2( (float) Game1.game.GraphicsDevice.PresentationParameters.BackBufferWidth, 
      //           (float) Game1.game.GraphicsDevice.PresentationParameters.BackBufferHeight )
      //           : parent.taille;
      this.taille = parent == null 
                        ? new Vector2( 800/*1600*/, 480/*900*/ ) 
                        : parent.taille;

   }//ATH

    protected override void LoadContent()
    {
      base.LoadContent();
      this.order = this.parent != null ? this.parent.order + 1 : 0;
      Debug.WriteLine((object) this.ancre);
      this.spriteBatch = new SpriteBatch(this.Game.GraphicsDevice);
      this.DrawOrder = Game1.game.GraphicsDevice.PresentationParameters.BackBufferHeight * 10 + this.order * 10;
      
      if (this.parent == null)
        return;

      Debug.WriteLine(this.parent.ToString() + " " + (object) this.parent.order + " " 
          + (object) this + " " + (object) this.DrawOrder);
    }

    public Rectangle realPos()
    {
      Rectangle rectangle1 = this.parent == null
                ? new Rectangle(0,
                                0, 
                                Game1.game.GraphicsDevice.PresentationParameters.BackBufferWidth, 
                                Game1.game.GraphicsDevice.PresentationParameters.BackBufferHeight) 
                : this.parent.realPos();
      Rectangle rectangle2;
      switch (this.ancre)
      {
        case Ancre.top:
          rectangle2 = new Rectangle((int) ((double) (rectangle1.X + rectangle1.Width / 2) 
              - (double) this.taille.X / 2.0 + (double) this.position.X),
              (int) ((double) rectangle1.Y + (double) this.position.Y), (int) this.taille.X, (int) this.taille.Y);
          break;
        case Ancre.left:
          rectangle2 = new Rectangle((int) ((double) rectangle1.X + (double) this.position.X),
              (int) ((double) (rectangle1.Y + rectangle1.Height / 2) - (double) this.taille.Y / 2.0
              + (double) this.position.Y),
              (int) this.taille.X, (int) this.taille.Y);
          break;
        case Ancre.right:
          rectangle2 = new Rectangle((int) ((double) (rectangle1.X + rectangle1.Width) - 
              (double) this.taille.X + (double) this.position.X),
              (int) ((double) (rectangle1.Y + rectangle1.Height / 2) - (double) this.taille.Y / 2.0
              + (double) this.position.Y),
              (int) this.taille.X, (int) this.taille.Y);
          break;
        case Ancre.bottom:
          rectangle2 = new Rectangle((int) ((double) (rectangle1.X + rectangle1.Width / 2) 
              - (double) this.taille.X / 2.0 + (double) this.position.X),
              (int) ((double) (rectangle1.Y + rectangle1.Height) - (double) this.taille.Y + (double) this.position.Y),
              (int) this.taille.X, (int) this.taille.Y);
          break;
        case Ancre.topright:
          rectangle2 = new Rectangle((int) ((double) (rectangle1.X + rectangle1.Width) 
              - (double) this.taille.X + (double) this.position.X),
              (int) ((double) rectangle1.Y + (double) this.position.Y), (int) this.taille.X, (int) this.taille.Y);
          break;
        case Ancre.bottomleft:
          rectangle2 = new Rectangle((int) ((double) rectangle1.X + (double) this.position.X),
              (int) ((double) (rectangle1.Y + rectangle1.Height) - (double) this.taille.Y + (double) this.position.Y),
              (int) this.taille.X, (int) this.taille.Y);
          break;
        case Ancre.bottomright:
          rectangle2 = new Rectangle((int) ((double) (rectangle1.X + rectangle1.Width)
              - (double) this.taille.X + (double) this.position.X),
              (int) ((double) (rectangle1.Y + rectangle1.Height) - (double) this.taille.Y
              + (double) this.position.Y),
              (int) this.taille.X, (int) this.taille.Y);
          break;
        case Ancre.center:
          rectangle2 = new Rectangle((int) ((double) (rectangle1.X + rectangle1.Width / 2)
              - (double) this.taille.X / 2.0 + (double) this.position.X), 
              (int) ((double) (rectangle1.Y + rectangle1.Height / 2)
              - (double) this.taille.Y / 2.0 + (double) this.position.Y),
              (int) this.taille.X, (int) this.taille.Y);
          break;
        default:

          rectangle2 = new Rectangle((int) ((double) rectangle1.X + (double) this.position.X),
              (int) ((double) rectangle1.Y + (double) this.position.Y),
              (int) this.taille.X, (int) this.taille.Y);
          break;
      }
      return rectangle2;
    }

    protected void AddGame()
    {
       Game1.game.Components.Add((IGameComponent)this);
    }

    public virtual void Remove()
    {
        Game1.game.Components.Remove((IGameComponent)this);
    }
  }
}
