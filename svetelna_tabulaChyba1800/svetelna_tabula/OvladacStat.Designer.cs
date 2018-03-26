namespace svetelna_tabula
{
    partial class OvladacStat
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
            this.label1 = new System.Windows.Forms.Label();
            this.bTop10Hostia = new System.Windows.Forms.Button();
            this.bTop10Domaci = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.vTop10Celkovo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.bOdhohrateZapasy = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(26, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Top 10 hráčov";
            // 
            // bTop10Hostia
            // 
            this.bTop10Hostia.Location = new System.Drawing.Point(203, 41);
            this.bTop10Hostia.Name = "bTop10Hostia";
            this.bTop10Hostia.Size = new System.Drawing.Size(71, 23);
            this.bTop10Hostia.TabIndex = 1;
            this.bTop10Hostia.Text = "button1";
            this.bTop10Hostia.UseVisualStyleBackColor = true;
            this.bTop10Hostia.Click += new System.EventHandler(this.bTop10Hostia_Click);
            // 
            // bTop10Domaci
            // 
            this.bTop10Domaci.Location = new System.Drawing.Point(203, 85);
            this.bTop10Domaci.Name = "bTop10Domaci";
            this.bTop10Domaci.Size = new System.Drawing.Size(71, 23);
            this.bTop10Domaci.TabIndex = 3;
            this.bTop10Domaci.Text = "button1";
            this.bTop10Domaci.UseVisualStyleBackColor = true;
            this.bTop10Domaci.Click += new System.EventHandler(this.bTop10Domaci_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(26, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Top 10 hráčov";
            // 
            // vTop10Celkovo
            // 
            this.vTop10Celkovo.Location = new System.Drawing.Point(203, 134);
            this.vTop10Celkovo.Name = "vTop10Celkovo";
            this.vTop10Celkovo.Size = new System.Drawing.Size(71, 23);
            this.vTop10Celkovo.TabIndex = 4;
            this.vTop10Celkovo.Text = "Zobraz";
            this.vTop10Celkovo.UseVisualStyleBackColor = true;
            this.vTop10Celkovo.Click += new System.EventHandler(this.vTop10Celkovo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(26, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Top 10 hračov celkovo";
            // 
            // bOdhohrateZapasy
            // 
            this.bOdhohrateZapasy.Location = new System.Drawing.Point(203, 179);
            this.bOdhohrateZapasy.Name = "bOdhohrateZapasy";
            this.bOdhohrateZapasy.Size = new System.Drawing.Size(71, 23);
            this.bOdhohrateZapasy.TabIndex = 6;
            this.bOdhohrateZapasy.Text = "Zobraz";
            this.bOdhohrateZapasy.UseVisualStyleBackColor = true;
            this.bOdhohrateZapasy.Click += new System.EventHandler(this.bOdhohrateZapasy_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(26, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Odohraté zápasy";
            // 
            // OvladacStat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(298, 261);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bOdhohrateZapasy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.vTop10Celkovo);
            this.Controls.Add(this.bTop10Domaci);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bTop10Hostia);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OvladacStat";
            this.Text = "OvladacStat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OvladacStat_FormClosing);
            this.Load += new System.EventHandler(this.OvladacStat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bTop10Hostia;
        private System.Windows.Forms.Button bTop10Domaci;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button vTop10Celkovo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bOdhohrateZapasy;
        private System.Windows.Forms.Label label4;
    }
}