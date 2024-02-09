// DelaiSaut

#nullable disable
namespace GameManager
{
  internal class DelaiSaut : Standard
  {
    private int nbPas;
    private int nbSaut;

    public DelaiSaut(int nbSaut)
    {
      this.Joueur.Hauteur = 0.0f;
      this.nbPas = 0;
      this.nbSaut = nbSaut;
      this.Joueur.AddEmpreinte(new Empreinte((Personnage) this.Joueur));
      this.Joueur.AddEmpreinte(new Empreinte((Personnage) this.Joueur));
    }

    public void Waiting()
    {
      if (this.nbPas < 4)
        ++this.nbPas;
      else
        this.Joueur.Etat = (Etat) new Standard((Etat) this);
    }

    public override void Sauter(Direction direction)
    {
      if (this.Joueur.PeutSauter)
      {
        base.Sauter(direction);
      }
      else
      {
        this.Joueur.Etat = (Etat) new Standard((Etat) this);
        this.Deplacement(direction);
      }
    }
  }
}
