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
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed class Actions : global::System.Configuration.ApplicationSettingsBase {

        private static Actions defaultInstance = ((Actions)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Actions())));

        public static Actions Default {
            get {
                return defaultInstance;
            }
        }

        [UserScopedSettingAttribute()]
        [DefaultSettingValueAttribute("<ActionsSettings><actionGroups></actionGroups></ActionsSettings>")]
        [SettingsSerializeAsAttribute(SettingsSerializeAs.Xml)]
        public ActionsSettings actionsSettings {
            get {return ((ActionsSettings)this["actionsSettings"]);}
            set {this["actionsSettings"] = (ActionsSettings)value; }
        }
    }
}


