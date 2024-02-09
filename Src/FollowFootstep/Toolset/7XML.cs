// Decompiled with JetBrains decompiler
// Type: Xml2CSharp.Sprites
// Assembly: monogameJam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A56AFD03-F9CC-4354-BD49-E5DE8D292E54
// Assembly location: C:\Users\Admin\Desktop\RE\FootStep\monogameJam.exe

using System.Collections.Generic;
using System.Xml.Serialization;

#nullable disable
namespace Xml2CSharp
{
  [XmlRoot(ElementName = "Sprites")]
  public class Sprites
  {
    [XmlElement(ElementName = "Sprite")]
    public List<Xml2CSharp.Sprite> Sprite { get; set; }

    public Sprites() => this.Sprite = new List<Xml2CSharp.Sprite>();
  }
}
