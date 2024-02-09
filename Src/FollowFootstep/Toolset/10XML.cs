// Xml2CSharp.TailleSprite

using System.Xml.Serialization;

#nullable disable
namespace Xml2CSharp
{
  [XmlRoot(ElementName = "TailleSprite")]
  public class TailleSprite
  {
    [XmlElement(ElementName = "Taille")]
    public Taille Taille { get; set; }

    [XmlElement(ElementName = "Position")]
    public Position Position { get; set; }
  }
}
