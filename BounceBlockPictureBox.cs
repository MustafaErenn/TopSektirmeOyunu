using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopSektirmeDevamiProje5
{
    public class BounceBlockPictureBox:PictureBox
    {
        Point _point;

        public BounceBlockPictureBox() 
        {
        }
        
        protected override void OnMouseDown(MouseEventArgs e)
        {
            _point = e.Location;
            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left += e.X - _point.X;
            }
            base.OnMouseDown(e);
        }
    }
}
