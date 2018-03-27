namespace svetelna_tabula
{
    partial class ZobrazovacStat
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
            this.lKto = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lKto
            // 
            this.lKto.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.lKto.ForeColor = System.Drawing.Color.SandyBrown;
            this.lKto.Location = new System.Drawing.Point(40, 21);
            this.lKto.Name = "lKto";
            this.lKto.Size = new System.Drawing.Size(723, 49);
            this.lKto.TabIndex = 0;
            this.lKto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ZobrazovacStat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lKto);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ZobrazovacStat";
            this.Text = "ZobrazovacStat";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ZobrazovacStat_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lKto;
    }
}