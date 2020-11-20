﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyperZombies
{
    public class AGeorge : Zombie
    {
        public AGeorge(int x, int y, Asset assets, string kata) : base(x, y, assets, kata)
        {
            ctr = 0;
            damage = 150;
            gold = 130;
            score = 275;
            hp = 2;
            speed = 60;
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