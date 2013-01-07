namespace GUI
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncWithServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showTablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.followAfterTrafficToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblalertImgs = new System.Windows.Forms.Label();
            this.lvImgs = new System.Windows.Forms.ListView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnRemoveImgs = new System.Windows.Forms.Button();
            this.btAddImage = new System.Windows.Forms.Button();
            this.lblFriend = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.friendsList = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btEncryptImage = new System.Windows.Forms.Button();
            this.btAddFriend = new System.Windows.Forms.Button();
            this.btDecrypt = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(797, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.statisticToolStripMenuItem,
            this.syncWithServerToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // statisticToolStripMenuItem
            // 
            this.statisticToolStripMenuItem.Name = "statisticToolStripMenuItem";
            this.statisticToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.statisticToolStripMenuItem.Text = "Statistic";
            // 
            // syncWithServerToolStripMenuItem
            // 
            this.syncWithServerToolStripMenuItem.Name = "syncWithServerToolStripMenuItem";
            this.syncWithServerToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.syncWithServerToolStripMenuItem.Text = "Sync with server";
            this.syncWithServerToolStripMenuItem.Click += new System.EventHandler(this.syncWithServerToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.showTablesToolStripMenuItem,
            this.followAfterTrafficToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // showTablesToolStripMenuItem
            // 
            this.showTablesToolStripMenuItem.Name = "showTablesToolStripMenuItem";
            this.showTablesToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.showTablesToolStripMenuItem.Text = "Show Tables";
            this.showTablesToolStripMenuItem.Click += new System.EventHandler(this.showTablesToolStripMenuItem_Click);
            // 
            // followAfterTrafficToolStripMenuItem
            // 
            this.followAfterTrafficToolStripMenuItem.Name = "followAfterTrafficToolStripMenuItem";
            this.followAfterTrafficToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.followAfterTrafficToolStripMenuItem.Text = "Follow after traffic";
            this.followAfterTrafficToolStripMenuItem.Click += new System.EventHandler(this.followAfterTrafficToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "(*.jpg)|*jpg";
            this.openFileDialog1.Multiselect = true;
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.lblalertImgs);
            this.groupBox3.Controls.Add(this.lvImgs);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(528, 465);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Authorized Images";
            // 
            // lblalertImgs
            // 
            this.lblalertImgs.AutoSize = true;
            this.lblalertImgs.BackColor = System.Drawing.Color.Transparent;
            this.lblalertImgs.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblalertImgs.ForeColor = System.Drawing.Color.Transparent;
            this.lblalertImgs.Image = global::GUI.Properties.Resources.list_background;
            this.lblalertImgs.Location = new System.Drawing.Point(112, 217);
            this.lblalertImgs.Name = "lblalertImgs";
            this.lblalertImgs.Size = new System.Drawing.Size(301, 42);
            this.lblalertImgs.TabIndex = 3;
            this.lblalertImgs.Text = "Add New Images";
            // 
            // lvImgs
            // 
            this.lvImgs.AllowDrop = true;
            this.lvImgs.BackColor = System.Drawing.SystemColors.Window;
            this.lvImgs.BackgroundImage = global::GUI.Properties.Resources.list_background1;
            this.lvImgs.BackgroundImageTiled = true;
            this.lvImgs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvImgs.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lvImgs.Location = new System.Drawing.Point(3, 16);
            this.lvImgs.Name = "lvImgs";
            this.lvImgs.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lvImgs.Size = new System.Drawing.Size(522, 446);
            this.lvImgs.TabIndex = 2;
            this.lvImgs.UseCompatibleStateImageBehavior = false;
            this.lvImgs.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvImgs_ItemSelectionChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSize = true;
            this.groupBox4.Controls.Add(this.btnRemoveImgs);
            this.groupBox4.Controls.Add(this.btAddImage);
            this.groupBox4.Controls.Add(this.lblFriend);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(15, 3, 15, 7);
            this.groupBox4.Size = new System.Drawing.Size(528, 53);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Friend";
            // 
            // btnRemoveImgs
            // 
            this.btnRemoveImgs.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRemoveImgs.Location = new System.Drawing.Point(332, 16);
            this.btnRemoveImgs.Name = "btnRemoveImgs";
            this.btnRemoveImgs.Size = new System.Drawing.Size(102, 30);
            this.btnRemoveImgs.TabIndex = 2;
            this.btnRemoveImgs.Text = "Remove Images";
            this.btnRemoveImgs.UseVisualStyleBackColor = true;
            this.btnRemoveImgs.Click += new System.EventHandler(this.btnRemoveImgs_Click);
            // 
            // btAddImage
            // 
            this.btAddImage.Dock = System.Windows.Forms.DockStyle.Right;
            this.btAddImage.Location = new System.Drawing.Point(434, 16);
            this.btAddImage.Name = "btAddImage";
            this.btAddImage.Size = new System.Drawing.Size(79, 30);
            this.btAddImage.TabIndex = 1;
            this.btAddImage.Text = "Add Images";
            this.btAddImage.UseVisualStyleBackColor = true;
            this.btAddImage.Click += new System.EventHandler(this.btAddImage_Click);
            // 
            // lblFriend
            // 
            this.lblFriend.AutoSize = true;
            this.lblFriend.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblFriend.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblFriend.Location = new System.Drawing.Point(15, 16);
            this.lblFriend.Name = "lblFriend";
            this.lblFriend.Size = new System.Drawing.Size(153, 25);
            this.lblFriend.TabIndex = 0;
            this.lblFriend.Text = "Choose Friend";
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.friendsList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(265, 406);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Friends";
            // 
            // friendsList
            // 
            this.friendsList.BackColor = System.Drawing.Color.Silver;
            this.friendsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.friendsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.friendsList.FormattingEnabled = true;
            this.friendsList.ItemHeight = 25;
            this.friendsList.Location = new System.Drawing.Point(3, 16);
            this.friendsList.Name = "friendsList";
            this.friendsList.Size = new System.Drawing.Size(259, 387);
            this.friendsList.TabIndex = 0;
            this.friendsList.SelectedIndexChanged += new System.EventHandler(this.friendsList_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.btEncryptImage);
            this.groupBox1.Controls.Add(this.btAddFriend);
            this.groupBox1.Controls.Add(this.btDecrypt);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 112);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control";
            // 
            // btEncryptImage
            // 
            this.btEncryptImage.Location = new System.Drawing.Point(95, 34);
            this.btEncryptImage.Name = "btEncryptImage";
            this.btEncryptImage.Size = new System.Drawing.Size(66, 53);
            this.btEncryptImage.TabIndex = 2;
            this.btEncryptImage.Text = "Encrypt Image";
            this.btEncryptImage.UseVisualStyleBackColor = true;
            this.btEncryptImage.Click += new System.EventHandler(this.btEncryptImage_Click);
            // 
            // btAddFriend
            // 
            this.btAddFriend.Location = new System.Drawing.Point(12, 34);
            this.btAddFriend.Name = "btAddFriend";
            this.btAddFriend.Size = new System.Drawing.Size(66, 53);
            this.btAddFriend.TabIndex = 1;
            this.btAddFriend.Text = "Add Friend";
            this.btAddFriend.UseVisualStyleBackColor = true;
            this.btAddFriend.Click += new System.EventHandler(this.btAddFriend_Click);
            // 
            // btDecrypt
            // 
            this.btDecrypt.Location = new System.Drawing.Point(177, 34);
            this.btDecrypt.Name = "btDecrypt";
            this.btDecrypt.Size = new System.Drawing.Size(66, 53);
            this.btDecrypt.TabIndex = 0;
            this.btDecrypt.Text = "Start Decrypt";
            this.btDecrypt.UseVisualStyleBackColor = true;
            this.btDecrypt.Click += new System.EventHandler(this.btDecrypt_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(797, 522);
            this.splitContainer1.SplitterDistance = 265;
            this.splitContainer1.TabIndex = 5;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer3.Size = new System.Drawing.Size(265, 522);
            this.splitContainer3.SplitterDistance = 112;
            this.splitContainer3.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer2.Size = new System.Drawing.Size(528, 522);
            this.splitContainer2.SplitterDistance = 53;
            this.splitContainer2.TabIndex = 5;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(80, 80);
            this.imageList1.Tag = "";
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(226)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(797, 546);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MinimumSize = new System.Drawing.Size(813, 584);
            this.Name = "MainForm";
            this.Text = "My Screen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statisticToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem syncWithServerToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblalertImgs;
        private System.Windows.Forms.ListView lvImgs;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btAddImage;
        private System.Windows.Forms.Label lblFriend;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btEncryptImage;
        private System.Windows.Forms.Button btAddFriend;
        private System.Windows.Forms.Button btDecrypt;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ToolStripMenuItem showTablesToolStripMenuItem;
        private System.Windows.Forms.ListBox friendsList;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnRemoveImgs;
        private System.Windows.Forms.ToolStripMenuItem followAfterTrafficToolStripMenuItem;

    }
}

