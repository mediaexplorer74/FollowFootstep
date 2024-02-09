// Decompiled with JetBrains decompiler
// Type: Xml2CSharp.Type
// Assembly: GameManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A56AFD03-F9CC-4354-BD49-E5DE8D292E54
// Assembly location: C:\Users\Admin\Desktop\RE\FootStep\GameManager.exe

using System.Xml.Serialization;

#nullable disable
namespace Xml2CSharp
{
  [XmlRoot(ElementName = "Type")]
  public class Type
  {
    [XmlAttribute(AttributeName = "nom")]
    public string Nom { get; set; }

    public Type()
    {
    }

    public Type(GameManager.Type type) => this.Nom = type.ToString();
  }
}
