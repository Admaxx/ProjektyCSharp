using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Zadanie
{
    class ChooseRandomWords
    {
        AllDatas ad = new AllDatas();
        int Key = 0;
        internal List<string> RandomWordsList = new List<string>();
        public ChooseRandomWords()
        {
            Key = ad.Key;
        }
        internal List<string> Words()
        {
            Random r = new Random();
            for (int i = 0; i <= 1; i++) {
                var RanWords = from f in ad.RandomWords //Wyszukuję ciągi znaków, które odpowiadają wylosowanemu kluczowi w słowniku.
                               where f.Key == r.Next(0, ad.RandomWords.Count - 1)
                               select new
                               {
                                   f.Value
                               };
                RanWords.ToList().ForEach(item => RandomWordsList.Add(item.Value));
            }

            return RandomWordsList;
        }

    }
}
