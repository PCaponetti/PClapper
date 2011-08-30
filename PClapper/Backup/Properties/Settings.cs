using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Xml.Serialization;
using System.Xml;
using System.ComponentModel;
using System.IO;

namespace PClapper.Properties
{
    internal partial class Settings
    {
        public void ResetNoSave() {
            foreach (SettingsProperty v in Properties) {
                try {
                    this[v.Name] = TypeDescriptor.GetConverter(v.PropertyType).ConvertFromString((string)v.DefaultValue);
                }
                catch (NotSupportedException) {
                    XmlSerializer serializer = new XmlSerializer(v.PropertyType);
                    this[v.Name] = serializer.Deserialize(new StringReader((string)v.DefaultValue));
                }
            }
        }
    }
}


