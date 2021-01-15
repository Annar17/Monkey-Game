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
    public partial class Form3 : Form
    {
        int Score = 0;
        int timeLeft = 90;        
        public Form3()
        {
            InitializeComponent();
            timer1.Start();
            timer2.Start();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }
              
        internal void SetLabelLevel(string l)
        {
            LevelLabel.Text = l;
        }

        internal void SetLabelUser(string k)
        {
            UsernameLabel.Text = k;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Score += 1;
            ScoreLabel.Text = Score.ToString();
        }
                
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                TimeLabel.Text = timeLeft.ToString();
            }
            else
            {
                timer1.Stop();
                timer2.Stop();
                MessageBox.Show("Time's up!" + Environment.NewLine + "Score: " + Score);
                string path = String.Format(@"{0}\data.txt", Application.StartupPath);
                var lines = File.ReadAllLines("data.txt");
                List<string> tmp = new List<string>();
                foreach (var s in lines)
                {
                    tmp.Add(s);
                }
                string oldL = "", newL = "";
                foreach (string s in tmp)
                {
                    if (s.Split(' ')[0] == UsernameLabel.Text)
                    {
                        oldL = s;
                    }
                }
                string[] tmp1 = oldL.Split(' ');
                if ((LevelLabel.Text == "Easy")&&(Score > Int32.Parse(tmp1[1])))
                {
                    tmp1[1] = Score.ToString();
                }
                else if ((LevelLabel.Text == "Medium")&&(Score > Int32.Parse(tmp1[2])))
                {
                    tmp1[2] = Score.ToString();
                }
                else if ((LevelLabel.Text == "Hard") && (Score > Int32.Parse(tmp1[3])))
                {
                    tmp1[3] = Score.ToString();
                }
                newL = tmp1[0] + " " + tmp1[1] + " " + tmp1[2] + " " + tmp1[3];
                tmp.Remove(oldL);
                tmp.Add(newL);
                File.WriteAllLines("data.txt", tmp);
                this.Close();
            }
        }
        
        public Random r = new Random();
        int X = 0, Y = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (LevelLabel.Text == "Easy")
            {
                timer2.Interval = 3000;
            }
            else if (LevelLabel.Text == "Medium")
            {
                timer2.Interval = 2000;
            }
            else
            {
                timer2.Interval = 1000;
            }
            X = ((int)(new Random().Next(0, 1020)));
            Y = ((int)(new Random().Next(0, 530)));
            if (X > 1020 - pictureBox1.Width)
            {
                X = 1020 - pictureBox1.Width;
            }
            if (Y > 530 - pictureBox1.Height)
            {
                Y = 530 - pictureBox1.Height;
            }
            pictureBox1.Location = new Point(X, Y);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
