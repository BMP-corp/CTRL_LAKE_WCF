namespace SegreteriaWF
{
    partial class HomeSegreteria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeSegreteria));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.newLezione = new System.Windows.Forms.Button();
            this.NoleggiaButton = new System.Windows.Forms.Button();
            this.RegistraClienteButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.editPrenotazione = new System.Windows.Forms.Button();
            this.NavigationPanel = new System.Windows.Forms.Panel();
            this.dateTimeFilter = new System.Windows.Forms.DateTimePicker();
            this.ClienteFilterBox = new System.Windows.Forms.TextBox();
            this.ButtonRefresh = new System.Windows.Forms.Button();
            this.FilterPanel = new System.Windows.Forms.Panel();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.tabellaPrenotazioni = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.NavigationPanel.SuspendLayout();
            this.FilterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.TopPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabellaPrenotazioni)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Linux Biolinum G", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "DATA:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // newLezione
            // 
            this.newLezione.BackColor = System.Drawing.Color.Gold;
            this.newLezione.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.newLezione.Font = new System.Drawing.Font("Hobo Std", 14F);
            this.newLezione.Location = new System.Drawing.Point(0, 24);
            this.newLezione.Name = "newLezione";
            this.newLezione.Size = new System.Drawing.Size(308, 64);
            this.newLezione.TabIndex = 3;
            this.newLezione.Text = "Lezione";
            this.newLezione.UseVisualStyleBackColor = false;
            this.newLezione.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // NoleggiaButton
            // 
            this.NoleggiaButton.BackColor = System.Drawing.Color.Gold;
            this.NoleggiaButton.Font = new System.Drawing.Font("Hobo Std", 14F);
            this.NoleggiaButton.Location = new System.Drawing.Point(3, 105);
            this.NoleggiaButton.Name = "NoleggiaButton";
            this.NoleggiaButton.Size = new System.Drawing.Size(305, 68);
            this.NoleggiaButton.TabIndex = 4;
            this.NoleggiaButton.Text = "Noleggia";
            this.NoleggiaButton.UseVisualStyleBackColor = false;
            // 
            // RegistraClienteButton
            // 
            this.RegistraClienteButton.BackColor = System.Drawing.Color.Gold;
            this.RegistraClienteButton.Font = new System.Drawing.Font("Hobo Std", 14F);
            this.RegistraClienteButton.Location = new System.Drawing.Point(0, 189);
            this.RegistraClienteButton.Name = "RegistraClienteButton";
            this.RegistraClienteButton.Size = new System.Drawing.Size(305, 68);
            this.RegistraClienteButton.TabIndex = 5;
            this.RegistraClienteButton.Text = "Registra Cliente";
            this.RegistraClienteButton.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Linux Biolinum G", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(457, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "CLIENTE:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.label3.Font = new System.Drawing.Font("Linux Biolinum G", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 37);
            this.label3.TabIndex = 7;
            this.label3.Text = "HOME ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // editPrenotazione
            // 
            this.editPrenotazione.BackColor = System.Drawing.Color.Gold;
            this.editPrenotazione.Font = new System.Drawing.Font("Hobo Std", 14F);
            this.editPrenotazione.Location = new System.Drawing.Point(0, 278);
            this.editPrenotazione.Name = "editPrenotazione";
            this.editPrenotazione.Size = new System.Drawing.Size(302, 64);
            this.editPrenotazione.TabIndex = 8;
            this.editPrenotazione.Text = "Modifica Prenotazione";
            this.editPrenotazione.UseVisualStyleBackColor = false;
            this.editPrenotazione.Click += new System.EventHandler(this.editPrenotazione_Click);
            // 
            // NavigationPanel
            // 
            this.NavigationPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NavigationPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NavigationPanel.BackColor = System.Drawing.Color.Transparent;
            this.NavigationPanel.Controls.Add(this.editPrenotazione);
            this.NavigationPanel.Controls.Add(this.RegistraClienteButton);
            this.NavigationPanel.Controls.Add(this.NoleggiaButton);
            this.NavigationPanel.Controls.Add(this.newLezione);
            this.NavigationPanel.Location = new System.Drawing.Point(1086, 10);
            this.NavigationPanel.Name = "NavigationPanel";
            this.NavigationPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.NavigationPanel.Size = new System.Drawing.Size(308, 367);
            this.NavigationPanel.TabIndex = 9;
            // 
            // dateTimeFilter
            // 
            this.dateTimeFilter.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dateTimeFilter.Location = new System.Drawing.Point(77, 18);
            this.dateTimeFilter.Name = "dateTimeFilter";
            this.dateTimeFilter.Size = new System.Drawing.Size(352, 23);
            this.dateTimeFilter.TabIndex = 10;
            this.dateTimeFilter.ValueChanged += new System.EventHandler(this.dateTimeFilter_ValueChanged);
            // 
            // ClienteFilterBox
            // 
            this.ClienteFilterBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ClienteFilterBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.ClienteFilterBox.Location = new System.Drawing.Point(550, 22);
            this.ClienteFilterBox.Name = "ClienteFilterBox";
            this.ClienteFilterBox.Size = new System.Drawing.Size(235, 20);
            this.ClienteFilterBox.TabIndex = 12;
            this.ClienteFilterBox.TextChanged += new System.EventHandler(this.ClienteFilterBox_TextChanged);
            // 
            // ButtonRefresh
            // 
            this.ButtonRefresh.BackColor = System.Drawing.Color.DarkOrange;
            this.ButtonRefresh.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.ButtonRefresh.Font = new System.Drawing.Font("Miriam Libre", 9.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ButtonRefresh.Location = new System.Drawing.Point(808, 10);
            this.ButtonRefresh.Name = "ButtonRefresh";
            this.ButtonRefresh.Size = new System.Drawing.Size(147, 43);
            this.ButtonRefresh.TabIndex = 13;
            this.ButtonRefresh.Text = "RicaricaDati";
            this.ButtonRefresh.UseVisualStyleBackColor = false;
            this.ButtonRefresh.Click += new System.EventHandler(this.FilterTableApply_Click);
            // 
            // FilterPanel
            // 
            this.FilterPanel.Controls.Add(this.ButtonRefresh);
            this.FilterPanel.Controls.Add(this.ClienteFilterBox);
            this.FilterPanel.Controls.Add(this.dateTimeFilter);
            this.FilterPanel.Controls.Add(this.label2);
            this.FilterPanel.Controls.Add(this.label1);
            this.FilterPanel.Location = new System.Drawing.Point(7, 102);
            this.FilterPanel.Name = "FilterPanel";
            this.FilterPanel.Size = new System.Drawing.Size(960, 58);
            this.FilterPanel.TabIndex = 14;
            this.FilterPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Monotype Corsiva", 20F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.Location = new System.Drawing.Point(124, 12);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(181, 33);
            this.welcomeLabel.TabIndex = 15;
            this.welcomeLabel.Text = "WelcomeMessage";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(973, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(435, 148);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // LogoutButton
            // 
            this.LogoutButton.BackColor = System.Drawing.Color.LightCoral;
            this.LogoutButton.Location = new System.Drawing.Point(808, 12);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(147, 43);
            this.LogoutButton.TabIndex = 17;
            this.LogoutButton.Text = "Logout";
            this.LogoutButton.UseVisualStyleBackColor = false;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.LogoutButton);
            this.panel1.Controls.Add(this.welcomeLabel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(7, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 64);
            this.panel1.TabIndex = 18;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(444, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 12;
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.panel1);
            this.TopPanel.Controls.Add(this.pictureBox1);
            this.TopPanel.Controls.Add(this.FilterPanel);
            this.TopPanel.Location = new System.Drawing.Point(3, 3);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1411, 173);
            this.TopPanel.TabIndex = 19;
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.tabellaPrenotazioni);
            this.BottomPanel.Controls.Add(this.NavigationPanel);
            this.BottomPanel.Location = new System.Drawing.Point(3, 182);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(1411, 392);
            this.BottomPanel.TabIndex = 20;
            // 
            // tabellaPrenotazioni
            // 
            this.tabellaPrenotazioni.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tabellaPrenotazioni.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Coral;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tabellaPrenotazioni.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tabellaPrenotazioni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabellaPrenotazioni.Location = new System.Drawing.Point(7, 10);
            this.tabellaPrenotazioni.Name = "tabellaPrenotazioni";
            this.tabellaPrenotazioni.Size = new System.Drawing.Size(1051, 379);
            this.tabellaPrenotazioni.TabIndex = 11;
            this.tabellaPrenotazioni.SelectionChanged += new System.EventHandler(this.tabellaPrenotazioni_SelectionChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.TopPanel);
            this.flowLayoutPanel1.Controls.Add(this.BottomPanel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1425, 585);
            this.flowLayoutPanel1.TabIndex = 21;
            // 
            // HomeSegreteria
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(1437, 603);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "HomeSegreteria";
            this.Text = "CTRL_LAKE Desktop";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.NavigationPanel.ResumeLayout(false);
            this.FilterPanel.ResumeLayout(false);
            this.FilterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.TopPanel.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabellaPrenotazioni)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button newLezione;
        private System.Windows.Forms.Button NoleggiaButton;
        private System.Windows.Forms.Button RegistraClienteButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button editPrenotazione;
        private System.Windows.Forms.Panel NavigationPanel;
        private System.Windows.Forms.DateTimePicker dateTimeFilter;
        private System.Windows.Forms.TextBox ClienteFilterBox;
        private System.Windows.Forms.Button ButtonRefresh;
        private System.Windows.Forms.Panel FilterPanel;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button LogoutButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn oraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipologiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn attrezzaturaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn istruttoreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagatoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView tabellaPrenotazioni;
        private System.Windows.Forms.TextBox textBox1;
    }
}

