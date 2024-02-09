// Decompiled with JetBrains decompiler
// Type: monogameJam.ATHCompositeColor
// Assembly: monogameJam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A56AFD03-F9CC-4354-BD49-E5DE8D292E54
// Assembly location: C:\Users\Admin\Desktop\RE\FootStep\monogameJam.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

#nullable disable
namespace monogameJam
{
  public class ATHCompositeColor : ATHComposite
  {
    protected Color color;
    protected Texture2D texture;

    public ATHCompositeColor(
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

    public override void Initialize() => base.Initialize();

    protected override void LoadContent()
    {
      base.LoadContent();
      this.texture = new Texture2D(this.Game.GraphicsDevice, 1, 1);
      this.texture.SetData<Color>(new Color[1]{ this.color });
    }

    public override void Update(GameTime gameTime) => base.Update(gameTime);

    public override void Draw(GameTime gameTime)
    {
      base.Draw(gameTime);
      this.spriteBatch.Begin();
      this.spriteBatch.Draw(this.texture, this.realPos(), Color.White);
      this.spriteBatch.End();
    }
  }
}
