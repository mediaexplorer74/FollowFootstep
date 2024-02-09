// ATHCompositeButton

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

#nullable disable
namespace GameManager
{
  public class ATHCompositeButton : ATHComposite
  {
    protected bool press;
    private BoutonType typeBouton;

    public ATHCompositeButton(
      ATH parent,
      Vector2 position,
      Vector2 taille,
      BoutonType boutonType,
      Ancre ancre = Ancre.topleft,
      bool press = false)
      : base(parent, position, taille, ancre)
    {
      this.ancre = ancre;
      this.typeBouton = boutonType;
      this.press = press;
    }

    public override void Update(GameTime gameTime)
    {
      MouseState state = Mouse.GetState();
      int x = state.X;
      state = Mouse.GetState();
      int y = state.Y;
      Rectangle rectangle = new Rectangle(x, y, 20, 20);
      ButtonState leftButton;
      int num;
      if (this.realPos().Intersects(rectangle))
      {
        leftButton = Mouse.GetState().LeftButton;
        if (leftButton.CompareTo((object) ButtonState.Pressed) == 0)
        {
          num = !this.press ? 1 : 0;
          goto label_4;
        }
      }
      num = 0;
label_4:
      if (num != 0)
      {
        Debug.WriteLine("Ca clique sur " + (object) this.typeBouton);
        this.press = true;
        this.action();
      }
      else
      {
        leftButton = Mouse.GetState().LeftButton;
        if (leftButton.CompareTo((object) ButtonState.Pressed) != 0 && this.press)
          this.press = false;
      }
      base.Update(gameTime);
    }

    public void action()
    {
      switch (this.typeBouton)
      {
        case BoutonType.CommencerLeJeu:
          Game1.game.StartGame();
          break;
        case BoutonType.FinDeJeu:
          Game1.game.AfficherAth(this.press);
          Game1.game.Carte.Remove();
          Game1.game.Components.Remove((IGameComponent) Game1.game.Joueur);
          break;
        case BoutonType.Fermer:
          Debug.WriteLine("Bouton fermer");
          this.Game.Exit();
          break;
        case BoutonType.NouvellePartie:
          Game1.game.Path = "saveOrigine.xml";
          Game1.game.createFromXML();
          break;
        case BoutonType.Sauvegarder:
          XML.Save("save.xml");
          Game1.game.Joueur.Etat.Reinitialiser();
          break;
        case BoutonType.Retour:
          Game1.game.Joueur.Etat.Reinitialiser();
          break;
      }
      this.parent.Remove();
    }
  }
}
