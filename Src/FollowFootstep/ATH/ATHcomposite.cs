// ATHComposite 

using Microsoft.Xna.Framework;
using System.Collections.Generic;

#nullable disable
namespace GameManager
{
  public class ATHComposite : ATH
  {
    protected List<ATH> children;

    public ATHComposite(ATH parent, Vector2 position, Vector2 taille, Ancre ancre = Ancre.topleft)
      : base(parent, position, taille, ancre)
    {
      this.children = new List<ATH>();
    }

    public List<ATH> Children
    {
      get => this.children;
      set => this.children = value;
    }

    public void add(ATH ath)
    {
      this.children.Add(ath);
      
      //RnD
      Game1.game.Components.Add((IGameComponent) ath);
    }

    public void remove(ATH ath)
    {
        this.children.Remove(ath);
    }

    public override void Remove()
    {
      while (this.Children.Count > 0)
      {
        this.Children[0].Remove();
        this.remove(this.Children[0]);
      }
      Game1.game.Components.Remove((IGameComponent) this);
      base.Remove();
    }
  }
}
