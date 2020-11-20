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
        public Form1()
        {
            InitializeComponent();
        }
        Player p1;
        Asset assets;
        List<Zombie> arrZombie;
        Random r;
        int ctrSpawn;
        
        Brush fontext;
        Brush fontext2;
        Font f;
        private void Form1_Load(object sender, EventArgs e)
        {
            p1 = new Player("Widean");
            label1.Text = p1.hp+"/"+ p1.maxhp;
            label2.Text = "Score: "+p1.score;
            label3.Text = "Gold: "+p1.gold;
            label4.Text = "Level: "+p1.level;
            progressBar1.Maximum = p1.maxhp;
            progressBar1.Value = p1.hp;

            r = new Random();
            assets = new Asset();
            arrZombie = new List<Zombie>();
            fontext2 = new SolidBrush(Color.Yellow);
            fontext = new SolidBrush(Color.LightCyan);
            f = new Font("Comic Sans ms", 16);
            int jumlah = r.Next(1, 4);
            for (int i = 0; i < jumlah; i++)
            {
                int jenis = r.Next(0, 4);
                int y = r.Next(50, 341);
                string rKata = assets.randomKata();
                if (jenis == 0) arrZombie.Add(new Jester(0, y, assets, rKata, assets.jester[0]));
                else if (jenis == 1) arrZombie.Add(new George(0, y, assets, rKata, assets.george[0]));
                else if (jenis == 2) arrZombie.Add(new AGeorge(0, y, assets, rKata, assets.ageorge[0]));
                else if (jenis == 3) arrZombie.Add(new Beatrix(0, y, assets, rKata, assets.beatrix[0]));
            }
            ctrSpawn = 0;
            textBox1.TextAlign = HorizontalAlignment.Center;
            timer1.Start();
            timer2.Start();
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
            
            //jester j.y+135
            //beatrix j.y+185
            //george & ageorge = j.y+165
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
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Zombie z in arrZombie)
            {
                if (!z.dead) z.x += z.speed;
                if (z is Jester) ((Jester)z).gantiAnimasi(assets.jester);
                if (z is George) ((George)z).gantiAnimasi(assets.george);
                if (z is AGeorge) ((AGeorge)z).gantiAnimasi(assets.ageorge);
                if (z is Beatrix) ((Beatrix)z).gantiAnimasi(assets.beatrix);
            }
            for (int i = arrZombie.Count - 1; i >= 0; i--)
            {
                if (arrZombie[i] is Jester)
                {
                    if (arrZombie[i].ctr == 18)
                    {
                        p1.score += arrZombie[i].score;
                        p1.gold += arrZombie[i].gold;
                        label2.Text = "Score: " + p1.score;
                        label3.Text = "Gold: " + p1.gold;

                        arrZombie.RemoveAt(i);
                    }
                }
                else
                {
                    if (arrZombie[i].ctr == 13)
                    {
                        p1.score += arrZombie[i].score;
                        p1.gold += arrZombie[i].gold;
                        label2.Text = "Score: " + p1.score;
                        label3.Text = "Gold: " + p1.gold;

                        arrZombie.RemoveAt(i);
                    }
                }

                if (arrZombie[i].x >= 1050)
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
                        z.dead = true;
                    }
                    z.ketemu = false;
                }
                textBox1.Text = "";
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (ctrSpawn == 3)
            {
                int jumlah = r.Next(1, 4);
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
    }
}
