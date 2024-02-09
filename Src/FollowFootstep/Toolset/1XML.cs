// Decompiled with JetBrains decompiler
// Type: Xml2CSharp.Empreinte
// Assembly: GameManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A56AFD03-F9CC-4354-BD49-E5DE8D292E54
// Assembly location: C:\Users\Admin\Desktop\RE\FootStep\GameManager.exe

using System.Xml.Serialization;

#nullable disable
namespace Xml2CSharp
{
  [XmlRoot(ElementName = "Empreinte")]
  public class Empreinte
  {
    [XmlElement(ElementName = "Position")]
    public Position Position { get; set; }

    [XmlElement(ElementName = "TailleSprite")]
    public TailleSprite TailleSprite { get; set; }

    [XmlElement(ElementName = "Vie")]
    public string Vie { get; set; }

    [XmlElement(ElementName = "Eternel")]
    public string Eternel { get; set; }
  }
}
