// Decompiled with JetBrains decompiler
// Type: monogameJam.Program
// Assembly: monogameJam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A56AFD03-F9CC-4354-BD49-E5DE8D292E54
// Assembly location: C:\Users\Admin\Desktop\RE\FootStep\monogameJam.exe

using System;

#nullable disable
namespace monogameJam
{
  public static class Program
  {
    public static Game1 game = new Game1();

    [STAThread]
    private static void Main() => Program.game.Run();
  }
}
