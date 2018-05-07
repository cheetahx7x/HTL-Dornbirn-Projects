namespace _005_SpaceTrade_Shane_Johannes
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
            this.txt_main = new System.Windows.Forms.LinkLabel();
            this.txt_inventory = new System.Windows.Forms.LinkLabel();
            this.Sun = new System.Windows.Forms.PictureBox();
            this.txt_information = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Sun)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_main
            // 
            this.txt_main.ActiveLinkColor = System.Drawing.Color.Teal;
            this.txt_main.AutoSize = true;
            this.txt_main.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txt_main.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_main.ForeColor = System.Drawing.Color.Teal;
            this.txt_main.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.txt_main.LinkColor = System.Drawing.Color.Teal;
            this.txt_main.Location = new System.Drawing.Point(0, 320);
            this.txt_main.Margin = new System.Windows.Forms.Padding(0);
            this.txt_main.Name = "txt_main";
            this.txt_main.Padding = new System.Windows.Forms.Padding(10);
            this.txt_main.Size = new System.Drawing.Size(20, 41);
            this.txt_main.TabIndex = 3;
            this.txt_main.UseCompatibleTextRendering = true;
            this.txt_main.VisitedLinkColor = System.Drawing.Color.Teal;
            this.txt_main.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.txt_main_LinkClicked);
            // 
            // txt_inventory
            // 
            this.txt_inventory.ActiveLinkColor = System.Drawing.Color.Teal;
            this.txt_inventory.AutoSize = true;
            this.txt_inventory.Dock = System.Windows.Forms.DockStyle.Left;
            this.txt_inventory.ForeColor = System.Drawing.Color.Teal;
            this.txt_inventory.LinkColor = System.Drawing.Color.Teal;
            this.txt_inventory.Location = new System.Drawing.Point(0, 0);
            this.txt_inventory.Name = "txt_inventory";
            this.txt_inventory.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_inventory.Size = new System.Drawing.Size(0, 18);
            this.txt_inventory.TabIndex = 4;
            this.txt_inventory.VisitedLinkColor = System.Drawing.Color.Teal;
            // 
            // Sun
            // 
            this.Sun.Location = new System.Drawing.Point(172, 149);
            this.Sun.Name = "Sun";
            this.Sun.Size = new System.Drawing.Size(100, 50);
            this.Sun.TabIndex = 5;
            this.Sun.TabStop = false;
            // 
            // txt_information
            // 
            this.txt_information.AutoSize = true;
            this.txt_information.Dock = System.Windows.Forms.DockStyle.Right;
            this.txt_information.Location = new System.Drawing.Point(426, 0);
            this.txt_information.Name = "txt_information";
            this.txt_information.Size = new System.Drawing.Size(0, 18);
            this.txt_information.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(426, 361);
            this.Controls.Add(this.txt_information);
            this.Controls.Add(this.Sun);
            this.Controls.Add(this.txt_inventory);
            this.Controls.Add(this.txt_main);
            this.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "SpaceTrade";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Sun)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel txt_main;
        private System.Windows.Forms.LinkLabel txt_inventory;
        private System.Windows.Forms.PictureBox Sun;
        private System.Windows.Forms.Label txt_information;
    }
}

