// Decompiled with JetBrains decompiler
// Type: Xml2CSharp.Joueur
// Assembly: GameManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A56AFD03-F9CC-4354-BD49-E5DE8D292E54
// Assembly location: C:\Users\Admin\Desktop\RE\FootStep\GameManager.exe

using System.Xml.Serialization;

#nullable disable
namespace Xml2CSharp
{
  [XmlRoot(ElementName = "Joueur")]
  public class Joueur
  {
    [XmlElement(ElementName = "Position")]
    public Position Position { get; set; }

    [XmlElement(ElementName = "Mort")]
    public string Mort { get; set; }

    [XmlElement(ElementName = "Empreintes")]
    public Empreintes Empreintes { get; set; }
  }
}
