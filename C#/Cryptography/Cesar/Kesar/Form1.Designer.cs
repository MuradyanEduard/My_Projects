namespace Kesar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TxtKey = new System.Windows.Forms.TextBox();
            this.TxtSentence = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnShifr = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelAnswer = new System.Windows.Forms.TextBox();
            this.ChBoxEncrypt = new System.Windows.Forms.CheckBox();
            this.ChBoxDecrypt = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtKey
            // 
            this.TxtKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.TxtKey.Location = new System.Drawing.Point(67, 222);
            this.TxtKey.Name = "TxtKey";
            this.TxtKey.Size = new System.Drawing.Size(42, 30);
            this.TxtKey.TabIndex = 0;
            // 
            // TxtSentence
            // 
            this.TxtSentence.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.TxtSentence.Location = new System.Drawing.Point(115, 222);
            this.TxtSentence.Name = "TxtSentence";
            this.TxtSentence.Size = new System.Drawing.Size(216, 30);
            this.TxtSentence.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(62, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(115, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sentence";
            // 
            // BtnShifr
            // 
            this.BtnShifr.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.BtnShifr.Location = new System.Drawing.Point(337, 219);
            this.BtnShifr.Name = "BtnShifr";
            this.BtnShifr.Size = new System.Drawing.Size(75, 33);
            this.BtnShifr.TabIndex = 4;
            this.BtnShifr.Text = "Start";
            this.BtnShifr.UseVisualStyleBackColor = true;
            this.BtnShifr.Click += new System.EventHandler(this.BtnShifr_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(70, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(651, 106);
            this.dataGridView1.TabIndex = 8;
            // 
            // labelAnswer
            // 
            this.labelAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.labelAnswer.Location = new System.Drawing.Point(67, 268);
            this.labelAnswer.Name = "labelAnswer";
            this.labelAnswer.Size = new System.Drawing.Size(264, 30);
            this.labelAnswer.TabIndex = 9;
            // 
            // ChBoxEncrypt
            // 
            this.ChBoxEncrypt.AutoSize = true;
            this.ChBoxEncrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.ChBoxEncrypt.Location = new System.Drawing.Point(67, 162);
            this.ChBoxEncrypt.Name = "ChBoxEncrypt";
            this.ChBoxEncrypt.Size = new System.Drawing.Size(97, 29);
            this.ChBoxEncrypt.TabIndex = 10;
            this.ChBoxEncrypt.Text = "Encrypt";
            this.ChBoxEncrypt.UseVisualStyleBackColor = true;
            this.ChBoxEncrypt.CheckedChanged += new System.EventHandler(this.ChBoxEncrypt_CheckedChanged);
            // 
            // ChBoxDecrypt
            // 
            this.ChBoxDecrypt.AutoSize = true;
            this.ChBoxDecrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.ChBoxDecrypt.Location = new System.Drawing.Point(170, 162);
            this.ChBoxDecrypt.Name = "ChBoxDecrypt";
            this.ChBoxDecrypt.Size = new System.Drawing.Size(98, 29);
            this.ChBoxDecrypt.TabIndex = 11;
            this.ChBoxDecrypt.Text = "Decrypt";
            this.ChBoxDecrypt.UseVisualStyleBackColor = true;
            this.ChBoxDecrypt.CheckedChanged += new System.EventHandler(this.ChBoxDecipher_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 356);
            this.Controls.Add(this.ChBoxDecrypt);
            this.Controls.Add(this.ChBoxEncrypt);
            this.Controls.Add(this.labelAnswer);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.BtnShifr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtSentence);
            this.Controls.Add(this.TxtKey);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Cesar";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtKey;
        private System.Windows.Forms.TextBox TxtSentence;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnShifr;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox labelAnswer;
        private System.Windows.Forms.CheckBox ChBoxEncrypt;
        private System.Windows.Forms.CheckBox ChBoxDecrypt;
    }
}

