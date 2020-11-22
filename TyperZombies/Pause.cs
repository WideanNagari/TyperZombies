using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TyperZombies
{
    public partial class Pause : Form
    {
        public Player p1;
        public Pause(Player p)
        {
            InitializeComponent();
            p1 = p;
        }
        public bool end;
        private void Pause_Load(object sender, EventArgs e)
        {
            end = false;
        }

        private void Pause_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Image.FromFile("bg2.png"), 0, 0, 1120, 600);
            g.DrawImage(Image.FromFile("./asset2/pause.png"), 370, 20, 350, 85);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Status s = new Status(p1);
            this.Hide();
            s.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Shop s = new Shop(p1);
            this.Hide();
            s.ShowDialog();
            this.Show();
            p1 = s.p1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            end = true;
            this.Close();
        }
    }
}
