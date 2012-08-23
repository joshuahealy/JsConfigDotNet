using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Appclay.JsConfig.Config;

namespace Appclay.JsConfig
{
	public static class JsConfig
	{
		private const string DefaultVarName = "jsConfig";

		static JsConfig() 
		{
			Items = new List<JsConfigField>();
			VarName = DefaultVarName;
			LoadJsConfig();
		}

		private static bool _invalidated = true;
		private static string _varJavascript;

		public static List<JsConfigField> Items { get; private set; }
		public static string VarName { get; set; }
		
		public static string VarJavascript
		{
			get
			{
				if (_invalidated)
				{
					_varJavascript = GenerateVarJavascript();
					_invalidated = false;
				}
				return _varJavascript;
			}
		}
	
		private static void LoadJsConfig()
		{
			try
			{
				var jsConfigSection = ConfigurationManager.GetSection("jsConfig") as JsConfigSection;

				if (jsConfigSection == null)
				{
					Console.WriteLine("Unable to load JsConfig configuration section");
				}
				else
				{
					VarName = jsConfigSection.VarName;
					foreach (JsConfigFieldElement fieldElement in jsConfigSection.Fields)
					{
						string value = String.IsNullOrWhiteSpace(fieldElement.AppSettingKey) ?
							fieldElement.Value :
							ConfigurationManager.AppSettings[fieldElement.AppSettingKey];
						var field = new JsConfigField
						{
							Name = fieldElement.Name,
							Value = value,
							IsString = fieldElement.IsString
						};
						Items.Add(field);
					}
				}

			}
			catch (ConfigurationErrorsException ex)
			{
				throw new Exception("Exception encountered while attempting to load JsConfig configuration section", ex);
			}
		}

		private static string GenerateVarJavascript()
		{
			return String.Format("window.{0} = {{\r\n", VarName) +
				String.Join(
					",\r\n", 
					Items.Select(f => String.Format(f.IsString ? "'{0}': '{1}'" : "'{0}': {1}", f.NameJsString, f.ValueJsString))
				) +
				"\r\n};";
		}

		public static void InvalidateVarJavascript()
		{
			_invalidated = true;
		}
	}
}
