namespace SegreteriaWF
{
    partial class Pagamento
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dettagliPagamentoGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.scontoTexB = new System.Windows.Forms.TextBox();
            this.danniTextB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.subtotLabel = new System.Windows.Forms.Label();
            this.scontoLabel = new System.Windows.Forms.Label();
            this.totLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dettagliPagamentoGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(512, 214);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "SUBTOTALE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(273, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(302, 38);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dettagli Pagamento";
            // 
            // dettagliPagamentoGridView
            // 
            this.dettagliPagamentoGridView.AllowUserToResizeColumns = false;
            this.dettagliPagamentoGridView.AllowUserToResizeRows = false;
            this.dettagliPagamentoGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dettagliPagamentoGridView.Location = new System.Drawing.Point(145, 111);
            this.dettagliPagamentoGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dettagliPagamentoGridView.Name = "dettagliPagamentoGridView";
            this.dettagliPagamentoGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dettagliPagamentoGridView.Size = new System.Drawing.Size(543, 52);
            this.dettagliPagamentoGridView.TabIndex = 4;
            this.dettagliPagamentoGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button1.Location = new System.Drawing.Point(541, 361);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 42);
            this.button1.TabIndex = 5;
            this.button1.Text = "PAGA";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(190, 216);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 34);
            this.button2.TabIndex = 6;
            this.button2.Text = "Aggiungi Sconto";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(190, 282);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(137, 34);
            this.button3.TabIndex = 7;
            this.button3.Text = "Aggiungi Danni";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // scontoTexB
            // 
            this.scontoTexB.Location = new System.Drawing.Point(89, 222);
            this.scontoTexB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.scontoTexB.Name = "scontoTexB";
            this.scontoTexB.Size = new System.Drawing.Size(46, 22);
            this.scontoTexB.TabIndex = 8;
            // 
            // danniTextB
            // 
            this.danniTextB.Location = new System.Drawing.Point(89, 288);
            this.danniTextB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.danniTextB.Name = "danniTextB";
            this.danniTextB.Size = new System.Drawing.Size(46, 22);
            this.danniTextB.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(538, 300);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "TOTALE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(538, 248);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "SCONTO";
            // 
            // subtotLabel
            // 
            this.subtotLabel.AutoSize = true;
            this.subtotLabel.Location = new System.Drawing.Point(622, 214);
            this.subtotLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.subtotLabel.Name = "subtotLabel";
            this.subtotLabel.Size = new System.Drawing.Size(102, 17);
            this.subtotLabel.TabIndex = 12;
            this.subtotLabel.Text = "<nessun dato>";
            // 
            // scontoLabel
            // 
            this.scontoLabel.AutoSize = true;
            this.scontoLabel.Location = new System.Drawing.Point(622, 248);
            this.scontoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.scontoLabel.Name = "scontoLabel";
            this.scontoLabel.Size = new System.Drawing.Size(102, 17);
            this.scontoLabel.TabIndex = 13;
            this.scontoLabel.Text = "<nessun dato>";
            // 
            // totLabel
            // 
            this.totLabel.AutoSize = true;
            this.totLabel.Location = new System.Drawing.Point(622, 300);
            this.totLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totLabel.Name = "totLabel";
            this.totLabel.Size = new System.Drawing.Size(102, 17);
            this.totLabel.TabIndex = 14;
            this.totLabel.Text = "<nessun dato>";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(622, 265);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "<nessun dato>";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(538, 265);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "DANNI";
            // 
            // Pagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(115F, 115F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(845, 435);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.totLabel);
            this.Controls.Add(this.scontoLabel);
            this.Controls.Add(this.subtotLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.danniTextB);
            this.Controls.Add(this.scontoTexB);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dettagliPagamentoGridView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Pagamento";
            this.Text = "NuovaLezione";
            this.Load += new System.EventHandler(this.Pagamento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dettagliPagamentoGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dettagliPagamentoGridView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox scontoTexB;
        private System.Windows.Forms.TextBox danniTextB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label subtotLabel;
        private System.Windows.Forms.Label scontoLabel;
        private System.Windows.Forms.Label totLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}