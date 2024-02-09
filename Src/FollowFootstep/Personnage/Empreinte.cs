// Decompiled with JetBrains decompiler
// Type: GameManager.Empreinte
// Assembly: GameManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A56AFD03-F9CC-4354-BD49-E5DE8D292E54
// Assembly location: C:\Users\Admin\Desktop\RE\FootStep\GameManager.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

#nullable disable
namespace GameManager
{
  public class Empreinte : Element2D
  {
    private bool eternel;
    private Personnage p;
    protected Rectangle tailleSprite;
    protected Rectangle collision;
    protected int vie;
    protected int maxVie;

    public int Vie
    {
      get => this.vie;
      set => this.vie = value;
    }

    public Rectangle TailleSprite
    {
      get => this.tailleSprite;
      set => this.tailleSprite = value;
    }

    public bool Eternel
    {
      get => this.eternel;
      set => this.eternel = value;
    }

    public Empreinte(Personnage p, int maxVie = 4, bool eternel = false)
      : base(p.Position, p.Taille, p.ModeleEmpreinte)
    {
      int num = p.DirectionJoueur != DirectionJoueur.haut 
                ? (p.DirectionJoueur != DirectionJoueur.droite
                ? (p.DirectionJoueur != DirectionJoueur.bas
                ? (p.DirectionJoueur != DirectionJoueur.gauche ? -2 : 6) : 4) : 2) : 0;
      this.vie = Joueur.nbMort;
      this.maxVie = maxVie;
      this.eternel = eternel;
      this.tailleSprite = new Rectangle(500 * (p.Souvenir.Count % 2 + num), 0, 500, 500);
      this.collision = p.Collision;
      this.p = p;
    }

    public Empreinte(Personnage p, Rectangle tailleSprite, int maxVie = 4, bool eternel = false)
      : base(p.Position, p.Taille, p.ModeleEmpreinte)
    {
      this.vie = Joueur.nbMort;
      this.maxVie = maxVie;
      this.eternel = eternel;
      this.tailleSprite = tailleSprite;
      this.collision = p.Collision;
      this.p = p;
    }

    public override void Update(GameTime gameTime)
    {
      base.Update(gameTime);
      if (Joueur.nbMort - this.vie <= 4 || this.eternel)
        return;
      this.Remove();
      this.p.Souvenir.Remove(this);
    }

    public override void Draw(GameTime gameTime)
    {
      Rectangle destinationRectangle =
                new Rectangle((int) ((double) this.position.X 
                - (double) Game1.game.Joueur.Position.X
                - (double) Game1.game.Joueur.Taille.X / 2.0 
                + (double) (this.Game.GraphicsDevice.PresentationParameters.BackBufferWidth / 2)),
                (int) ((double) this.position.Y - (double) Game1.game.Joueur.Position.Y
                - (double) Game1.game.Joueur.Taille.X / 2.0 
                + (double) (this.Game.GraphicsDevice.PresentationParameters.BackBufferHeight / 2)),
                (int) this.taille.X, (int) this.taille.Y);

      if (destinationRectangle.X + destinationRectangle.Width <= 0 
                || destinationRectangle.X >= this.Game.GraphicsDevice.PresentationParameters.BackBufferWidth
                || destinationRectangle.Y + destinationRectangle.Height <= 0 
                || destinationRectangle.Y >= this.Game.GraphicsDevice.PresentationParameters.BackBufferHeight)
        return;

      this.DrawOrder = destinationRectangle.Y + destinationRectangle.Height * 10;

        //Element2D.spriteBatch.Begin();
        Element2D.spriteBatch.Begin(SpriteSortMode.BackToFront, null,
                    null, null, null, null, Game1.globalTransformation);

        Element2D.spriteBatch.Draw(this.sprite, destinationRectangle,
          new Rectangle?(this.tailleSprite), Color.White 
          * (float) (0.30000001192092896 - 0.30000001192092896
          * (!this.eternel ? (double) (Joueur.nbMort - this.vie) / (double) this.maxVie : 0.0)));

      Element2D.spriteBatch.End();
    }
  }
}
