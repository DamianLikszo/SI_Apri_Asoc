namespace Algo_Apri_Asoc
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
            this.rtxtWczytany = new System.Windows.Forms.RichTextBox();
            this.rtxtWynik = new System.Windows.Forms.RichTextBox();
            this.rtxtLogi = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnWczytaj = new System.Windows.Forms.Button();
            this.btnLicz = new System.Windows.Forms.Button();
            this.btnWyjscie = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudProgL = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudProgM = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nudProgCZ = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudProgL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudProgM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudProgCZ)).BeginInit();
            this.SuspendLayout();
            // 
            // rtxtWczytany
            // 
            this.rtxtWczytany.Location = new System.Drawing.Point(12, 293);
            this.rtxtWczytany.Name = "rtxtWczytany";
            this.rtxtWczytany.ReadOnly = true;
            this.rtxtWczytany.Size = new System.Drawing.Size(342, 213);
            this.rtxtWczytany.TabIndex = 0;
            this.rtxtWczytany.Text = "";
            // 
            // rtxtWynik
            // 
            this.rtxtWynik.Location = new System.Drawing.Point(360, 293);
            this.rtxtWynik.Name = "rtxtWynik";
            this.rtxtWynik.ReadOnly = true;
            this.rtxtWynik.Size = new System.Drawing.Size(342, 213);
            this.rtxtWynik.TabIndex = 1;
            this.rtxtWynik.Text = "";
            // 
            // rtxtLogi
            // 
            this.rtxtLogi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rtxtLogi.Location = new System.Drawing.Point(12, 32);
            this.rtxtLogi.Name = "rtxtLogi";
            this.rtxtLogi.Size = new System.Drawing.Size(483, 223);
            this.rtxtLogi.TabIndex = 2;
            this.rtxtLogi.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Logi:";
            // 
            // btnWczytaj
            // 
            this.btnWczytaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnWczytaj.Location = new System.Drawing.Point(501, 32);
            this.btnWczytaj.Name = "btnWczytaj";
            this.btnWczytaj.Size = new System.Drawing.Size(205, 35);
            this.btnWczytaj.TabIndex = 4;
            this.btnWczytaj.Text = "Wczytaj Zbiór";
            this.btnWczytaj.UseVisualStyleBackColor = true;
            this.btnWczytaj.Click += new System.EventHandler(this.btnWczytaj_Click);
            // 
            // btnLicz
            // 
            this.btnLicz.Enabled = false;
            this.btnLicz.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLicz.Location = new System.Drawing.Point(501, 167);
            this.btnLicz.Name = "btnLicz";
            this.btnLicz.Size = new System.Drawing.Size(205, 35);
            this.btnLicz.TabIndex = 5;
            this.btnLicz.Text = "Licz";
            this.btnLicz.UseVisualStyleBackColor = true;
            this.btnLicz.Click += new System.EventHandler(this.btnLicz_Click);
            // 
            // btnWyjscie
            // 
            this.btnWyjscie.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnWyjscie.Location = new System.Drawing.Point(501, 220);
            this.btnWyjscie.Name = "btnWyjscie";
            this.btnWyjscie.Size = new System.Drawing.Size(205, 35);
            this.btnWyjscie.TabIndex = 6;
            this.btnWyjscie.Text = "Wyjście";
            this.btnWyjscie.UseVisualStyleBackColor = true;
            this.btnWyjscie.Click += new System.EventHandler(this.btnWyjscie_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Zbiór Wczytany:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(356, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Wynik:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(497, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Próg:";
            // 
            // nudProgL
            // 
            this.nudProgL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nudProgL.Location = new System.Drawing.Point(575, 128);
            this.nudProgL.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudProgL.Name = "nudProgL";
            this.nudProgL.Size = new System.Drawing.Size(52, 27);
            this.nudProgL.TabIndex = 10;
            this.nudProgL.ValueChanged += new System.EventHandler(this.nudProgL_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(633, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "/";
            // 
            // nudProgM
            // 
            this.nudProgM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nudProgM.Location = new System.Drawing.Point(654, 128);
            this.nudProgM.Name = "nudProgM";
            this.nudProgM.Size = new System.Drawing.Size(52, 27);
            this.nudProgM.TabIndex = 12;
            this.nudProgM.ValueChanged += new System.EventHandler(this.nudProgM_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(497, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Próg Częstości:";
            // 
            // nudProgCZ
            // 
            this.nudProgCZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nudProgCZ.Location = new System.Drawing.Point(664, 85);
            this.nudProgCZ.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nudProgCZ.Name = "nudProgCZ";
            this.nudProgCZ.Size = new System.Drawing.Size(42, 27);
            this.nudProgCZ.TabIndex = 14;
            this.nudProgCZ.ValueChanged += new System.EventHandler(this.nudProgCZ_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 518);
            this.Controls.Add(this.nudProgCZ);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudProgM);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudProgL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnWyjscie);
            this.Controls.Add(this.btnLicz);
            this.Controls.Add(this.btnWczytaj);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtxtLogi);
            this.Controls.Add(this.rtxtWynik);
            this.Controls.Add(this.rtxtWczytany);
            this.Name = "Form1";
            this.Text = "Algorytm Apriori i Reguły Asocjacyjne - Damian Likszo";
            ((System.ComponentModel.ISupportInitialize)(this.nudProgL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudProgM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudProgCZ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtWczytany;
        private System.Windows.Forms.RichTextBox rtxtWynik;
        private System.Windows.Forms.RichTextBox rtxtLogi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnWczytaj;
        private System.Windows.Forms.Button btnLicz;
        private System.Windows.Forms.Button btnWyjscie;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudProgL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudProgM;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudProgCZ;
    }
}

