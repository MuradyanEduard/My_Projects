namespace ParzPoxarinum
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
            this.label1 = new System.Windows.Forms.Label();
            this.TxtKey = new System.Windows.Forms.TextBox();
            this.TxtSentence = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.dataGridView1.Location = new System.Drawing.Point(69, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(688, 112);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(66, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Key";
            // 
            // TxtKey
            // 
            this.TxtKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.TxtKey.Location = new System.Drawing.Point(69, 240);
            this.TxtKey.Name = "TxtKey";
            this.TxtKey.Size = new System.Drawing.Size(153, 30);
            this.TxtKey.TabIndex = 2;
            // 
            // TxtSentence
            // 
            this.TxtSentence.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.TxtSentence.Location = new System.Drawing.Point(248, 240);
            this.TxtSentence.Name = "TxtSentence";
            this.TxtSentence.Size = new System.Drawing.Size(248, 30);
            this.TxtSentence.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(243, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sentence";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnStart.Location = new System.Drawing.Point(502, 240);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(82, 30);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // labelAnswer
            // 
            this.labelAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.labelAnswer.Location = new System.Drawing.Point(69, 291);
            this.labelAnswer.Name = "labelAnswer";
            this.labelAnswer.Size = new System.Drawing.Size(427, 30);
            this.labelAnswer.TabIndex = 7;
            // 
            // ChBoxEncrypt
            // 
            this.ChBoxEncrypt.AutoSize = true;
            this.ChBoxEncrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.ChBoxEncrypt.Location = new System.Drawing.Point(69, 180);
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
            this.ChBoxDecrypt.Location = new System.Drawing.Point(203, 180);
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
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ChBoxDecrypt);
            this.Controls.Add(this.ChBoxEncrypt);
            this.Controls.Add(this.labelAnswer);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.TxtSentence);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtKey;
        private System.Windows.Forms.TextBox TxtSentence;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox labelAnswer;
        private System.Windows.Forms.CheckBox ChBoxEncrypt;
        private System.Windows.Forms.CheckBox ChBoxDecrypt;
    }
}

