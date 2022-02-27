using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopSektirmeDevamiProje5
{
    public class CircularPictureBox : PictureBox
    {
        public Color _renk;
        public int _positionX;
        public int _positionY;
        public int _directionX;
        public int _directionY;
        private int _formSizeX;
        private int _formSizeY;
        private  Timer myTimer;


        public void MakeOppositeX()
        {
            _directionX *= -1;
        }
        public void MakeOppositeY()
        {
            _directionY *= -1;
        }

        public CircularPictureBox(Color renk, int positionX, int positionY, int directionX, int directionY, int formSizeX, int formSizeY)
        {
            _renk = renk;
            _positionX = positionX;
            _positionY = positionY;
            _directionX = directionX;
            _directionY = directionY;
            _formSizeX = formSizeX;
            _formSizeY = formSizeY;

            myTimer = new Timer();
            myTimer.Interval = 20;
            myTimer.Start();

            myTimer.Tick += new EventHandler(TimerEventProcessor);
            this.Size = new Size(75, 75);


            this.BackColor = _renk;
            this.Location = new Point((int)_positionX, (int)_positionY);
            this.Visible = true;

        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            GraphicsPath grPath = new GraphicsPath();
            grPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            Region = new Region(grPath);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            base.OnPaint(e);
        }

        private void movement()
        {
            this.Left += (_directionX);
            this.Top -= (_directionY);
        }
        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            movement();
        }
        public void StopTheBall()
        {
            myTimer.Enabled = false;
        }

        public void MoveTheBall()
        {
            myTimer.Enabled = true;
        }





    }
}
