using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Zadanie
{
    class FirstLowerLetters
    {
        AllDatas ad = new AllDatas();
        internal int LowerL = 0;
        public FirstLowerLetters()
        {
            LowerL = ad.LowerLetters;

        }
        internal int LowerFirst(string First)
        {
            LowerL = 0;
            foreach (char r in First)
            {
                if (char.ToUpper(r) != r && char.IsLetter(r))
                    LowerL++;

            }
            return LowerL;
        }
    }
}
