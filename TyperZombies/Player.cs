using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyperZombies
{
    public class Player
    {
        public string nama { get; set; }
        public int level { get; set; }
        public int score { get; set; }
        public int gold { get; set; }
        public int hp { get; set; }
        public int maxhp { get; set; }
        public int kill { get; set; }
        public int party { get; set; }
        public int bomb { get; set; }
        public int heal { get; set; }
        public int hpBooster { get; set; }
        public int sog { get; set; }
        public int aBox { get; set; }

        public Player(string nama, int level, int score, int gold, int hp, int maxhp, int kill, int party, int bomb, int heal, int hpBooster, int sog, int aBox)
        {
            this.nama = nama;
            this.level = level;
            this.score = score;
            this.gold = gold;
            this.hp = hp;
            this.maxhp = maxhp;
            this.kill = kill;
            this.party = party;
            this.bomb = bomb;
            this.heal = heal;
            this.hpBooster = hpBooster;
            this.sog = sog;
            this.aBox = aBox;
        }

        public Player(string nama)
        {
            this.nama = nama;
            this.level = 1;
            this.score = 0;
            this.gold = 0;
            this.hp = 1500;
            this.maxhp = 1500;
            this.kill = 0;
            this.party = 0;
            this.bomb = 0;
            this.heal = 0;
            this.hpBooster = 1;
            this.sog = 0;
            this.aBox = 0;
        }
    }
}
