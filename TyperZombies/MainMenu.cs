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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            button1.Image = (Image)(new Bitmap(Image.FromFile("./asset2/new-game.png"), new Size(180, 50)));
            button2.Image = (Image)(new Bitmap(Image.FromFile("./asset2/continue.png"), new Size(180, 50)));
            button3.Image = (Image)(new Bitmap(Image.FromFile("./asset2/high-score.png"), new Size(180, 50)));
            button4.Image = (Image)(new Bitmap(Image.FromFile("./asset2/about.png"), new Size(130, 40)));
            button5.Image = (Image)(new Bitmap(Image.FromFile("./asset2/exit.png"), new Size(110, 42)));
        }

        private void MainMenu_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Image.FromFile("bg1.png"), 0, 0, 1120, 600);
            g.DrawImage(Image.FromFile("./asset2/logo.png"), 260, 10, 600, 100);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            About a = new About();
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to exit?";
            string title = "Exit";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Newgame n = new Newgame();
            this.Hide();
            n.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Continue c = new Continue();
            this.Hide();
            c.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Highscore h = new Highscore();
            this.Hide();
            h.ShowDialog();
            this.Show();
        }
    }
}
