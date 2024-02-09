// Game1

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using Xml2CSharp;

#nullable disable
namespace GameManager
{
  public class Game1 : Game
  {
    public static Game1 game = new Game1();

    public GraphicsDeviceManager graphics;
    public SpriteBatch spriteBatch;

    public static Vector2 baseScreenSize = new Vector2(800, 480);
    
    public static Matrix globalTransformation;

    public static int backbufferWidth, backbufferHeight;

    RenderTarget2D renderTarget;


    private int i = 0;
    private ATHComposite ath;
    private bool init = true;
    private string path;
    private Carte carte;
    private Joueur joueur;
    public static Fabrique f = new Fabrique();

    private SpriteFont spriteFont;


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
      
      //this.graphics.GraphicsProfile = GraphicsProfile.HiDef;

      this.Content.RootDirectory = "Content";

      graphics = new GraphicsDeviceManager(this);


#if WINDOWS_PHONE
            TargetElapsedTime = TimeSpan.FromTicks(333333);
#endif
        graphics.IsFullScreen = false;//true;//set it true for W10M



        //RnD
        graphics.PreferredBackBufferWidth = 800; // 1600
        graphics.PreferredBackBufferHeight = 480; // 900

        graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft
            | DisplayOrientation.LandscapeRight;// | DisplayOrientation.Portrait;

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

      Game1.game.Components.Add((IGameComponent) this.carte);
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


    // Initialize
    protected override void Initialize()
    {
        this.renderTarget = new RenderTarget2D(this.GraphicsDevice, 800, 480, false,
        this.GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.Depth24);

      //RnD
      if (this.init)
      {
        this.init = false;

        //this.AfficherAth();
      }
      
      base.Initialize();

            //TEST ZONE
       //     if (this.init)
       //     {
       //         this.init = false;
       //         this.AfficherAth();
       //     }


        }//Initialize

    protected override void LoadContent()
    {
        // Experimental
        //if (this.init)
        //{
            //this.init = false;
            //this.AfficherAth();
        //}


        this.Content.RootDirectory = "Content";

        this.spriteFont = this.Content.Load<SpriteFont>("spritefont");

        this.spriteBatch = new SpriteBatch(this.GraphicsDevice);


            // ... ?

      ScalePresentationArea();
    }

    protected override void UnloadContent()
    {
    }

    //!
    public void ScalePresentationArea()
    {
        //Work out how much we need to scale our graphics to fill the screen
        backbufferWidth = this.GraphicsDevice.PresentationParameters.BackBufferWidth - 0; // 40 - dirty hack for Astoria!
        backbufferHeight = this.GraphicsDevice.PresentationParameters.BackBufferHeight;

        float horScaling = backbufferWidth / baseScreenSize.X;
        float verScaling = backbufferHeight / baseScreenSize.Y;

        Vector3 screenScalingFactor = new Vector3(horScaling, verScaling, 1);

        globalTransformation = Matrix.CreateScale(screenScalingFactor);

        Debug.WriteLine("Screen Size - Width["
            + GraphicsDevice.PresentationParameters.BackBufferWidth + "] " +
            "Height [" + GraphicsDevice.PresentationParameters.BackBufferHeight + "]");
    }//

    protected override void Update(GameTime gameTime)
    {
        // !
        //Confirm the screen has not been resized by the user
        if (backbufferHeight != GraphicsDevice.PresentationParameters.BackBufferHeight ||
            backbufferWidth != GraphicsDevice.PresentationParameters.BackBufferWidth)
        {
            ScalePresentationArea();
        }

        ++this.i;

        Random random = new Random((int) DateTime.Now.Ticks);

        //if (this.i != 60)
        //{         
        //  Debug.WriteLine("[i] Game1, Update, after Random, i=" + this.i);
        //}

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
            //RnD
            //this.GraphicsDevice.Clear(new Color(184, 227, 229));
            //Game1.game.GraphicsDevice.Clear(new Color (184, 227, 229));
            this.GraphicsDevice.Clear(Color.CornflowerBlue);

            //--------------------------------------------------
            
            this.spriteBatch.Begin(SpriteSortMode.BackToFront, null,
        null, null, null, null, globalTransformation);

            this.spriteBatch.DrawString(this.spriteFont,
            "Oh crap! It's here! I did not put hiding spots here! Sorry!", 
              new Vector2(3f, 100f), Color.White, 0.0f, new Vector2(0.0f, 0.0f),
              1f, SpriteEffects.None, 
              0.0f);

            // ...?

            //foreach (IGameComponent component in this.Components)
            //{
            //    component.Initialize();
            //}


            this.spriteBatch.End();
            
            //--------------------------------------------------

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
            

      //RnD
      //Game1.game.Components.Add((IGameComponent) this.ath);
    }
  }
}
