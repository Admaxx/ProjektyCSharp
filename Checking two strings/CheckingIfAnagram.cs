using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _1Zadanie
{
    class CheckingIfAnagram
    {
        AnagramChecking ac = new AnagramChecking();
        internal string Anagram(string First, string Second)
        {
            return "Status anagramu: " + ac.Anagram(First, Second);



        }
    }
}
