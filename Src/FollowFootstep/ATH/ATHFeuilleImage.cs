// Decompiled with JetBrains decompiler
// Type: monogameJam.ATHFeuilleImage
// Assembly: monogameJam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A56AFD03-F9CC-4354-BD49-E5DE8D292E54
// Assembly location: C:\Users\Admin\Desktop\RE\FootStep\monogameJam.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

#nullable disable
namespace monogameJam
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
      this.sprite = Program.game.Content.Load<Texture2D>(this.texture);
    }

    public override void Update(GameTime gameTime) => base.Update(gameTime);

    public override void Draw(GameTime gameTime)
    {
      base.Draw(gameTime);
      this.spriteBatch.Begin();
      this.spriteBatch.Draw(this.sprite, this.realPos(), Color.White);
      this.spriteBatch.End();
    }
  }
}
