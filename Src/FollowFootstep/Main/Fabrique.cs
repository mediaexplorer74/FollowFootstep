// Fabrique

using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;

#nullable disable
namespace GameManager
{
  public class Fabrique
  {
    private Vector2 minSize = new Vector2(30f, 30f);
    public int idCrabe = 0;
    public int idTrou = 0;
    public int idIllot = 0;
    public int idBouteille = 0;

    public Composant creerComposant(string objet, Vector2 position, int tailleX = 20, int tailleY = 20)
    {
      switch (objet)
      {
        case "Bouteille":
          ++this.idBouteille;
          Composant c1 = new Composant("bouteille1", position, new Vector2(50f, 80f),
              "bouteille_mer", new Rectangle(0, 40, 50, 40), Type.TBouteille, "Bouteille");
          c1.Solid = true;
          Game1.game.Carte.add(c1);
          return c1;
        case "Cabane":
          Composant c2 = new Composant("cabane", position, new Vector2(600f, 630f),
              "cabane", new Rectangle(10, 520, 360, 100), Type.TMaison, "Cabane");
          c2.Solid = true;
          Game1.game.Carte.add(c2);
          return c2;
        case "Crabe":
          ++this.idCrabe;
          PNJ c3 = new PNJ("crabe" + (object) this.idCrabe, position, new Vector2(30f, 30f), 
              "crabe", new Rectangle(0, 15, 30, 15), Type.PetitPNJ, "Crabe");
          c3.Solid = false;
          Game1.game.Carte.add((Composant) c3);
          return (Composant) c3;
        case "Illot":
          bool flag1 = false;
          foreach (Composant composant in Game1.game.Carte.Composants)
          {
            if (composant.Type == Type.TIllot && composant.Hitbox().Intersects(
                new Rectangle((int) position.X, (int) position.Y, tailleX, tailleY)))
              ;
          }
          if (!flag1)
          {
            ++this.idIllot;
            Composant c4 = new Composant("illot" + (object) this.idTrou, position, new Vector2(140f, 90f),
                "tonneau_englouti", new Rectangle(41, 29, 60, 20), Type.TIllot, "Illot");
            c4.Solid = false;
            Game1.game.Carte.add(c4);
            return c4;
          }
          Debug.WriteLine("Il y'a déjà un illot ici!");
          return (Composant) null;
        case "Papa":
          PNJ pnj = new PNJ("PapaRocher", new Vector2(5125f, 4850f), new Vector2(200f, 300f),
              "papa_Rocher",
              new Rectangle(35, 186, 132, 84), Type.PapaRocher, "papa_rocher");
          pnj.AddSprite((SimpleSprite) new SpriteComposant((Composant) pnj, "papa",
              new Vector2(200f, 300f), Vector2.Zero, 2));
          pnj.Solid = true;
          Game1.game.Carte.add((Composant) pnj);
          return (Composant) pnj;
        case "Rocher":
          Composant c5 = new Composant("rocher", position, new Vector2(130f, 130f), 
              "rocher", new Rectangle(0, 75, 130, 55), Type.PetitPNJ, "Rocher");
          c5.Solid = true;
          Game1.game.Carte.add(c5);
          return c5;
        case "Tonneau":
          Composant c6 = new Composant("tonneau", position, new Vector2(60f, 76f), 
              "tonneau", new Rectangle(0, 46, 60, 30), Type.TPoussable, "Tonneau");
          c6.Solid = true;
          Game1.game.Carte.add(c6);
          return c6;
        case "Trou":
          bool flag2 = false;
          foreach (Composant composant in Game1.game.Carte.Composants)
          {
            if (composant.Type == Type.Trou && composant.Hitbox().Intersects(
                new Rectangle((int) position.X, (int) position.Y, tailleX, tailleY)))
              flag2 = true;
          }
          if (!flag2)
          {
            ++this.idTrou;
            Composant c7 = new Composant("trou" + (object) this.idTrou, position,
                new Vector2((float) tailleX, (float) tailleY), "map", Type.Trou, "Trou");
            c7.Solid = false;
            Game1.game.Carte.add(c7);
            return c7;
          }
          Debug.WriteLine("Il y'a déjà un trou ici!");
          return (Composant) null;
        default:
          return (Composant) null;
      }
    }
  }
}
