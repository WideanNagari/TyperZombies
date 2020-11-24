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

namespace TyperZombies
{
    public partial class Form1 : Form
    {
        Player p1;
        List<Zombie> arrZombie;
        Asset assets;
        public Form1(Player p, List<Zombie> arrz, Asset aa)
        {
            InitializeComponent();
            p1 = p;
            arrZombie = arrz;
            assets = aa;
        }
        Random r;
        int ctrSpawn;
        Image imgExplode;
        int ctrExplode, ctrLabel;
        Brush fontext;
        Brush fontext2;
        Font f;
        bool bomb2;
        bool dead;
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "db_proyek.mdf;Integrated Security=True;Connect Timeout=30";
        private void Form1_Load(object sender, EventArgs e)
        {
            dead = false;
            label1.Text = p1.hp+"/"+ p1.maxhp;
            label2.Text = "Score: "+p1.score;
            label3.Text = "Gold: "+p1.gold;
            label4.Text = "Level: "+p1.level;
            progressBar1.Maximum = p1.maxhp;
            progressBar1.Value = p1.hp;
            progressBar2.Value = p1.party;

            button1.Image = (Image)(new Bitmap(assets.pausee, new Size(57, 57)));
            button2.Image = (Image)(new Bitmap(assets.bom, new Size(57, 57)));
            button3.Image = (Image)(new Bitmap(assets.heal, new Size(70, 70)));
            button4.Image = (Image)(new Bitmap(assets.sog, new Size(70, 70)));
            button5.Image = (Image)(new Bitmap(assets.box, new Size(70, 70)));
            button6.Image = (Image)(new Bitmap(assets.play, new Size(57, 57)));

            textBox1.TextAlign = HorizontalAlignment.Center;
            r = new Random();
            fontext2 = new SolidBrush(Color.Yellow);
            fontext = new SolidBrush(Color.LightCyan);
            f = new Font("Comic Sans ms", 16);
            ctrSpawn = 0;

            foreach (Zombie z in arrZombie)
            {
                z.assets = assets;
                if (z is Jester) z.sprite = assets.jester[z.ctr];
                else if (z is George) z.sprite = assets.george[z.ctr];
                else if (z is AGeorge) z.sprite = assets.ageorge[z.ctr];
                else if (z is Beatrix) z.sprite = assets.beatrix[z.ctr];
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Image.FromFile("background.png"), 0, 0, 1120, 600);
            foreach (Zombie z in arrZombie)
            {
                g.DrawImage(z.sprite, z.x, z.y, z.sprite.Width / 2.3f, z.sprite.Height / 2.3f);
                if (!z.dead)
                {
                    if (z is Jester)
                    {
                        if (z.ketemu) g.DrawString(z.kata, f, fontext2, z.x + (z.sprite.Width * 0.05F), z.y + 135);
                        else g.DrawString(z.kata, f, fontext, z.x + (z.sprite.Width * 0.05F), z.y + 135);
                    }

                    if (z is George)
                    {
                        if (z.ketemu) g.DrawString(z.kata, f, fontext2, z.x + (z.sprite.Width * 0.05F), z.y + 165);
                        else g.DrawString(z.kata, f, fontext, z.x + (z.sprite.Width * 0.05F), z.y + 165);
                    }

                    if (z is AGeorge)
                    {
                        if (z.ketemu) g.DrawString(z.kata, f, fontext2, z.x + (z.sprite.Width * 0.05F), z.y + 165);
                        else g.DrawString(z.kata, f, fontext, z.x + (z.sprite.Width * 0.05F), z.y + 165);
                    }

                    if (z is Beatrix)
                    {
                        if (z.ketemu) g.DrawString(z.kata, f, fontext2, z.x + (z.sprite.Width * 0.05F), z.y + 185);
                        else g.DrawString(z.kata, f, fontext, z.x + (z.sprite.Width * 0.05F), z.y + 185);
                    }
                } 
            }
            if (imgExplode!=null)
            {
                g.DrawImage(imgExplode, 400, 150, 400, 400);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int k = textBox1.Text.Length;
            if (textBox1.Text.Equals(" "))
            {
                textBox1.Text = "";
            }
            foreach (Zombie z in arrZombie)
            {
                if (k > 0)
                {
                    if (z.kata.Length > k)
                    {
                        string ss = z.kata.Substring(0, k);
                        if (ss.ToLower().Equals(textBox1.Text)) z.ketemu = true;
                        else z.ketemu = false;
                    }
                }
                else z.ketemu = false;
            }
            if (textBox1.Text.Equals("ChEaT"))
            {
                timer1.Stop();
                timer2.Stop();
                Cheat c = new Cheat(p1);
                this.Hide();
                c.ShowDialog();
                this.Show();
                p1 = c.p1;
                label6.Text = "Tekan tombol play untuk melanjutkan!";
                label6.Visible = true;
                textBox1.Text = "";

                label1.Text = p1.hp + "/" + p1.maxhp;
                label2.Text = "Score: " + p1.score;
                label3.Text = "Gold: " + p1.gold;
                label4.Text = "Level: " + p1.level;
                progressBar1.Maximum = p1.maxhp;
                progressBar1.Value = p1.hp;

                cekValid();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (imgExplode!=null)
            {
                if (ctrExplode <= 12)
                {
                    imgExplode = assets.bomb[ctrExplode];
                    ctrExplode++;
                }
                else
                {
                    ctrExplode = 0;
                    imgExplode = null;
                }
            }
            foreach (Zombie z in arrZombie)
            {
                if (!z.dead)
                {
                    if(p1.party>0) z.x += z.speed * 15/10;
                    else z.x += z.speed;
                }
                if (z is Jester) ((Jester)z).gantiAnimasi(assets.jester);
                if (z is George) ((George)z).gantiAnimasi(assets.george);
                if (z is AGeorge) ((AGeorge)z).gantiAnimasi(assets.ageorge);
                if (z is Beatrix) ((Beatrix)z).gantiAnimasi(assets.beatrix);
            }
            int d = 0;
            for (int i = arrZombie.Count - 1; i >= 0; i--)
            {
                if (arrZombie[i].x >= 1000)
                {
                    p1.hp -= arrZombie[i].damage;
                    if (progressBar1.Value - arrZombie[i].damage > 0)
                    {
                        progressBar1.Value -= arrZombie[i].damage;
                        label1.Text = p1.hp + "/" + p1.maxhp;
                    }
                    else
                    {
                        progressBar1.Value = 0;
                        label1.Text = "0/" + p1.maxhp;
                        dead = true;
                    }
                    arrZombie.RemoveAt(i);
                }
                if (arrZombie[i] is Jester)
                {
                    if (arrZombie[i].ctr == 18)
                    {
                        if (arrZombie[i].doubled)
                        {
                            p1.score += arrZombie[i].score * 2;
                            p1.gold += arrZombie[i].gold * 2;
                        }
                        else
                        {
                            p1.score += arrZombie[i].score;
                            p1.gold += arrZombie[i].gold;
                        }
                        if (p1.efekSog > 0 && !bomb2)
                        {
                            p1.efekSog--;
                            p1.gold += 200;
                        }
                        if (!bomb2) p1.kill++;
                        if (p1.kill % 5 == 0 && p1.party == 0)
                        {
                            p1.level++;
                            p1.efekBox--;
                            p1.gold += 1000;
                            label4.Text = "Level: " + p1.level;
                        }
                        label2.Text = "Score: " + p1.score;
                        label3.Text = "Gold: " + p1.gold;
                        
                        arrZombie.RemoveAt(i);

                        d = 1;
                    }
                }
                else
                {
                    if (arrZombie[i].ctr == 13)
                    {
                        if (arrZombie[i].doubled)
                        {
                            p1.score += arrZombie[i].score * 2;
                            p1.gold += arrZombie[i].gold * 2;
                        }
                        else
                        {
                            p1.score += arrZombie[i].score;
                            p1.gold += arrZombie[i].gold;
                        }
                        if (p1.efekSog > 0 && !bomb2)
                        {
                            p1.efekSog--;
                            p1.gold += 200;
                        }
                        if (!bomb2) p1.kill++;
                        if (p1.kill%5==0 && p1.party==0)
                        {
                            p1.level++;
                            p1.efekBox--;
                            p1.gold += 1000;
                            label4.Text = "Level: "+p1.level;
                        }
                        label2.Text = "Score: " + p1.score;
                        label3.Text = "Gold: " + p1.gold;

                        arrZombie.RemoveAt(i);

                        d = 1;
                    }
                }
            }
            if (p1.efekSog == 0 && p1.sog > 0) button4.Enabled = true;
            if (bomb2 && d == 1) bomb2 = false;
            if (p1.level % 3 == 0 && p1.party == 0)
            {
                p1.party = 100;
                progressBar2.Value = p1.party;
                label5.Visible = true;
            }
            else if (p1.level % 3 == 0)
            {
                //kecepatan,gold,skor semua zombie ditambah
                //kecepatan spawn ditambah
                p1.party -= 1;
                progressBar2.Value = p1.party;
                if (p1.party==0)
                {
                    p1.level++;
                    p1.efekBox--;
                    label4.Text = "Level: "+p1.level;
                    label5.Visible = false;
                }
            }

            Invalidate();
            if (dead)
            {
                timer1.Stop();
                timer2.Stop();
                string query = $"Update player set status = '0' where Id='"+p1.id+"'";
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                query = $"Update Highscore set status = '0' where id_player='" + p1.id + "'";
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Game Over!");
                this.Close();
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString().Equals("Space"))
            {
                foreach (Zombie z in arrZombie)
                {
                    if (z.kata.Equals(textBox1.Text))
                    {
                        z.hp -= 1;
                        z.kata = assets.randomKata();
                        if (z.hp <= 0)
                        {
                            if (p1.party > 0) z.doubled = true;
                            z.dead = true;
                        }
                    }
                    z.ketemu = false;
                }
                textBox1.Text = "";
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (label7.Visible)
            {
                if (ctrLabel > 0) ctrLabel--;
                else label7.Visible = false;
            }
            int cd = 3;
            if (p1.party>0) cd = 2;
            if (ctrSpawn == cd)
            {
                int jumlah = r.Next(1, 3);
                int tempY = 0;
                for (int i = 0; i < jumlah; i++)
                {
                    int jenis = r.Next(0, 4);
                    int y;
                    bool lewat = false;
                    do
                    {
                        y = r.Next(0, 5);
                        if (i == 0)
                        {
                            tempY = y;
                            lewat = true;
                        }
                        else
                        {
                            if (tempY != y) lewat = true;
                        }
                    } while (lewat == false);
                    
                    if (y == 0) y = -50;
                    else if (y == 1) y = 60;
                    else if (y == 2) y = 160;
                    else if (y == 3) y = 250;
                    else if (y == 4) y = 350;

                    if (jenis == 0)
                    {
                        y += 50;
                        arrZombie.Add(new Jester(0, y, assets, assets.randomKata(), assets.jester[0]));
                    }
                    else if (jenis == 1) arrZombie.Add(new George(0, y, assets, assets.randomKata(), assets.george[0]));
                    else if (jenis == 2) arrZombie.Add(new AGeorge(0, y, assets, assets.randomKata(), assets.ageorge[0]));
                    else if (jenis == 3) arrZombie.Add(new Beatrix(0, y, assets, assets.randomKata(), assets.beatrix[0]));

                    if (p1.efekBox > 0) arrZombie[arrZombie.Count - 1].hp = 1;
                }
                ctrSpawn = 0;
            }
            
            Invalidate();
            ctrSpawn++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            timer1.Stop();
            timer2.Stop();
            Pause p = new Pause(p1,arrZombie,assets);
            p.ShowDialog();
            if (p.end)
            {
                this.Close();
            }
            else
            {
                label6.Text = "Tekan tombol play untuk melanjutkan!";
                label6.Visible = true;
                this.Show();
                p1 = p.p1;

                label1.Text = p1.hp + "/" + p1.maxhp;
                label2.Text = "Score: " + p1.score;
                label3.Text = "Gold: " + p1.gold;
                label4.Text = "Level: " + p1.level;
                progressBar1.Maximum = p1.maxhp;
                progressBar1.Value = p1.hp;
                cekValid();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label6.Visible = false;
            timer1.Start();
            timer2.Start();

            cekValid();
        }

        private void cekValid()
        {
            if (p1.bomb > 0) button2.Enabled = true;
            else button2.Enabled = false;
            if (p1.heal>0) button3.Enabled = true;
            else button3.Enabled = false;
            if (p1.sog>0 && p1.efekSog==0) button4.Enabled = true;
            else button4.Enabled = false;
            if (p1.aBox>0 && p1.efekBox==0) button5.Enabled = true;
            else button5.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            p1.bomb -= 1;
            imgExplode = assets.bomb[0];
            foreach (Zombie z in arrZombie)
            {
                z.dead = true;
            }
            cekValid();
            label7.Text = "Bomb berhasil dipakai! " + p1.bomb + " Bomb tersisa.";
            label7.Visible = true;
            ctrLabel = 2;
            bomb2 = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (p1.hp<p1.maxhp)
            {
                p1.heal -= 1;
                p1.hp += 500;
                if (p1.hp > p1.maxhp) p1.hp = p1.maxhp;
                progressBar1.Value = p1.hp;
                label1.Text = p1.hp + "/" + p1.maxhp;
                cekValid();
                label7.Text = "Massive Heal berhasil dipakai! " + p1.heal + " Massive Heal tersisa.";
                label7.Visible = true;
                ctrLabel = 2;
            }
            else
            {
                label7.Text = "HP sudah maksimal! ";
                label7.Visible = true;
                ctrLabel = 2;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            p1.sog -= 1;
            p1.efekSog = 10;
            label7.Text = "Sack of Gold berhasil dipakai! " + p1.sog + " Sack of Gold tersisa.";
            label7.Visible = true;
            ctrLabel = 2;
            cekValid();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            p1.aBox -= 1;
            p1.efekBox = 2;
            label7.Text = "Angel Box berhasil dipakai! " + p1.aBox + " Angel Box tersisa.";
            label7.Visible = true;
            ctrLabel = 2;

            foreach (Zombie z in arrZombie)
            {
                z.hp = 1;
            }
            cekValid();
        }
    }
}
