using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace StudioCleaner
{
	public partial class PropertyForm : DockContent
	{
		public PropertyForm()
		{
			InitializeComponent();
		}

		private void richXML_Enter(object sender, EventArgs e)
		{
			this.BringToFront();
		}
	}
}
