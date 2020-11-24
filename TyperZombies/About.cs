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
        Asset asset;
        public About(Asset a)
        {
            InitializeComponent();
            asset = a;
        }

        private void About_Load(object sender, EventArgs e)
        {
            button1.Image = (Image)(new Bitmap(Image.FromFile("./asset2/back.png"), new Size(180, 65)));
        }

        private void About_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Image.FromFile("bg1.png"), 0, 0, 1120, 600);
            g.DrawImage(asset.logo, 260, 10, 600, 100);
            g.DrawImage(asset.evan, 275, 200, 570, 45);
            g.DrawImage(asset.indah, 155, 270, 830, 45);
            g.DrawImage(asset.valent, 155, 340, 820, 45);
            g.DrawImage(asset.widean, 275, 410, 570, 45);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
