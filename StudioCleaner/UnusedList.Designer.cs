namespace StudioCleaner
{
	partial class UnusedList
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
			this.resourceChecboxList = new System.Windows.Forms.CheckedListBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.btnDeleteRes = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// resourceChecboxList
			// 
			this.resourceChecboxList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.resourceChecboxList.FormattingEnabled = true;
			this.resourceChecboxList.Location = new System.Drawing.Point(0, 0);
			this.resourceChecboxList.Name = "resourceChecboxList";
			this.resourceChecboxList.Size = new System.Drawing.Size(396, 379);
			this.resourceChecboxList.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.resourceChecboxList);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(396, 379);
			this.panel1.TabIndex = 2;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Controls.Add(this.button3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 379);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(396, 55);
			this.panel2.TabIndex = 3;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(105, 16);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// btnDeleteRes
			// 
			this.btnDeleteRes.Location = new System.Drawing.Point(24, 16);
			this.btnDeleteRes.Name = "btnDeleteRes";
			this.btnDeleteRes.Size = new System.Drawing.Size(75, 23);
			this.btnDeleteRes.TabIndex = 1;
			this.btnDeleteRes.Text = "button2";
			this.btnDeleteRes.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(12, 16);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 2;
			this.button3.Text = "button3";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.btnDeleteRes);
			this.panel3.Controls.Add(this.button1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel3.Location = new System.Drawing.Point(204, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(192, 55);
			this.panel3.TabIndex = 3;
			// 
			// UnusedList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(396, 434);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.Name = "UnusedList";
			this.Text = "UnusedList";
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button btnDeleteRes;
		private System.Windows.Forms.Button button1;
		public System.Windows.Forms.CheckedListBox resourceChecboxList;
		private System.Windows.Forms.Panel panel3;

	}
}