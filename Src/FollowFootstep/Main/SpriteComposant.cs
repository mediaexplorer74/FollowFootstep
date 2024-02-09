// SpriteComposant

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace GameManager
{
  internal class SpriteComposant : SimpleSprite
  {
    protected Composant parent;
    protected int[,] indexSprite;
    protected int iSprite;
    protected DateTime lastChangeDate;
    protected float opacity;
    private bool mainSprite;

    public float Opacity
    {
      get => this.opacity;
      set => this.opacity = value;
    }

    public SpriteComposant(
      Composant parent,
      string texture,
      Vector2 taille,
      Vector2 position,
      int order = 1,
      float opacity = 1f,
      bool mainSprite = true,
      bool toXML = false)
      : base((Element2D) parent, texture, taille, position, order)
    {
      this.toXML = toXML;
      this.mainSprite = mainSprite;
      this.parent = parent;
      this.position = position;
      this.iSprite = 0;
      this.lastChangeDate = DateTime.Now;
      this.indexSprite = new int[1, 1]{ { 1 } };
      this.opacity = opacity;
      this.order = order;
    }

    public SpriteComposant(
      Composant parent,
      string texture,
      Vector2 taille,
      Vector2 position,
      Rectangle tailleSprite,
      int[,] indexSprite,
      int order = 1,
      float opacity = 1f,
      bool mainSprite = true,
      bool toXML = false)
      : base((Element2D) parent, texture, taille, position, order)
    {
      this.toXML = toXML;
      this.mainSprite = mainSprite;
      this.parent = parent;
      this.position = position;
      this.tailleSprite = tailleSprite;
      this.iSprite = 0;
      this.lastChangeDate = DateTime.Now;
      this.indexSprite = indexSprite;
      this.opacity = opacity;
      this.order = order;
    }

    protected Vector2 SpritePos()
    {
      Vector2 vector2 = new Vector2(0.0f, 0.0f);
      if (this.indexSprite.Length > 1)
      {
        vector2.X = (float) (this.iSprite % (this.indexSprite.GetUpperBound(1) + 1));
        vector2.Y = ((float) this.iSprite - vector2.X) / (float) (this.indexSprite.GetUpperBound(1) + 1);
        if ((DateTime.Now - this.lastChangeDate).TotalMilliseconds > 80.0)
        {
          this.lastChangeDate = DateTime.Now;
          if (this.indexSprite.Length > 1)
            ++this.iSprite;

          //RnD
          var a = this.parent.GetType().GetElementType();//.IsSubclassOf(typeof(Personnage));

          if ((this.parent is Personnage /*|| this.parent.GetType().IsSubclassOf(typeof(Personnage))*/ ) 
            && ((Personnage) this.parent).Deplacer
            && (double) this.parent.Hauteur == 0.0)
            ++((Personnage) this.parent).Nbpas;
        }
        if (this.iSprite >= this.indexSprite.Length)
          this.iSprite = 0;
        if ((double) vector2.Y > (double) this.indexSprite.GetUpperBound(0)
                    || this.indexSprite[(int) vector2.Y, (int) vector2.X] != this.parent.TypeSprite)
        {
          this.iSprite = 0;
          vector2.X = 0.0f;
          vector2.Y = 0.0f;
          while (this.iSprite < this.indexSprite.Length && this.indexSprite[(int) vector2.Y,
              (int) vector2.X] != this.parent.TypeSprite)
          {
            ++vector2.X;
            ++this.iSprite;
            if ((double) vector2.X > (double) this.indexSprite.GetUpperBound(1))
            {
              vector2.X = 0.0f;
              ++vector2.Y;
            }
          }
        }
      }
      return vector2;
    }

    public override void Draw(GameTime gameTime)
    {
      if ("papa".Equals(this.texture) && Game1.game.Joueur.ReachFather)
      {
        float num = (float) ((5600.0 - (double) Game1.game.Joueur.Position.Y) / 781.0);
        if ((double) num <= 0.0)
          this.Remove();
        else
          this.opacity = num;
      }
      Rectangle destinationRectangle = new Rectangle((int) ((double) this.position.X
          + (double) this.parent.Position.X - (double) Game1.game.Joueur.Position.X 
          - (double) Game1.game.Joueur.Taille.X / 2.0 
          + (double) (this.Game.GraphicsDevice.PresentationParameters.BackBufferWidth / 2)), 
          (int) ((double) this.position.Y + (double) this.parent.Position.Y -
          (double) Game1.game.Joueur.Position.Y - (double) Game1.game.Joueur.Taille.Y / 2.0 
          + (double) (this.Game.GraphicsDevice.PresentationParameters.BackBufferHeight / 2)
          - (this.order > 0 ? (double) this.parent.Hauteur * 5.0 : 0.0)),
          (int) ((double) this.taille.X * (this.order > 1 ? 1.0 + (double) this.parent.Hauteur / 100.0 : 1.0)),
          (int) ((double) this.taille.Y * (this.order > 1 ? 1.0 + (double) this.parent.Hauteur / 100.0 : 1.0)));

      if
      ( 
        destinationRectangle.X + destinationRectangle.Width > 0
        && destinationRectangle.X < this.Game.GraphicsDevice.PresentationParameters.BackBufferWidth
        && destinationRectangle.Y + destinationRectangle.Height > 0 
        && destinationRectangle.Y < this.Game.GraphicsDevice.PresentationParameters.BackBufferHeight 
      )
      {
        this.parent.Afficher = true;
        Vector2 vector2 = this.SpritePos();

        if (this.parent.Type == Type.Trou)
          this.DrawOrder = destinationRectangle.Y * 10 - this.Game.GraphicsDevice.PresentationParameters.BackBufferHeight;
        else if (this.parent.Type == Type.TIllot)
          this.DrawOrder = destinationRectangle.Y * 10;
        else if (this.order == 0)
          this.DrawOrder = destinationRectangle.Y * 10;
        else
          this.DrawOrder = (destinationRectangle.Y + destinationRectangle.Height) * 10 + this.order;

            //this.spriteBatch.Begin();
            this.spriteBatch.Begin(SpriteSortMode.BackToFront, null,
                null, null, null, null, Game1.globalTransformation);

                this.spriteBatch.Draw(this.sprite, destinationRectangle, new Rectangle?(new Rectangle(
            this.tailleSprite.X + this.tailleSprite.Width * (int) vector2.X,
            this.tailleSprite.Y + this.tailleSprite.Height * (int) vector2.Y,
            this.tailleSprite.Width, this.tailleSprite.Height)), 
            Color.White * (this.opacity * (float) (1.0 - (this.order == 0 ? (double) this.parent.Hauteur / 10.0 : 0.0))));

        this.spriteBatch.End();
      }
      else
        this.parent.Afficher = false;
    }
  }
}
