// Decompiled with JetBrains decompiler
// Type: monogameJam.Game1
// Assembly: monogameJam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A56AFD03-F9CC-4354-BD49-E5DE8D292E54
// Assembly location: C:\Users\Admin\Desktop\RE\FootStep\monogameJam.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using Xml2CSharp;

#nullable disable
namespace monogameJam
{
  public class Game1 : Game
  {
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;
    private int i = 0;
    private ATHComposite ath;
    private bool init = true;
    private string path;
    private Carte carte;
    private Joueur joueur;
    public static Fabrique f = new Fabrique();

    public Carte Carte
    {
      get => this.carte;
      set => this.carte = value;
    }

    public Joueur Joueur
    {
      get => this.joueur;
      set => this.joueur = value;
    }

    public bool Init
    {
      get => this.init;
      set => this.init = value;
    }

    public string Path
    {
      get => this.path;
      set => this.path = value;
    }

    public ATHComposite Ath
    {
      get => this.ath;
      set => this.ath = value;
    }

    public Game1()
    {
      this.graphics = new GraphicsDeviceManager((Game) this);

      this.graphics.GraphicsProfile = GraphicsProfile.HiDef;
      this.Content.RootDirectory = "Content";

      this.graphics.PreferredBackBufferWidth = 1200;//1600;
      this.graphics.PreferredBackBufferHeight = 720;// 900;

      this.graphics.IsFullScreen = false;
      
      this.path = "saveOrigine.xml";
    }

    public void StartGame()
    {
      if (this.init)
      {
        this.Initialize();
      }
      else
      {
        if (this.carte != null)
        {
          this.carte.Remove();
          this.Components.Remove((IGameComponent) this.joueur);
        }
        this.path = "save.xml";
        this.createFromXML();
      }
    }

    public void createFromXML()
    {
      Sauvegarde sauvegarde = XML.Load(this.path);
      this.joueur = new Joueur();
      this.joueur.Position = new Vector2(float.Parse(sauvegarde.Joueur.Position.X), 
          float.Parse(sauvegarde.Joueur.Position.Y));
      Joueur.nbMort = int.Parse(sauvegarde.Joueur.Mort);
      foreach (Xml2CSharp.Empreinte empreinte in sauvegarde.Joueur.Empreintes.Empreinte)
      {
        Empreinte e = new Empreinte((Personnage) this.joueur, 
            new Rectangle(int.Parse(empreinte.TailleSprite.Position.X),
            int.Parse(empreinte.TailleSprite.Position.Y),
            int.Parse(empreinte.TailleSprite.Taille.X),
            int.Parse(empreinte.TailleSprite.Taille.Y)));

        e.Vie = int.Parse(empreinte.Vie);
        e.Position = new Vector2(float.Parse(empreinte.Position.X), float.Parse(empreinte.Position.Y));
        e.Eternel = bool.Parse(empreinte.Eternel);
        this.joueur.AddEmpreinte(e);
      }
      this.carte = new Carte();
      Program.game.Components.Add((IGameComponent) this.carte);
      this.carte.add((Composant) this.joueur);
      foreach (Xml2CSharp.Composant composant in sauvegarde.Carte.Composants.Composant)
      {
        Composant parent = Game1.f.creerComposant(composant.Classe, 
            new Vector2(float.Parse(composant.Position.X), float.Parse(composant.Position.Y)),
            int.Parse(composant.Taille.X), int.Parse(composant.Taille.Y));
        foreach (Sprite sprite in composant.Sprites.Sprite)
        {
          SimpleSprite simpleSprite = sprite.Opacite == null
                        ? (sprite.Order == null 
                        ? new SimpleSprite((Element2D) parent, sprite.Nom,
                        new Vector2((float) int.Parse(sprite.Taille.X),
                        (float) int.Parse(sprite.Taille.Y)), 
                        new Vector2((float) int.Parse(sprite.Position.X),
                        (float) int.Parse(sprite.Position.Y)))
                        : new SimpleSprite((Element2D) parent, sprite.Nom,
                        new Vector2((float) int.Parse(sprite.Taille.X), 
                        (float) int.Parse(sprite.Taille.Y)), 
                        new Vector2((float) int.Parse(sprite.Position.X),
                        (float) int.Parse(sprite.Position.Y)),
                        int.Parse(sprite.Order))) 
                        : (SimpleSprite) new SpriteComposant
                        (parent, sprite.Nom, new Vector2(
                            (float) int.Parse(sprite.Taille.X), 
                            (float) int.Parse(sprite.Taille.Y)),
                            new Vector2((float) int.Parse(sprite.Position.X),
                            (float) int.Parse(sprite.Position.Y)),
                            int.Parse(sprite.Order), float.Parse(sprite.Opacite));

          parent.Sprites.Add(simpleSprite);
        }
      }
      this.Joueur.Etat = (Etat) new Standard();
    }

    protected override void Initialize()
    {
      if (this.init)
      {
        this.init = false;
        this.AfficherAth();
      }
      base.Initialize();
    }

    protected override void LoadContent()
    {
      this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
    }

    protected override void UnloadContent()
    {
    }

    protected override void Update(GameTime gameTime)
    {
      ++this.i;
      
      //Random random = new Random((int) DateTime.Now.Ticks);
      //if (this.i != 60)
      //{
      //  ; //
      //  Debug.WriteLine("[i] i=" + this.i);
      //}

      base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
      this.GraphicsDevice.Clear(new Color(184, 227, 229));
      base.Draw(gameTime);
    }

    public void AfficherAth(bool press = false)
    {
      this.IsMouseVisible = true;
      this.ath = new ATHComposite((ATH) null, new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f));
      ATHCompositeButton parent1 =
                new ATHCompositeButton((ATH) this.ath, new Vector2(0.0f, -100f), 
                new Vector2(400f, 80f), BoutonType.NouvellePartie, Ancre.left, press);
      
      this.ath.add((ATH) parent1);

      parent1.add((ATH) new ATHCompositeColor((ATH) parent1, new Vector2(0.0f, 0.0f),
          new Vector2(0.0f, 0.0f), Color.Black));
      ((ATHComposite) parent1.Children[0]).add((ATH) new ATHFeuilleText(parent1.Children[0],
          new Vector2(50f, 0.0f), new Vector2(0.0f, 0.0f), "New game", Color.White, 2f, Ancre.center));
      ATHCompositeButton parent2 = new ATHCompositeButton((ATH) this.ath, new Vector2(0.0f, 0.0f), 
          new Vector2(400f, 80f), BoutonType.CommencerLeJeu, Ancre.left, press);
      this.ath.add((ATH) parent2);
      parent2.add((ATH) new ATHCompositeColor((ATH) parent2, new Vector2(0.0f, 0.0f),
          new Vector2(0.0f, 0.0f), Color.Black));
      ((ATHComposite) parent1.Children[0]).add((ATH) new ATHFeuilleText(parent2.Children[0],
          new Vector2(50f, 0.0f), new Vector2(0.0f, 0.0f), "Continue", Color.White, 2f, Ancre.center));
      ATHCompositeButton parent3 = new ATHCompositeButton((ATH) this.ath, new Vector2(0.0f, 100f),
          new Vector2(400f, 80f), BoutonType.Fermer, Ancre.left, press);
      this.ath.add((ATH) parent3);
      parent3.add((ATH) new ATHCompositeColor((ATH) parent3, new Vector2(0.0f, 0.0f),
          new Vector2(0.0f, 0.0f), Color.Black));
      ((ATHComposite) parent3.Children[0]).add((ATH) new ATHFeuilleText(parent3.Children[0],
          new Vector2(50f, 0.0f), new Vector2(0.0f, 0.0f), "Quit", Color.White, 2f, Ancre.center));
      ATHCompositeColor parent4 = new ATHCompositeColor((ATH) this.ath, new Vector2(0.0f, 0.0f),
          new Vector2(800f, 900f), Color.Black, Ancre.right);
      this.ath.add((ATH) parent4);
      parent4.add((ATH) new ATHFeuilleText((ATH) parent4, new Vector2(0.0f, -200f), 
          new Vector2(0.0f, 0.0f), "AWSD to walk", Color.White, 1f, Ancre.center));
      parent4.add((ATH) new ATHFeuilleText((ATH) parent4, new Vector2(0.0f, -150f), 
          new Vector2(0.0f, 0.0f), "Space to jump", Color.White, 1f, Ancre.center));
      parent4.add((ATH) new ATHFeuilleText((ATH) parent4, new Vector2(0.0f, -100f), 
          new Vector2(0.0f, 0.0f), "Shift to interact with objects", Color.White, 1f, Ancre.center));
      parent4.add((ATH) new ATHFeuilleText((ATH) parent4, new Vector2(0.0f, -50f), 
          new Vector2(0.0f, 0.0f), "Echap to load menu", Color.White, 1f, Ancre.center));
      parent4.add((ATH) new ATHFeuilleText((ATH) parent4, new Vector2(0.0f, 0.0f),
          new Vector2(0.0f, 0.0f), "Enjoy ! :)", Color.White, 1f, Ancre.center));
      parent4.add((ATH) new ATHFeuilleText((ATH) parent4, new Vector2(0.0f, 100f), 
          new Vector2(0.0f, 0.0f), "In this game, you must find your father by following his footstep.",
          Color.White, 1f, Ancre.center));
      parent4.add((ATH) new ATHFeuilleText((ATH) parent4, new Vector2(0.0f, 150f), 
          new Vector2(0.0f, 0.0f),
          "Be careful, even if the water is'nt deep, you can't see hole on your way.",
          Color.White, 1f, Ancre.center));
      Program.game.Components.Add((IGameComponent) this.ath);
    }
  }
}
