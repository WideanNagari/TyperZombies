using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyperZombies
{
    public class Jester : Zombie
    {
        public Jester(int x, int y, Asset assets, string kata, Image img) : base(x, y, assets, kata, img)
        {
            damage = 100;
            gold = 50;
            score = 100;
            hp = 1;
            speed = 8;
        }

        public void gantiAnimasi(List<Image> arrImg)
        {
            if (!dead)
            {
                if (ctr > 9)
                {
                    ctr = 0;
                }
                sprite = arrImg[ctr];
                ctr++;
            }
            else
            {
                if (ctr2==0)
                {
                    ctr2 = 1;
                    ctr = 10;
                }
            }

            if (dead)
            {
                sprite = arrImg[ctr];
                ctr++;
            }
        }
    }
}
