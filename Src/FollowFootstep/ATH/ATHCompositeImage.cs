// ATHCompositeImage

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

#nullable disable
namespace GameManager
{
  public class ATHCompositeImage : ATHComposite
  {
    protected string texture;
    protected Texture2D sprite;

    public ATHCompositeImage(
      ATH parent,
      Vector2 position,
      Vector2 taille,
      string texture,
      Ancre ancre = Ancre.topleft)
      : base(parent, position, taille, ancre)
    {
      this.ancre = ancre;
      Debug.WriteLine(texture);
      this.texture = texture;
    }

    protected override void LoadContent()
    {
      base.LoadContent();
      this.sprite = Game.Content.Load<Texture2D>(this.texture);
    }

    public override void Update(GameTime gameTime) => base.Update(gameTime);

    public override void Draw(GameTime gameTime)
    {
      base.Draw(gameTime);

        //this.spriteBatch.Begin();
        spriteBatch.Begin(SpriteSortMode.BackToFront, null,
            null, null, null, null, Game1.globalTransformation);

        this.spriteBatch.Draw(this.sprite, this.realPos(), Color.White);
      
      this.spriteBatch.End();
    }
  }
}
