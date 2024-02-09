// Xml2CSharp.Carte

using System.Xml.Serialization;

#nullable disable
namespace Xml2CSharp
{
  [XmlRoot(ElementName = "Carte")]
  public class Carte
  {
    [XmlElement(ElementName = "Composants")]
    public Composants Composants { get; set; }
  }
}
