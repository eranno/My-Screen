namespace GUI
{
    partial class EncrypForm
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbImgFiles = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.encryptNstore = new System.Windows.Forms.Button();
            this.btLoadImg = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "(*.jpg)|*jpg";
            this.openFileDialog1.Multiselect = true;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::GUI.Properties.Resources.Encrypt_background;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.lbImgFiles);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.encryptNstore);
            this.panel1.Controls.Add(this.btLoadImg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(348, 206);
            this.panel1.TabIndex = 0;
            // 
            // lbImgFiles
            // 
            this.lbImgFiles.FormattingEnabled = true;
            this.lbImgFiles.Location = new System.Drawing.Point(166, 70);
            this.lbImgFiles.Name = "lbImgFiles";
            this.lbImgFiles.Size = new System.Drawing.Size(155, 108);
            this.lbImgFiles.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.GhostWhite;
            this.label1.Location = new System.Drawing.Point(81, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Encrypt Images";
            // 
            // encryptNstore
            // 
            this.encryptNstore.Location = new System.Drawing.Point(30, 124);
            this.encryptNstore.Name = "encryptNstore";
            this.encryptNstore.Size = new System.Drawing.Size(113, 54);
            this.encryptNstore.TabIndex = 1;
            this.encryptNstore.Text = "Encrypt And Store";
            this.encryptNstore.UseVisualStyleBackColor = true;
            this.encryptNstore.Click += new System.EventHandler(this.encryptNstore_Click);
            // 
            // btLoadImg
            // 
            this.btLoadImg.Location = new System.Drawing.Point(30, 70);
            this.btLoadImg.Name = "btLoadImg";
            this.btLoadImg.Size = new System.Drawing.Size(113, 31);
            this.btLoadImg.TabIndex = 0;
            this.btLoadImg.Text = "Load Images";
            this.btLoadImg.UseVisualStyleBackColor = true;
            this.btLoadImg.Click += new System.EventHandler(this.btLoadImg_Click);
            // 
            // EncrypForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 206);
            this.Controls.Add(this.panel1);
            this.Name = "EncrypForm";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button encryptNstore;
        private System.Windows.Forms.Button btLoadImg;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListBox lbImgFiles;
    }
}