using System;

namespace Online_Judge.Core.Attributes
{
	/// <summary>
	/// StringValueAttribute class
	/// </summary>
	public class StringValueAttribute : Attribute
	{
		public string Value;

		public StringValueAttribute(string value)
		{
			Value = value;
		}
	}
}
