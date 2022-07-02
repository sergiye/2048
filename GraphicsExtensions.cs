using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace u2048 {
  internal static class GraphicsExtensions {
    internal static void DrawTextCenterXws(this Graphics g, string sText, Font nFont, SolidBrush nSolidBrush,
      SolidBrush nSolidBrush2, int x, int y) {
      var stringSize = g.MeasureString(sText, nFont);
      g.DrawString(sText, nFont, nSolidBrush, new PointF(x - stringSize.Width / 2 + 1, y + 1));
      g.DrawString(sText, nFont, nSolidBrush2, new PointF(x - stringSize.Width / 2, y));
    }

    internal static void DrawTextCenterWs(this Graphics g, string sText, Font nFont, SolidBrush nSolidBrush,
      SolidBrush nSolidBrush2, int x, int y) {
      var stringSize = g.MeasureString(sText, nFont);
      g.DrawString(sText, nFont, nSolidBrush, new PointF(x - stringSize.Width / 2 + 1, y - stringSize.Height / 2 + 1));
      g.DrawString(sText, nFont, nSolidBrush2, new PointF(x - stringSize.Width / 2, y - stringSize.Height / 2));
    }

    private static GraphicsPath RoundedRect(Rectangle bounds, int radius) {
      var diameter = radius * 2;
      var size = new Size(diameter, diameter);
      var arc = new Rectangle(bounds.Location, size);
      var path = new GraphicsPath();

      if (radius == 0) {
        path.AddRectangle(bounds);
        return path;
      }

      // top left arc  
      path.AddArc(arc, 180, 90);

      // top right arc  
      arc.X = bounds.Right - diameter;
      path.AddArc(arc, 270, 90);

      // bottom right arc  
      arc.Y = bounds.Bottom - diameter;
      path.AddArc(arc, 0, 90);

      // bottom left arc 
      arc.X = bounds.Left;
      path.AddArc(arc, 90, 90);

      path.CloseFigure();
      return path;
    }

    internal static void DrawRoundedRectangle(this Graphics graphics, Pen pen, Rectangle bounds, int cornerRadius) {
      if (graphics == null)
        throw new ArgumentNullException("graphics");
      if (pen == null)
        throw new ArgumentNullException("pen");
      using (var path = RoundedRect(bounds, cornerRadius)) {
        graphics.DrawPath(pen, path);
      }
    }

    internal static void FillRoundedRectangle(this Graphics graphics, Brush brush, Rectangle bounds, int cornerRadius) {
      if (graphics == null)
        throw new ArgumentNullException("graphics");
      if (brush == null)
        throw new ArgumentNullException("brush");
      using (var path = RoundedRect(bounds, cornerRadius)) {
        graphics.FillPath(brush, path);
      }
    }
  }
}