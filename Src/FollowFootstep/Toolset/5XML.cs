// Xml2CSharp.Taille

using System.Xml.Serialization;

#nullable disable
namespace Xml2CSharp
{
  [XmlRoot(ElementName = "Taille")]
  public class Taille
  {
    [XmlAttribute(AttributeName = "x")]
    public string X { get; set; }

    [XmlAttribute(AttributeName = "y")]
    public string Y { get; set; }

    public Taille()
    {
    }

    public Taille(float x, float y)
    {
      this.X = x.ToString();
      this.Y = y.ToString();
    }
  }
}
