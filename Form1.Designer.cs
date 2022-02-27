
namespace TopSektirmeDevamiProje5
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.leftBodyCorner = new System.Windows.Forms.PictureBox();
            this.leftTopBody = new System.Windows.Forms.PictureBox();
            this.rightTopBody = new System.Windows.Forms.PictureBox();
            this.rightBodyCorner = new System.Windows.Forms.PictureBox();
            this.leftTopCorner = new System.Windows.Forms.PictureBox();
            this.rightTopCorner = new System.Windows.Forms.PictureBox();
            this.gameResultLabel = new System.Windows.Forms.Label();
            this.ballCount = new System.Windows.Forms.Label();
            this.playLabel = new TopSektirmeDevamiProje5.playNpause();
            this.pauseLabel = new TopSektirmeDevamiProje5.playNpause();
            this.scoreLabel = new TopSektirmeDevamiProje5.playNpause();
            this.restorebtn = new TopSektirmeDevamiProje5.playNpause();
            this.backupbtn = new TopSektirmeDevamiProje5.playNpause();
            ((System.ComponentModel.ISupportInitialize)(this.leftBodyCorner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftTopBody)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightTopBody)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightBodyCorner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftTopCorner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightTopCorner)).BeginInit();
            this.SuspendLayout();
            // 
            // leftBodyCorner
            // 
            this.leftBodyCorner.BackColor = System.Drawing.Color.Black;
            this.leftBodyCorner.Location = new System.Drawing.Point(0, 32);
            this.leftBodyCorner.Name = "leftBodyCorner";
            this.leftBodyCorner.Size = new System.Drawing.Size(40, 750);
            this.leftBodyCorner.TabIndex = 0;
            this.leftBodyCorner.TabStop = false;
            // 
            // leftTopBody
            // 
            this.leftTopBody.BackColor = System.Drawing.Color.Black;
            this.leftTopBody.Location = new System.Drawing.Point(0, 0);
            this.leftTopBody.Name = "leftTopBody";
            this.leftTopBody.Size = new System.Drawing.Size(280, 36);
            this.leftTopBody.TabIndex = 1;
            this.leftTopBody.TabStop = false;
            // 
            // rightTopBody
            // 
            this.rightTopBody.BackColor = System.Drawing.Color.Black;
            this.rightTopBody.Location = new System.Drawing.Point(530, 0);
            this.rightTopBody.Name = "rightTopBody";
            this.rightTopBody.Size = new System.Drawing.Size(280, 36);
            this.rightTopBody.TabIndex = 2;
            this.rightTopBody.TabStop = false;
            // 
            // rightBodyCorner
            // 
            this.rightBodyCorner.BackColor = System.Drawing.Color.Black;
            this.rightBodyCorner.Location = new System.Drawing.Point(771, 32);
            this.rightBodyCorner.Name = "rightBodyCorner";
            this.rightBodyCorner.Size = new System.Drawing.Size(40, 750);
            this.rightBodyCorner.TabIndex = 3;
            this.rightBodyCorner.TabStop = false;
            // 
            // leftTopCorner
            // 
            this.leftTopCorner.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.leftTopCorner.Location = new System.Drawing.Point(274, -1);
            this.leftTopCorner.Name = "leftTopCorner";
            this.leftTopCorner.Size = new System.Drawing.Size(15, 35);
            this.leftTopCorner.TabIndex = 4;
            this.leftTopCorner.TabStop = false;
            // 
            // rightTopCorner
            // 
            this.rightTopCorner.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rightTopCorner.Location = new System.Drawing.Point(521, -1);
            this.rightTopCorner.Name = "rightTopCorner";
            this.rightTopCorner.Size = new System.Drawing.Size(18, 34);
            this.rightTopCorner.TabIndex = 5;
            this.rightTopCorner.TabStop = false;
            // 
            // gameResultLabel
            // 
            this.gameResultLabel.AutoSize = true;
            this.gameResultLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gameResultLabel.Location = new System.Drawing.Point(293, 334);
            this.gameResultLabel.Name = "gameResultLabel";
            this.gameResultLabel.Size = new System.Drawing.Size(220, 46);
            this.gameResultLabel.TabIndex = 6;
            this.gameResultLabel.Text = "Oyun Sonucu";
            this.gameResultLabel.Visible = false;
            // 
            // ballCount
            // 
            this.ballCount.AutoSize = true;
            this.ballCount.Location = new System.Drawing.Point(47, 43);
            this.ballCount.Name = "ballCount";
            this.ballCount.Size = new System.Drawing.Size(81, 20);
            this.ballCount.TabIndex = 7;
            this.ballCount.Text = "Top Adedi:";
            // 
            // playLabel
            // 
            this.playLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.playLabel.Location = new System.Drawing.Point(545, 785);
            this.playLabel.Name = "playLabel";
            this.playLabel.Size = new System.Drawing.Size(100, 40);
            this.playLabel.TabIndex = 10;
            this.playLabel.Text = "Play";
            this.playLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.playLabel.Click += new System.EventHandler(this.PlayButtonClicked);
            // 
            // pauseLabel
            // 
            this.pauseLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.pauseLabel.Location = new System.Drawing.Point(670, 785);
            this.pauseLabel.Name = "pauseLabel";
            this.pauseLabel.Size = new System.Drawing.Size(100, 40);
            this.pauseLabel.TabIndex = 11;
            this.pauseLabel.Text = "Pause";
            this.pauseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pauseLabel.Click += new System.EventHandler(this.PauseButtonClicked);
            // 
            // scoreLabel
            // 
            this.scoreLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.scoreLabel.Location = new System.Drawing.Point(640, 53);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(100, 40);
            this.scoreLabel.TabIndex = 12;
            this.scoreLabel.Text = "Score: 0";
            this.scoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // restorebtn
            // 
            this.restorebtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.restorebtn.Location = new System.Drawing.Point(180, 785);
            this.restorebtn.Name = "restorebtn";
            this.restorebtn.Size = new System.Drawing.Size(100, 40);
            this.restorebtn.TabIndex = 14;
            this.restorebtn.Text = "Restore";
            this.restorebtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.restorebtn.Click += new System.EventHandler(this.RestoreButtonClicked);
            // 
            // backupbtn
            // 
            this.backupbtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.backupbtn.Location = new System.Drawing.Point(55, 785);
            this.backupbtn.Name = "backupbtn";
            this.backupbtn.Size = new System.Drawing.Size(100, 40);
            this.backupbtn.TabIndex = 13;
            this.backupbtn.Text = "Backup";
            this.backupbtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.backupbtn.Click += new System.EventHandler(this.BackupButtonClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 833);
            this.Controls.Add(this.restorebtn);
            this.Controls.Add(this.backupbtn);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.pauseLabel);
            this.Controls.Add(this.playLabel);
            this.Controls.Add(this.ballCount);
            this.Controls.Add(this.gameResultLabel);
            this.Controls.Add(this.rightTopCorner);
            this.Controls.Add(this.leftTopCorner);
            this.Controls.Add(this.rightBodyCorner);
            this.Controls.Add(this.rightTopBody);
            this.Controls.Add(this.leftTopBody);
            this.Controls.Add(this.leftBodyCorner);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BlockMoveDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BlockMoveUp);
            ((System.ComponentModel.ISupportInitialize)(this.leftBodyCorner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftTopBody)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightTopBody)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightBodyCorner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftTopCorner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightTopCorner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox leftBodyCorner;
        private System.Windows.Forms.PictureBox leftTopBody;
        private System.Windows.Forms.PictureBox rightTopBody;
        private System.Windows.Forms.PictureBox rightBodyCorner;
        private System.Windows.Forms.PictureBox leftTopCorner;
        private System.Windows.Forms.PictureBox rightTopCorner;
        private System.Windows.Forms.Label gameResultLabel;
        private System.Windows.Forms.Label ballCount;
        private playNpause playLabel;
        private playNpause pauseLabel;
        private playNpause scoreLabel;
        private playNpause restorebtn;
        private playNpause backupbtn;
    }
}

