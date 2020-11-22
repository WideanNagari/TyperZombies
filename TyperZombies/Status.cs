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
    public partial class Status : Form
    {
        public Player p1;
        public Status(Player p)
        {
            InitializeComponent();
            p1 = p;
        }

        private void Status_Load(object sender, EventArgs e)
        {
            button1.Image = (Image)(new Bitmap(Image.FromFile("./asset2/back.png"), new Size(120, 45)));
            nama.Text = p1.nama;
            level.Text = p1.level+"";
            hp.Text = p1.hp + "/" + p1.maxhp;
            skor.Text = p1.score + "";
            gold.Text = p1.gold + "";
            count.Text = p1.kill + "";
        }

        private void Status_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Image.FromFile("bg2.png"), 0, 0, 1120, 600);
            g.DrawImage(Image.FromFile("./asset2/status.png"), 420, 10, 280, 60);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
