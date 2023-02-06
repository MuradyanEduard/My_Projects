namespace Stegonagraph
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pbUnhide = new System.Windows.Forms.PictureBox();
            this.pbHide = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.tbPublicKey = new System.Windows.Forms.TextBox();
            this.tbPrivateKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelGenerate = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnhide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHide)).BeginInit();
            this.panelGenerate.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbUnhide
            // 
            this.pbUnhide.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbUnhide.BackgroundImage")));
            this.pbUnhide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbUnhide.Location = new System.Drawing.Point(195, 12);
            this.pbUnhide.Name = "pbUnhide";
            this.pbUnhide.Size = new System.Drawing.Size(120, 120);
            this.pbUnhide.TabIndex = 18;
            this.pbUnhide.TabStop = false;
            this.pbUnhide.Click += new System.EventHandler(this.PbUnhide_Click);
            // 
            // pbHide
            // 
            this.pbHide.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbHide.BackgroundImage")));
            this.pbHide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbHide.Location = new System.Drawing.Point(25, 13);
            this.pbHide.Name = "pbHide";
            this.pbHide.Size = new System.Drawing.Size(120, 120);
            this.pbHide.TabIndex = 19;
            this.pbHide.TabStop = false;
            this.pbHide.Click += new System.EventHandler(this.PbHide_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(320, 40);
            this.button1.TabIndex = 53;
            this.button1.Text = "About Application";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnGenerate.Location = new System.Drawing.Point(12, 185);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(320, 40);
            this.btnGenerate.TabIndex = 57;
            this.btnGenerate.Text = "GenerateKey";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // tbPublicKey
            // 
            this.tbPublicKey.Location = new System.Drawing.Point(105, 52);
            this.tbPublicKey.Name = "tbPublicKey";
            this.tbPublicKey.Size = new System.Drawing.Size(197, 20);
            this.tbPublicKey.TabIndex = 59;
            // 
            // tbPrivateKey
            // 
            this.tbPrivateKey.Location = new System.Drawing.Point(105, 26);
            this.tbPrivateKey.Name = "tbPrivateKey";
            this.tbPrivateKey.Size = new System.Drawing.Size(197, 20);
            this.tbPrivateKey.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 61;
            this.label1.Text = "Private Key:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(8, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 62;
            this.label2.Text = "Public Key:";
            // 
            // panelGenerate
            // 
            this.panelGenerate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGenerate.Controls.Add(this.tbPublicKey);
            this.panelGenerate.Controls.Add(this.tbPrivateKey);
            this.panelGenerate.Controls.Add(this.label1);
            this.panelGenerate.Controls.Add(this.label2);
            this.panelGenerate.Location = new System.Drawing.Point(12, 231);
            this.panelGenerate.Name = "panelGenerate";
            this.panelGenerate.Size = new System.Drawing.Size(320, 94);
            this.panelGenerate.TabIndex = 67;
            this.panelGenerate.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(348, 349);
            this.Controls.Add(this.panelGenerate);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pbHide);
            this.Controls.Add(this.pbUnhide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steganography";
            ((System.ComponentModel.ISupportInitialize)(this.pbUnhide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHide)).EndInit();
            this.panelGenerate.ResumeLayout(false);
            this.panelGenerate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbUnhide;
        private System.Windows.Forms.PictureBox pbHide;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox tbPublicKey;
        private System.Windows.Forms.TextBox tbPrivateKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelGenerate;
    }
}