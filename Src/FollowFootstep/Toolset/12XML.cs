﻿// Decompiled with JetBrains decompiler
// Type: Xml2CSharp.Sauvegarde
// Assembly: GameManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A56AFD03-F9CC-4354-BD49-E5DE8D292E54
// Assembly location: C:\Users\Admin\Desktop\RE\FootStep\GameManager.exe

using System.Xml.Serialization;

#nullable disable
namespace Xml2CSharp
{
  [XmlRoot(ElementName = "Sauvegarde")]
  public class Sauvegarde
  {
    [XmlElement(ElementName = "Joueur")]
    public Joueur Joueur { get; set; }

    [XmlElement(ElementName = "Carte")]
    public Carte Carte { get; set; }
  }
}
