using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipsFinal
{
    class RandomPlace : AllDatas
    {
        Random rand = new Random();
        internal int RandomVal() => rand.Next(minSize, maxSize);
    }
}
