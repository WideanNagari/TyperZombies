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
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            button1.Image = (Image)(new Bitmap(Image.FromFile("./asset2/back.png"), new Size(180, 65)));
        }

        private void About_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Image.FromFile("bg1.png"), 0, 0, 1120, 600);
            g.DrawImage(Image.FromFile("./asset2/logo.png"), 260, 10, 600, 100);
            g.DrawImage(Image.FromFile("./asset2/evan.png"), 275, 200, 570, 45);
            g.DrawImage(Image.FromFile("./asset2/indah.png"), 155, 270, 830, 45);
            g.DrawImage(Image.FromFile("./asset2/valentino.png"), 155, 340, 820, 45);
            g.DrawImage(Image.FromFile("./asset2/widean.png"), 275, 410, 570, 45);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
