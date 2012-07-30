using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Appclay.JsConfig.Config
{
	public class JsConfigFieldCollection : ConfigurationElementCollection
	{
		public JsConfigFieldCollection()
		{
			JsConfigFieldElement property = (JsConfigFieldElement)CreateNewElement();
			Add(property);
		}

		public override ConfigurationElementCollectionType CollectionType
		{
			get
			{
				return ConfigurationElementCollectionType.AddRemoveClearMap;
			}
		}

		protected override ConfigurationElement CreateNewElement()
		{
			return new JsConfigFieldElement();
		}

		protected override Object GetElementKey(ConfigurationElement element)
		{
			return ((JsConfigFieldElement)element).Name;
		}

		public JsConfigFieldElement this[int index]
		{
			get
			{
				return (JsConfigFieldElement)BaseGet(index);
			}
			set
			{
				if (BaseGet(index) != null)
				{
					BaseRemoveAt(index);
				}
				BaseAdd(index, value);
			}
		}

		new public JsConfigFieldElement this[string Name]
		{
			get
			{
				return (JsConfigFieldElement)BaseGet(Name);
			}
		}

		public int IndexOf(JsConfigFieldElement property)
		{
			return BaseIndexOf(property);
		}

		public void Add(JsConfigFieldElement property)
		{
			BaseAdd(property);
		}
		protected override void BaseAdd(ConfigurationElement element)
		{
			BaseAdd(element, false);
		}

		public void Remove(JsConfigFieldElement property)
		{
			if (BaseIndexOf(property) >= 0)
				BaseRemove(property.Name);
		}

		public void RemoveAt(int index)
		{
			BaseRemoveAt(index);
		}

		public void Remove(string name)
		{
			BaseRemove(name);
		}

		public void Clear()
		{
			BaseClear();
		}
	}
}
