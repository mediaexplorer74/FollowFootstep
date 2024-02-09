// Menu

using Microsoft.Xna.Framework;

#nullable disable
namespace GameManager
{
  internal class Menu : Etat
  {
    public Menu() => this.Afficher();

    private void Afficher()
    {
      ATHComposite parent1 = new ATHComposite((ATH) null,
          new Vector2(0.0f, 0.0f), 
          new Vector2(0.0f, 0.0f));
      
      Game1.game.Components.Add((IGameComponent) parent1);
      
      ATHCompositeButton parent2 = new ATHCompositeButton((ATH) parent1, new Vector2(0.0f, -200f), 
          new Vector2(400f, 80f), BoutonType.Retour, Ancre.center);
      parent1.add((ATH) parent2);
      parent2.add((ATH) new ATHCompositeColor((ATH) parent2, new Vector2(0.0f, 0.0f),
          new Vector2(0.0f, 0.0f), Color.Black));

      ((ATHComposite) parent2.Children[0]).add((ATH) new ATHFeuilleText(parent2.Children[0], 
          new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f), "Return", Color.White, 2f, Ancre.center));
      ATHCompositeButton parent3 = new ATHCompositeButton((ATH) parent1, new Vector2(0.0f, -100f), 
          new Vector2(400f, 80f), BoutonType.Sauvegarder, Ancre.center);

      parent1.add((ATH) parent3);
      parent3.add((ATH) new ATHCompositeColor((ATH) parent3, new Vector2(0.0f, 0.0f), 
          new Vector2(0.0f, 0.0f), Color.Black));
      ((ATHComposite) parent3.Children[0]).add((ATH) new ATHFeuilleText(parent3.Children[0],
          new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f), "Save", Color.White, 2f, Ancre.center));
      ATHCompositeButton parent4 = new ATHCompositeButton((ATH) parent1, new Vector2(0.0f, 0.0f),
          new Vector2(400f, 80f), BoutonType.CommencerLeJeu, Ancre.center);
      parent1.add((ATH) parent4);
      parent4.add((ATH) new ATHCompositeColor((ATH) parent4, new Vector2(0.0f, 0.0f),
          new Vector2(0.0f, 0.0f), Color.Black));
      ((ATHComposite) parent4.Children[0]).add((ATH) new ATHFeuilleText(parent4.Children[0], 
          new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f), "Load", Color.White, 2f, Ancre.center));
      ATHCompositeButton parent5 = new ATHCompositeButton((ATH) parent1, new Vector2(0.0f, 100f),
          new Vector2(400f, 80f), BoutonType.FinDeJeu, Ancre.center);
      parent1.add((ATH) parent5);
      parent5.add((ATH) new ATHCompositeColor((ATH) parent5, new Vector2(0.0f, 0.0f), 
          new Vector2(0.0f, 0.0f), Color.Black));
      ((ATHComposite) parent5.Children[0]).add((ATH) new ATHFeuilleText(parent5.Children[0], 
          new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f), nameof (Menu), Color.White, 2f, Ancre.center));
      ATHCompositeButton parent6 = new ATHCompositeButton((ATH) parent1, 
          new Vector2(0.0f, 200f), new Vector2(400f, 80f), BoutonType.Fermer, Ancre.center);
      parent1.add((ATH) parent6);
      parent6.add((ATH) new ATHCompositeColor((ATH) parent6, new Vector2(0.0f, 0.0f),
          new Vector2(0.0f, 0.0f), Color.Black));
      ((ATHComposite) parent6.Children[0]).add((ATH) new ATHFeuilleText(parent6.Children[0], 
          new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f), "Quit", Color.White, 2f, Ancre.center));
    }

    public override void monMenu()
    {
        this.Joueur.Etat = (Etat)new Standard();
    }

    public override void Deplacement(Direction direction)
    {
        //
    }

    public override void ActionObjet()
    {
        //
    }

    public override void Attraper(Composant c)
    {
        //
    }
  }
}
