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
    public partial class Shop : Form
    {
        public Player p1;
        public Shop(Player p)
        {
            InitializeComponent();
            p1 = p;
        }

        private void Shop_Load(object sender, EventArgs e)
        {
            button1.Image = (Image)(new Bitmap(Image.FromFile("./asset2/back.png"), new Size(120, 45)));
            gold.Text = p1.gold + "";
            aBox.Text = "Owned : "+p1.aBox;
            sgold.Text = "Owned : "+p1.sog;
            heal.Text = "Owned : "+p1.heal;
            bom.Text = "Owned : "+p1.bomb;
        }

        private void Shop_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Image.FromFile("bg2.png"), 0, 0, 1120, 600);
            g.DrawImage(Image.FromFile("./asset2/shop.png"), 450, 10, 200, 60);
            g.DrawImage(Image.FromFile("./asset2/bomb.png"), 470, 90, 75, 75);
            g.DrawImage(Image.FromFile("./asset2/heal.png"), 460, 170, 85, 85);
            g.DrawImage(Image.FromFile("./asset2/hp.png"), 460, 260, 75, 75);
            g.DrawImage(Image.FromFile("./asset2/gold.png"), 460, 340, 85, 85);
            g.DrawImage(Image.FromFile("./asset2/box.png"), 460, 430, 85, 85);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Membunuh semua zombie yang ada di map", "Effect");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Menambah HP sebanyak 500", "Effect");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Menambah max HP dan current HP sebanyak 500", "Effect");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Menambah gold sebanyak 200 setelah membunuh zombie (efek akan hilang setelah membunuh 10 zombie)", "Effect");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Melemahkan zombie untuk 2 round kedepan (Hp semua zombie menjadi 1)","Effect");
        }
    }
}
