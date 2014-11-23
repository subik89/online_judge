using System;

namespace Online_Judge.BLL.Attributes
{
	/// <summary>
	/// StringValueAttribute class
	/// </summary>
	public class StringValueAttribute : Attribute
	{
		public string Attribute;

		public StringValueAttribute(string attribute)
		{
			Attribute = attribute;
		}
	}
}
