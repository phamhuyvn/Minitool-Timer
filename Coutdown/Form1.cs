using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices;

namespace Coutdown
{
    public partial class Form1 : Form
    {
        int select = 0;
        private TimeOnly value = new TimeOnly(0,0,0);
        private TimeSpan TimeSpan = TimeSpan.Zero;
        private DateTime StartTime;
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;



            label1.BackColor = label2.BackColor = label3.BackColor = label4.BackColor = label5.BackColor = System.Drawing.Color.Transparent;
            label4.Parent = this;
            label5.Parent = this;

            centerlabel();

            label1.Text = label2.Text = label3.Text = "00";
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            TimeSpan elapsed = TimeSpan - (TimeOnly.FromDateTime(DateTime.Now) - TimeOnly.FromDateTime(StartTime));
            label1.Text = elapsed.Hours.ToString("00");
            label2.Text = elapsed.Minutes.ToString("00");
            label3.Text = elapsed.Seconds.ToString("00");
            if(elapsed < TimeSpan.Zero)
            {
                //timer1.Enabled = false;
                //timer2.Enabled = true;
                runwatch();
                TimeSpan = TimeSpan.Zero;
                
            }

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    increse(0);
                    timelabelupdate();
                    break;
                case Keys.Up:
                    increse(1);
                    timelabelupdate();
                    break;
                case Keys.Left:
                    change(0);
                    timelabelupdate();
                    break;
                case Keys.Right:
                    change(1);
                    timelabelupdate();
                    break;
                case Keys.Space:
                    runwatch();
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;  
            }
            //timelabelupdate();
        }
        private void timelabelupdate()
        {
            label1.Text = TimeSpan.Hours.ToString("00");
            label2.Text = TimeSpan.Minutes.ToString("00");
            label3.Text = TimeSpan.Seconds.ToString("00");
        }
        private void increse(int i)
        {
            switch (select)
            {
                case 0:
                    if ((i == 0)&&(TimeSpan.Seconds>0)) {
                        TimeSpan = TimeSpan.Add(TimeSpan.FromSeconds(-1));
                    }
                    else
                    {
                        TimeSpan = TimeSpan.Add(TimeSpan.FromSeconds(1));
                    }
                    break;
                case 1:
                    if ((i == 0)&&(TimeSpan.Minutes>0))
                    {
                        TimeSpan = TimeSpan.Add(TimeSpan.FromMinutes(-1));
                    }
                    else
                    {
                        TimeSpan = TimeSpan.Add(TimeSpan.FromMinutes(1));
                    }
                    break;
                case 2:
                    if ((i == 0)&&(TimeSpan.Hours>0))
                    {
                        TimeSpan = TimeSpan.Add(TimeSpan.FromHours(-1));
                    }
                    else
                    {
                        TimeSpan = TimeSpan.Add(TimeSpan.FromHours(1));
                    }
                    break;
            }
        }
        private void change(int i)
        {
            label1.ForeColor = label2.ForeColor = label3.ForeColor = Color.White;
            switch (i)
            {
                case 0:
                    select++;
                    if (select == 3)
                    {
                        select = 0;
                    }
                    break;
                case 1:
                    select--;
                    if (select == -1)
                    {
                        select = 2;
                    }
                    break;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void centerlabel()
        {
            int y = this.Height / 2 - label2.Height / 2;
            var left = new Point(this.Width / 2 - label2.Width / 2 - label5.Width - label2.Width, y);
            var dot1 = new Point(this.Width / 2 - label2.Width / 2 - label5.Width, y);
            var center = new Point(this.Width / 2 - label2.Width / 2, y);
            var dot2 = new Point(this.Width / 2 - label2.Width / 2 + label2.Width, y);
            var right = new Point(this.Width / 2 - label2.Width / 2 + label5.Width + label2.Width, y);
            label1.Location = left;
            label2.Location = center;
            label3.Location = right;
            label4.Location = dot1;
            label5.Location = dot2;
        }
        private void runwatch()
        {
            label1.ForeColor = label2.ForeColor = label3.ForeColor = Color.White;
            if (timer1.Enabled == false)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                this.TopMost = true;
                centerlabel();
                StartTime = DateTime.Now;
                timer1.Enabled = true;
                timer2.Enabled = false;
                Cursor.Hide();
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.WindowState = FormWindowState.Normal;
                centerlabel();
                timer1.Enabled=false;
                timer2.Enabled=true;
                Cursor.Show();
            }
            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            switch (select)
            {
                case 0:
                    label3.ForeColor = label3.ForeColor==Color.Black?Color.White:Color.Black;
                    break;
                case 1:
                    label2.ForeColor = label2.ForeColor == Color.Black ? Color.White : Color.Black;
                    break;
                case 2:
                    label1.ForeColor = label1.ForeColor == Color.Black ? Color.White : Color.Black;
                    break;
            }
        }
    }
}
