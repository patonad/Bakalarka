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
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Top 10 hráčov";
            // 
            // bTop10Hostia
            // 
            this.bTop10Hostia.Location = new System.Drawing.Point(129, 34);
            this.bTop10Hostia.Name = "bTop10Hostia";
            this.bTop10Hostia.Size = new System.Drawing.Size(75, 23);
            this.bTop10Hostia.TabIndex = 1;
            this.bTop10Hostia.Text = "button1";
            this.bTop10Hostia.UseVisualStyleBackColor = true;
            this.bTop10Hostia.Click += new System.EventHandler(this.bTop10Hostia_Click);
            // 
            // bTop10Domaci
            // 
            this.bTop10Domaci.Location = new System.Drawing.Point(129, 82);
            this.bTop10Domaci.Name = "bTop10Domaci";
            this.bTop10Domaci.Size = new System.Drawing.Size(75, 23);
            this.bTop10Domaci.TabIndex = 3;
            this.bTop10Domaci.Text = "button1";
            this.bTop10Domaci.UseVisualStyleBackColor = true;
            this.bTop10Domaci.Click += new System.EventHandler(this.bTop10Domaci_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Top 10 hráčov";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(153, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OvladacStat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bTop10Domaci);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bTop10Hostia);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "OvladacStat";
            this.Text = "OvladacStat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OvladacStat_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bTop10Hostia;
        private System.Windows.Forms.Button bTop10Domaci;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}