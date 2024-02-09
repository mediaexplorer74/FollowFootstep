// XML

using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;
using Windows.Storage;
using Xml2CSharp;

#nullable disable
namespace GameManager
{
  internal class XML
  {
    public static Sauvegarde Load(string path)
    {
      string fullpath = ApplicationData.Current.LocalFolder.Path + "/" + path;
      try
      {
        using (FileStream fileStream = new FileStream(/*path*/fullpath, FileMode.Open))
          return new XmlSerializer(typeof (Sauvegarde)).Deserialize((Stream) fileStream) as Sauvegarde;
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Exception loading config file: " + (object) ex);
        return (Sauvegarde) null;
      }
    }

    public static void Save(string path)
    {
      Sauvegarde save = new Sauvegarde()
      {
        Joueur = new Xml2CSharp.Joueur()
      };

      save.Joueur.Position = new Position(Game1.game.Joueur.Position.X, Game1.game.Joueur.Position.Y);
      XML.Save(save, path);
    }

    public static void Save(Sauvegarde save, string path)
    {
      string fullpath = ApplicationData.Current.LocalFolder.Path + "/" + path;
      save.Joueur.Empreintes = new Empreintes();
      save.Carte = new Xml2CSharp.Carte();
      save.Carte.Composants = new Composants();
      save.Joueur.Mort = Joueur.nbMort.ToString();
      save.Joueur.Empreintes = new Empreintes();
      
      foreach (Empreinte empreinte in Game1.game.Joueur.Souvenir)
      { 
        save.Joueur.Empreintes.Empreinte.Add(new Xml2CSharp.Empreinte()
        {
            Position = new Position(empreinte.Position.X, empreinte.Position.Y),
            Vie = empreinte.Vie.ToString(),
            Eternel = empreinte.Eternel.ToString(),
            TailleSprite = new TailleSprite()
            {
                Position = new Position((float)empreinte.TailleSprite.X, (float)empreinte.TailleSprite.Y),
                Taille = new Taille((float)empreinte.TailleSprite.Width, (float)empreinte.TailleSprite.Height)
            }
        });
      }

      foreach (Composant composant1 in Game1.game.Carte.Composants)
      {
        if (!(composant1 is Joueur))
        {
          Xml2CSharp.Composant composant2 = new Xml2CSharp.Composant();
          composant2.Taille = new Taille(composant1.Taille.X, composant1.Taille.Y);
          composant2.Position = new Position(composant1.Position.X, composant1.Position.Y);
          composant2.Sprites = new Sprites();
          composant2.Classe = composant1.Classe;
          foreach (SimpleSprite sprite in composant1.Sprites)
          {
            if (sprite.ToXML)
              composant2.Sprites.Sprite.Add(new Sprite()
              {
                Nom = sprite.Texture,
                Taille = new Taille(sprite.Taille.X, sprite.Taille.Y),
                Position = new Position(sprite.Position.X, sprite.Position.Y)
              });
          }
          save.Carte.Composants.Composant.Add(composant2);
        }
      }
      try
      {
        using (FileStream fileStream = new FileStream(fullpath, FileMode.Create))
          new XmlSerializer(typeof (Sauvegarde)).Serialize((Stream) fileStream, (object) save);
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Exception creating config file: " + (object) ex);
      }
    }
  }
}
