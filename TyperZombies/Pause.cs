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
    public partial class Pause : Form
    {
        public Player p1;
        public Pause(Player p)
        {
            InitializeComponent();
            p1 = p;
        }
        public bool end;
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "db_proyek.mdf;Integrated Security=True;Connect Timeout=30";
        private void Pause_Load(object sender, EventArgs e)
        {
            end = false;
        }

        private void Pause_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Image.FromFile("bg2.png"), 0, 0, 1120, 600);
            g.DrawImage(Image.FromFile("./asset2/pause.png"), 370, 20, 350, 85);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Status s = new Status(p1);
            this.Hide();
            s.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Shop s = new Shop(p1);
            this.Hide();
            s.ShowDialog();
            this.Show();
            p1 = s.p1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            end = true;
            this.Close();
        }

        XmlDocument doc;
        private void save(Player p)
        {
            doc = new XmlDocument();
            XmlNode root = doc.CreateElement("ListPlayer");
            doc.AppendChild(root);

            XmlNode child = doc.CreateElement("player");
            root.AppendChild(child);
            child.InnerText = p.nama;

            XmlAttribute attr = doc.CreateAttribute("id");
            attr.Value = p.id;
            child.Attributes.Append(attr);

            attr = doc.CreateAttribute("level");
            attr.Value = p.level + "";
            child.Attributes.Append(attr);

            attr = doc.CreateAttribute("score");
            attr.Value = p.score + "";
            child.Attributes.Append(attr);

            attr = doc.CreateAttribute("gold");
            attr.Value = p.gold + "";
            child.Attributes.Append(attr);

            attr = doc.CreateAttribute("hp");
            attr.Value = p.hp + "";
            child.Attributes.Append(attr);

            attr = doc.CreateAttribute("maxhp");
            attr.Value = p.maxhp + "";
            child.Attributes.Append(attr);

            attr = doc.CreateAttribute("kill");
            attr.Value = p.kill + "";
            child.Attributes.Append(attr);

            attr = doc.CreateAttribute("party");
            attr.Value = p.party + "";
            child.Attributes.Append(attr);

            attr = doc.CreateAttribute("bomb");
            attr.Value = p.bomb + "";
            child.Attributes.Append(attr);

            attr = doc.CreateAttribute("heal");
            attr.Value = p.heal + "";
            child.Attributes.Append(attr);

            attr = doc.CreateAttribute("hpBooster");
            attr.Value = p.hpBooster + "";
            child.Attributes.Append(attr);

            attr = doc.CreateAttribute("sog");
            attr.Value = p.sog + "";
            child.Attributes.Append(attr);

            attr = doc.CreateAttribute("aBox");
            attr.Value = p.aBox + "";
            child.Attributes.Append(attr);

            attr = doc.CreateAttribute("efekSog");
            attr.Value = p.efekSog + "";
            child.Attributes.Append(attr);

            attr = doc.CreateAttribute("efekBox");
            attr.Value = p.efekBox + "";
            child.Attributes.Append(attr);

            doc.Save(p.nama + ".xml");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            save(p1);

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = $"Update Highscore set skor = '"+p1.score+ "',gold = '" + p1.gold + "',level = '" + p1.level + "' where id_player = '"+p1.id+"'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
