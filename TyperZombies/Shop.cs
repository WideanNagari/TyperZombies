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
        Asset asset;
        public Shop(Player p, Asset a)
        {
            InitializeComponent();
            p1 = p;
            asset = a;
        }

        private void Shop_Load(object sender, EventArgs e)
        {
            button1.Image = (Image)(new Bitmap(asset.back, new Size(120, 45)));
            gold.Text = p1.gold + "";
            aBox.Text = "Owned : "+p1.aBox;
            sgold.Text = "Owned : "+p1.sog;
            heal.Text = "Owned : "+p1.heal;
            bom.Text = "Owned : "+p1.bomb;
            darah.Text = p1.hp + "/" + p1.maxhp;
            button4.Text = (p1.hpBooster * 350) + " Gold";
        }

        private void Shop_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Image.FromFile("bg2.png"), 0, 0, 1120, 600);
            g.DrawImage(asset.shop, 450, 10, 200, 60);
            g.DrawImage(asset.bom, 470, 90, 75, 75);
            g.DrawImage(asset.heal, 460, 170, 85, 85);
            g.DrawImage(asset.hp, 460, 260, 75, 75);
            g.DrawImage(asset.sog, 460, 340, 85, 85);
            g.DrawImage(asset.box, 460, 430, 85, 85);
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (p1.gold>=1500)
            {
                p1.gold -= 1500;
                p1.bomb += 1;
                gold.Text = p1.gold + "";
                bom.Text = "Owned : " + p1.bomb;
            }
            else MessageBox.Show("Gold tidak cukup!", "Gagal membeli item");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (p1.gold >= 500)
            {
                p1.gold -= 500;
                p1.heal += 1;
                gold.Text = p1.gold + "";
                heal.Text = "Owned : " + p1.heal;
            }
            else MessageBox.Show("Gold tidak cukup!", "Gagal membeli item");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (p1.gold >= (p1.hpBooster*350))
            {
                p1.gold -= (p1.hpBooster * 350);
                p1.hpBooster += 1;
                p1.hp += 500;
                p1.maxhp += 500;
                darah.Text = p1.hp + "/" + p1.maxhp;
                gold.Text = p1.gold + "";
                button4.Text = (p1.hpBooster * 350) + " Gold";
            }
            else MessageBox.Show("Gold tidak cukup!", "Gagal membeli item");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (p1.gold >= 1200)
            {
                p1.gold -= 1200;
                p1.sog += 1;
                gold.Text = p1.gold + "";
                sgold.Text = "Owned : " + p1.sog;
            }
            else MessageBox.Show("Gold tidak cukup!", "Gagal membeli item");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (p1.gold >= 2500)
            {
                p1.gold -= 2500;
                p1.aBox += 1;
                gold.Text = p1.gold + "";
                aBox.Text = "Owned : " + p1.aBox;
            }
            else MessageBox.Show("Gold tidak cukup!", "Gagal membeli item");
        }
    }
}
