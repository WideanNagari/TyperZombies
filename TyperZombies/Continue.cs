using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TyperZombies
{
    public partial class Continue : Form
    {
        List<string> arrP;
        public Continue(List<string> arrp)
        {
            InitializeComponent();
            arrP = arrp;
        }
        Player p;
        XmlDocument doc;
        private void Continue_Load(object sender, EventArgs e)
        {
            button1.Image = (Image)(new Bitmap(Image.FromFile("./asset2/back.png"), new Size(180, 65)));
        }

        private void Continue_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Image.FromFile("bg1.png"), 0, 0, 1120, 600);
            g.DrawImage(Image.FromFile("./asset2/continue.png"), 360, 10, 400, 75);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Mohon isi semua field!");
            }
            else
            {
                bool ada = false;
                string pass = "";
                foreach (string s in arrP)
                {
                    string[] arr = s.Split(' ');
                    if (arr[0].Equals(textBox1.Text))
                    {
                        pass = arr[1];
                        ada = true;
                    }
                }
                if (!ada)
                {
                    MessageBox.Show("Username tidak ditemukan!", "Gagal!");
                }
                else
                {
                    if (textBox2.Text == pass)
                    {
                        p = new Player(textBox1.Text);
                        load(p);
                        Form1 f = new Form1(p);
                        this.Hide();
                        f.ShowDialog();
                        this.Close();
                    }
                    else MessageBox.Show("Password salah!");
                }
            }
        }

        private void load(Player p)
        {
            doc = new XmlDocument();
            doc.Load(p.nama+".xml");
            foreach (XmlNode item in doc.DocumentElement.ChildNodes)
            {
                p.level = Convert.ToInt32(item.Attributes["level"].InnerText);
                p.score = Convert.ToInt32(item.Attributes["score"].InnerText);
                p.gold = Convert.ToInt32(item.Attributes["gold"].InnerText);
                p.hp = Convert.ToInt32(item.Attributes["hp"].InnerText);
                p.maxhp = Convert.ToInt32(item.Attributes["maxhp"].InnerText);
                p.kill = Convert.ToInt32(item.Attributes["kill"].InnerText);
                p.party = Convert.ToInt32(item.Attributes["party"].InnerText);
                p.bomb = Convert.ToInt32(item.Attributes["bomb"].InnerText);
                p.heal = Convert.ToInt32(item.Attributes["heal"].InnerText);
                p.hpBooster = Convert.ToInt32(item.Attributes["hpBooster"].InnerText);
                p.sog = Convert.ToInt32(item.Attributes["sog"].InnerText);
                p.aBox = Convert.ToInt32(item.Attributes["aBox"].InnerText);
            }
        }
    }
}
