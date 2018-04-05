namespace HokejModul
{
    partial class UvodneMenuHokej
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
            this.lExitHokej = new System.Windows.Forms.Button();
            this.lStartHokej = new System.Windows.Forms.Button();
            this.tBHostia = new System.Windows.Forms.TextBox();
            this.tBDomaci = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lExitHokej
            // 
            this.lExitHokej.BackColor = System.Drawing.Color.LightBlue;
            this.lExitHokej.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lExitHokej.Location = new System.Drawing.Point(43, 237);
            this.lExitHokej.Name = "lExitHokej";
            this.lExitHokej.Size = new System.Drawing.Size(216, 46);
            this.lExitHokej.TabIndex = 11;
            this.lExitHokej.Text = "Koniec";
            this.lExitHokej.UseVisualStyleBackColor = false;
            this.lExitHokej.Click += new System.EventHandler(this.lExitHokej_Click);
            // 
            // lStartHokej
            // 
            this.lStartHokej.BackColor = System.Drawing.Color.LightBlue;
            this.lStartHokej.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lStartHokej.Location = new System.Drawing.Point(43, 122);
            this.lStartHokej.Name = "lStartHokej";
            this.lStartHokej.Size = new System.Drawing.Size(216, 96);
            this.lStartHokej.TabIndex = 10;
            this.lStartHokej.Text = "Štart";
            this.lStartHokej.UseVisualStyleBackColor = false;
            this.lStartHokej.Click += new System.EventHandler(this.lStartHokej_Click);
            // 
            // tBHostia
            // 
            this.tBHostia.BackColor = System.Drawing.Color.LightCyan;
            this.tBHostia.Location = new System.Drawing.Point(159, 64);
            this.tBHostia.Name = "tBHostia";
            this.tBHostia.Size = new System.Drawing.Size(100, 20);
            this.tBHostia.TabIndex = 9;
            // 
            // tBDomaci
            // 
            this.tBDomaci.BackColor = System.Drawing.Color.LightCyan;
            this.tBDomaci.Location = new System.Drawing.Point(159, 34);
            this.tBDomaci.Name = "tBDomaci";
            this.tBDomaci.Size = new System.Drawing.Size(100, 20);
            this.tBDomaci.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(40, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tím hostí:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(40, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tím domácich:";
            // 
            // UvodneMenuHokej
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(307, 304);
            this.Controls.Add(this.lExitHokej);
            this.Controls.Add(this.lStartHokej);
            this.Controls.Add(this.tBHostia);
            this.Controls.Add(this.tBDomaci);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UvodneMenuHokej";
            this.Text = "Úvodné menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UvodneMenuHokej_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button lExitHokej;
        private System.Windows.Forms.Button lStartHokej;
        private System.Windows.Forms.TextBox tBHostia;
        private System.Windows.Forms.TextBox tBDomaci;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}