// Decompiled with JetBrains decompiler
// Type: GameManager.Joueur
// Assembly: GameManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A56AFD03-F9CC-4354-BD49-E5DE8D292E54
// Assembly location: C:\Users\Admin\Desktop\RE\FootStep\GameManager.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

#nullable disable
namespace GameManager
{
  public class Joueur : Personnage
  {
    private int peutBouger = 0;
    private Etat etat;
    private bool relacherSaut;
    private DirectionJoueur lastDirection;
    private float impulsion;
    private bool shiftpress = false;
    public static int nbMort = 0;
    private bool peutSauter;
    private float coolDown;
    private int lastTypeSprite;
    private bool actionObjet;
    private bool reachFather = false;
    private DateTime elapsedTime;

    public bool PeutSauter
    {
      get => this.peutSauter;
      set => this.peutSauter = value;
    }

    public Etat Etat
    {
      get => this.etat;
      set => this.etat = value;
    }

    public float Impulsion
    {
      get => this.impulsion;
      set => this.impulsion = value;
    }

    public bool ActionObjet
    {
      get => this.actionObjet;
      set => this.actionObjet = value;
    }

    public int LastTypeSprite
    {
      get => this.lastTypeSprite;
      set => this.lastTypeSprite = value;
    }

    public int PeutBouger
    {
      get => this.peutBouger;
      set => this.peutBouger = value;
    }

    public bool ReachFather
    {
      get => this.reachFather;
      set => this.reachFather = value;
    }

    public Joueur(string classe = "Joueur")
      : base(nameof (Joueur), new Vector2(52f, 0.0f), new Vector2(200f, 200f), "sprite_joueur", 
            new Rectangle(70, 180, 60, 25), Type.TJoueur, new int[6, 7]
      {
        {
          1,  1,  1,  1, 1, 1,
          5
        },
        {
          2,
          2,
          2,
          2,
          2,
          2,
          6
        },
        {
          3,
          3,
          3,
          3,
          3,
          3,
          7
        },
        {
          4,
          4,
          4,
          4,
          4,
          4,
          8
        },
        {
          9,
          10,
          11,
          15,
          16,
          17,
          0
        },
        {
          12,
          13,
          14,
          18,
          19,
          20,
          0
        }
      }, new Rectangle(0, 0, 500, 500), classe)
    {
      this.typeSprite = 1;
      this.lastTypeSprite = this.typeSprite;
      this.impulsion = 0.0f;
      this.vitesse = 4f;
    }

    public Joueur(
      string nom,
      Vector2 position,
      Vector2 taille,
      string texture,
      Rectangle collision,
      Type typeComposant,
      int[,] indexSprite,
      Rectangle tailleSprite,
      string classe = "Joueur")
      : base(nom, position, taille, texture, collision, typeComposant, indexSprite, tailleSprite, classe)
    {
      this.typeSprite = 1;
      this.lastTypeSprite = this.typeSprite;
      this.impulsion = 0.0f;
      this.vitesse = 4f;
    }

    public override void Initialize()
    {
      base.Initialize();
      
      if (!Game1.game.Init)
        this.etat = (Etat) new Reapparition();

      this.relacherSaut = true;
      this.coolDown = 0.0f;
      this.actionObjet = false;
      this.peutSauter = true;
    }

    public override void Update(GameTime gametime)
    {
      this.Control();
      if (!Game1.game.Init && this.etat is Reapparition)
        this.etat.setReady();
      if (!this.peutSauter && !(this.etat is Saut))
      {
        this.coolDown += (float) gametime.ElapsedGameTime.TotalMilliseconds;
        if ((double) this.coolDown >= 300.0)
        {
          this.coolDown = 0.0f;
          this.peutSauter = true;
        }
      }
      base.Update(gametime);
    }

    public void StopAnimation()
    {
      this.deplacer = false;
      if (!this.deplacer)
      {
        switch (this.directionJoueur)
        {
          case DirectionJoueur.droite:
            this.typeSprite = 8;
            break;
          case DirectionJoueur.gauche:
            this.typeSprite = 6;
            break;
          case DirectionJoueur.haut:
            this.typeSprite = 5;
            break;
          case DirectionJoueur.bas:
            this.typeSprite = 7;
            break;
        }
      }
      this.GestionVitesse();
    }

    public void DebutAnimation()
    {
      this.deplacer = true;
      if (!this.actionObjet)
      {
        KeyboardState state = Keyboard.GetState();
        int num1;
        if (state.IsKeyDown(Keys.W))
        {
          state = Keyboard.GetState();
          if (!state.IsKeyDown(Keys.A))
          {
            state = Keyboard.GetState();
            if (!state.IsKeyDown(Keys.S))
            {
              state = Keyboard.GetState();
              num1 = !state.IsKeyDown(Keys.D) ? 1 : 0;
              goto label_6;
            }
          }
        }
        num1 = 0;
label_6:
        if (num1 != 0)
        {
          this.directionJoueur = DirectionJoueur.haut;
          this.typeSprite = 1;
          this.lastTypeSprite = this.typeSprite;
        }
        else
        {
          state = Keyboard.GetState();
          int num2;
          if (!state.IsKeyDown(Keys.W))
          {
            state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.A))
            {
              state = Keyboard.GetState();
              if (!state.IsKeyDown(Keys.S))
              {
                state = Keyboard.GetState();
                num2 = !state.IsKeyDown(Keys.D) ? 1 : 0;
                goto label_13;
              }
            }
          }
          num2 = 0;
label_13:
          if (num2 != 0)
          {
            this.directionJoueur = DirectionJoueur.gauche;
            this.typeSprite = 2;
            this.lastTypeSprite = this.typeSprite;
          }
          else
          {
            state = Keyboard.GetState();
            int num3;
            if (!state.IsKeyDown(Keys.W))
            {
              state = Keyboard.GetState();
              if (!state.IsKeyDown(Keys.A))
              {
                state = Keyboard.GetState();
                if (state.IsKeyDown(Keys.S))
                {
                  state = Keyboard.GetState();
                  num3 = !state.IsKeyDown(Keys.D) ? 1 : 0;
                  goto label_20;
                }
              }
            }
            num3 = 0;
label_20:
            if (num3 != 0)
            {
              this.directionJoueur = DirectionJoueur.bas;
              this.typeSprite = 3;
              this.lastTypeSprite = this.typeSprite;
            }
            else
            {
              state = Keyboard.GetState();
              int num4;
              if (!state.IsKeyDown(Keys.W))
              {
                state = Keyboard.GetState();
                if (!state.IsKeyDown(Keys.A))
                {
                  state = Keyboard.GetState();
                  if (!state.IsKeyDown(Keys.S))
                  {
                    state = Keyboard.GetState();
                    num4 = state.IsKeyDown(Keys.D) ? 1 : 0;
                    goto label_27;
                  }
                }
              }
              num4 = 0;
label_27:
              if (num4 != 0)
              {
                this.directionJoueur = DirectionJoueur.droite;
                this.typeSprite = 4;
                this.lastTypeSprite = this.typeSprite;
              }
            }
          }
        }
      }
      else
      {
        switch (this.directionJoueur)
        {
          case DirectionJoueur.droite:
            this.typeSprite = 4;
            break;
          case DirectionJoueur.gauche:
            this.typeSprite = 2;
            break;
          case DirectionJoueur.haut:
            this.typeSprite = 1;
            break;
          case DirectionJoueur.bas:
            this.typeSprite = 3;
            break;
        }
        this.lastTypeSprite = this.typeSprite;
      }
      this.GestionVitesse();
    }

    public void GestionVitesse()
    {
      if (this.deplacer)
      {
        if ((double) this.velocite < (double) this.vitesse)
        {
          this.velocite += 0.8f;
          if ((double) this.velocite <= (double) this.vitesse)
            return;
          this.velocite = this.vitesse;
        }
        else
        {
          if ((double) this.velocite <= (double) this.vitesse)
            return;
          this.velocite -= 0.8f;
          if ((double) this.velocite < (double) this.vitesse)
            this.velocite = this.vitesse;
        }
      }
      else if ((double) this.velocite > 0.0)
      {
        this.velocite -= 0.8f;
        if ((double) this.velocite < 0.0)
          this.velocite = 0.0f;
        this.etat.Deplacement(this.etat.direction);
      }
      else
        this.etat.Deplacement(Direction.Center);
    }

    public void Control()
    {
      if (this.peutBouger == 0)
      {
        if ((Keyboard.GetState().GetPressedKeys().Length == 0 
                    || Keyboard.GetState().GetPressedKeys().Length == 1
                    && Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                    && !(this.etat is GameManager.Cinematique))
          this.StopAnimation();
        else
          this.DebutAnimation();
        if ((double) this.hauteur > 0.0 && (double) this.impulsion > 0.30000001192092896)
          this.typeSprite = (this.lastTypeSprite - 1) * 3 + 9;
        else if ((double) this.hauteur > 0.0 && (double) this.impulsion < 0.30000001192092896 
                    && (double) this.impulsion > -0.30000001192092896)
          this.typeSprite = (this.lastTypeSprite - 1) * 3 + 10;
        else if ((double) this.hauteur > 0.0 && (double) this.impulsion < -0.30000001192092896)
          this.typeSprite = (this.lastTypeSprite - 1) * 3 + 11;
        if (Keyboard.GetState().IsKeyDown(Keys.W)
                    && Keyboard.GetState().IsKeyDown(Keys.D) 
                    && Keyboard.GetState().IsKeyDown(Keys.A) 
                    && !this.actionObjet)
        {
          this.etat.Deplacement(Direction.Top);
          this.directionJoueur = DirectionJoueur.haut;
          this.typeSprite = 1;
        }
        else if (Keyboard.GetState().IsKeyDown(Keys.S) 
                    && Keyboard.GetState().IsKeyDown(Keys.A) 
                    && Keyboard.GetState().IsKeyDown(Keys.D)
                    && !this.actionObjet)
        {
          this.etat.Deplacement(Direction.Bottom);
          this.directionJoueur = DirectionJoueur.bas;
          this.typeSprite = 3;
        }
        else if (Keyboard.GetState().IsKeyDown(Keys.D))
        {
          if (Keyboard.GetState().IsKeyDown(Keys.W))
            this.etat.Deplacement(Direction.RightTop);
          else if (Keyboard.GetState().IsKeyDown(Keys.S))
            this.etat.Deplacement(Direction.RightBottom);
          else
            this.etat.Deplacement(Direction.Right);
        }
        else if (Keyboard.GetState().IsKeyDown(Keys.A))
        {
          if (Keyboard.GetState().IsKeyDown(Keys.W))
            this.etat.Deplacement(Direction.LeftTop);
          else if (Keyboard.GetState().IsKeyDown(Keys.S))
            this.etat.Deplacement(Direction.LeftBottom);
          else
            this.etat.Deplacement(Direction.Left);
        }
        else if (Keyboard.GetState().IsKeyDown(Keys.W))
          this.etat.Deplacement(Direction.Top);
        else if (Keyboard.GetState().IsKeyDown(Keys.S))
          this.etat.Deplacement(Direction.Bottom);

        if (Keyboard.GetState().IsKeyDown(Keys.Escape) && this.etat is Standard)
          this.etat.monMenu();
        this.Sauter();
        this.Porter();
        this.Sauvegarde();
        this.Cinematique();
      }
      else if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) && this.peutBouger == 1)
      {
        this.etat.ActionObjet();
      }
      else
      {
        if (!Keyboard.GetState().IsKeyUp(Keys.LeftShift) || this.peutBouger != -1)
          return;

        this.peutBouger = 1;
      }
    }

    public void Sauter()
    {
      if (this.relacherSaut && Keyboard.GetState().IsKeyDown(Keys.Space)
                && !(this.etat is GameManager.Porter) && !(this.etat is Pousser))
      {
        this.etat.Sauter(Direction.Center);
        this.relacherSaut = false;
      }

            if (this.relacherSaut || !Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                return;
            }

      this.relacherSaut = true;
    }

    public void Porter()
    {
      if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) && !this.shiftpress)
      {
        this.shiftpress = true;
        this.etat.ActionObjet();
      }
      else
      {
        KeyboardState state = Keyboard.GetState();
        if (state.IsKeyUp(Keys.LeftShift) && (this.etat is Pousser || this.etat is GameManager.Porter))
        {
          this.shiftpress = false;
          this.etat.Lacher();
          this.etat = (Etat) new Standard();
          this.actionObjet = false;
        }
        else
        {
          state = Keyboard.GetState();
          if (!state.IsKeyUp(Keys.LeftShift))
            return;
          this.shiftpress = false;
        }
      }
    }

    protected override void tomber()
    {
      if (!this.solid)
        return;
      this.Etat.Mourir();
    }

    public void Sauvegarde()
    {
      if (this.etat is Standard && Keyboard.GetState().IsKeyDown(Keys.P))
      {
        Game1.game.Path = "save.xml";
        XML.Save("save.xml");
      }

      if (!Keyboard.GetState().IsKeyDown(Keys.M))
      {
            return;
      }

      //RnD: old entity: Program.game....
      Game1.game.StartGame();
    }

    public void Cinematique()
    {
      if (!(this.etat is GameManager.Cinematique))
        return;
            if (!this.reachFather)
            {
                if ((double)this.position.X > 5090.0 || (double)this.position.X < 5080.0 
                    || (double)this.position.Y > 5000.0)
                {
                    ((GameManager.Cinematique)this.etat).sansLesMains();
                }
                else
                {
                    this.StopAnimation();
                    this.reachFather = true;
                    this.elapsedTime = DateTime.Now;
                }
            }
            else if ((DateTime.Now - this.elapsedTime).TotalMilliseconds < 2000.0)
            {
                Debug.WriteLine((DateTime.Now - this.elapsedTime).TotalMilliseconds);
            }
            else if ((double)this.position.Y < 5600.0)
                ((GameManager.Cinematique)this.etat).sansLesMains();
            else
                this.etat.Reinitialiser();
    }
  }
}
