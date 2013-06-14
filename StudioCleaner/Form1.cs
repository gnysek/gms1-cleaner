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
using System.Xml.Linq;

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
		List<string> usedObjects = new List<string>();

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

				clearTrees();

				string PName = Path.GetFileNameWithoutExtension(Path.GetFileNameWithoutExtension(openFileDialog1.FileName));
				treeViewGMX.Nodes.Add(PName);
				treeViewDisk.Nodes.Add(PName);
				readGMX(openFileDialog1.FileName);

				treeViewDisk.ExpandAll();
				toolStripStatusOrphans.Text = orphans.ToString();

				btnClearAll.Enabled = (orphans > 0) ? true : false;
				btnUnusedAll.Enabled = true;
				btnUnusedPNG.Enabled = true;
				btnUnusedSprites.Enabled = true;

				foreach (PropertyForm p in this.MdiChildren)
				{
					p.Dispose();
				}

				checkZeroOprhans();
			}
		}

		private void clearTrees()
		{
			treeViewGMX.Nodes.Clear();
			treeViewDisk.Nodes.Clear();
		}

		private void checkZeroOprhans()
		{
			if (orphans == 0)
			{
				//MessageBox.Show("Looks like this project is free of orphans! Project will be closed!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				//clearTrees();
				MessageBox.Show("Looks like this project is free of orphans!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				btnClearAll.Enabled = false;
			}
		}

		private void readGMX(string filename)
		{
			XMLfile = new XmlDocument();
			XMLfile.Load(filename);

			//list of GM resource types
			string[] resTree = new string[] { "sprites", "sounds", "backgrounds", "scripts", "paths", "fonts", "timelines", "objects", "rooms" };

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

				TreeNode mmain = new TreeNode(fup(nodeElementsName));
				mmain.Name = fup(nodeElementsName);

				//TreeNode main = treeViewGMX.Nodes.Add(fup(nodeElementsName), fup(nodeElementsName));

				readSubNode(root, nodeName, nodeElementsName, mmain);

				if (mmain.Nodes.Count > 0) treeViewGMX.Nodes.Add(mmain);
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

					string[] extensions = { "*.gmx", "*.gml" };

					foreach (string ext in extensions)
					{
						foreach (string f in Directory.GetFiles(p, ext))
						{
							string resName = Path.GetFileNameWithoutExtension(Path.GetFileNameWithoutExtension(f));

							if (ext == extensions[1])
							{
								resName = Path.GetFileName(f);
							}

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
					sub.ContextMenuStrip = contextMenuStrip2;
					sub.Tag = (nodeName == "scripts") ? n.InnerText /*+ ".gml"*/ : n.InnerText + "." + n.Name + ".gmx";
				}
			}
		}

		private void treeViewDisk_MouseUp(object sender, MouseEventArgs e)
		{
			treeViewMouseUp(sender, e, treeViewDisk);
		}

		private void treeViewGMX_MouseUp(object sender, MouseEventArgs e)
		{
			treeViewMouseUp(sender, e, treeViewGMX);
		}

		private void treeViewMouseUp(object sender, MouseEventArgs e, TreeView t)
		{
			if (e.Button == MouseButtons.Right)
			{
				Point pt = new Point(e.X, e.Y);
				t.PointToClient(pt);

				TreeNode Node = t.GetNodeAt(pt);
				if (Node != null)
				{
					if (Node.Bounds.Contains(pt))
					{
						t.SelectedNode = Node;
					}
				}
			}
		}

		private void toolStripOpenDir_Click(object sender, EventArgs e)
		{
			string filePath = @treeViewDisk.SelectedNode.Tag.ToString();
			openResourceInExplorer(filePath);
		}

		private void openResourceInExplorer(string filePath)
		{
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

			toolStripStatusOrphans.Text = orphans.ToString();

			clearAllOprhansOnStack();

			checkZeroOprhans();
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
					+ ((subFileNames.Count > 10) ? ("\n...\nand " + (subFileNames.Count - 10).ToString() + " more") : ""),
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

		private string getTreeViewGMXSelectedNodePath()
		{
			return GMXfilename.Replace(Path.GetFileName(GMXfilename), "") + treeViewGMX.SelectedNode.Tag.ToString();
		}

		private string getTreeViewGMXSelectedNodePath(string resName)
		{
			return GMXfilename.Replace(Path.GetFileName(GMXfilename), "") + resName;
		}

		private void toolStripOpenXML_Click(object sender, EventArgs e)
		{
			string filePath = getTreeViewGMXSelectedNodePath();
			string tag = Path.GetFileNameWithoutExtension(filePath);

			createPropWindow(filePath, tag);
		}

		private PropertyForm createPropWindow(string filename, string tag)
		{
			if (this.MdiChildren.Length > 0)
			{
				foreach (PropertyForm p in this.MdiChildren)
				{
					if (p.Tag.ToString() == tag)
					{
						p.BringToFront();
						return p;
					}
				}
			}

			//PropertyForm f = new PropertyForm();
			//f.TopLevel = false;
			//f.Tag = tag;
			////f.StartPosition = FormStartPosition.Manual;
			////f.Dock = DockStyle.Fill;
			//f.MdiParent = this;
			////panelCodeEditor.Controls.Add(f);
			//f.BringToFront();

			PropertyForm f = new PropertyForm();
			f.MdiParent = this;
			f.Tag = tag;
			f.Dock = DockStyle.Fill;

			TabPage t = new TabPage() { Text = tag + "          ", Name = tag, Tag = filename };
			t.Controls.Add(f);
			tabControl1.TabPages.Add(t);
			f.Show();
			tabControl1.SelectTab(tag);


			if (filename != "") {
				f.richXML.LoadFile(filename, RichTextBoxStreamType.PlainText);
				HighlightColors.HighlightRTF(f.richXML);
			}
			
			//this.LayoutMdi(MdiLayout.Cascade);
			//int pos = ((panelCodeEditor.Controls.Count - 1) * 30) % (panelCodeEditor.Width - f.Width) + 1;
			//f.Location = new Point(pos, pos);
			f.Text = tag;
			f.Show();

			return f;
		}

		private void treeViewGMX_DoubleClick(object sender, EventArgs e)
		{
			if (treeViewGMX.SelectedNode == null) return;
			if (treeViewGMX.SelectedNode.Nodes.Count > 0) return;

			toolStripOpenXML_Click(sender, e);
		}

		private void openInExplorerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			openResourceInExplorer(getTreeViewGMXSelectedNodePath());
		}

		private void btnUnusedAll_Click(object sender, EventArgs e)
		{
			findUnusedByType("Objects");
		}


		private void btnUnusedSprites_Click(object sender, EventArgs e)
		{
			findUnusedByType("Sprites");
		}

		private void findUnusedByType(string searchType)
		{

			usedObjects.Clear();

			List<string> allObjects = new List<string>();

			btnUnusedAll.Enabled = false;

			PropertyForm p = createPropWindow("", "unused" + searchType);
			RichTextBox richXML = p.richXML;
			richXML.Clear();
			p.Text = "Unused " + searchType;

			try
			{
				TreeNode to = treeViewGMX.Nodes.Find(searchType, true).First();
				allObjects = findChildItems(to);

				// first find in rooms - it's easier
				// since there is creation code for rooms... it's not best way :(
				/*TreeNode t = treeViewGMX.Nodes.Find("Rooms", true).First();
				foreach (TreeNode node in t.Nodes)
				{
					if (node.Nodes.Count == 0)
					{
						findAllObjectsInRoom(getTreeViewGMXSelectedNodePath(node.Tag.ToString()));
					}
				}*/

				int cnt = 0;

				string[] nodesToSearch = new string[] { "Scripts", "Objects", "Rooms" };

				progressTotal.Maximum = nodesToSearch.Count();
				progressTotal.Value = 0;
				progressTotal.Visible = true;
				this.Refresh();

				foreach (string nodeName in nodesToSearch)
				{
					// now search in scripts, obj, rooms
					try
					{
						TreeNode sc = treeViewGMX.Nodes.Find(nodeName, true).First();
						findObjectInObjects(sc, allObjects);

						// remove those found
						foreach (string obj in usedObjects)
						{
							allObjects.Remove(obj);
						}
					}
					catch (Exception error)
					{
						richXML.AppendText("Nothing found under " + nodeName + " (Error: " + error.Message + ")\n");
						cnt++;
					}

					progressTotal.Value++;
					this.Refresh();
				}

				// reports

				richXML.AppendText("Those " + searchType + " are found inside rooms & objects & scripts:\r\n");
				cnt++;

				foreach (string obj in usedObjects)
				{
					richXML.AppendText(obj + "\r\n");
					richXML.Select(richXML.GetFirstCharIndexFromLine(cnt), richXML.Lines[cnt].Length);
					richXML.SelectionColor = Color.Green;
					cnt++;
				}

				if (allObjects.Count > 0)
				{
					richXML.AppendText("Those " + searchType + " are NOT found inside rooms & objects:\r\n");

					cnt++;

					foreach (string obj in allObjects)
					{
						richXML.AppendText(obj + "\r\n");
						richXML.Select(richXML.GetFirstCharIndexFromLine(cnt), richXML.Lines[cnt].Length);
						richXML.SelectionColor = Color.Red;
						cnt++;
					}
				}

				progressTotal.Visible = false;
			}
			catch (Exception ex)
			{
				richXML.AppendText("Error: " + ex.Message);
			}

			btnUnusedAll.Enabled = true;
		}

		private void findObjectInObjects(TreeNode t, List<string> search)
		{
			if (t == null) return;

			foreach (TreeNode node in t.Nodes)
			{
				if (node.Nodes.Count == 0)
				{
					string filename = getTreeViewGMXSelectedNodePath(node.Tag.ToString());
					System.IO.StreamReader file = new System.IO.StreamReader(filename);
					string line;
					int counter = 0;
					while ((line = file.ReadLine()) != null)
					{
						foreach (string word in search)
						{
							if (line.Contains(word))
							{
								if (usedObjects.IndexOf(word) == -1)
									usedObjects.Add(word);
							}
						}
						counter++;
					}
					file.Close();
				}
				else
				{
					findObjectInObjects(node, search);
				}
			}
		}

		private List<string> findChildItems(TreeNode t)
		{
			return findChildItems(t, new List<string>());
		}

		private List<string> findChildItems(TreeNode t, List<string> skip)
		{
			List<string> list = new List<string>();

			foreach (TreeNode node in t.Nodes)
			{
				if (node.Nodes.Count == 0)
				{
					if (skip.IndexOf(node.Text) == -1)
						list.Add(node.Text);
				}
				else
				{
					list.AddRange(findChildItems(node, skip));
				}
			}

			return list;
		}

		private void btnUnusedPNG_Click(object sender, EventArgs e)
		{
			PropertyForm p = createPropWindow("", "unusedPNG");
			RichTextBox richXML = p.richXML;
			richXML.Clear();
			p.Text = "Orphan PNGs on disk";
			
			btnUnusedPNG.Enabled = false;

			List<string> allObjects = new List<string>();
			List<string> usedSprites = new List<string>();

			try
			{
				TreeNode to = treeViewGMX.Nodes.Find("Sprites", true).First();
				//allObjects = findChildItems(to);
				allObjects = getXmlResourcePaths(to);

				//richXML.AppendText(String.Join("\n", allObjects));
				foreach (string filename in allObjects)
				{
					XMLfile = new XmlDocument();
					XMLfile.Load(filename);

					XmlNode root;
					root = XMLfile.SelectSingleNode("sprite/frames");

					if (root == null) continue;
					foreach (XmlNode frame in root)
					{
						//richXML.AppendText(Path.GetFileName(frame.InnerText) + "\n");
						usedSprites.Add(Path.GetFileName(frame.InnerText));
					}
				}

				foreach (string filename in Directory.GetFiles(GMXfilename.Replace(Path.GetFileName(GMXfilename), "") + "\\sprites\\images", "*.*"))
				{
					if (usedSprites.IndexOf(Path.GetFileName(filename)) == -1)
					{
						richXML.AppendText(Path.GetFileName(filename) + "\n");
					}
				}
			}
			catch (Exception error)
			{
				richXML.AppendText(error.Message);
			}

			btnUnusedPNG.Enabled = true;
		}

		public List<string> getXmlResourcePaths(TreeNode search)
		{
			List<string> tmp = new List<string>();

			if (search == null) return tmp;

			foreach (TreeNode node in search.Nodes)
			{
				if (node.Nodes.Count == 0)
				{
					tmp.Add(getTreeViewGMXSelectedNodePath(node.Tag.ToString()));
				}
				else
				{
					tmp.AddRange(getXmlResourcePaths(node));
				}
			}

			return tmp;
		}

		private void Form1_Shown(object sender, EventArgs e)
		{
			this.Text = this.Text + " / v. " + Application.ProductVersion;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			PropertyForm f = new PropertyForm();
			f.MdiParent = this;
			TabPage t = new TabPage(){ Text = "Test"};
			t.Controls.Add(f);
			f.Dock = DockStyle.Fill;
			tabControl1.TabPages.Add(t);
			f.Show();
		}

		private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
		{
			//This code will render a "x" mark at the end of the Tab caption.
			e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - 15, e.Bounds.Top + 4);
			e.Graphics.DrawString(this.tabControl1.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 5, e.Bounds.Top + 4);
			e.DrawFocusRectangle();
		}

		private void tabControl1_MouseDown(object sender, MouseEventArgs e)
		{
			//Looping through the controls.
			for (int i = 0; i < this.tabControl1.TabPages.Count; i++)
			{
				Rectangle r = tabControl1.GetTabRect(i);
				//Getting the position of the "x" mark.
				Rectangle closeButton = new Rectangle(r.Right - 15, r.Top + 4, 9, 7);
				if (closeButton.Contains(e.Location))
				{
					if (MessageBox.Show("Would you like to Close this Tab?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						this.tabControl1.TabPages.RemoveAt(i);
						break;
					}
				}
			}
		}

		//private void findAllObjectsInRoom(string roomFilename)
		//{
		//    XMLfile = new XmlDocument();
		//    XMLfile.Load(roomFilename);

		//    XmlNode root;
		//    root = XMLfile.SelectSingleNode("room/instances");

		//    if (root == null) return;

		//    List<string> objNames = new List<string>();

		//    foreach (XmlNode instance in root)
		//    {
		//        if (instance.Attributes["objName"] != null)
		//        {
		//            if (usedObjects.IndexOf(instance.Attributes["objName"].Value) == -1)
		//            {
		//                usedObjects.Add(instance.Attributes["objName"].Value);
		//            }
		//        }
		//    }
		//}
	}
}
