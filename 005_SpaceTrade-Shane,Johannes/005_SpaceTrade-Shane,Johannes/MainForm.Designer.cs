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
            this.Main_Picture = new System.Windows.Forms.PictureBox();
            this.txt_information = new System.Windows.Forms.Label();
            this.txt_Username = new System.Windows.Forms.TextBox();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.btn_Login = new System.Windows.Forms.Button();
            this.txt_Fehler = new System.Windows.Forms.Label();
            this.Module1 = new System.Windows.Forms.PictureBox();
            this.Module2 = new System.Windows.Forms.PictureBox();
            this.Module3 = new System.Windows.Forms.PictureBox();
            this.Module4 = new System.Windows.Forms.PictureBox();
            this.Module5 = new System.Windows.Forms.PictureBox();
            this.Module6 = new System.Windows.Forms.PictureBox();
            this.Module8 = new System.Windows.Forms.PictureBox();
            this.Module7 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Main_Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Module1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Module2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Module3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Module4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Module5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Module6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Module8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Module7)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_main
            // 
            this.txt_main.ActiveLinkColor = System.Drawing.Color.Teal;
            this.txt_main.AutoEllipsis = true;
            this.txt_main.AutoSize = true;
            this.txt_main.CausesValidation = false;
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
            // Main_Picture
            // 
            this.Main_Picture.Enabled = false;
            this.Main_Picture.ErrorImage = null;
            this.Main_Picture.InitialImage = null;
            this.Main_Picture.Location = new System.Drawing.Point(0, -1);
            this.Main_Picture.Name = "Main_Picture";
            this.Main_Picture.Size = new System.Drawing.Size(273, 212);
            this.Main_Picture.TabIndex = 5;
            this.Main_Picture.TabStop = false;
            this.Main_Picture.Visible = false;
            this.Main_Picture.Click += new System.EventHandler(this.Main_Picture_Click);
            // 
            // txt_information
            // 
            this.txt_information.AutoSize = true;
            this.txt_information.Dock = System.Windows.Forms.DockStyle.Right;
            this.txt_information.Location = new System.Drawing.Point(1064, 0);
            this.txt_information.Name = "txt_information";
            this.txt_information.Size = new System.Drawing.Size(0, 18);
            this.txt_information.TabIndex = 6;
            // 
            // txt_Username
            // 
            this.txt_Username.BackColor = System.Drawing.SystemColors.MenuText;
            this.txt_Username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Username.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.txt_Username.Location = new System.Drawing.Point(98, 336);
            this.txt_Username.MaxLength = 20;
            this.txt_Username.Name = "txt_Username";
            this.txt_Username.Size = new System.Drawing.Size(150, 25);
            this.txt_Username.TabIndex = 7;
            this.txt_Username.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Username_KeyDown);
            // 
            // txt_Password
            // 
            this.txt_Password.BackColor = System.Drawing.SystemColors.MenuText;
            this.txt_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Password.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.txt_Password.Location = new System.Drawing.Point(295, 336);
            this.txt_Password.MaxLength = 20;
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.Size = new System.Drawing.Size(150, 25);
            this.txt_Password.TabIndex = 8;
            this.txt_Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Password_KeyDown);
            // 
            // btn_Login
            // 
            this.btn_Login.BackColor = System.Drawing.Color.Teal;
            this.btn_Login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Login.ForeColor = System.Drawing.Color.Black;
            this.btn_Login.Location = new System.Drawing.Point(9, 336);
            this.btn_Login.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(75, 27);
            this.btn_Login.TabIndex = 10;
            this.btn_Login.TabStop = false;
            this.btn_Login.Text = "Login";
            this.btn_Login.UseVisualStyleBackColor = false;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // txt_Fehler
            // 
            this.txt_Fehler.AutoSize = true;
            this.txt_Fehler.ForeColor = System.Drawing.Color.DarkRed;
            this.txt_Fehler.Location = new System.Drawing.Point(395, 149);
            this.txt_Fehler.Name = "txt_Fehler";
            this.txt_Fehler.Size = new System.Drawing.Size(0, 18);
            this.txt_Fehler.TabIndex = 11;
            // 
            // Module1
            // 
            this.Module1.BackColor = System.Drawing.Color.Transparent;
            this.Module1.ErrorImage = null;
            this.Module1.InitialImage = null;
            this.Module1.Location = new System.Drawing.Point(1029, 348);
            this.Module1.Name = "Module1";
            this.Module1.Size = new System.Drawing.Size(35, 13);
            this.Module1.TabIndex = 12;
            this.Module1.TabStop = false;
            // 
            // Module2
            // 
            this.Module2.BackColor = System.Drawing.Color.Transparent;
            this.Module2.ErrorImage = null;
            this.Module2.InitialImage = null;
            this.Module2.Location = new System.Drawing.Point(1029, 336);
            this.Module2.Name = "Module2";
            this.Module2.Size = new System.Drawing.Size(34, 13);
            this.Module2.TabIndex = 13;
            this.Module2.TabStop = false;
            // 
            // Module3
            // 
            this.Module3.BackColor = System.Drawing.Color.Transparent;
            this.Module3.ErrorImage = null;
            this.Module3.InitialImage = null;
            this.Module3.Location = new System.Drawing.Point(1029, 320);
            this.Module3.Name = "Module3";
            this.Module3.Size = new System.Drawing.Size(34, 13);
            this.Module3.TabIndex = 14;
            this.Module3.TabStop = false;
            // 
            // Module4
            // 
            this.Module4.BackColor = System.Drawing.Color.Transparent;
            this.Module4.ErrorImage = null;
            this.Module4.InitialImage = null;
            this.Module4.Location = new System.Drawing.Point(1030, 301);
            this.Module4.Name = "Module4";
            this.Module4.Size = new System.Drawing.Size(34, 13);
            this.Module4.TabIndex = 15;
            this.Module4.TabStop = false;
            // 
            // Module5
            // 
            this.Module5.BackColor = System.Drawing.Color.Transparent;
            this.Module5.ErrorImage = null;
            this.Module5.InitialImage = null;
            this.Module5.Location = new System.Drawing.Point(1030, 282);
            this.Module5.Name = "Module5";
            this.Module5.Size = new System.Drawing.Size(34, 13);
            this.Module5.TabIndex = 16;
            this.Module5.TabStop = false;
            // 
            // Module6
            // 
            this.Module6.BackColor = System.Drawing.Color.Transparent;
            this.Module6.ErrorImage = null;
            this.Module6.InitialImage = null;
            this.Module6.Location = new System.Drawing.Point(1030, 263);
            this.Module6.Name = "Module6";
            this.Module6.Size = new System.Drawing.Size(34, 13);
            this.Module6.TabIndex = 17;
            this.Module6.TabStop = false;
            // 
            // Module8
            // 
            this.Module8.BackColor = System.Drawing.Color.Transparent;
            this.Module8.ErrorImage = null;
            this.Module8.InitialImage = null;
            this.Module8.Location = new System.Drawing.Point(1029, 225);
            this.Module8.Name = "Module8";
            this.Module8.Size = new System.Drawing.Size(34, 13);
            this.Module8.TabIndex = 18;
            this.Module8.TabStop = false;
            // 
            // Module7
            // 
            this.Module7.BackColor = System.Drawing.Color.Transparent;
            this.Module7.ErrorImage = null;
            this.Module7.InitialImage = null;
            this.Module7.Location = new System.Drawing.Point(1030, 244);
            this.Module7.Name = "Module7";
            this.Module7.Size = new System.Drawing.Size(34, 13);
            this.Module7.TabIndex = 19;
            this.Module7.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1064, 361);
            this.Controls.Add(this.Module7);
            this.Controls.Add(this.Module8);
            this.Controls.Add(this.Module6);
            this.Controls.Add(this.Module5);
            this.Controls.Add(this.Module4);
            this.Controls.Add(this.Module3);
            this.Controls.Add(this.Module2);
            this.Controls.Add(this.Module1);
            this.Controls.Add(this.txt_Fehler);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.txt_Username);
            this.Controls.Add(this.txt_information);
            this.Controls.Add(this.Main_Picture);
            this.Controls.Add(this.txt_inventory);
            this.Controls.Add(this.txt_main);
            this.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "SpaceTrade";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Main_Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Module1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Module2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Module3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Module4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Module5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Module6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Module8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Module7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel txt_main;
        private System.Windows.Forms.LinkLabel txt_inventory;
        private System.Windows.Forms.PictureBox Main_Picture;
        private System.Windows.Forms.Label txt_information;
        private System.Windows.Forms.TextBox txt_Username;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Label txt_Fehler;
        private System.Windows.Forms.PictureBox Module1;
        private System.Windows.Forms.PictureBox Module2;
        private System.Windows.Forms.PictureBox Module3;
        private System.Windows.Forms.PictureBox Module4;
        private System.Windows.Forms.PictureBox Module5;
        private System.Windows.Forms.PictureBox Module6;
        private System.Windows.Forms.PictureBox Module8;
        private System.Windows.Forms.PictureBox Module7;
    }
}

