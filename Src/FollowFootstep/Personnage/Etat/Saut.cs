// Decompiled with JetBrains decompiler
// Type: monogameJam.Saut
// Assembly: monogameJam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A56AFD03-F9CC-4354-BD49-E5DE8D292E54
// Assembly location: C:\Users\Admin\Desktop\RE\FootStep\monogameJam.exe

#nullable disable
namespace monogameJam
{
  internal class Saut : Etat
  {
    private int nbSaut;
    private const int NBMAXSAUT = 3;

    public int NbSaut
    {
      get => this.nbSaut;
      set => this.nbSaut = value;
    }

    public Saut()
    {
      this.Joueur.Vitesse = 6f;
      this.Joueur.Hauteur = 0.0f;
      this.Joueur.Impulsion = 1.2f;
      this.nbSaut = 0;
      this.Joueur.AddEmpreinte(new Empreinte((Personnage) this.Joueur));
      this.Joueur.AddEmpreinte(new Empreinte((Personnage) this.Joueur));
    }

    public Saut(int nbSaut)
    {
      this.Joueur.Hauteur = 0.0f;
      if (nbSaut < 3)
      {
        this.Joueur.AddEmpreinte(new Empreinte((Personnage) this.Joueur));
        this.Joueur.AddEmpreinte(new Empreinte((Personnage) this.Joueur));
        if (nbSaut > 0)
          this.Joueur.Impulsion = (float) (1.5 / (1.5 * (double) nbSaut));
        else if (nbSaut == 0)
          this.Joueur.Impulsion = 1.5f;
      }
      else
        this.Joueur.Impulsion = 0.0f;
      this.nbSaut = nbSaut;
    }

    public override void Sauter(Direction direction)
    {
    }

    public override void ActionObjet()
    {
    }

    public override void Attraper(Composant c)
    {
    }

    public override void Deplacement(Direction direction)
    {
      this.Joueur.Hauteur += this.Joueur.Impulsion;
      this.Joueur.Impulsion -= 0.07f;
      if ((double) this.Joueur.Hauteur <= 0.0)
      {
        this.Joueur.Etat = (Etat) new DelaiSaut(this.nbSaut);
        this.Joueur.TypeSprite = this.Joueur.LastTypeSprite;
      }
      base.Deplacement(direction);
    }
  }
}
