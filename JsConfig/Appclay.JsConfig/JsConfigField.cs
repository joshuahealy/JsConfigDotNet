using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appclay.JsConfig
{
	public class JsConfigField
	{
		public string Name { get; set; }
		public string Value { get; set; }
		public bool IsString { get; set; }

		public string NameJsString
		{
			get
			{
				return ConvertToJsString(Name);
			}
		}

		public string ValueJsString
		{
			get
			{ 
				return IsString ? ConvertToJsString(Value) : Value;
			}
		}

		private string ConvertToJsString(string str)
		{ 
			return str
				.Replace("\\", "\\\\")
				.Replace("\n", "\\\n")
				.Replace("\r", "\\\r")
				.Replace("\t", "\\\t")
				.Replace("'", "\\'");
		}
	}
}
