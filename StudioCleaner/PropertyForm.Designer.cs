namespace StudioCleaner
{
	partial class PropertyForm
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
			this.richXML = new System.Windows.Forms.RichTextBox();
			this.gmxEditor1 = new StudioCleaner.GmxEditor();
			this.SuspendLayout();
			// 
			// richXML
			// 
			this.richXML.BackColor = System.Drawing.Color.White;
			this.richXML.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.richXML.DetectUrls = false;
			this.richXML.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richXML.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.richXML.Location = new System.Drawing.Point(0, 0);
			this.richXML.Name = "richXML";
			this.richXML.ReadOnly = true;
			this.richXML.Size = new System.Drawing.Size(347, 207);
			this.richXML.TabIndex = 2;
			this.richXML.Text = "";
			this.richXML.WordWrap = false;
			this.richXML.Enter += new System.EventHandler(this.richXML_Enter);
			// 
			// gmxEditor1
			// 
			this.gmxEditor1.Location = new System.Drawing.Point(292, 12);
			this.gmxEditor1.Name = "gmxEditor1";
			this.gmxEditor1.Size = new System.Drawing.Size(43, 42);
			this.gmxEditor1.TabIndex = 1;
			this.gmxEditor1.Visible = false;
			// 
			// PropertyForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(347, 207);
			this.Controls.Add(this.gmxEditor1);
			this.Controls.Add(this.richXML);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PropertyForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "PropertyForm";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.ResumeLayout(false);

		}

		#endregion

		private GmxEditor gmxEditor1;
		public System.Windows.Forms.RichTextBox richXML;
	}
}