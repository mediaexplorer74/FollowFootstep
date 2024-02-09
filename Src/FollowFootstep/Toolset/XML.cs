// Decompiled with JetBrains decompiler
// Type: Xml2CSharp.Position
// Assembly: monogameJam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A56AFD03-F9CC-4354-BD49-E5DE8D292E54
// Assembly location: C:\Users\Admin\Desktop\RE\FootStep\monogameJam.exe

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
