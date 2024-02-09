// Xml2CSharp.Position

using System.Xml.Serialization;

#nullable disable
namespace Xml2CSharp
{
  [XmlRoot(ElementName = "Position")]
  public class Position
  {
    [XmlAttribute(AttributeName = "x")]
    public string X { get; set; }

    [XmlAttribute(AttributeName = "y")]
    public string Y { get; set; }

    public Position()
    {
    }

    public Position(float x, float y)
    {
      this.X = x.ToString();
      this.Y = y.ToString();
    }
  }
}
