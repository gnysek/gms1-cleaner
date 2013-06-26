using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;

namespace StudioCleaner
{
	public partial class UnusedList : DockContent
	{
		public List<KeyValuePair<string, string>> resourceList = new List<KeyValuePair<string,string>>();
		public UnusedList()
		{
			InitializeComponent();
			resourceChecboxList.Items.Clear();
		}

		public void addItem(string filename) {
			resourceChecboxList.Items.Add(Path.GetFileName(filename),true);
			resourceList.Add(new KeyValuePair<string, string>(Path.GetFileName(filename), filename));
		}
	}
}
