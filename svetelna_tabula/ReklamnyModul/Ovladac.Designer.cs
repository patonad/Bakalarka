namespace ReklamnyModul
{
    partial class Ovladac
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StartVideo = new System.Windows.Forms.Button();
            this.StopVideo = new System.Windows.Forms.Button();
            this.cLBZoznamReklam = new System.Windows.Forms.CheckedListBox();
            this.pauseVideo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartVideo
            // 
            this.StartVideo.BackColor = System.Drawing.Color.LightBlue;
            this.StartVideo.Location = new System.Drawing.Point(158, 262);
            this.StartVideo.Name = "StartVideo";
            this.StartVideo.Size = new System.Drawing.Size(75, 23);
            this.StartVideo.TabIndex = 0;
            this.StartVideo.Text = "Start";
            this.StartVideo.UseVisualStyleBackColor = false;
            this.StartVideo.Click += new System.EventHandler(this.StartVideo_Click);
            // 
            // StopVideo
            // 
            this.StopVideo.BackColor = System.Drawing.Color.LightBlue;
            this.StopVideo.Location = new System.Drawing.Point(376, 262);
            this.StopVideo.Name = "StopVideo";
            this.StopVideo.Size = new System.Drawing.Size(75, 23);
            this.StopVideo.TabIndex = 1;
            this.StopVideo.Text = "Stop";
            this.StopVideo.UseVisualStyleBackColor = false;
            this.StopVideo.Click += new System.EventHandler(this.StopVideo_Click);
            // 
            // cLBZoznamReklam
            // 
            this.cLBZoznamReklam.FormattingEnabled = true;
            this.cLBZoznamReklam.Location = new System.Drawing.Point(12, 12);
            this.cLBZoznamReklam.Name = "cLBZoznamReklam";
            this.cLBZoznamReklam.Size = new System.Drawing.Size(591, 229);
            this.cLBZoznamReklam.TabIndex = 4;
            // 
            // pauseVideo
            // 
            this.pauseVideo.BackColor = System.Drawing.Color.LightBlue;
            this.pauseVideo.Location = new System.Drawing.Point(267, 262);
            this.pauseVideo.Name = "pauseVideo";
            this.pauseVideo.Size = new System.Drawing.Size(75, 23);
            this.pauseVideo.TabIndex = 5;
            this.pauseVideo.Text = "Pause";
            this.pauseVideo.UseVisualStyleBackColor = false;
            this.pauseVideo.Click += new System.EventHandler(this.PauseVideo_Click);
            // 
            // Ovladac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(615, 307);
            this.Controls.Add(this.pauseVideo);
            this.Controls.Add(this.cLBZoznamReklam);
            this.Controls.Add(this.StopVideo);
            this.Controls.Add(this.StartVideo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Ovladac";
            this.Text = "Reklama";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Ovladac_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartVideo;
        private System.Windows.Forms.Button StopVideo;
        private System.Windows.Forms.CheckedListBox cLBZoznamReklam;
        private System.Windows.Forms.Button pauseVideo;
    }
}