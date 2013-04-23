using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StudioCleaner
{
	public partial class GmxEditor : UserControl
	{
		public List<string> lines = new List<string>();

		public GmxEditor()
		{
			InitializeComponent();
		}

		private void GmxEditor_Paint(object sender, PaintEventArgs e)
		{
			ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Red, ButtonBorderStyle.Solid);
		}
	}
}
