// ATHFeuilleColor

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

#nullable disable
namespace GameManager
{
  public class ATHFeuilleColor : ATH
  {
    protected Color color;
    protected Texture2D texture;

    public ATHFeuilleColor(
      ATH parent,
      Vector2 position,
      Vector2 taille,
      Color color,
      Ancre ancre = Ancre.topleft)
      : base(parent, position, taille, ancre)
    {
      this.ancre = ancre;
      this.color = color;
    }

    protected override void LoadContent()
    {
      base.LoadContent();
      this.texture = new Texture2D(this.Game.GraphicsDevice, 1, 1);
      this.texture.SetData<Color>(new Color[1]{ this.color });
    }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
    {
      base.Draw(gameTime);
      //this.spriteBatch.Begin();
      this.spriteBatch.Begin(SpriteSortMode.BackToFront, null,
                null, null, null, null, Game1.globalTransformation);

      this.spriteBatch.Draw(this.texture, this.realPos(), Color.White);
      this.spriteBatch.End();
    }
  }
}
