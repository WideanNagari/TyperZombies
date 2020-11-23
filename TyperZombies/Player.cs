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
        public int efekSog { get; set; }
        public int efekBox { get; set; }
        public string id { get; set; }

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
            this.efekSog = 0;
            this.efekBox = 0;
        }
    }
}
