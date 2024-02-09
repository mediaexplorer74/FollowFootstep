// Decompiled with JetBrains decompiler
// Type: GameManager.Porter
// Assembly: GameManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A56AFD03-F9CC-4354-BD49-E5DE8D292E54
// Assembly location: C:\Users\Admin\Desktop\RE\FootStep\GameManager.exe

#nullable disable
namespace GameManager
{
  internal class Porter : Etat
  {
    public Porter(Composant c) => this.joueur.ActionObjet = true;

    public override void Deplacement(Direction direction)
    {
    }

    public override void Lacher()
    {
    }

    public override void Jeter()
    {
    }

    public override void ActionObjet()
    {
    }

    public override void Attraper(Composant c)
    {
    }
  }
}
