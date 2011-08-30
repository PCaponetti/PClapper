using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PClapper {
    
    [Serializable]
    public class ActionsSettings {
        public List<ActionGroup> actionGroups = new List<ActionGroup>();

        public void addActionGroup(ActionGroup group) {
            foreach (ActionGroup g in actionGroups) {
                if (g.pattern.isSubPatternOf(group.pattern)) {
                    g.immediate = g.subPattern;
                }
                if (group.pattern.isSubPatternOf(g.pattern)) {
                    group.immediate = group.subPattern;
                }
            }
            actionGroups.Add(group);
        }

        public ActionsSettings DeepClone() {
            MemoryStream m = new MemoryStream();
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(m, this);
            m.Position = 0;
            return (ActionsSettings)b.Deserialize(m);
        }

        public int longestSilence {
            get {
                int max=0;
                foreach (ActionGroup ag in actionGroups) {
                    max = Math.Max(max, ag.pattern.longestSilence);
                }
                return max;
            }
        }
    }

    [Serializable]
    public class ActionSetting {
        public string action="";
        public string parameters="";
        public ActionSetting() {
        }
        public ActionSetting(string a, string p) {
            MemberwiseClone();
            action = a;
            parameters = p;
        }
    }

    [Serializable]
    public class ActionGroup {
        public ClapPattern pattern;
        public String name;
        public Boolean immediate = true;
        public Boolean subPattern = false;
        
        public List<ActionSetting> actions = new List<ActionSetting>();

        public ActionGroup(String name, ClapPattern p, List<ActionSetting> actions) {
            this.pattern = p;
            this.name = name;
            this.actions = actions;
        }

        public ActionGroup(String name) {
            this.name = name;
        }

        public ActionGroup() {
        }

    }
}
