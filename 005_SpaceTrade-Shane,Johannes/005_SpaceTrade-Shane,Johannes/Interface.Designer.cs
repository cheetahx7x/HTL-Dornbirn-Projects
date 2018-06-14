namespace _005_SpaceTrade_Shane_Johannes
{
    partial class Interface
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
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_next_sys = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_exit
            // 
            this.btn_exit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_exit.Location = new System.Drawing.Point(675, 0);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(0);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(25, 25);
            this.btn_exit.TabIndex = 0;
            this.btn_exit.Text = "X";
            this.btn_exit.UseVisualStyleBackColor = true;
            // 
            // btn_next_sys
            // 
            this.btn_next_sys.Location = new System.Drawing.Point(566, 515);
            this.btn_next_sys.Name = "btn_next_sys";
            this.btn_next_sys.Size = new System.Drawing.Size(122, 23);
            this.btn_next_sys.TabIndex = 1;
            this.btn_next_sys.Text = "Travel to next System";
            this.btn_next_sys.UseVisualStyleBackColor = true;
            this.btn_next_sys.Click += new System.EventHandler(this.btn_next_sys_Click);
            // 
            // Interface
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 550);
            this.Controls.Add(this.btn_next_sys);
            this.Controls.Add(this.btn_exit);
            this.Font = new System.Drawing.Font("Modern No. 20", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Interface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Interface";
            this.Load += new System.EventHandler(this.Interface_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_next_sys;
    }
}