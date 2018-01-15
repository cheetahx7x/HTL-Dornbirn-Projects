namespace _004_Throw
{
    partial class Umgebung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Umgebung));
            this.strip1 = new System.Windows.Forms.ToolStrip();
            this.txt_winkel = new System.Windows.Forms.ToolStripTextBox();
            this.lbl_speed = new System.Windows.Forms.ToolStripLabel();
            this.lbl_winkel = new System.Windows.Forms.ToolStripLabel();
            this.txt_speed = new System.Windows.Forms.ToolStripTextBox();
            this.btn_fire = new System.Windows.Forms.ToolStripButton();
            this.strip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // strip1
            // 
            this.strip1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.strip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_winkel,
            this.txt_winkel,
            this.lbl_speed,
            this.txt_speed,
            this.btn_fire});
            this.strip1.Location = new System.Drawing.Point(0, 0);
            this.strip1.Name = "strip1";
            this.strip1.Size = new System.Drawing.Size(984, 25);
            this.strip1.TabIndex = 1;
            this.strip1.Text = "toolStrip1";
            // 
            // txt_winkel
            // 
            this.txt_winkel.Name = "txt_winkel";
            this.txt_winkel.Size = new System.Drawing.Size(100, 25);
            // 
            // lbl_speed
            // 
            this.lbl_speed.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lbl_speed.Name = "lbl_speed";
            this.lbl_speed.Size = new System.Drawing.Size(94, 22);
            this.lbl_speed.Text = "Geschwindigkeit";
            // 
            // lbl_winkel
            // 
            this.lbl_winkel.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lbl_winkel.Name = "lbl_winkel";
            this.lbl_winkel.Size = new System.Drawing.Size(43, 22);
            this.lbl_winkel.Tag = "Winkel";
            this.lbl_winkel.Text = "Winkel";
            // 
            // txt_speed
            // 
            this.txt_speed.Name = "txt_speed";
            this.txt_speed.Size = new System.Drawing.Size(100, 25);
            // 
            // btn_fire
            // 
            this.btn_fire.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_fire.Image = ((System.Drawing.Image)(resources.GetObject("btn_fire.Image")));
            this.btn_fire.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_fire.Name = "btn_fire";
            this.btn_fire.Size = new System.Drawing.Size(23, 22);
            this.btn_fire.Text = "FireButton";
            this.btn_fire.Click += new System.EventHandler(this.btn_fire_Click);
            // 
            // Umgebung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.strip1);
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.Name = "Umgebung";
            this.Text = "Wurf";
            this.Load += new System.EventHandler(this.Umgebung_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Umgebung_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Umgebung_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Umgebung_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Umgebung_MouseClick);
            this.Resize += new System.EventHandler(this.Umgebung_Resize);
            this.strip1.ResumeLayout(false);
            this.strip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip strip1;
        private System.Windows.Forms.ToolStripLabel lbl_winkel;
        private System.Windows.Forms.ToolStripTextBox txt_winkel;
        private System.Windows.Forms.ToolStripLabel lbl_speed;
        private System.Windows.Forms.ToolStripTextBox txt_speed;
        private System.Windows.Forms.ToolStripButton btn_fire;
    }
}

