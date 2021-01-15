using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atomiki
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            if (EasyButton.Checked)
            {
                MediumButton.Checked = false;
                HardButton.Checked = false;
            }
            else if (MediumButton.Checked)
            {
                EasyButton.Checked = false;
                HardButton.Checked = false;
            }
            else
            {
                EasyButton.Checked = false;
                MediumButton.Checked = false;
            }
        }

        internal void SetLabelText(string u, int ea, int m, int h, int me, string ue, int mm, string um, int mh, string uh)
        {
            Userlabel.Text = u;
            label5.Text = ea.ToString();
            label8.Text = m.ToString();
            label9.Text = h.ToString();
            label10.Text = ue + ":" + " " + me.ToString();
            label11.Text = um + ":" + " " + mm.ToString();
            label12.Text = uh + ":" + " " + mh.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            f3.SetLabelUser(Userlabel.Text);
            if (EasyButton.Checked)
            {
                f3.SetLabelLevel(EasyButton.Text);
            }
            else if (MediumButton.Checked)
            {
                f3.SetLabelLevel(MediumButton.Text);
            }
            else
            {
                f3.SetLabelLevel(HardButton.Text);
            }
        }       

        private void Logout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }            
    }
}
