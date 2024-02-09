// Decompiled with JetBrains decompiler
// Type: monogameJam.ATHFeuilleText
// Assembly: monogameJam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A56AFD03-F9CC-4354-BD49-E5DE8D292E54
// Assembly location: C:\Users\Admin\Desktop\RE\FootStep\monogameJam.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

#nullable disable
namespace monogameJam
{
  internal class ATHFeuilleText : ATH
  {
    protected SpriteFont font;
    protected float taillePolice;
    protected string text;
    protected Color color;

    public ATHFeuilleText(
      ATH parent,
      Vector2 position,
      Vector2 taille,
      string text,
      Color color,
      float taillePolice,
      Ancre ancre = Ancre.topleft)
      : base(parent, position, taille, ancre)
    {
      this.text = text;
      this.color = color;
      this.taillePolice = taillePolice;
      this.taille = taille;
    }

    protected override void LoadContent()
    {
      base.LoadContent();
      this.font = Program.game.Content.Load<SpriteFont>("File");
    }

    public override void Draw(GameTime gameTime)
    {
      this.spriteBatch.Begin();
      this.spriteBatch.DrawString(this.font, this.text, new Vector2((float) this.realPos().X - (float) ((double) this.font.MeasureString(this.text).X * (double) this.taillePolice / 2.0), (float) this.realPos().Y - (float) ((double) this.font.MeasureString(this.text).Y * (double) this.taillePolice / 2.0)), this.color, 0.0f, new Vector2(0.0f, 0.0f), this.taillePolice, SpriteEffects.None, 0.0f);
      this.spriteBatch.End();
      base.Draw(gameTime);
    }
  }
}
