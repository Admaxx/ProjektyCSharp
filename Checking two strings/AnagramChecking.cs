using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _1Zadanie
{
    class AnagramChecking
    {
        internal bool Anagram(string First, string Second) 
        {
            
            if (First.ToUpper() != Second.ToUpper())
                return 
                string.Concat(First.ToUpper().Where(char.IsLetter) //Sprawdzam, czy ułożone alfabetycznie znaki ciągu
                .OrderBy(item => item))                            
                ==
                string.Concat(Second.ToUpper().Where(char.IsLetter) //równają się z ułożonymi alfabetycznie znakami ciągu drugiego
                .OrderBy(item => item));
            else
            {
                return false;

            }
            
        }

    }
}
