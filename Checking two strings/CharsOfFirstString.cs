using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _1Zadanie
{
    class CharsOfFirstString
    {
        
        List<int> AllFirstChars = new List<int>()
        {
            {0 },
            {0 },
            {0 },
            {0 }

        };
        AllDatas ad = new AllDatas();
        List<int> FirstChars = new List<int>();
        public CharsOfFirstString()
        {
            FirstChars = ad.ListOfChars;


        }
        internal List<int> CharsCals(string First)
        {
            FirstChars.Clear();
            for(int i = 0;i <= 3;i++)
            {
                AllFirstChars[i] = 0;

            }
            FirstChars.Clear();
            //MessageBox.Show(First.Length+"|");
            foreach(char s in First)
            {
                if (char.IsLetter(s))
                {
                    AllFirstChars[0] += 1;
                    //MessageBox.Show(AllChars[0]+"");
                }
                else if (char.IsDigit(s))
                    AllFirstChars[1] += 1;
                else if (char.IsWhiteSpace(s))
                    AllFirstChars[2] += 1;
                else
                {
                    AllFirstChars[3] += 1;

                }


            }
            foreach(int i in AllFirstChars)
            {
                FirstChars.Add(i);
                
            }


            return FirstChars;

        }



    }
}
