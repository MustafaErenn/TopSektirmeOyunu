using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopSektirmeDevamiProje5
{
    public partial class Form1 : Form
    {

        // MUSTAFA EREN 18360859024 PROJE 8
        // Proje8'nin isterleri proje5'in devamı oldugundan direkt olarak proje5 projesinin üstünde değişiklik yaptım
        // İsmi Proje5 olarak kaldı ancak bu PROJE8 isterlerini karşılayan ödevdir.
        // gp_yedek.json dosyası bin>Debug>net5.0-windows> içinde yer almaktadir.
        // gp_yedek.json dosyası şifrelidir.

        // proje 8 de istenen timer'i thread ile değiştirme işlemi yapılmıştır.
        // Otomatik save için kullanılan timer yerine thread kullanılmıştır.
        // 62-67 satirlar arası görünmektedir.

        public static Timer BallCreateTimer = new Timer();
        public static Timer CollisionTimer = new Timer();
        public static Timer BallPositionTimer = new Timer();
        public static Timer GameResultTimer = new Timer();
        public static Timer KeyboardMoveTimer = new Timer();
        public static Timer BackupSaveTimer = new Timer();

        Random rnd = new Random();
        Gameplay gp;
        public Form1()
        {
            InitializeComponent();

            gp = new Gameplay(this);

            BallCreateTimer.Tick += new EventHandler(BallCreateEventProcessor);
            BallCreateTimer.Interval = 10000;
            BallCreateTimer.Start();

            KeyboardMoveTimer.Tick += new EventHandler(KeyboardMoveEventProcessor);
            KeyboardMoveTimer.Interval = 10;
            KeyboardMoveTimer.Start();

            CollisionTimer.Tick += new EventHandler(CollisionEventProcessor);
            CollisionTimer.Interval = 20;
            CollisionTimer.Start();

            BallPositionTimer.Tick += new EventHandler(BallPositionEventProcessor);
            BallPositionTimer.Interval = 30;
            BallPositionTimer.Start();

            GameResultTimer.Tick += new EventHandler(GameResultEventProcessor);
            GameResultTimer.Interval = 30;
            GameResultTimer.Start();


            //AUTO SAVE'DEN SORUMLU OLAN TİMER VE BUNU KAPATIP ALTTAKİ THREAD'İ OLUSTURDUM.
            //BackupSaveTimer.Tick += new EventHandler(BackupSaveEventProcessor);
            //BackupSaveTimer.Interval = 10000;//120000
            //BackupSaveTimer.Start();

            Task autoSaveTask = Task.Run(new Action(BackupAutoSaveThreadFunction));

        }
        private void KeyboardMoveEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            gp.KeyboardMovement();
        }

        private void BlockMoveDown(object sender, KeyEventArgs e)
        {
            gp.BlockMoveDown(e);
        }

        private void BlockMoveUp(object sender, KeyEventArgs e)
        {
            gp.BlockMoveUp(e);
        }
        private void GameResultEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            gp.GameCheck(ref BallCreateTimer, ref CollisionTimer, ref BallPositionTimer, ref GameResultTimer,ref KeyboardMoveTimer);
        }
        

        
        private void BackupAutoSaveThreadFunction()
        {
            gp.AutoSaveWithThread();
        }
        //private void BackupSaveEventProcessor(Object myObject, EventArgs myEventArgs)
        //{
        //    //AUTO SAVE TIMER EVENT FONKSİYONU
        //    gp.AutoSave(ref BackupSaveTimer);
        //}

        private void BallPositionEventProcessor(Object myObject, EventArgs myEventArgs)
        {
           gp.BallPositionCheck();
        }

     
        private void BallCreateEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            gp.BallCreate(ref BallCreateTimer);
        }

        private void CollisionEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            gp.CollisionDetection(gp.bounceBlock,
              leftTopCorner,
              rightTopCorner,
              leftBodyCorner,
              rightBodyCorner,
              leftTopBody,
              rightTopBody);
        }

        private void PlayButtonClicked(object sender, EventArgs e)
        {
            gp.PlayGame(ref BallCreateTimer, ref CollisionTimer, ref BallPositionTimer, ref GameResultTimer, ref KeyboardMoveTimer);
        }

        private void PauseButtonClicked(object sender, EventArgs e)
        {
            gp.PauseGame(ref BallCreateTimer, ref CollisionTimer, ref BallPositionTimer, ref GameResultTimer, ref KeyboardMoveTimer);
        }

        private void BackupButtonClicked(object sender, EventArgs e)
        {
            gp.ManualSave();
        }
        private void RestoreButtonClicked(object sender, EventArgs e)
        {
            gp.ManualLoadBackup();
        }
    }
}
