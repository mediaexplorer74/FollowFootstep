// ATHFeuilleImage

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

#nullable disable
namespace GameManager
{
  public class ATHFeuilleImage : ATH
  {
    protected string texture;
    protected Texture2D sprite;

    public ATHFeuilleImage(
      ATH parent,
      Vector2 position,
      Vector2 taille,
      string texture,
      Ancre ancre = Ancre.topleft)
      : base(parent, position, taille, ancre)
    {
      this.texture = texture;
    }

    protected override void LoadContent()
    {
      base.LoadContent();
      this.sprite = Game1.game.Content.Load<Texture2D>(this.texture);
    }

    public override void Update(GameTime gameTime) => base.Update(gameTime);

    public override void Draw(GameTime gameTime)
    {
      base.Draw(gameTime);
           
        //this.spriteBatch.Begin();
        this.spriteBatch.Begin(SpriteSortMode.BackToFront, null,
                    null, null, null, null, Game1.globalTransformation);

        this.spriteBatch.Draw(this.sprite, this.realPos(), Color.White);
        this.spriteBatch.End();
    }
  }
}
