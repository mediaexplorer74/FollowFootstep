// Decompiled with JetBrains decompiler
// Type: Xml2CSharp.Empreintes
// Assembly: monogameJam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A56AFD03-F9CC-4354-BD49-E5DE8D292E54
// Assembly location: C:\Users\Admin\Desktop\RE\FootStep\monogameJam.exe

using System.Collections.Generic;
using System.Xml.Serialization;

#nullable disable
namespace Xml2CSharp
{
  [XmlRoot(ElementName = "Empreintes")]
  public class Empreintes
  {
    [XmlElement(ElementName = "Empreinte")]
    public List<Xml2CSharp.Empreinte> Empreinte { get; set; }

    public Empreintes() => this.Empreinte = new List<Xml2CSharp.Empreinte>();
  }
}
