using System;
using System.Linq;
using Online_Judge.Core.Attributes;

namespace Online_Judge.Core.Extensions
{
	/// <summary>
	/// EnumExtensions class
	/// </summary>
	public static class EnumExtensions
	{
		public static string GetString(this Enum value)
		{
			return value.GetValueAttributeValue<StringValueAttribute>();
		}

		public static string GetValueAttributeValue<T>(this Enum value) where T : StringValueAttribute
		{
			string valueString;

			var attr = value.GetAttributeOrDefault<T>(out valueString);

			return attr != null ? attr.Value : valueString;
		}

		private static T GetAttributeOrDefault<T>(this Enum value, out string valueString) where T : Attribute
		{
			valueString = value.ToString();
			var fieldInfo = value.GetType().GetField(valueString);

			return fieldInfo == null
					   ? null
					   : ((T[])fieldInfo.GetCustomAttributes(typeof(T), false))
							 .FirstOrDefault(x => x.GetType() == typeof(T));
		}
	}
}
