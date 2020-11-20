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

        public Player(string nama, int level, int score, int gold, int hp, int maxhp)
        {
            this.nama = nama;
            this.level = level;
            this.score = score;
            this.gold = gold;
            this.hp = hp;
            this.maxhp = maxhp;
        }

        public Player(string nama)
        {
            this.nama = nama;
            this.level = 1;
            this.score = 0;
            this.gold = 0;
            this.hp = 1500;
            this.maxhp = 1500;
        }
    }
}
