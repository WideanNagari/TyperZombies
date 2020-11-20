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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int x = 0, y = 100;
        AGeorge j;
        Asset assets;
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.TextAlign = HorizontalAlignment.Center;
            assets = new Asset();
            j = new AGeorge(1,2,assets,"");
            j.gantiAnimasi(assets.ageorge);
            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Image.FromFile("background.png"), 0, 0, 1120, 600);
            g.DrawImage(j.sprite, x, y, j.sprite.Width/2.3f, j.sprite.Height/2.3f);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            j.gantiAnimasi(assets.ageorge);
            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString().Equals("Space"))
            {
                textBox1.Text = "";
            }
        }
    }
}
