using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _1Zadanie
{
    class NumberOfVowels
    {
        CheckFirstString first = new CheckFirstString();
        CheckSecondString second = new CheckSecondString();
        AllDatas ad = new AllDatas();
        Dictionary<int, string> vowels = new Dictionary<int, string>();
        public NumberOfVowels()
        {
            vowels = ad.Vowels;


        }

        internal string Check(string First, string Second)
        {

            return "Pierwszy ciąg znaków ma "
                + first.Check(First, vowels) + ", a drugi "
                + second.Check(Second, vowels) + " samogłosek/i";

        }


    }
}
