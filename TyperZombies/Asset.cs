using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyperZombies
{
    public class Asset
    {
        public List<Image> jester { get; set; }
        public List<Image> george { get; set; }
        public List<Image> ageorge { get; set; }
        public List<Image> beatrix { get; set; }
        public List<Image> bomb { get; set; }
        public List<string> bankKata { get; set; }

        //highscore
        public Image evan { get; set; }
        public Image indah { get; set; }
        public Image valent { get; set; }
        public Image widean { get; set; }

        //background
        public Image background { get; set; }

        //item
        public Image bom { get; set; }
        public Image heal { get; set; }
        public Image hp { get; set; }
        public Image sog { get; set; }
        public Image box { get; set; }

        public Image pausee { get; set; }
        public Image play { get; set; }

        //tulisan
        public Image about { get; set; }
        public Image back { get; set; }
        public Image cheat { get; set; }
        public Image cont { get; set; }
        public Image exit { get; set; }
        public Image high { get; set; }
        public Image logo { get; set; }
        public Image newGame { get; set; }
        public Image pause { get; set; }
        public Image shop { get; set; }
        public Image status { get; set; }

        Random r;
        public Asset()
        {
            jester = new List<Image>();
            jester.Add(Image.FromFile("./Zombie4/Walk1.png"));
            jester.Add(Image.FromFile("./Zombie4/Walk2.png"));
            jester.Add(Image.FromFile("./Zombie4/Walk3.png"));
            jester.Add(Image.FromFile("./Zombie4/Walk4.png"));
            jester.Add(Image.FromFile("./Zombie4/Walk5.png"));
            jester.Add(Image.FromFile("./Zombie4/Walk6.png"));
            jester.Add(Image.FromFile("./Zombie4/Walk7.png"));
            jester.Add(Image.FromFile("./Zombie4/Walk8.png"));
            jester.Add(Image.FromFile("./Zombie4/Walk9.png"));
            jester.Add(Image.FromFile("./Zombie4/Walk10.png"));
            jester.Add(Image.FromFile("./Zombie4/Dead1.png"));
            jester.Add(Image.FromFile("./Zombie4/Dead2.png"));
            jester.Add(Image.FromFile("./Zombie4/Dead3.png"));
            jester.Add(Image.FromFile("./Zombie4/Dead4.png"));
            jester.Add(Image.FromFile("./Zombie4/Dead5.png"));
            jester.Add(Image.FromFile("./Zombie4/Dead6.png"));
            jester.Add(Image.FromFile("./Zombie4/Dead7.png"));
            jester.Add(Image.FromFile("./Zombie4/Dead8.png"));

            george = new List<Image>();
            george.Add(Image.FromFile("./Zombie1/Walk1.png"));
            george.Add(Image.FromFile("./Zombie1/Walk2.png"));
            george.Add(Image.FromFile("./Zombie1/Walk3.png"));
            george.Add(Image.FromFile("./Zombie1/Walk4.png"));
            george.Add(Image.FromFile("./Zombie1/Walk5.png"));
            george.Add(Image.FromFile("./Zombie1/Walk6.png"));
            george.Add(Image.FromFile("./Zombie1/Dead1.png"));
            george.Add(Image.FromFile("./Zombie1/Dead2.png"));
            george.Add(Image.FromFile("./Zombie1/Dead3.png"));
            george.Add(Image.FromFile("./Zombie1/Dead4.png"));
            george.Add(Image.FromFile("./Zombie1/Dead5.png"));
            george.Add(Image.FromFile("./Zombie1/Dead6.png"));
            george.Add(Image.FromFile("./Zombie1/Dead7.png"));
            george.Add(Image.FromFile("./Zombie1/Dead8.png"));

            ageorge = new List<Image>();
            ageorge.Add(Image.FromFile("./Zombie2/Walk1.png"));
            ageorge.Add(Image.FromFile("./Zombie2/Walk2.png"));
            ageorge.Add(Image.FromFile("./Zombie2/Walk3.png"));
            ageorge.Add(Image.FromFile("./Zombie2/Walk4.png"));
            ageorge.Add(Image.FromFile("./Zombie2/Walk5.png"));
            ageorge.Add(Image.FromFile("./Zombie2/Walk6.png"));
            ageorge.Add(Image.FromFile("./Zombie2/Dead1.png"));
            ageorge.Add(Image.FromFile("./Zombie2/Dead2.png"));
            ageorge.Add(Image.FromFile("./Zombie2/Dead4.png"));
            ageorge.Add(Image.FromFile("./Zombie2/Dead3.png"));
            ageorge.Add(Image.FromFile("./Zombie2/Dead5.png"));
            ageorge.Add(Image.FromFile("./Zombie2/Dead6.png"));
            ageorge.Add(Image.FromFile("./Zombie2/Dead7.png"));
            ageorge.Add(Image.FromFile("./Zombie2/Dead8.png"));

            beatrix = new List<Image>();
            beatrix.Add(Image.FromFile("./Zombie3/Walk1.png"));
            beatrix.Add(Image.FromFile("./Zombie3/Walk2.png"));
            beatrix.Add(Image.FromFile("./Zombie3/Walk3.png"));
            beatrix.Add(Image.FromFile("./Zombie3/Walk4.png"));
            beatrix.Add(Image.FromFile("./Zombie3/Walk5.png"));
            beatrix.Add(Image.FromFile("./Zombie3/Walk6.png"));
            beatrix.Add(Image.FromFile("./Zombie3/Dead1.png"));
            beatrix.Add(Image.FromFile("./Zombie3/Dead2.png"));
            beatrix.Add(Image.FromFile("./Zombie3/Dead3.png"));
            beatrix.Add(Image.FromFile("./Zombie3/Dead4.png"));
            beatrix.Add(Image.FromFile("./Zombie3/Dead5.png"));
            beatrix.Add(Image.FromFile("./Zombie3/Dead6.png"));
            beatrix.Add(Image.FromFile("./Zombie3/Dead7.png"));
            beatrix.Add(Image.FromFile("./Zombie3/Dead8.png"));

            bomb = new List<Image>();
            bomb.Add(Image.FromFile("./Bomb/bomb1.png"));
            bomb.Add(Image.FromFile("./Bomb/bomb2.png"));
            bomb.Add(Image.FromFile("./Bomb/bomb3.png"));
            bomb.Add(Image.FromFile("./Bomb/bomb4.png"));
            bomb.Add(Image.FromFile("./Bomb/bomb5.png"));
            bomb.Add(Image.FromFile("./Bomb/bomb6.png"));
            bomb.Add(Image.FromFile("./Bomb/bomb7.png"));
            bomb.Add(Image.FromFile("./Bomb/bomb8.png"));
            bomb.Add(Image.FromFile("./Bomb/bomb9.png"));
            bomb.Add(Image.FromFile("./Bomb/bomb10.png"));
            bomb.Add(Image.FromFile("./Bomb/bomb11.png"));
            bomb.Add(Image.FromFile("./Bomb/bomb12.png"));
            bomb.Add(Image.FromFile("./Bomb/bomb13.png"));

            evan = Image.FromFile("./asset2/evan.png");
            indah = Image.FromFile("./asset2/indah.png");
            valent = Image.FromFile("./asset2/valentino.png");
            widean = Image.FromFile("./asset2/widean.png");

            background = Image.FromFile("background.png");

            bom = Image.FromFile("./asset2/bomb.png");
            heal = Image.FromFile("./asset2/heal.png");
            hp = Image.FromFile("./asset2/Hp.png");
            sog = Image.FromFile("./asset2/gold.png");
            box = Image.FromFile("./asset2/box.png");

            about = Image.FromFile("./asset2/about.png");
            back = Image.FromFile("./asset2/back.png");
            cheat = Image.FromFile("./asset2/Cheat.png");
            cont = Image.FromFile("./asset2/continue.png");
            exit = Image.FromFile("./asset2/exit.png");
            high = Image.FromFile("./asset2/high-score.png");
            logo = Image.FromFile("./asset2/logo.png");
            newGame = Image.FromFile("./asset2/new-game.png");
            pause = Image.FromFile("./asset2/Pause.png");
            shop = Image.FromFile("./asset2/shop.png");
            status = Image.FromFile("./asset2/status.png");

            pausee = Image.FromFile("./asset2/pauseI.png");
            play = Image.FromFile("./asset2/play.png");

            bankKata = new List<string>();
            StreamReader sr = new StreamReader("bankKata.txt");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                bankKata.Add(line);
            }
            sr.Close();

            r = new Random();
        }

        public string randomKata()
        {
            int idx = r.Next(0,499);
            return bankKata[idx];
        }
    }
}
