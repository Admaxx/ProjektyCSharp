using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Zadanie
{
    class AnagramResult
    {

        AnagramChecking ac = new AnagramChecking();
        internal string Anagram(string First, string Second)
        {
            return "Status anagramu: " + ac.Anagram(First, Second);



        }

    }
}
