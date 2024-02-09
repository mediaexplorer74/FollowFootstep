// Decompiled with JetBrains decompiler
// Type: Xml2CSharp.Composants
// Assembly: GameManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A56AFD03-F9CC-4354-BD49-E5DE8D292E54
// Assembly location: C:\Users\Admin\Desktop\RE\FootStep\GameManager.exe

using System.Collections.Generic;
using System.Xml.Serialization;

#nullable disable
namespace Xml2CSharp
{
  [XmlRoot(ElementName = "Composants")]
  public class Composants
  {
    [XmlElement(ElementName = "Composant")]
    public List<Xml2CSharp.Composant> Composant { get; set; }

    public Composants() => this.Composant = new List<Xml2CSharp.Composant>();
  }
}
