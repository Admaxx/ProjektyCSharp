using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Zadanie
{
    internal class AllDatas
    {
        internal List<int> ListOfChars = new List<int>();

        internal string ReversedString = "";

        internal int Key = 0;

        internal int UpperLetters = 0;
        internal int LowerLetters = 0;
        
        internal Dictionary<int,string> Vowels = new Dictionary<int, string>()
        {
            {1, "A" },
            {2, "Ą" },
            {3, "E" },
            {4, "Ę" },
            {5, "I" },
            {6, "O" },
            {7, "U" },
            {8, "Y" },
            {9, "Ó" }
        };
        internal Dictionary<int, string> RandomWords = new Dictionary<int, string>()
        {
            {0, "Garnek"},
            {1, "Barok" },
            {2, "Dywan"},
            {3, "Niebieski ptak"},
            {4, "Samochód"},
            {5, "Al Funcoot"},
            {6, "Count Olaf"},
            {7, "kobra"},
            {8, "robak"},
            {9, "Salvador Dali" },
            {10, "Avida Dollars"},
            {11, "Tom Marvolo Riddle" },
            {12, "I am Lord Voldemort" },
            {13, "Z łbem na łapie chudy pies śpi po łapy owej kres" },
            {14, "Pewnie podpieprzyłaś suchej kiełbasy, małpo!"}

        };


    }
}
