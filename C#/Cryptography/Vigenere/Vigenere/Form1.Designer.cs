namespace Vigenere
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TxtKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.labelAnswer = new System.Windows.Forms.TextBox();
            this.ChBoxEncrypt = new System.Windows.Forms.CheckBox();
            this.ChBoxDecrypt = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(352, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(593, 586);
            this.dataGridView1.TabIndex = 0;
            // 
            // TxtKey
            // 
            this.TxtKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.TxtKey.Location = new System.Drawing.Point(30, 135);
            this.TxtKey.Name = "TxtKey";
            this.TxtKey.Size = new System.Drawing.Size(284, 30);
            this.TxtKey.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(25, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(25, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Text";
            // 
            // textBox
            // 
            this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.textBox.Location = new System.Drawing.Point(30, 209);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(284, 30);
            this.textBox.TabIndex = 3;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnStart.Location = new System.Drawing.Point(30, 261);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(93, 37);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // labelAnswer
            // 
            this.labelAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.labelAnswer.Location = new System.Drawing.Point(30, 319);
            this.labelAnswer.Name = "labelAnswer";
            this.labelAnswer.Size = new System.Drawing.Size(284, 30);
            this.labelAnswer.TabIndex = 7;
            // 
            // ChBoxEncrypt
            // 
            this.ChBoxEncrypt.AutoSize = true;
            this.ChBoxEncrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.ChBoxEncrypt.Location = new System.Drawing.Point(30, 31);
            this.ChBoxEncrypt.Name = "ChBoxEncrypt";
            this.ChBoxEncrypt.Size = new System.Drawing.Size(97, 29);
            this.ChBoxEncrypt.TabIndex = 8;
            this.ChBoxEncrypt.Text = "Encrypt";
            this.ChBoxEncrypt.UseVisualStyleBackColor = true;
            this.ChBoxEncrypt.CheckedChanged += new System.EventHandler(this.ChBoxEncrypt_CheckedChanged);
            // 
            // ChBoxDecrypt
            // 
            this.ChBoxDecrypt.AutoSize = true;
            this.ChBoxDecrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.ChBoxDecrypt.Location = new System.Drawing.Point(30, 66);
            this.ChBoxDecrypt.Name = "ChBoxDecrypt";
            this.ChBoxDecrypt.Size = new System.Drawing.Size(98, 29);
            this.ChBoxDecrypt.TabIndex = 9;
            this.ChBoxDecrypt.Text = "Decrypt";
            this.ChBoxDecrypt.UseVisualStyleBackColor = true;
            this.ChBoxDecrypt.CheckedChanged += new System.EventHandler(this.ChBoxDecrypt_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 632);
            this.Controls.Add(this.ChBoxDecrypt);
            this.Controls.Add(this.ChBoxEncrypt);
            this.Controls.Add(this.labelAnswer);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtKey);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Vigenere";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox TxtKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox labelAnswer;
        private System.Windows.Forms.CheckBox ChBoxEncrypt;
        private System.Windows.Forms.CheckBox ChBoxDecrypt;
    }
}

