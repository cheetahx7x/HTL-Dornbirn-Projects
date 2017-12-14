namespace _001_Ein_Auslesen_SQL_Database
{
    partial class Form1
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
            this.btn_execute = new System.Windows.Forms.Button();
            this.dgv_Personal = new System.Windows.Forms.DataGridView();
            this.clm_persnr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_vn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_zn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Personal)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_execute
            // 
            this.btn_execute.Location = new System.Drawing.Point(12, 411);
            this.btn_execute.Name = "btn_execute";
            this.btn_execute.Size = new System.Drawing.Size(132, 38);
            this.btn_execute.TabIndex = 0;
            this.btn_execute.Text = "Execute";
            this.btn_execute.UseVisualStyleBackColor = true;
            this.btn_execute.Click += new System.EventHandler(this.btn_execute_Click);
            // 
            // dgv_Personal
            // 
            this.dgv_Personal.AllowUserToAddRows = false;
            this.dgv_Personal.AllowUserToDeleteRows = false;
            this.dgv_Personal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Personal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clm_persnr,
            this.clm_vn,
            this.clm_zn});
            this.dgv_Personal.Location = new System.Drawing.Point(629, 12);
            this.dgv_Personal.Name = "dgv_Personal";
            this.dgv_Personal.ReadOnly = true;
            this.dgv_Personal.Size = new System.Drawing.Size(343, 437);
            this.dgv_Personal.TabIndex = 1;
            // 
            // clm_persnr
            // 
            this.clm_persnr.HeaderText = "PersonalNr.";
            this.clm_persnr.Name = "clm_persnr";
            this.clm_persnr.ReadOnly = true;
            // 
            // clm_vn
            // 
            this.clm_vn.HeaderText = "Vorname";
            this.clm_vn.Name = "clm_vn";
            this.clm_vn.ReadOnly = true;
            // 
            // clm_zn
            // 
            this.clm_zn.HeaderText = "Zuname";
            this.clm_zn.Name = "clm_zn";
            this.clm_zn.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.dgv_Personal);
            this.Controls.Add(this.btn_execute);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Personal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_execute;
        private System.Windows.Forms.DataGridView dgv_Personal;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_persnr;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_vn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_zn;
    }
}

