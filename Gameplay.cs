
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using System.Security.Cryptography;
using System.Threading;

namespace TopSektirmeDevamiProje5
{
    public class Gameplay
    {
        Random rnd = new Random();
        int _formSizeX;
        int _formSizeY;
        List<CircularPictureBox> balls = new List<CircularPictureBox>();
        private Form _form;

        public bool moveLeft;
        public bool moveRight;
        int bounceBlockSpeed = 10;
        int buttonCount = 0;
        bool isPaused = false;
        int score = 0;
        public BounceBlockPictureBox bounceBlock;

        
        private readonly string jsonPath = Combine(CurrentDirectory, "gp_yedek.json");
        private GameplayBackup BackupDatasFromFile;

        RijndaelManaged enc = new RijndaelManaged();
        

        public Gameplay(Form form)
        {
            _form = form;
            _formSizeX = _form.Size.Width;
            _formSizeY = _form.Size.Height;


            bounceBlock = new BounceBlockPictureBox();
            bounceBlock.BackColor = Color.DarkOrange;
            bounceBlock.Location = new Point(200, _form.Size.Height - bounceBlock.Size.Height - 90);
            bounceBlock.Size = new Size(200, 30);

            _form.Controls.Add(bounceBlock);
            _form.Controls["gameResultLabel"].Visible = false;

            enc.GenerateKey();
            enc.GenerateIV();

            LoadBackup();

        }


        public void PlayGame(
            ref System.Windows.Forms.Timer BallCreateTimer,
            ref System.Windows.Forms.Timer CollisionTimer,
            ref System.Windows.Forms.Timer BallPositionTimer,
            ref System.Windows.Forms.Timer GameResultTimer,
            ref System.Windows.Forms.Timer KeyboardMoveTimer)
        {
            if (isPaused)
            {
                BallCreateTimer.Start();
                CollisionTimer.Start();
                BallPositionTimer.Start();
                GameResultTimer.Start();
                KeyboardMoveTimer.Start();
                this.MoveBalls();
            }
            isPaused = false;
        }

        public void PauseGame(
            ref System.Windows.Forms.Timer BallCreateTimer,
            ref System.Windows.Forms.Timer CollisionTimer,
            ref System.Windows.Forms.Timer BallPositionTimer,
            ref System.Windows.Forms.Timer GameResultTimer,
            ref System.Windows.Forms.Timer KeyboardMoveTimer)
        {
            if (isPaused == false)
            {
                BallCreateTimer.Stop();
                CollisionTimer.Stop();
                BallPositionTimer.Stop();
                GameResultTimer.Stop();
                KeyboardMoveTimer.Stop();
                this.StopBalls();
            }
            isPaused = true;
        }
        public void GameCheck(
            ref System.Windows.Forms.Timer BallCreateTimer,
            ref System.Windows.Forms.Timer CollisionTimer,
            ref System.Windows.Forms.Timer BallPositionTimer,
            ref System.Windows.Forms.Timer GameResultTimer,
            ref System.Windows.Forms.Timer KeyboardMoveTimer)
        {
            if (balls.Count == 0 && buttonCount >= 5)
            {

                _form.Controls["gameResultLabel"].Text = "Kazandınız";

                BallCreateTimer.Stop();
                CollisionTimer.Stop();
                BallPositionTimer.Stop();
                GameResultTimer.Stop();
                KeyboardMoveTimer.Stop();
                isPaused = true;
                this.StopBalls();
                _form.Controls["gameResultLabel"].Visible = true;
            }
            else if (balls.Count >= 10)
            {
                _form.Controls["gameResultLabel"].Text = "10 Topa Ulaşıldı";

                BallCreateTimer.Stop();
                CollisionTimer.Stop();
                BallPositionTimer.Stop();
                GameResultTimer.Stop();
                KeyboardMoveTimer.Stop();
                isPaused = true;
                this.StopBalls();
                _form.Controls["gameResultLabel"].Visible = true;
            }
        }
        
        
        private void ReadBackup()
        {
            try
            {
                string jsonFromFile;
                using (var reader = new StreamReader(jsonPath))
                {
                    jsonFromFile = reader.ReadToEnd();
                }

                string decryptedJson = Protector.Decrypt(jsonFromFile);
                BackupDatasFromFile = JsonConvert.DeserializeObject<GameplayBackup>(decryptedJson);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
        private void LoadBackup()
        {
            if (File.Exists(jsonPath))
            {
                var result = MessageBox.Show("yedekten yükleme yapılsın mı?", "Yükleme",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ReadBackup();

                    for (int i = 0; i < balls.Count; i++)
                    {
                        _form.Controls.Remove(balls[i]);
                    }
                    balls.Clear();

                    foreach (var ball in BackupDatasFromFile.Balls)
                    {
                        CircularPictureBox tempTop = new CircularPictureBox(
                            ball._renk,
                            ball._positionX,
                            ball._positionY,
                            ball._directionX,
                            ball._directionY,
                            _formSizeX,
                            _formSizeY
                            );
                        balls.Add(tempTop);
                        _form.Controls.Add(tempTop);

                        _form.Controls["ballCount"].Text = "Top Sayisi : " + balls.Count.ToString();
                    }
                    bounceBlock.Location = BackupDatasFromFile.BouncBlockPosition;
                    buttonCount = BackupDatasFromFile.BallCount;
                    score = BackupDatasFromFile.Score;
                    _form.Controls["scoreLabel"].Text = "Score : " + score.ToString();

                }
            }

        }

        private void StopBalls()
        {
            foreach (var ball in balls)
            {
                ball.StopTheBall();
            }
        }

        private void MoveBalls()
        {
            foreach (var ball in balls)
            {
                ball.MoveTheBall();
            }
        }

        public void BallCreate(ref System.Windows.Forms.Timer BallCreateTimer)
        {
            if (buttonCount < 5)
            {
                buttonCount += 1;

                int color1 = rnd.Next(255);
                int color2 = rnd.Next(255);
                int color3 = rnd.Next(255);

                int posX = rnd.Next(220, _formSizeX - 400);
                int posY = rnd.Next(220, _formSizeY - 400);


                int dirX = 0;
                int dirY = 0;

                while (true)
                {
                    dirX = rnd.Next(-10, 10);
                    dirY = rnd.Next(-10, 10);

                    if (dirX != 0 && dirY != 0)
                    {
                        break;
                    }
                }

                CircularPictureBox tempTop = new CircularPictureBox(
                    Color.FromArgb(color1, color2, color3),
                    posX,
                    posY,
                    dirX,
                    dirY,
                    _formSizeX,
                    _formSizeY
                    );
                balls.Add(tempTop);
                _form.Controls.Add(tempTop);
                _form.Controls["ballCount"].Text = "Top Sayisi : " + balls.Count.ToString();
                BallCreateTimer.Enabled = true;
            }
            else
            {
                BallCreateTimer.Enabled = false;
            }
        }


        public void CollisionDetection(BounceBlockPictureBox bounceBlock,
            PictureBox leftTopCorner,
            PictureBox rightTopCorner,
            PictureBox leftBodyCorner,
            PictureBox rightBodyCorner,
            PictureBox leftTopBody,
            PictureBox rightTopBody
            )
        {
            foreach (var ball in balls)
            {
                if (ball.Bounds.IntersectsWith(bounceBlock.Bounds))
                {
                    ball.MakeOppositeY();
                    score++;
                    _form.Controls["scoreLabel"].Text = "Score: " + score.ToString();
                }
                if (ball.Bounds.IntersectsWith(leftTopCorner.Bounds))
                {
                    ball.MakeOppositeX();
                }
                if (ball.Bounds.IntersectsWith(rightTopCorner.Bounds))
                {
                    ball.MakeOppositeX();
                }
                if (ball.Bounds.IntersectsWith(leftBodyCorner.Bounds))
                {
                    ball.MakeOppositeX();
                }
                if (ball.Bounds.IntersectsWith(rightBodyCorner.Bounds))
                {
                    ball.MakeOppositeX();
                }
                if (ball.Bounds.IntersectsWith(leftTopBody.Bounds))
                {
                    ball.MakeOppositeY();
                }
                if (ball.Bounds.IntersectsWith(rightTopBody.Bounds))
                {
                    ball.MakeOppositeY();
                }

            }

        }

        public void BallPositionCheck()
        {
            for (int i = 0; i < balls.Count; i++)
            {
                if (balls[i].Location.Y <= -20)
                {
                    score += 10;
                    _form.Controls.Remove(balls[i]);
                    balls.Remove(balls[i]);
                    _form.Controls["ballCount"].Text = "Top Sayisi : " + balls.Count.ToString();
                    _form.Controls["scoreLabel"].Text = "Score: " + score.ToString();
                }
                else if (balls[i].Location.Y >= _formSizeY - 90)
                {
                    score -= 20;
                    _form.Controls.Remove(balls[i]);
                    balls.Remove(balls[i]);
                    _form.Controls["ballCount"].Text = "Top Sayisi : " + balls.Count.ToString();
                    _form.Controls["scoreLabel"].Text = "Score: " + score.ToString();

                    BallCreateForPenalty();
                    BallCreateForPenalty();
                }
            }

        }

        public void BallCreateForPenalty()
        {
            int color1 = rnd.Next(255);
            int color2 = rnd.Next(255);
            int color3 = rnd.Next(255);

            int posX = rnd.Next(220, _formSizeX - 220);
            int posY = rnd.Next(220, _formSizeY - 220);


            int dirX = 0;
            int dirY = 0;

            while (true)
            {
                dirX = rnd.Next(-10, 10);
                dirY = rnd.Next(-10, 10);

                if (dirX != 0 && dirY != 0)
                {
                    break;
                }
            }


            CircularPictureBox tempTop = new CircularPictureBox(
                Color.FromArgb(color1, color2, color3),
                posX,
                posY,
                dirX,
                dirY,
                _formSizeX,
                _formSizeY
                );
            balls.Add(tempTop);
            _form.Controls.Add(tempTop);

            _form.Controls["ballCount"].Text = "Top Sayisi : " + balls.Count.ToString();
        }

        public void KeyboardMovement()
        {
            if (moveLeft == true && bounceBlock.Left > 40)
            {
                bounceBlock.Left -= bounceBlockSpeed;
            }
            if (moveRight == true && bounceBlock.Right < _formSizeX - 55)
            {
                bounceBlock.Left += bounceBlockSpeed;
            }
        }

        public void BlockMoveDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = true;
            }
        }

        public void BlockMoveUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = false;
            }
        }

        public void AutoSaveWithThread()
        {
            while (true)
            {
                Thread.Sleep(15000); // Normalde 2 dk olucak ama test için 15 saniye yaptım.

                try
                {
                    var datas = GetDatas();
                    var jsonToWrite = JsonConvert.SerializeObject(datas, Formatting.Indented);
                    string encryptedJson = Protector.Encrypt(jsonToWrite);
                    using (var writer = new StreamWriter(jsonPath))
                    {
                        writer.Write(encryptedJson);
                    }

                    MessageBox.Show("Auto Save");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        //public void AutoSave(ref System.Windows.Forms.Timer BackupSaveTimer)
        //{
        //    MessageBox.Show("AutoSave");
        //    BackupSaveTimer.Enabled = true;
        //    try
        //    {
        //        var datas = GetDatas();
        //        var jsonToWrite = JsonConvert.SerializeObject(datas, Formatting.Indented);
        //        string encryptedJson = Protector.Encrypt(jsonToWrite);
        //        using (var writer = new StreamWriter(jsonPath))
        //        {
        //            writer.Write(encryptedJson);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}
        public void ManualSave()
        {
            try
            {
                var datas = GetDatas();

                var jsonToWrite = JsonConvert.SerializeObject(datas, Formatting.Indented);
                string encryptedJson = Protector.Encrypt(jsonToWrite);

                using (var writer = new StreamWriter(jsonPath))
                {
                    writer.Write(encryptedJson);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void ManualLoadBackup()
        {
            LoadBackup();
        }

        public GameplayBackup GetDatas()
        {
            List<Balls> ballProps = new List<Balls>();

            foreach (var ball in balls)
            {
                Balls tempBall = new Balls
                {
                    _renk = ball._renk,
                    _directionX = ball._directionX,
                    _directionY = ball._directionY,
                    _positionX = ball.Location.X,
                    _positionY = ball.Location.Y
                };
                ballProps.Add(tempBall);
            }
            GameplayBackup datas = new GameplayBackup
            {
                Balls = ballProps,
                BallCount = ballProps.Count,
                BouncBlockPosition = bounceBlock.Location,
                Score = score
            };
            return datas;
        }
    }
}
