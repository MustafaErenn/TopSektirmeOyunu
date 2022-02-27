using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopSektirmeDevamiProje5
{
    public class GameplayBackup
    {
        public int Score { get; set; }
        public int BallCount { get; set; }
        public List<Balls> Balls { get; set; }
        public Point BouncBlockPosition { get; set; }
    }
}
