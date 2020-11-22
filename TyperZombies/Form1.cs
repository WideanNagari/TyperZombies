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
    public partial class Form1 : Form
    {
        Player p1;
        public Form1(Player p)
        {
            InitializeComponent();
            p1 = p;
        }
        Asset assets;
        List<Zombie> arrZombie;
        Random r;
        int ctrSpawn;
        
        Brush fontext;
        Brush fontext2;
        Font f;
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = p1.hp+"/"+ p1.maxhp;
            label2.Text = "Score: "+p1.score;
            label3.Text = "Gold: "+p1.gold;
            label4.Text = "Level: "+p1.level;
            progressBar1.Maximum = p1.maxhp;
            progressBar1.Value = p1.hp;
            progressBar2.Value = p1.party;
            cekValid();

            button1.Image = (Image)(new Bitmap(Image.FromFile("./asset2/pauseI.png"), new Size(57, 57)));
            button2.Image = (Image)(new Bitmap(Image.FromFile("./asset2/bomb.png"), new Size(57, 57)));
            button3.Image = (Image)(new Bitmap(Image.FromFile("./asset2/heal.png"), new Size(70, 70)));
            button4.Image = (Image)(new Bitmap(Image.FromFile("./asset2/gold.png"), new Size(70, 70)));
            button5.Image = (Image)(new Bitmap(Image.FromFile("./asset2/box.png"), new Size(70, 70)));
            button6.Image = (Image)(new Bitmap(Image.FromFile("./asset2/play.png"), new Size(57, 57)));

            textBox1.TextAlign = HorizontalAlignment.Center;
            r = new Random();
            assets = new Asset();
            arrZombie = new List<Zombie>();
            fontext2 = new SolidBrush(Color.Yellow);
            fontext = new SolidBrush(Color.LightCyan);
            f = new Font("Comic Sans ms", 16);
            ctrSpawn = 0;
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
                        p1.kill++;
                        if (p1.kill % 5 == 0 && p1.party == 0)
                        {
                            p1.level++;
                            p1.gold += 1000;
                            label4.Text = "Level: " + p1.level;
                        }
                        label2.Text = "Score: " + p1.score;
                        label3.Text = "Gold: " + p1.gold;

                        arrZombie.RemoveAt(i);
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
                        p1.kill++;
                        if (p1.kill%5==0 && p1.party==0)
                        {
                            p1.level++;
                            p1.gold += 1000;
                            label4.Text = "Level: "+p1.level;
                        }
                        label2.Text = "Score: " + p1.score;
                        label3.Text = "Gold: " + p1.gold;

                        arrZombie.RemoveAt(i);
                    }
                }
            }
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
                    label4.Text = "Level: "+p1.level;
                    label5.Visible = false;
                }
            }
            Invalidate();
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
            int cd = 3;
            if (p1.party>0) cd = 2;
            if (ctrSpawn == cd)
            {
                int jumlah = r.Next(1, 3);
                for (int i = 0; i < jumlah; i++)
                {
                    int jenis = r.Next(0, 4);
                    int y = r.Next(50, 341);
                    if (jenis == 0) arrZombie.Add(new Jester(0, y, assets, assets.randomKata(), assets.jester[0]));
                    else if (jenis == 1) arrZombie.Add(new George(0, y, assets, assets.randomKata(), assets.george[0]));
                    else if (jenis == 2) arrZombie.Add(new AGeorge(0, y, assets, assets.randomKata(), assets.ageorge[0]));
                    else if (jenis == 3) arrZombie.Add(new Beatrix(0, y, assets, assets.randomKata(), assets.beatrix[0]));
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
            Pause p = new Pause(p1);
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
        }

        private void cekValid()
        {
            if (p1.bomb > 0) button2.Enabled = true;
            else button2.Enabled = false;
            if (p1.heal>0) button3.Enabled = true;
            else button3.Enabled = false;
            if (p1.sog>0) button4.Enabled = true;
            else button4.Enabled = false;
            if (p1.aBox>0) button5.Enabled = true;
            else button5.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            p1.bomb -= 1;
            cekValid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            p1.heal -= 1;
            cekValid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            p1.sog -= 1;
            cekValid();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            p1.aBox -= 1;
            cekValid();
        }
    }
}
