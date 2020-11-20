using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyperZombies
{
    public class Zombie
    {
        public int x { get; set; }
        public int y { get; set; }
        public bool dead { get; set; }
        public bool ketemu { get; set; }
        public bool doubled { get; set; }
        public int ctr { get; set; }
        public int ctr2 { get; set; }
        public Image sprite { get; set; }
        public int damage { get; set; }
        public int gold { get; set; }
        public int score { get; set; }
        public int hp { get; set; }
        public int speed { get; set; }
        public string kata { get; set; }
        protected Asset assets;

        public Zombie(int x, int y, Asset assets, string kata, Image img)
        {
            this.sprite = img;
            this.kata = kata;
            this.ctr = 0;
            this.ctr2 = 0;
            this.x = x;
            this.y = y;
            this.dead = false;
            this.assets = assets;
            this.ketemu = false;
            this.doubled = false;
        }
    }
}
