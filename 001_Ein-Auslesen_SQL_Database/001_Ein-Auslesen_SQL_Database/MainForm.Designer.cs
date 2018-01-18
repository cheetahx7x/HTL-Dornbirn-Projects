namespace _001_Ein_Auslesen_SQL_Database
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
            this.btn_execute = new System.Windows.Forms.Button();
            this.txt_sql = new System.Windows.Forms.TextBox();
            this.dgv_tables = new System.Windows.Forms.DataGridView();
            this.clm_tables = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmb_DB = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tables)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_execute
            // 
            this.btn_execute.Location = new System.Drawing.Point(12, 38);
            this.btn_execute.Name = "btn_execute";
            this.btn_execute.Size = new System.Drawing.Size(132, 38);
            this.btn_execute.TabIndex = 0;
            this.btn_execute.Text = "Execute";
            this.btn_execute.UseVisualStyleBackColor = true;
            this.btn_execute.Click += new System.EventHandler(this.btn_execute_Click);
            // 
            // txt_sql
            // 
            this.txt_sql.AllowDrop = true;
            this.txt_sql.Location = new System.Drawing.Point(12, 12);
            this.txt_sql.Name = "txt_sql";
            this.txt_sql.Size = new System.Drawing.Size(285, 20);
            this.txt_sql.TabIndex = 1;
            // 
            // dgv_tables
            // 
            this.dgv_tables.AllowUserToAddRows = false;
            this.dgv_tables.AllowUserToDeleteRows = false;
            this.dgv_tables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_tables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clm_tables});
            this.dgv_tables.Location = new System.Drawing.Point(303, 12);
            this.dgv_tables.Name = "dgv_tables";
            this.dgv_tables.ReadOnly = true;
            this.dgv_tables.Size = new System.Drawing.Size(144, 437);
            this.dgv_tables.TabIndex = 2;
            // 
            // clm_tables
            // 
            this.clm_tables.HeaderText = "Tabellen";
            this.clm_tables.Name = "clm_tables";
            this.clm_tables.ReadOnly = true;
            // 
            // cmb_DB
            // 
            this.cmb_DB.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cmb_DB.Location = new System.Drawing.Point(150, 38);
            this.cmb_DB.Name = "cmb_DB";
            this.cmb_DB.Size = new System.Drawing.Size(147, 21);
            this.cmb_DB.Sorted = true;
            this.cmb_DB.TabIndex = 2;
            this.cmb_DB.SelectedIndexChanged += new System.EventHandler(this.cmb_DB_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.cmb_DB);
            this.Controls.Add(this.dgv_tables);
            this.Controls.Add(this.txt_sql);
            this.Controls.Add(this.btn_execute);
            this.Name = "MainForm";
            this.Text = "SQL Connect";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tables)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_execute;
        private System.Windows.Forms.TextBox txt_sql;
        private System.Windows.Forms.DataGridView dgv_tables;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_tables;
        private System.Windows.Forms.ComboBox cmb_DB;
    }
}

