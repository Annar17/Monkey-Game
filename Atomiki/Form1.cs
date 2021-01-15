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
    public partial class Form1 : Form
    {     
        public Form1()
        {
            InitializeComponent();
        }

        int find = 0, maxe = 0, te = 0, maxm = 0, tm = 0, maxh = 0, th = 0;
        private void Login_Click(object sender, EventArgs e)
        {
            bool exists = false;
            String Username = UsernameBox1.Text;
            if (!string.IsNullOrEmpty(Username))
            {
                string path = String.Format(@"{0}\data.txt", Application.StartupPath);                
                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(Username + " " + 0 + " " + 0 + " " + 0);
                        sw.Close();
                    }
                }
                List<string> tmp = new List<string>();
                var lines = File.ReadAllLines("data.txt");
                foreach (var line in lines)
                {
                    tmp.Add(line);
                    if (line.Contains(Username))
                    {
                        exists = true;
                    }
                }
                if (!exists)
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(Username + " " + 0 + " " + 0 + " " + 0);
                        tmp.Add(Username + " " + 0 + " " + 0 + " " + 0);
                        sw.Close();
                    }
                }
                int i = 0;
                var lineCount = File.ReadLines(path).Count();
                String[] user = new string[lineCount];
                int[] easy = new int[lineCount];
                int[] medium = new int[lineCount];
                int[] hard = new int[lineCount];
                try
                {
                    foreach (var s in tmp)
                    {
                        String[] tmp1 = s.Split(' ');
                        user[i] = tmp1[0];
                        easy[i] = int.Parse(tmp1[1]);
                        medium[i] = int.Parse(tmp1[2]);
                        hard[i] = int.Parse(tmp1[3]);
                        if (Username == user[i])
                        {
                            find = i;
                        }
                        i++;
                    }
                }
                catch (Exception a) { }
                maxe = easy.Max();
                te = Array.IndexOf(easy, maxe);
                maxm = medium.Max();
                tm = Array.IndexOf(medium, maxm);
                maxh = hard.Max();
                th = Array.IndexOf(hard, maxh);
                Form2 f2 = new Form2();
                f2.Show();
                f2.SetLabelText(user[find], easy[find], medium[find], hard[find], maxe, user[te], maxm, user[tm], maxh, user[th]);
            }
            else
            {
                MessageBox.Show("Please enter your username to proceed!");
            }
        }
        
        private void Exit_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }
    }
}
