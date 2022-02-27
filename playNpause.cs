using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopSektirmeDevamiProje5
{
    public class playNpause: Label
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            this.AutoSize = false;
            this.Font = new Font(this.Font.FontFamily, 10, FontStyle.Bold);
            this.Size = new Size(100, 40);
            this.TextAlign = ContentAlignment.MiddleCenter;
            
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, 
                Color.Black, 5,ButtonBorderStyle.Solid,
                Color.Black, 5, ButtonBorderStyle.Solid,
                Color.Black, 5, ButtonBorderStyle.Solid,
                Color.Black, 5, ButtonBorderStyle.Solid);
            base.OnPaint(e);
        }
    }
}
