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
        List<Player> arrp;
        Asset asset;
        public Highscore(List<Player> a, Asset aa)
        {
            InitializeComponent();
            arrp = a;
            asset = aa;
        }
        List<Player> highScore;
        private void Highscore_Load(object sender, EventArgs e)
        {
            button1.Image = (Image)(new Bitmap(Image.FromFile("./asset2/back.png"), new Size(180, 65)));
            highScore = new List<Player>();
            highScore = arrp.OrderByDescending(x => x.score).ToList<Player>();
            if (highScore.Count > 0 && highScore[0] != null) label1.Text = "1. " + highScore[0].nama + " - " + highScore[0].score + " - " + highScore[0].gold + " - " + highScore[0].level;
            if (highScore.Count > 1 && highScore[1] != null) label2.Text = "2. " + highScore[1].nama + " - " + highScore[1].score + " - " + highScore[1].gold + " - " + highScore[1].level;
            if (highScore.Count > 2 && highScore[2] != null) label3.Text = "3. " + highScore[2].nama + " - " + highScore[2].score + " - " + highScore[2].gold + " - " + highScore[2].level;
            if (highScore.Count > 3 && highScore[3] != null) label4.Text = "4. " + highScore[3].nama + " - " + highScore[3].score + " - " + highScore[3].gold + " - " + highScore[3].level;
            if (highScore.Count > 4 && highScore[4] != null) label5.Text = "5. " + highScore[4].nama + " - " + highScore[4].score + " - " + highScore[4].gold + " - " + highScore[4].level;
        }

        private void Highscore_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Image.FromFile("bg1.png"), 0, 0, 1120, 600);
            g.DrawImage(asset.high, 335, 10, 450, 75);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
