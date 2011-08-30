using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PClapper
{
    public partial class ClapPatternControl : UserControl 
    {
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ClapPattern pattern {
            get {
                ClapPattern result = new ClapPattern();
                for (int i = 0; i < boxes.Length; i++) {
                    if (boxes[i].Checked) result.claps.Add(i);
                }
                return result;
            }
            set {
                for (int i = 0; i < boxes.Length; i++) {
                    boxes[i].Checked = false;
                }
                foreach (int clap in value.claps) {
                    if (clap < boxes.Length) boxes[clap].Checked = true;
                }
            }
        }

        public ClapPattern getPattern() {
            return null;
        }

        public  void setPattern(ClapPattern p) {
        }

        public ClapPatternControl()
        {
            InitializeComponent();
            this.boxes = new CheckBox[8] { box1, box2, box3, box4, box5, box6, box7, box8 };
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonListen_Click(object sender, EventArgs e) {
            this.pattern.Play();
        }
    }
}
