using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgeOfLemons
{
    public partial class AOLTest : Form
    {
        decimal gold = 0;
        int level = 1;
        decimal goldIncome = 1;
        decimal interval = 0.10m;
        long time = 1000;
        bool started = false;
        float ld = 0;

        public AOLTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;

            Stopwatch sw = Stopwatch.StartNew();
            progressBar1.Value = 0;
            int prev = 0;
            while(true)
            {
                Application.DoEvents();
                int vv = (int)(((float)Math.Min(sw.ElapsedMilliseconds, time) / (float)time) * 100.0f);
                progressBar1.Value = vv;

                progressBar1.Value = prev;

                prev = vv;
                progressBar1.Update();
                Application.DoEvents();

                if(sw.ElapsedMilliseconds >= time)
                {
                    gold += goldIncome;
                    sw.Stop();

                    progressBar1.Value = vv;
                    progressBar1.Update();
                    Application.DoEvents();

                    break;
                }

            }
            progressBar1.Value = 0;
            progressBar1.Refresh();

            UpdateText();

            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((decimal)level * goldIncome * 1.1m <= gold)
            {
                gold -= (decimal)level * goldIncome * 1.1m;
                level += 1;

                goldIncome += interval;

                interval += 0.10m;
                UpdateText();
            }
        }

        private void UpdateText()
        {
            button2.Text = "Upgrade: " + string.Format("{0:c2}", (decimal)level * goldIncome * 1.1m);
            label1.Text = "Gold: " + string.Format("{0:c2}", gold);
            button1.Text = "Lemon: " + level;
            label2.Text = string.Format("{0:c2}", goldIncome);

            if((float)level  / (float)25 != ld)
            {
                time -= (long)(((float)level / (float)25 - ld) * 100);
                ld = (float)level / (float)25;
                time = Math.Max(50, time);
            }

            label3.Text = Math.Round(time / 1000.0f, 2) + " seconds";
        }

        private void AOLTest_Load(object sender, EventArgs e)
        {
            UpdateText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(100.00m <= gold)
            {
                button3.Enabled = false;
                timer1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (button1.Enabled)
                button1.PerformClick();
            button2.PerformClick();
            //button4.PerformClick();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            gold += 10000.00m;
            UpdateText();

        }
    }
}
