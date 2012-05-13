namespace StudioCleaner
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.treeViewGMX = new System.Windows.Forms.TreeView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.treeViewDisk = new System.Windows.Forms.TreeView();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.panel4 = new System.Windows.Forms.Panel();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusOrphans = new System.Windows.Forms.ToolStripStatusLabel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.butExpandAllDisk = new System.Windows.Forms.Button();
			this.butExpandAllGMX = new System.Windows.Forms.Button();
			this.btnClearAll = new System.Windows.Forms.Button();
			this.btnOpen = new System.Windows.Forms.Button();
			this.toolStripOpenDir = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.panel4.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// treeViewGMX
			// 
			this.treeViewGMX.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeViewGMX.ImageIndex = 0;
			this.treeViewGMX.ImageList = this.imageList1;
			this.treeViewGMX.Location = new System.Drawing.Point(0, 0);
			this.treeViewGMX.Name = "treeViewGMX";
			this.treeViewGMX.SelectedImageIndex = 0;
			this.treeViewGMX.Size = new System.Drawing.Size(432, 395);
			this.treeViewGMX.TabIndex = 0;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "folder.png");
			this.imageList1.Images.SetKeyName(1, "file_extension_dll.png");
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Controls.Add(this.butExpandAllDisk);
			this.panel1.Controls.Add(this.butExpandAllGMX);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.btnClearAll);
			this.panel1.Controls.Add(this.btnOpen);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(853, 66);
			this.panel1.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label2.Location = new System.Drawing.Point(429, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(79, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Orphan files:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(12, 46);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(81, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Project Files:";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.treeViewGMX);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(432, 395);
			this.panel2.TabIndex = 2;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.treeViewDisk);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel3.Location = new System.Drawing.Point(432, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(421, 395);
			this.panel3.TabIndex = 3;
			// 
			// treeViewDisk
			// 
			this.treeViewDisk.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeViewDisk.ImageIndex = 0;
			this.treeViewDisk.ImageList = this.imageList1;
			this.treeViewDisk.Location = new System.Drawing.Point(0, 0);
			this.treeViewDisk.Name = "treeViewDisk";
			this.treeViewDisk.SelectedImageIndex = 0;
			this.treeViewDisk.Size = new System.Drawing.Size(421, 395);
			this.treeViewDisk.TabIndex = 0;
			this.treeViewDisk.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeViewDisk_MouseUp);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.DefaultExt = "*.project.gmx";
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.Filter = "GM:S Project|*.project.gmx";
			this.openFileDialog1.SupportMultiDottedExtensions = true;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripOpenDir,
            this.deleteToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(176, 48);
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.panel3);
			this.panel4.Controls.Add(this.panel2);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(0, 66);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(853, 395);
			this.panel4.TabIndex = 5;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusOrphans});
			this.statusStrip1.Location = new System.Drawing.Point(0, 437);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(853, 24);
			this.statusStrip1.SizingGrip = false;
			this.statusStrip1.TabIndex = 6;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(55, 19);
			this.toolStripStatusLabel1.Text = "Oprhans:";
			// 
			// toolStripStatusOrphans
			// 
			this.toolStripStatusOrphans.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.toolStripStatusOrphans.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
			this.toolStripStatusOrphans.Name = "toolStripStatusOrphans";
			this.toolStripStatusOrphans.Size = new System.Drawing.Size(17, 19);
			this.toolStripStatusOrphans.Text = "0";
			this.toolStripStatusOrphans.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::StudioCleaner.Properties.Resources.icon48;
			this.pictureBox1.InitialImage = null;
			this.pictureBox1.Location = new System.Drawing.Point(793, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(48, 48);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			// 
			// butExpandAllDisk
			// 
			this.butExpandAllDisk.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.butExpandAllDisk.Image = global::StudioCleaner.Properties.Resources.folders_explorer;
			this.butExpandAllDisk.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.butExpandAllDisk.Location = new System.Drawing.Point(511, 41);
			this.butExpandAllDisk.Margin = new System.Windows.Forms.Padding(0);
			this.butExpandAllDisk.Name = "butExpandAllDisk";
			this.butExpandAllDisk.Size = new System.Drawing.Size(79, 24);
			this.butExpandAllDisk.TabIndex = 5;
			this.butExpandAllDisk.Text = "Expand All";
			this.butExpandAllDisk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.butExpandAllDisk.UseVisualStyleBackColor = true;
			this.butExpandAllDisk.Click += new System.EventHandler(this.butExpandAllDisk_Click);
			// 
			// butExpandAllGMX
			// 
			this.butExpandAllGMX.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.butExpandAllGMX.Image = global::StudioCleaner.Properties.Resources.folders_explorer;
			this.butExpandAllGMX.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.butExpandAllGMX.Location = new System.Drawing.Point(96, 41);
			this.butExpandAllGMX.Margin = new System.Windows.Forms.Padding(0);
			this.butExpandAllGMX.Name = "butExpandAllGMX";
			this.butExpandAllGMX.Size = new System.Drawing.Size(79, 24);
			this.butExpandAllGMX.TabIndex = 4;
			this.butExpandAllGMX.Text = "Expand All";
			this.butExpandAllGMX.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.butExpandAllGMX.UseVisualStyleBackColor = true;
			this.butExpandAllGMX.Click += new System.EventHandler(this.butExpandAllGMX_Click);
			// 
			// btnClearAll
			// 
			this.btnClearAll.Enabled = false;
			this.btnClearAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btnClearAll.Image = global::StudioCleaner.Properties.Resources.bin;
			this.btnClearAll.Location = new System.Drawing.Point(131, 3);
			this.btnClearAll.Name = "btnClearAll";
			this.btnClearAll.Size = new System.Drawing.Size(112, 38);
			this.btnClearAll.TabIndex = 1;
			this.btnClearAll.Text = "Remove all orphans";
			this.btnClearAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnClearAll.UseVisualStyleBackColor = true;
			this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
			// 
			// btnOpen
			// 
			this.btnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btnOpen.Image = global::StudioCleaner.Properties.Resources.folder;
			this.btnOpen.Location = new System.Drawing.Point(12, 3);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(113, 38);
			this.btnOpen.TabIndex = 0;
			this.btnOpen.Text = "Open GMX Project...";
			this.btnOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// toolStripOpenDir
			// 
			this.toolStripOpenDir.Image = global::StudioCleaner.Properties.Resources.folder_go;
			this.toolStripOpenDir.Name = "toolStripOpenDir";
			this.toolStripOpenDir.Size = new System.Drawing.Size(175, 22);
			this.toolStripOpenDir.Text = "Open in directory...";
			this.toolStripOpenDir.Click += new System.EventHandler(this.toolStripOpenDir_Click);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Image = global::StudioCleaner.Properties.Resources.delete;
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(853, 461);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "GMX cleaner (C) 2012 by gnysek";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.contextMenuStrip1.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView treeViewGMX;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnClearAll;
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TreeView treeViewDisk;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem toolStripOpenDir;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button butExpandAllGMX;
		private System.Windows.Forms.Button butExpandAllDisk;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusOrphans;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}

