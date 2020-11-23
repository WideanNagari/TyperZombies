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
    public partial class Newgame : Form
    {
        List<string> arrP;
        public Newgame(List<string> arrp)
        {
            InitializeComponent();
            arrP = arrp;
        }
        
        Player p;
        XmlDocument doc;
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "db_proyek.mdf;Integrated Security=True;Connect Timeout=30";
        private void Newgame_Load(object sender, EventArgs e)
        {
            button1.Image = (Image)(new Bitmap(Image.FromFile("./asset2/back.png"), new Size(180, 65)));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Newgame_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Image.FromFile("bg1.png"), 0, 0, 1120, 600);
            g.DrawImage(Image.FromFile("./asset2/new-game.png"), 360, 10, 400, 75);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="" || textBox2.Text == "")
            {
                MessageBox.Show("Mohon isi semua field!");
            }
            else
            {
                bool ada = false;
                foreach (string s in arrP)
                {
                    string[] arr = s.Split(' ');
                    if (arr[0].Equals(textBox1.Text))
                    {
                        ada = true;
                    }
                }
                if (ada)
                {
                    MessageBox.Show("Username sudah ada, coba username yang lain!", "Gagal!");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                else
                {
                    p = new Player(textBox1.Text);
                    SqlConnection conn = new SqlConnection(connectionString);
                    conn.Open();
                    string query = "Select * from player";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    string id = "";
                    SqlDataReader readers = cmd.ExecuteReader();
                    while (readers.Read())
                    {
                        id = readers.GetString(0);
                    }
                    string jum;
                    int jum2;
                    if (id == "")
                    {
                        id = "P001";
                    }
                    else
                    {
                        jum = id.Substring(1, 3);
                        jum2 = Convert.ToInt32(jum);
                        jum2++;
                        if (jum2 < 10)
                        {
                            id = "P00" + jum2;
                        }
                        else if (jum2 < 100)
                        {
                            id = "P0" + jum2;
                        }
                        else
                        {
                            id = "P" + jum2;
                        }
                    }
                    p.id = id;
                    conn.Close();
                    conn.Open();
                    query = $"Insert into player(id,nama,password,status) values('{id}','{textBox1.Text}','{textBox2.Text}','1')";
                    cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    conn.Open();
                    query = $"Insert into Highscore(id_player,skor,gold,level,status) values('{id}','0','0','1','1')";
                    cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    save(p);

                    Form1 f = new Form1(p);
                    this.Hide();
                    f.ShowDialog();
                    this.Close();
                }
            }
        }

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
            attr.Value = p.score+"";
            child.Attributes.Append(attr);

            attr = doc.CreateAttribute("gold");
            attr.Value = p.gold+"";
            child.Attributes.Append(attr);

            attr = doc.CreateAttribute("hp");
            attr.Value = p.hp+"";
            child.Attributes.Append(attr);

            attr = doc.CreateAttribute("maxhp");
            attr.Value = p.maxhp+"";
            child.Attributes.Append(attr);

            attr = doc.CreateAttribute("kill");
            attr.Value = p.kill+"";
            child.Attributes.Append(attr);

            attr = doc.CreateAttribute("party");
            attr.Value = p.party+"";
            child.Attributes.Append(attr);

            attr = doc.CreateAttribute("bomb");
            attr.Value = p.bomb+"";
            child.Attributes.Append(attr);

            attr = doc.CreateAttribute("heal");
            attr.Value = p.heal+"";
            child.Attributes.Append(attr);

            attr = doc.CreateAttribute("hpBooster");
            attr.Value = p.hpBooster+"";
            child.Attributes.Append(attr);

            attr = doc.CreateAttribute("sog");
            attr.Value = p.sog+"";
            child.Attributes.Append(attr);

            attr = doc.CreateAttribute("aBox");
            attr.Value = p.aBox+"";
            child.Attributes.Append(attr);

            attr = doc.CreateAttribute("efekSog");
            attr.Value = p.efekSog + "";
            child.Attributes.Append(attr);

            attr = doc.CreateAttribute("efekBox");
            attr.Value = p.efekBox + "";
            child.Attributes.Append(attr);

            doc.Save(p.nama+".xml");
        }
    }
}
