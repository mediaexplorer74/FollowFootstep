// Mort

using Microsoft.Xna.Framework;

#nullable disable
namespace GameManager
{
  internal class Mort : Etat
  {
    private ATHComposite athMort;

    public ATHComposite AthMort
    {
      get => this.athMort;
      set => this.athMort = value;
    }

    public Mort()
    {
      Game1.game.IsMouseVisible = true;
      this.Joueur.Solid = false;
      this.joueur.Position = Vector2.Zero;
      ++Joueur.nbMort;
      this.AfficherMenuMort();
      this.Joueur.Etat = (Etat) new Reapparition();
      XML.Save("save.xml");
    }

    public void AfficherMenuMort()
    {
      this.athMort = new ATHComposite((ATH) null, new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f));

      Game1.game.Components.Add((IGameComponent) this.athMort);

      ATHCompositeButton parent1 = new ATHCompositeButton((ATH) this.athMort, new Vector2(0.0f, -100f),
          new Vector2(400f, 50f), BoutonType.CommencerLeJeu, Ancre.center);

      this.athMort.add((ATH) parent1);

      parent1.add((ATH) new ATHCompositeColor((ATH) parent1, new Vector2(0.0f, 0.0f), 
          new Vector2(0.0f, 0.0f), Color.Black));
      ((ATHComposite) parent1.Children[0]).add((ATH) new ATHFeuilleText(parent1.Children[0], 
          new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f), "Continue", Color.White, 2f, Ancre.center));
      ATHCompositeButton parent2 = new ATHCompositeButton((ATH) this.athMort, new Vector2(0.0f, 0.0f),
          new Vector2(400f, 50f), BoutonType.FinDeJeu, Ancre.center);
      this.athMort.add((ATH) parent2);

      parent2.add((ATH) new ATHCompositeColor((ATH) parent2, new Vector2(0.0f, 0.0f),
          new Vector2(0.0f, 0.0f), Color.Black));

      ((ATHComposite) parent2.Children[0]).add((ATH) new ATHFeuilleText(parent2.Children[0],
          new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f), "Menu", Color.White, 2f, Ancre.center));

      ATHCompositeButton parent3 = new ATHCompositeButton((ATH) this.athMort,
          new Vector2(0.0f, 100f), new Vector2(400f, 50f), BoutonType.Fermer, Ancre.center);

      this.athMort.add((ATH) parent3);

      parent3.add((ATH) new ATHCompositeColor((ATH) parent3, new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f), 
          Color.Black));
      ((ATHComposite) parent3.Children[0]).add((ATH) new ATHFeuilleText(parent3.Children[0],
          new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f), "Quit", Color.White, 2f, Ancre.center));
    }

    private void Afficher()
    {
            //
    }

    public override void Restart()
    {
      this.Joueur.Etat = (Etat) new Reapparition();
      ++Joueur.nbMort;

      XML.Save(XML.Load(Game1.game.Path), Game1.game.Path);
      
      Game1.game.Path = "save.xml";
      
      Game1.game.StartGame();    
    }

    public override void Deplacement(Direction direction)
    {
       //
    }

    public override void Sauter(Direction direction)
    {
        //
    }

    public override void Jeter()
    {
       //
    }

    public override void Lacher()
    {
       //
    }

    public override void Mourir()
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
