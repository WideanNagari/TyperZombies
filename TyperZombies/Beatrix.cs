using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyperZombies
{
    public class Beatrix : Zombie
    {
        public Beatrix(int x, int y, Asset assets, string kata, Image img) : base(x, y, assets,kata,img)
        {
            ctr = 0;
            damage = 300;
            gold = 175;
            score = 350;
            hp = 2;
            speed = 3;
        }

        public void gantiAnimasi(List<Image> arrImg)
        {
            if (!dead)
            {
                if (ctr > 5)
                {
                    ctr = 0;
                }
                sprite = arrImg[ctr];
                ctr++;
            }
            else
            {
                if (ctr2 == 0)
                {
                    ctr2 = 1;
                    ctr = 6;
                }
            }

            if (dead)
            {
                if (ctr > 13)
                {
                    ctr = 6;
                }
                sprite = arrImg[ctr];
                ctr++;
            }
        }
    }
}
