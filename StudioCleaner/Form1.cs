using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Globalization;

namespace StudioCleaner
{
	public partial class Form1 : Form
	{
		private string GMXfilename = "";
		XmlDocument XMLfile;
		int orphans = 0;
		List<string> subFileNames = new List<string>();
		List<string> subFilePaths = new List<string>();
		List<TreeNode> subFileNodes = new List<TreeNode>();

		public Form1()
		{
			InitializeComponent();
		}

		private string fup(string text)
		{
			return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);
		}

		private void btnOpen_Click(object sender, EventArgs e)
		{
			openFileDialog1.FileName = "";
			DialogResult result = openFileDialog1.ShowDialog();

			if (result == DialogResult.OK)
			{
				GMXfilename = openFileDialog1.FileName;
				orphans = 0;

				treeViewGMX.Nodes.Clear();
				treeViewDisk.Nodes.Clear();
				string PName = Path.GetFileNameWithoutExtension(Path.GetFileNameWithoutExtension(openFileDialog1.FileName));
				treeViewGMX.Nodes.Add(PName);
				treeViewDisk.Nodes.Add(PName);
				readGMX(openFileDialog1.FileName);

				treeViewDisk.ExpandAll();
				toolStripStatusOrphans.Text = orphans.ToString();

				btnClearAll.Enabled = (orphans > 0) ? true : false;

				if (orphans == 0)
				{
					MessageBox.Show("Looks that this project is free of orphans! Yay!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void readGMX(string filename)
		{
			XMLfile = new XmlDocument();
			XMLfile.Load(filename);

			//list of GM resource types
			string[] resTree = new string[] { "sprites", "sounds", "backgrounds", "paths", "fonts", "scripts", "objects", "rooms" };

			foreach (string resType in resTree)
			{
				readGMXnode(filename, resType);
			}

		}

		private void readGMXnode(string filename, string nodeName)
		{
			string nodeElementsName;
			XmlNode root;

			try
			{
				root = XMLfile.SelectSingleNode("assets/" + nodeName);

				if (root == null)
				{
					return;
				}

				nodeElementsName = root.Attributes["name"].InnerText;

				TreeNode main = treeViewGMX.Nodes.Add(fup(nodeElementsName));

				readSubNode(root, nodeName, nodeElementsName, main);
			}
			catch (Exception e)
			{
				MessageBox.Show(nodeName + ": " + e.Message);
			}

			// compare with directory
			try
			{
				string p;
				p = Path.GetDirectoryName(filename) + "\\" + nodeName;
				if (Directory.Exists(p))
				{
					TreeNode main = treeViewDisk.Nodes.Add(fup(nodeName));

					foreach (string f in Directory.GetFiles(p, "*.gmx"))
					{
						string resName = Path.GetFileNameWithoutExtension(Path.GetFileNameWithoutExtension(f));

						try
						{
							TreeNode selected = treeViewGMX.Nodes.Find(nodeName + "\\" + resName, true)[0];
						}
						catch
						{
							TreeNode current = main.Nodes.Add(Path.GetFileName(f), Path.GetFileName(f));
							current.ForeColor = Color.Red;
							current.ContextMenuStrip = contextMenuStrip1;
							current.Tag = f;
							current.ImageIndex = current.SelectedImageIndex = 1;
							orphans++;
						}
					}

					if (main.Nodes.Count < 1)
					{
						main.Remove();
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void readSubNode(XmlNode node, string nodeName, string nodeElementsName, TreeNode main)
		{
			foreach (XmlNode n in node)
			{
				if (n.Attributes["name"] != null)
				{
					TreeNode sub = main.Nodes.Add(n.Attributes["name"].InnerText);
					readSubNode(n, nodeName, nodeElementsName, sub);
				}
				else
				{
					TreeNode sub = main.Nodes.Add(n.InnerText, Path.GetFileName(n.InnerText));
					sub.ImageIndex = sub.SelectedImageIndex = 1;
				}
			}
		}

		private void treeViewDisk_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				Point pt = new Point(e.X, e.Y);
				treeViewDisk.PointToClient(pt);

				TreeNode Node = treeViewDisk.GetNodeAt(pt);
				if (Node != null)
				{
					if (Node.Bounds.Contains(pt))
					{
						treeViewDisk.SelectedNode = Node;
					}
				}
			}
		}

		private void toolStripOpenDir_Click(object sender, EventArgs e)
		{
			string filePath = @treeViewDisk.SelectedNode.Tag.ToString();
			if (!File.Exists(filePath))
			{
				return;
			}

			System.Diagnostics.Process.Start("explorer.exe", @"/select, " + filePath);
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			clearAllOprhansOnStack();

			checkForSubOrphanFiles(treeViewDisk.SelectedNode);

			if (!askAboutClearing(1)) return;

			deleteAllOprhansOnStack();
		}

		private void deleteAllOprhansOnStack()
		{
			// remove subfiles
			foreach (string f in subFilePaths)
			{
				File.Delete(f);
			}

			foreach (TreeNode t in subFileNodes)
			{
				File.Delete(t.Tag.ToString());

				TreeNode parent = t.Parent;
				t.Remove();
				if (parent.Nodes.Count == 0) parent.Remove();
				
				orphans--;
			}

			if (orphans == 0)
			{
				btnClearAll.Enabled = false;
			}

			toolStripStatusOrphans.Text = orphans.ToString();

			clearAllOprhansOnStack();
		}

		private void clearAllOprhansOnStack()
		{
			subFileNames.Clear();
			subFilePaths.Clear();
			subFileNodes.Clear();
		}

		private void butExpandAllGMX_Click(object sender, EventArgs e)
		{
			treeViewGMX.ExpandAll();
		}

		private void butExpandAllDisk_Click(object sender, EventArgs e)
		{
			treeViewDisk.ExpandAll();
		}

		/// <summary>
		/// Clear all oprhan files
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnClearAll_Click(object sender, EventArgs e)
		{
			if (orphans == 0)
			{
				MessageBox.Show(
					"No orphan files found",
					Application.ProductName,
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);
				return;
			}

			clearAllOprhansOnStack();

			foreach (TreeNode t in treeViewDisk.Nodes)
			{
				if (t.Nodes.Count > 0)
				{
					checkWholeTreeForCleaning(t);
				}
			}

			if (!askAboutClearing(orphans)) return;

			deleteAllOprhansOnStack();
		}

		private bool askAboutClearing(int howMany)
		{
			if (subFileNames.Count > 0)
			{
				if (DialogResult.No == MessageBox.Show(
					"Removing those " + howMany.ToString() + " orphan(s) will also remove those files, are you sure?\n\n"
					+ string.Join("\n", subFileNames.ToArray(), 0, Math.Min(subFileNames.Count, 10))
					+ ((subFileNames.Count > 10) ? ("\n...\nand " + (subFileNames.Count-10).ToString() + " more")  : ""),
					"Confirm",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question
				))
				{
					return false;
				}
			}
			else
			{
				if (DialogResult.No == MessageBox.Show(
					"This will delete " + howMany.ToString() + " oprhan(s). Are you sure? This operation will be permament!",
					"Confirm",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question
				))
				{
					return false;
				}
			}

			return true;
		}

		private void checkWholeTreeForCleaning(TreeNode parent)
		{
			foreach (TreeNode t in parent.Nodes)
			{
				checkForSubOrphanFiles(t);
			}
		}

		/// <summary>
		/// Checks that any other file than GMX also needs to be removed
		/// </summary>
		/// <param name="t"></param>
		private void checkForSubOrphanFiles(TreeNode t)
		{
			string filename = t.Tag.ToString();
			if (!File.Exists(filename))
			{
				MessageBox.Show("File not found, skipped...\n" + filename, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			checkForSubOrphanFilesByFilter(filename, ".sprite.gmx", "images", "_*");
			checkForSubOrphanFilesByFilter(filename, ".background.gmx");
			checkForSubOrphanFilesByFilter(filename, ".sound.gmx", "audio");

			subFileNodes.Add(t);
		}

		/// <summary>
		/// Checks for any files with same name like filename when filename contains proper filter, in subfolder, with additional sufix
		/// </summary>
		/// <param name="filename">current file filename</param>
		/// <param name="filter">file extension filter</param>
		/// <param name="subfolder">subfolder to search, default as images</param>
		/// <param name="suffix">suffix added to filename without extension, default as *</param>
		/// <returns></returns>
		private bool checkForSubOrphanFilesByFilter(string filename, string filter, string subfolder = "images", string suffix = "*")
		{
			bool found = false;
			if (filename.IndexOf(filter) > 0)
			{
				string dir = Path.GetDirectoryName(filename) + "\\" + subfolder + "\\";

				foreach (string f in Directory.GetFiles(dir, Path.GetFileNameWithoutExtension(Path.GetFileNameWithoutExtension(filename)) + suffix))
				{
					subFileNames.Add(Path.GetFileName(f));
					subFilePaths.Add(f);
					found = true;
				}
			}

			return found;
		}
	}
}
