using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Zadanie
{
    class CheckFirstString
    {
        internal int Check(string First, Dictionary<int, string> Vowels)
        {
            List<string> Numbers = new List<string>();
            foreach (char s in First)
            {
                var FirstVowel = from f in Vowels
                                 where f.Value == Convert.ToString(Char.ToUpper(s))
                                 select new
                                 {
                                     f.Value


                                 };
                FirstVowel.ToList().ForEach(item => Numbers.Add(item.Value));


            }
            return Numbers.Count();


        }
    }
}
