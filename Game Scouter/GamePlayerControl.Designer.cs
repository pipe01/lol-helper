namespace LoL_Helper.Game_Scouter
{
    partial class GamePlayerControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picChampIcon = new System.Windows.Forms.PictureBox();
            this.lblSummName = new System.Windows.Forms.Label();
            this.picLeague = new System.Windows.Forms.PictureBox();
            this.lblRank = new System.Windows.Forms.Label();
            this.picSumm1 = new System.Windows.Forms.PictureBox();
            this.picSumm2 = new System.Windows.Forms.PictureBox();
            this.panLeagueInfo = new System.Windows.Forms.Panel();
            this.lblSeries = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLP = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tPanelReset = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picChampIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeague)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSumm1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSumm2)).BeginInit();
            this.panLeagueInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // picChampIcon
            // 
            this.picChampIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picChampIcon.Location = new System.Drawing.Point(3, 3);
            this.picChampIcon.Name = "picChampIcon";
            this.picChampIcon.Size = new System.Drawing.Size(60, 60);
            this.picChampIcon.TabIndex = 0;
            this.picChampIcon.TabStop = false;
            // 
            // lblSummName
            // 
            this.lblSummName.AutoSize = true;
            this.lblSummName.Location = new System.Drawing.Point(68, 6);
            this.lblSummName.Name = "lblSummName";
            this.lblSummName.Size = new System.Drawing.Size(16, 13);
            this.lblSummName.TabIndex = 1;
            this.lblSummName.Text = "---";
            // 
            // picLeague
            // 
            this.picLeague.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picLeague.Location = new System.Drawing.Point(3, 69);
            this.picLeague.Name = "picLeague";
            this.picLeague.Size = new System.Drawing.Size(165, 119);
            this.picLeague.TabIndex = 2;
            this.picLeague.TabStop = false;
            this.picLeague.Click += new System.EventHandler(this.picLeague_Click);
            // 
            // lblRank
            // 
            this.lblRank.Location = new System.Drawing.Point(68, 55);
            this.lblRank.Name = "lblRank";
            this.lblRank.Size = new System.Drawing.Size(100, 15);
            this.lblRank.TabIndex = 3;
            this.lblRank.Text = "label1";
            this.lblRank.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picSumm1
            // 
            this.picSumm1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picSumm1.Location = new System.Drawing.Point(68, 22);
            this.picSumm1.Name = "picSumm1";
            this.picSumm1.Size = new System.Drawing.Size(30, 30);
            this.picSumm1.TabIndex = 4;
            this.picSumm1.TabStop = false;
            // 
            // picSumm2
            // 
            this.picSumm2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picSumm2.Location = new System.Drawing.Point(104, 22);
            this.picSumm2.Name = "picSumm2";
            this.picSumm2.Size = new System.Drawing.Size(30, 30);
            this.picSumm2.TabIndex = 4;
            this.picSumm2.TabStop = false;
            // 
            // panLeagueInfo
            // 
            this.panLeagueInfo.Controls.Add(this.lblSeries);
            this.panLeagueInfo.Controls.Add(this.label2);
            this.panLeagueInfo.Controls.Add(this.lblLP);
            this.panLeagueInfo.Controls.Add(this.label1);
            this.panLeagueInfo.Location = new System.Drawing.Point(3, 69);
            this.panLeagueInfo.Name = "panLeagueInfo";
            this.panLeagueInfo.Size = new System.Drawing.Size(165, 119);
            this.panLeagueInfo.TabIndex = 5;
            this.panLeagueInfo.Visible = false;
            this.panLeagueInfo.Click += new System.EventHandler(this.panLeagueInfo_Click);
            // 
            // lblSeries
            // 
            this.lblSeries.AutoSize = true;
            this.lblSeries.Location = new System.Drawing.Point(46, 25);
            this.lblSeries.Name = "lblSeries";
            this.lblSeries.Size = new System.Drawing.Size(35, 13);
            this.lblSeries.TabIndex = 3;
            this.lblSeries.Text = "label3";
            this.lblSeries.Visible = false;
            this.lblSeries.Click += new System.EventHandler(this.panLeagueInfo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Series:";
            this.label2.Visible = false;
            this.label2.Click += new System.EventHandler(this.panLeagueInfo_Click);
            // 
            // lblLP
            // 
            this.lblLP.AutoSize = true;
            this.lblLP.Location = new System.Drawing.Point(83, 5);
            this.lblLP.Name = "lblLP";
            this.lblLP.Size = new System.Drawing.Size(29, 13);
            this.lblLP.TabIndex = 1;
            this.lblLP.Text = "NaN";
            this.lblLP.Click += new System.EventHandler(this.panLeagueInfo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "League Points:";
            this.label1.Click += new System.EventHandler(this.panLeagueInfo_Click);
            // 
            // tPanelReset
            // 
            this.tPanelReset.Interval = 5000;
            this.tPanelReset.Tick += new System.EventHandler(this.tPanelReset_Tick);
            // 
            // GamePlayerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCoral;
            this.Controls.Add(this.panLeagueInfo);
            this.Controls.Add(this.picSumm2);
            this.Controls.Add(this.picSumm1);
            this.Controls.Add(this.lblRank);
            this.Controls.Add(this.picLeague);
            this.Controls.Add(this.lblSummName);
            this.Controls.Add(this.picChampIcon);
            this.Name = "GamePlayerControl";
            this.Size = new System.Drawing.Size(173, 195);
            this.Load += new System.EventHandler(this.GamePlayerControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picChampIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeague)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSumm1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSumm2)).EndInit();
            this.panLeagueInfo.ResumeLayout(false);
            this.panLeagueInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picChampIcon;
        private System.Windows.Forms.Label lblSummName;
        private System.Windows.Forms.PictureBox picLeague;
        private System.Windows.Forms.Label lblRank;
        private System.Windows.Forms.PictureBox picSumm1;
        private System.Windows.Forms.PictureBox picSumm2;
        private System.Windows.Forms.Panel panLeagueInfo;
        private System.Windows.Forms.Label lblLP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer tPanelReset;
        private System.Windows.Forms.Label lblSeries;
        private System.Windows.Forms.Label label2;
    }
}
