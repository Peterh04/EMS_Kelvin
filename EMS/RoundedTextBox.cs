using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace EMS
{
    internal class RoundedTextBox : TextBox
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

        
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(new Rectangle(0, 0, 20, 20), 180, 90);
                path.AddArc(new Rectangle(Width - 20, 0, 20, 20), 270, 90);
                path.AddArc(new Rectangle(Width - 20, Height - 20, 20, 20), 0, 90);
                path.AddArc(new Rectangle(0, Height - 20, 20, 20), 90, 90);
                path.CloseAllFigures();

                
                this.Region = new Region(path);

                
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(Color.Gray, 1))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }
    }
}
