using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

/**
 * source: http://blogs.msdn.com/b/cobold/archive/2011/01/31/xml-highlight-in-richtextbox.aspx
 **/

namespace StudioCleaner
{
	public class HighlightColors
	{
		public static Color HC_NODE = Color.Blue;
		public static Color HC_STRING = Color.Goldenrod;
		public static Color HC_ATTRIBUTE = Color.Green;
		public static Color HC_COMMENT = Color.Gray;
		public static Color HC_INNERTEXT = Color.Black;

		public static RichTextBox HighlightRTF(RichTextBox rtb)
		{
			//foreach (string str in rtb.Lines)
			//{
			//    if (str.Contains("<"))
			//    {
			string str = rtb.Text;
			int k = 0;
			int st, en;
			int lasten = -1;
			while (k < str.Length)
			{
				st = str.IndexOf('<', k);

				if (st < 0)
					break;

				if (lasten > 0)
				{
					rtb.Select(lasten + 1, st - lasten - 1);
					rtb.SelectionColor = HighlightColors.HC_INNERTEXT;
				}

				en = str.IndexOf('>', st + 1);
				if (en < 0)
					break;

				k = en + 1;
				lasten = en;

				if (str[st + 1] == '!')
				{
					//rtb.Select(st + 1, en - st - 1);
					rtb.Select(st, en - st + 1);
					rtb.SelectionColor = HighlightColors.HC_COMMENT;
					continue;

				}
				String nodeText = str.Substring(st + 1, en - st - 1);

				bool inString = false;

				int lastSt = -1;
				int state = 0;
				/* 0 = before node name
				 * 1 = in node name
				   2 = after node name
				   3 = in attribute
				   4 = in string
				   */
				int startNodeName = 0, startAtt = 0;
				for (int i = 0; i < nodeText.Length; ++i)
				{
					if (nodeText[i] == '"')
						inString = !inString;

					if (inString && nodeText[i] == '"')
						lastSt = i;
					else
						if (nodeText[i] == '"')
						{
							//rtb.Select(lastSt + st + 2, i - lastSt - 1);
							rtb.Select(lastSt + st + 1, i - lastSt + 1);
							rtb.SelectionColor = HighlightColors.HC_STRING;
						}

					switch (state)
					{
						case 0:
							if (!Char.IsWhiteSpace(nodeText, i))
							{
								startNodeName = i;
								state = 1;
							}
							break;
						case 1:
							if (Char.IsWhiteSpace(nodeText, i))
							{
								rtb.Select(startNodeName + st, i - startNodeName + 1);
								//rtb.Select(startNodeName + st - 2, i - startNodeName + 1);
								rtb.SelectionColor = HighlightColors.HC_NODE;
								state = 2;
							}
							break;
						case 2:
							if (!Char.IsWhiteSpace(nodeText, i))
							{
								startAtt = i;
								state = 3;
							}
							break;

						case 3:
							if (Char.IsWhiteSpace(nodeText, i) || nodeText[i] == '=')
							{
								//rtb.Select(startAtt + st, i - startAtt + 1);
								rtb.Select(startAtt + st, i - startAtt + 2);
								rtb.SelectionColor = HighlightColors.HC_ATTRIBUTE;
								state = 4;
							}
							break;
						case 4:
							if (nodeText[i] == '"' && !inString)
								state = 2;
							break;


					}

				}
				if (state == 1)
				{
					rtb.Select(st + 1, nodeText.Length);
					//rtb.Select(st, nodeText.Length + 2);
					rtb.SelectionColor = HighlightColors.HC_NODE;
				}
			}

			rtb.Select(0,0);

			return rtb;
		}
		//    }
		//}
	}
}
