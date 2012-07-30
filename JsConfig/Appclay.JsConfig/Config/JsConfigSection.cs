using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Appclay.JsConfig.Config
{
	public class JsConfigSection : ConfigurationSection
	{
		[ConfigurationProperty("varName", DefaultValue="jsConfig", IsRequired=false)]
		public string VarName
		{
			get 
			{
				return (string)this["varName"];
			}
			set
			{
				this["varName"] = value;
			}
		}

		[ConfigurationProperty("fields", IsDefaultCollection = false)]
		[ConfigurationCollection(typeof(JsConfigFieldCollection), AddItemName = "add", ClearItemsName = "clear", RemoveItemName = "remove")]
		public JsConfigFieldCollection Fields
		{
			get
			{
				JsConfigFieldCollection collection = (JsConfigFieldCollection)base["fields"];
				return collection;
			}
		}
		
	}

	

	
	
}
