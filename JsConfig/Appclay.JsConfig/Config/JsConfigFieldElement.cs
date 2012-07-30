using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Appclay.JsConfig.Config
{
	public class JsConfigFieldElement : ConfigurationElement
	{
		[ConfigurationProperty("name", IsRequired = true, IsKey = true)]
		public string Name
		{
			get
			{
				return (string)this["name"];
			}
			set
			{
				this["name"] = value;
			}
		}

		[ConfigurationProperty("value", IsRequired = false)]
		public string Value
		{
			get
			{
				return (string)this["value"];
			}
			set
			{
				this["value"] = value;
			}
		}

		[ConfigurationProperty("appSettingKey", IsRequired = false)]
		public string AppSettingKey
		{
			get
			{
				return (string)this["appSettingKey"];
			}
			set
			{
				this["appSettingKey"] = value;
			}
		}

		[ConfigurationProperty("isString", DefaultValue = true, IsRequired = false)]
		public bool IsString
		{
			get
			{
				return (bool)this["isString"];
			}
			set
			{
				this["isString"] = value;
			}
		}
	}
}
