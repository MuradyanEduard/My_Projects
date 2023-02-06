namespace Stegonagraph
{
    partial class KeyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEndKey = new System.Windows.Forms.Button();
            this.tbCryptedHide = new System.Windows.Forms.TextBox();
            this.tbPublic = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lsbDataGridView = new System.Windows.Forms.DataGridView();
            this.nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.getKeyDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGetKey = new System.Windows.Forms.Button();
            this.tbCryptedUnhide = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPrivate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lsbDataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.getKeyDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnEndKey);
            this.panel1.Controls.Add(this.tbCryptedHide);
            this.panel1.Controls.Add(this.tbPublic);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lsbDataGridView);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton3);
            this.panel1.Controls.Add(this.radioButton4);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 371);
            this.panel1.TabIndex = 70;
            this.panel1.Visible = false;
            // 
            // btnEndKey
            // 
            this.btnEndKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnEndKey.Location = new System.Drawing.Point(18, 282);
            this.btnEndKey.Name = "btnEndKey";
            this.btnEndKey.Size = new System.Drawing.Size(243, 35);
            this.btnEndKey.TabIndex = 72;
            this.btnEndKey.Text = "Crypted Key";
            this.btnEndKey.UseVisualStyleBackColor = true;
            this.btnEndKey.Click += new System.EventHandler(this.btnEndKey_Click);
            // 
            // tbCryptedHide
            // 
            this.tbCryptedHide.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbCryptedHide.Location = new System.Drawing.Point(17, 323);
            this.tbCryptedHide.Name = "tbCryptedHide";
            this.tbCryptedHide.Size = new System.Drawing.Size(243, 26);
            this.tbCryptedHide.TabIndex = 71;
            // 
            // tbPublic
            // 
            this.tbPublic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbPublic.Location = new System.Drawing.Point(17, 250);
            this.tbPublic.Name = "tbPublic";
            this.tbPublic.Size = new System.Drawing.Size(243, 26);
            this.tbPublic.TabIndex = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(13, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 68;
            this.label1.Text = "Public Key";
            // 
            // lsbDataGridView
            // 
            this.lsbDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.lsbDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lsbDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nom,
            this.lsb});
            this.lsbDataGridView.Location = new System.Drawing.Point(13, 42);
            this.lsbDataGridView.MultiSelect = false;
            this.lsbDataGridView.Name = "lsbDataGridView";
            this.lsbDataGridView.Size = new System.Drawing.Size(172, 162);
            this.lsbDataGridView.TabIndex = 58;
            this.lsbDataGridView.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.lsbDataGridView_RowStateChanged);
            // 
            // nom
            // 
            this.nom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.nom.HeaderText = "N";
            this.nom.Name = "nom";
            this.nom.ReadOnly = true;
            this.nom.Width = 40;
            // 
            // lsb
            // 
            this.lsb.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.lsb.HeaderText = "LSB count";
            this.lsb.Name = "lsb";
            this.lsb.ReadOnly = true;
            this.lsb.Width = 82;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(9, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 20);
            this.label3.TabIndex = 67;
            this.label3.Text = "Steganography Key";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.radioButton1.Location = new System.Drawing.Point(204, 65);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(57, 24);
            this.radioButton1.TabIndex = 63;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "1 bit";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.radioButton2.Location = new System.Drawing.Point(203, 95);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(57, 24);
            this.radioButton2.TabIndex = 64;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "2 bit";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.radioButton3.Location = new System.Drawing.Point(204, 125);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(57, 24);
            this.radioButton3.TabIndex = 65;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "3 bit";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.radioButton4.Location = new System.Drawing.Point(204, 155);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(57, 24);
            this.radioButton4.TabIndex = 66;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "4 bit";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnStart.Location = new System.Drawing.Point(12, 389);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(289, 46);
            this.btnStart.TabIndex = 71;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.getKeyDataGridView);
            this.panel2.Controls.Add(this.btnGetKey);
            this.panel2.Controls.Add(this.tbCryptedUnhide);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.tbPrivate);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(351, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(289, 371);
            this.panel2.TabIndex = 73;
            this.panel2.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(72, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 20);
            this.label5.TabIndex = 73;
            this.label5.Text = "Steganography Key";
            // 
            // getKeyDataGridView
            // 
            this.getKeyDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.getKeyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.getKeyDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.getKeyDataGridView.Location = new System.Drawing.Point(56, 187);
            this.getKeyDataGridView.MultiSelect = false;
            this.getKeyDataGridView.Name = "getKeyDataGridView";
            this.getKeyDataGridView.Size = new System.Drawing.Size(177, 162);
            this.getKeyDataGridView.TabIndex = 73;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn1.HeaderText = "N";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn2.HeaderText = "LSB count";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 82;
            // 
            // btnGetKey
            // 
            this.btnGetKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnGetKey.Location = new System.Drawing.Point(22, 126);
            this.btnGetKey.Name = "btnGetKey";
            this.btnGetKey.Size = new System.Drawing.Size(243, 35);
            this.btnGetKey.TabIndex = 73;
            this.btnGetKey.Text = "Get Steganography Key";
            this.btnGetKey.UseVisualStyleBackColor = true;
            this.btnGetKey.Click += new System.EventHandler(this.btnGetKey_Click);
            // 
            // tbCryptedUnhide
            // 
            this.tbCryptedUnhide.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbCryptedUnhide.Location = new System.Drawing.Point(22, 94);
            this.tbCryptedUnhide.Name = "tbCryptedUnhide";
            this.tbCryptedUnhide.Size = new System.Drawing.Size(243, 26);
            this.tbCryptedUnhide.TabIndex = 76;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(18, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 20);
            this.label4.TabIndex = 75;
            this.label4.Text = "Crypted Key";
            // 
            // tbPrivate
            // 
            this.tbPrivate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbPrivate.Location = new System.Drawing.Point(22, 34);
            this.tbPrivate.Name = "tbPrivate";
            this.tbPrivate.Size = new System.Drawing.Size(243, 26);
            this.tbPrivate.TabIndex = 74;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(18, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 73;
            this.label2.Text = "Private Key";
            // 
            // KeyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(316, 457);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KeyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KeyForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.KeyForm_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lsbDataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.getKeyDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView lsbDataGridView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.TextBox tbCryptedHide;
        private System.Windows.Forms.TextBox tbPublic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnEndKey;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView getKeyDataGridView;
        private System.Windows.Forms.Button btnGetKey;
        private System.Windows.Forms.TextBox tbCryptedUnhide;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPrivate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn lsb;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}