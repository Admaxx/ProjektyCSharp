using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _1Zadanie
{
    class CheckIfPalindrome : AllDatas
    {

        internal bool Palindrome(string First, string Second)
        {
            ReversedString = "";
            foreach (char v in Second.Reverse())
            {
                ReversedString += v;
                
            }
            //MessageBox.Show(First.ToUpper() + "|" + ReversedString.ToUpper());
            return First.ToUpper() == ReversedString.ToUpper();


        }


    }
}
