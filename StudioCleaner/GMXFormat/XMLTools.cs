using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.ComponentModel;

namespace StudioCleaner.GMXFormat
{
	public enum XmlErrorTypes
	{
		NoError,
		TagNotFound,
		ValueParseError,
		InvalidXml
	}

	public class XmlParseErrorOccurredEventArgs : EventArgs
	{
		public XmlParseErrorOccurredEventArgs(XElement aParentElement, XmlErrorTypes aErrorType, string aInformation)
		{
			Parent = aParentElement;
			ErrorType = aErrorType;
			Information = aInformation;
		}

		public readonly XElement Parent;
		public readonly XmlErrorTypes ErrorType;
		public readonly string Information;
		public bool Abort = false;
	}

	public class OnProcessAbortedArgs : EventArgs
	{
	}

	public class XMLTools
	{
		#region events

		public event System.EventHandler<XmlParseErrorOccurredEventArgs> XmlParseErrorOccurred;
		protected bool OnXmlParseErrorOccurred(XElement aParentElement, XmlErrorTypes aErrorType, string aInformation)
		{
			if (XmlParseErrorOccurred != null)
			{
				var args = new XmlParseErrorOccurredEventArgs(aParentElement, aErrorType, aInformation);
				XmlParseErrorOccurred(this, args);

				return args.Abort;
			}

			return false;
		}

		#endregion

		protected XElement GetElement(XElement aParent, XName aName)
		{
			var element = aParent.Element(aName);

			if (element == null)
			{
				if (OnXmlParseErrorOccurred(aParent, XmlErrorTypes.TagNotFound, aName.LocalName))
					throw new Exception("GMXMLT: Processing aborted on empty XElement.");//Exceptions.ProcessingAborted();
			}

			return element;
		}

		protected T GetElementValue<T>(XElement attrParent, XName attrName) where T : struct
		{
			var element = GetElement(attrParent, attrName);

			if (element != null)
			{
				try
				{
					if (typeof(T).IsEnum)
						return (T)Enum.Parse(typeof(T), element.Value, true);
					else
						return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(element.Value);
				}
				catch
				{
					if (OnXmlParseErrorOccurred(element, XmlErrorTypes.ValueParseError, element.Value))
						throw new Exception("GMXMLT: Processing aborted on parsing Value.");
				}
			}

			return default(T);
		}
	}
}
