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
    public partial class Highscore : Form
    {
        public Highscore()
        {
            InitializeComponent();
        }

        private void Highscore_Load(object sender, EventArgs e)
        {
            button1.Image = (Image)(new Bitmap(Image.FromFile("./asset2/back.png"), new Size(180, 65)));
        }

        private void Highscore_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Image.FromFile("bg1.png"), 0, 0, 1120, 600);
            g.DrawImage(Image.FromFile("./asset2/high-score.png"), 335, 10, 450, 75);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
