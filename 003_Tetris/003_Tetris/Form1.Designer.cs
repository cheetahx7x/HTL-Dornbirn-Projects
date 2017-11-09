namespace _003_Tetris
{
    partial class Tetris
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
            this.picturebox_T = new System.Windows.Forms.PictureBox();
            this.picturebox_preview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_T)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_preview)).BeginInit();
            this.SuspendLayout();
            // 
            // picturebox_T
            // 
            this.picturebox_T.BackColor = System.Drawing.Color.White;
            this.picturebox_T.Location = new System.Drawing.Point(17, 105);
            this.picturebox_T.Name = "picturebox_T";
            this.picturebox_T.Size = new System.Drawing.Size(600, 850);
            this.picturebox_T.TabIndex = 0;
            this.picturebox_T.TabStop = false;
            this.picturebox_T.Paint += new System.Windows.Forms.PaintEventHandler(this.Tetris_Paint);
            // 
            // picturebox_preview
            // 
            this.picturebox_preview.BackColor = System.Drawing.Color.White;
            this.picturebox_preview.Location = new System.Drawing.Point(530, 12);
            this.picturebox_preview.Name = "picturebox_preview";
            this.picturebox_preview.Size = new System.Drawing.Size(87, 87);
            this.picturebox_preview.TabIndex = 1;
            this.picturebox_preview.TabStop = false;
            this.picturebox_preview.Paint += new System.Windows.Forms.PaintEventHandler(this.Preview_Paint);
            // 
            // Tetris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(634, 961);
            this.Controls.Add(this.picturebox_preview);
            this.Controls.Add(this.picturebox_T);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Tetris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tetris";
            this.Load += new System.EventHandler(this.Tetris_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tetris_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Tetris_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_T)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_preview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picturebox_T;
        private System.Windows.Forms.PictureBox picturebox_preview;
    }
}

