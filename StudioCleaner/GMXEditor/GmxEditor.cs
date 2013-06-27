using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace GMXEditor
{
	public partial class GmxEditor : UserControl, ISupportInitialize
	{
		public List<string> lines = new List<string>();
		public bool ShowLineNumbers = true;
		public float lineInterval = 1;

		public GmxEditor()
		{

		}

		void ISupportInitialize.BeginInit()
		{
			//
		}

		void ISupportInitialize.EndInit()
		{
			//OnTextChanged();
			//Selection.Start = Place.Empty;
			//DoCaretVisible();
			//IsChanged = false;
			//ClearUndo();
		}

		/// <summary>
		/// Draw control
		/// </summary>
		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			int LeftIndent = 0;
			int minLeftIndent = 0;
			int iLine;
			SizeF size = GetCharSize(Font, 'M');
			float charHeight = size.Height + lineInterval;

			for (iLine = 0; iLine < 5; iLine++)
			{
				float y = iLine * charHeight;
				// draw line number
				if (ShowLineNumbers)
				{
					using (var lineNumberBrush = new SolidBrush(Color.Red))
						e.Graphics.DrawString((iLine + 0).ToString(), Font, lineNumberBrush,
											  //new RectangleF(-10, y, LeftIndent - minLeftIndent - 2 + 10, 8),
											  new RectangleF(0, y, 30, charHeight),
											  new StringFormat(StringFormatFlags.DirectionRightToLeft));
				}

			}

			base.OnPaint(e);
		}

		public static SizeF GetCharSize(Font font, char c)
		{
			Size sz2 = TextRenderer.MeasureText("<" + c.ToString() + ">", font);
			Size sz3 = TextRenderer.MeasureText("<>", font);

			return new SizeF(sz2.Width - sz3.Width + 1, /*sz2.Height*/font.Height);
		}
	}
}
