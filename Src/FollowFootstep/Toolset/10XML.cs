// Decompiled with JetBrains decompiler
// Type: Xml2CSharp.TailleSprite
// Assembly: monogameJam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A56AFD03-F9CC-4354-BD49-E5DE8D292E54
// Assembly location: C:\Users\Admin\Desktop\RE\FootStep\monogameJam.exe

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
