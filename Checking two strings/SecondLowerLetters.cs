using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Zadanie
{
    class SecondLowerLetters
    {
        AllDatas ad = new AllDatas();
        internal int LowerL = 0;
        public SecondLowerLetters()
        {
            LowerL = ad.LowerLetters;

        }
        internal int LowerSecond(string Second)
        {
            LowerL = 0;
            foreach (char r in Second)
            {
                if (char.ToUpper(r) != r && char.IsLetter(r))
                    LowerL++;

            }
            return LowerL;
        }
    }
}
