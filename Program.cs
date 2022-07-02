using System;
using System.Windows.Forms;

namespace u2048 {
  static class Program {
    [STAThread]
    static void Main() {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new Main());
    }
  }
}
