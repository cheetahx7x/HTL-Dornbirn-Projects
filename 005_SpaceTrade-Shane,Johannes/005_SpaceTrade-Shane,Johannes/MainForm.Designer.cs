﻿namespace _005_SpaceTrade_Shane_Johannes
{
    partial class MainForm
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
            this.txt_inventory = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // txt_inventory
            // 
            this.txt_inventory.ActiveLinkColor = System.Drawing.Color.Teal;
            this.txt_inventory.AutoEllipsis = true;
            this.txt_inventory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txt_inventory.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_inventory.ForeColor = System.Drawing.Color.Teal;
            this.txt_inventory.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.txt_inventory.LinkColor = System.Drawing.Color.Teal;
            this.txt_inventory.Location = new System.Drawing.Point(0, 161);
            this.txt_inventory.Margin = new System.Windows.Forms.Padding(0);
            this.txt_inventory.Name = "txt_inventory";
            this.txt_inventory.Padding = new System.Windows.Forms.Padding(10);
            this.txt_inventory.Size = new System.Drawing.Size(426, 200);
            this.txt_inventory.TabIndex = 3;
            this.txt_inventory.UseCompatibleTextRendering = true;
            this.txt_inventory.VisitedLinkColor = System.Drawing.Color.Teal;
            this.txt_inventory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.txt_inventory_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(426, 361);
            this.Controls.Add(this.txt_inventory);
            this.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "SpaceTrade";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel txt_inventory;
    }
}

