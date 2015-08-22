using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenLawOffice.Word
{
    public class LoadingPanelControl : Panel
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
                return cp;
            }
        }

        public LoadingPanelControl()
        {
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush backgroundBrush = new SolidBrush(Color.FromArgb(180, 200, 200, 200));
            Brush labelBoxBrush = new SolidBrush(Color.FromArgb(225, 255, 255, 255));
            Font font = new System.Drawing.Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point);
            PointF textPosition;
            SizeF stringSize;

            base.OnPaint(e);

            stringSize = g.MeasureString("Please wait...", font);
            textPosition = new PointF((Width - stringSize.Width) / 2, (Height - stringSize.Height) / 2);

            // Background
            g.FillRectangle(backgroundBrush, 0, 0, Width, Height);

            // Label Box
            g.FillRectangle(labelBoxBrush, textPosition.X - 30, textPosition.Y - 20, stringSize.Width + 60, stringSize.Height + 40);
            g.DrawRectangle(new Pen(Color.Black, 1), textPosition.X - 30, textPosition.Y - 20, stringSize.Width + 60, stringSize.Height + 40);
            
            // Label
            g.DrawString("Please wait...", font, Brushes.Black, textPosition);
        }
    }
}
