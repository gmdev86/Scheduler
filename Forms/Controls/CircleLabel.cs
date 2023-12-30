using System.Drawing;
using System.Windows.Forms;

namespace Scheduler.Forms.Controls
{
    public class CircleLabel : Label
    {
        public CircleLabel()
        {
            this.Text = "00";
            this.AutoSize = true;
            
            Size textSize = TextRenderer.MeasureText(this.Text, this.Font);
            this.Size = new Size(textSize.Width + 10, textSize.Height + 10);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;

            using (Pen pen = new Pen(Color.Red, 2))
            {
                Rectangle circleBounds = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
                graphics.DrawEllipse(pen, circleBounds);
            }

        }

    }
}
