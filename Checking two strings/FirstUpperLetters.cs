using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Zadanie
{
    class FirstUpperLetters
    {
        AllDatas ad = new AllDatas();
        internal int UpperL = 0;
        public FirstUpperLetters()
        {

            UpperL = ad.UpperLetters;


        }
        internal int UpperFirst(string First)
        {
            UpperL = 0;
            foreach (char r in First)
            {
                if (char.ToUpper(r) == r && char.IsLetter(r))
                    UpperL++;


            }
            return UpperL;
        }

    }
}
