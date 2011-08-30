using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WaveLib;

namespace PClapper.GUI {


    public partial class AudioDevicePicker : UserControl {

        public event EventHandler SelectedIndexChanged;
        
        public int selectedDeviceId {
            get {
                return ((AudioDevice)comboBox.SelectedItem).id;
            }
            set {
                if (value + 1 < comboBox.Items.Count ) 
                    comboBox.SelectedIndex = value + 1;
                else
                    comboBox.SelectedIndex = 0;
            }
        }

        public class AudioDevice {
            private int _id;
            private string _name;
            public int id { get { return _id; } }
            public string name { get { return _name; } }
            public AudioDevice(int id, string name) {
                this._id = id;
                this._name = name;
            }
        }

        public AudioDevicePicker() {
            InitializeComponent();

            comboBox.Items.Add(new AudioDevice(-1, "Default"));
            int waveInDevicesCount = WaveNative.waveInGetNumDevs();
            if (waveInDevicesCount > 0) {
                for (int uDeviceID = 0; uDeviceID < waveInDevicesCount; uDeviceID++) {
                    WaveNative.WaveInCaps waveInCaps = new WaveNative.WaveInCaps();
                    WaveNative.waveInGetDevCapsA(uDeviceID, ref waveInCaps, Marshal.SizeOf(typeof(WaveNative.WaveInCaps)));
                    AudioDevice device = new AudioDevice(uDeviceID, new string(waveInCaps.szPname).Remove(new string(waveInCaps.szPname).IndexOf('\0')).Trim());
                    comboBox.Items.Add(device);
                }
            }
            comboBox.SelectedIndex = 0;
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (SelectedIndexChanged != null) this.SelectedIndexChanged.Invoke(sender, e);
        }

    }
}
