using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Zadanie
{
    class SecondUpperLetters
    {
        AllDatas ad = new AllDatas();
        internal int UpperL = 0;
        public SecondUpperLetters()
        {
            UpperL = ad.UpperLetters;

        }
        internal int UpperSecond(string Second)
        {
            UpperL = 0;
            foreach (char r in Second)
            {
                if (char.ToUpper(r) == r && char.IsLetter(r))
                    UpperL++;

            }
            return UpperL;
        }
    }
}
