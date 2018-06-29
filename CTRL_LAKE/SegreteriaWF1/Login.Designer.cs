namespace SegreteriaWF
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.LoginButton = new System.Windows.Forms.Button();
            this.LogoPic = new System.Windows.Forms.PictureBox();
            this.PicturePanel = new System.Windows.Forms.Panel();
            this.PasswordInputField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UsernameView = new System.Windows.Forms.TextBox();
            this.LoginPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPic)).BeginInit();
            this.PicturePanel.SuspendLayout();
            this.LoginPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.Font = new System.Drawing.Font("Miriam Libre", 9.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginButton.Location = new System.Drawing.Point(417, 15);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(130, 69);
            this.LoginButton.TabIndex = 0;
            this.LoginButton.TabStop = false;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // LogoPic
            // 
            this.LogoPic.Image = ((System.Drawing.Image)(resources.GetObject("LogoPic.Image")));
            this.LogoPic.Location = new System.Drawing.Point(16, 11);
            this.LogoPic.Name = "LogoPic";
            this.LogoPic.Size = new System.Drawing.Size(703, 262);
            this.LogoPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LogoPic.TabIndex = 1;
            this.LogoPic.TabStop = false;
            // 
            // PicturePanel
            // 
            this.PicturePanel.AutoSize = true;
            this.PicturePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PicturePanel.Controls.Add(this.LogoPic);
            this.PicturePanel.Location = new System.Drawing.Point(21, 8);
            this.PicturePanel.Name = "PicturePanel";
            this.PicturePanel.Size = new System.Drawing.Size(722, 276);
            this.PicturePanel.TabIndex = 7;
            // 
            // PasswordInputField
            // 
            this.PasswordInputField.Font = new System.Drawing.Font("Myriad Pro", 9.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordInputField.Location = new System.Drawing.Point(154, 53);
            this.PasswordInputField.Name = "PasswordInputField";
            this.PasswordInputField.PasswordChar = '$';
            this.PasswordInputField.Size = new System.Drawing.Size(237, 32);
            this.PasswordInputField.TabIndex = 2;
            this.PasswordInputField.TextChanged += new System.EventHandler(this.PasswordInputField_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Miriam Libre", 9.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Miriam Libre", 9.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // UsernameView
            // 
            this.UsernameView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UsernameView.Cursor = System.Windows.Forms.Cursors.Default;
            this.UsernameView.Font = new System.Drawing.Font("Myriad Pro", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameView.Location = new System.Drawing.Point(154, 15);
            this.UsernameView.Name = "UsernameView";
            this.UsernameView.ReadOnly = true;
            this.UsernameView.Size = new System.Drawing.Size(237, 32);
            this.UsernameView.TabIndex = 5;
            this.UsernameView.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UsernameView.TextChanged += new System.EventHandler(this.UsernameView_TextChanged);
            // 
            // LoginPanel
            // 
            this.LoginPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LoginPanel.Controls.Add(this.UsernameView);
            this.LoginPanel.Controls.Add(this.label2);
            this.LoginPanel.Controls.Add(this.label1);
            this.LoginPanel.Controls.Add(this.PasswordInputField);
            this.LoginPanel.Controls.Add(this.LoginButton);
            this.LoginPanel.Location = new System.Drawing.Point(106, 313);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(577, 107);
            this.LoginPanel.TabIndex = 6;
            // 
            // Login
            // 
            this.AcceptButton = this.LoginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LoginPanel);
            this.Controls.Add(this.PicturePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LogoPic)).EndInit();
            this.PicturePanel.ResumeLayout(false);
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.PictureBox LogoPic;
        private System.Windows.Forms.Panel PicturePanel;
        private System.Windows.Forms.TextBox PasswordInputField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UsernameView;
        private System.Windows.Forms.Panel LoginPanel;
    }
}