﻿namespace FutbalModul
{
    partial class UvodneMenuFutbal
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
            this.lExitFutbal = new System.Windows.Forms.Button();
            this.lStartFutbal = new System.Windows.Forms.Button();
            this.tBHostia = new System.Windows.Forms.TextBox();
            this.tBDomaci = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lExitFutbal
            // 
            this.lExitFutbal.BackColor = System.Drawing.Color.LightBlue;
            this.lExitFutbal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lExitFutbal.Location = new System.Drawing.Point(43, 238);
            this.lExitFutbal.Name = "lExitFutbal";
            this.lExitFutbal.Size = new System.Drawing.Size(216, 47);
            this.lExitFutbal.TabIndex = 17;
            this.lExitFutbal.Text = "Koniec";
            this.lExitFutbal.UseVisualStyleBackColor = false;
            this.lExitFutbal.Click += new System.EventHandler(this.LExitFutbal_Click);
            // 
            // lStartFutbal
            // 
            this.lStartFutbal.BackColor = System.Drawing.Color.LightBlue;
            this.lStartFutbal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lStartFutbal.Location = new System.Drawing.Point(43, 117);
            this.lStartFutbal.Name = "lStartFutbal";
            this.lStartFutbal.Size = new System.Drawing.Size(216, 97);
            this.lStartFutbal.TabIndex = 16;
            this.lStartFutbal.Text = "Štart";
            this.lStartFutbal.UseVisualStyleBackColor = false;
            this.lStartFutbal.Click += new System.EventHandler(this.LStartFutbal_Click);
            // 
            // tBHostia
            // 
            this.tBHostia.BackColor = System.Drawing.Color.LightCyan;
            this.tBHostia.Location = new System.Drawing.Point(159, 66);
            this.tBHostia.Name = "tBHostia";
            this.tBHostia.Size = new System.Drawing.Size(100, 20);
            this.tBHostia.TabIndex = 15;
            // 
            // tBDomaci
            // 
            this.tBDomaci.BackColor = System.Drawing.Color.LightCyan;
            this.tBDomaci.Location = new System.Drawing.Point(159, 36);
            this.tBDomaci.Name = "tBDomaci";
            this.tBDomaci.Size = new System.Drawing.Size(100, 20);
            this.tBDomaci.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(40, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Tím hostí:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(40, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tím domácich:";
            // 
            // UvodneMenuFutbal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(307, 306);
            this.Controls.Add(this.lExitFutbal);
            this.Controls.Add(this.lStartFutbal);
            this.Controls.Add(this.tBHostia);
            this.Controls.Add(this.tBDomaci);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UvodneMenuFutbal";
            this.Text = "Úvodné menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UvodneMenuFutbal_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button lExitFutbal;
        private System.Windows.Forms.Button lStartFutbal;
        private System.Windows.Forms.TextBox tBHostia;
        private System.Windows.Forms.TextBox tBDomaci;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}