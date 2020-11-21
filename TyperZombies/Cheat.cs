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
    public partial class Cheat : Form
    {
        public Cheat()
        {
            InitializeComponent();
        }

        private void Cheat_Load(object sender, EventArgs e)
        {
            button1.Image = (Image)(new Bitmap(Image.FromFile("./asset2/back.png"), new Size(120, 45)));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cheat_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Image.FromFile("bg2.png"), 0, 0, 1120, 600);
            g.DrawImage(Image.FromFile("./asset2/cheat.png"), 490, 10, 200, 60);
            g.DrawImage(Image.FromFile("./asset2/bomb.png"), 1005, 262, 45, 45);
            g.DrawImage(Image.FromFile("./asset2/heal.png"), 1002, 310, 50, 50);
            g.DrawImage(Image.FromFile("./asset2/gold.png"), 1000, 360, 50, 50);
            g.DrawImage(Image.FromFile("./asset2/box.png"), 1000, 410, 50, 50);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") MessageBox.Show("Mohon isi field terlebih dahulu!");
            else
            {
                try
                {
                    int jumlah = Convert.ToInt32(textBox1.Text);
                }
                catch (Exception) { MessageBox.Show("Mohon mengisi dengan angka saja!"); }
                textBox1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "") MessageBox.Show("Mohon isi field terlebih dahulu!");
            else
            {
                try
                {
                    int jumlah = Convert.ToInt32(textBox2.Text);
                }
                catch (Exception) { MessageBox.Show("Mohon mengisi dengan angka saja!"); }
                textBox2.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "") MessageBox.Show("Mohon isi field terlebih dahulu!");
            else
            {
                try
                {
                    int jumlah = Convert.ToInt32(textBox3.Text);
                }
                catch (Exception) { MessageBox.Show("Mohon mengisi dengan angka saja!"); }
                textBox3.Text = "";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "") MessageBox.Show("Mohon isi field terlebih dahulu!");
            else
            {
                try
                {
                    int jumlah = Convert.ToInt32(textBox4.Text);
                }
                catch (Exception) { MessageBox.Show("Mohon mengisi dengan angka saja!"); }
                textBox4.Text = "";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "") MessageBox.Show("Mohon isi field terlebih dahulu!");
            else
            {
                try
                {
                    int jumlah = Convert.ToInt32(textBox5.Text);
                }
                catch (Exception) { MessageBox.Show("Mohon mengisi dengan angka saja!"); }
                textBox5.Text = "";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "") MessageBox.Show("Mohon isi field terlebih dahulu!");
            else
            {
                try
                {
                    int jumlah = Convert.ToInt32(textBox7.Text);
                }
                catch (Exception) { MessageBox.Show("Mohon mengisi dengan angka saja!"); }
                textBox7.Text = "";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "") MessageBox.Show("Mohon isi field terlebih dahulu!");
            else
            {
                try
                {
                    int jumlah = Convert.ToInt32(textBox8.Text);
                }
                catch (Exception) { MessageBox.Show("Mohon mengisi dengan angka saja!"); }
                textBox8.Text = "";
            }
        }
    }
}
