using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _1Zadanie
{
    class CharsOfSecondString
    {
        List<int> AllSecondChars = new List<int>()
        {
            {0 },
            {0 },
            {0 },
            {0 }

        };
        AllDatas ad = new AllDatas();
        List<int> SecondChars = new List<int>();
        public CharsOfSecondString()
        {
            SecondChars = ad.ListOfChars;


        }
        internal List<int> CharsCals(string Second)
        {
            SecondChars.Clear();
            for (int i = 0; i <= 3; i++)
            {
                AllSecondChars[i] = 0;

            }
            
            //MessageBox.Show(First.Length+"|");
            foreach (char s in Second)
            {
                if (char.IsLetter(s))
                {
                    AllSecondChars[0] += 1;
                    //MessageBox.Show(AllChars[0]+"");
                }
                else if (char.IsDigit(s))
                    AllSecondChars[1] += 1;
                else if (char.IsWhiteSpace(s))
                    AllSecondChars[2] += 1;
                else
                {
                    AllSecondChars[3] += 1;

                }


            }
            foreach (int i in AllSecondChars)
            {
                SecondChars.Add(i);
                
            }


            return SecondChars;

        }



    }
}
