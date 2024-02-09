// Decompiled with JetBrains decompiler
// Type: monogameJam.ATHCompositeButton
// Assembly: monogameJam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A56AFD03-F9CC-4354-BD49-E5DE8D292E54
// Assembly location: C:\Users\Admin\Desktop\RE\FootStep\monogameJam.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

#nullable disable
namespace monogameJam
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
      //Rectangle rectangle = new Rectangle();
      //      ref 
      //Rectangle local;// = ref rectangle;
      MouseState state = Mouse.GetState();
      int x = state.X;
      state = Mouse.GetState();
      int y = state.Y;
      Rectangle /*local*/rectangle = new Rectangle(x, y, 20, 20);
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
          Program.game.StartGame();
          break;
        case BoutonType.FinDeJeu:
          Program.game.AfficherAth(this.press);
          Program.game.Carte.Remove();
          Program.game.Components.Remove((IGameComponent) Program.game.Joueur);
          break;
        case BoutonType.Fermer:
          Debug.WriteLine("Bouton fermer");
          this.Game.Exit();
          break;
        case BoutonType.NouvellePartie:
          Program.game.Path = "saveOrigine.xml";
          Program.game.createFromXML();
          break;
        case BoutonType.Sauvegarder:
          XML.Save("save.xml");
          Program.game.Joueur.Etat.Reinitialiser();
          break;
        case BoutonType.Retour:
          Program.game.Joueur.Etat.Reinitialiser();
          break;
      }
      this.parent.Remove();
    }
  }
}
