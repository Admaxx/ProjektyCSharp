using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _1Zadanie
{
    class SecondAnagram
    {
        internal bool Anagram(string First, string Second)
        {
            List<string> list = new List<string>();
            foreach (char r in First)
            {
                if (!list.Any(item => Convert.ToString(r).Contains(item)))
                {
                    var IsAnagram = from f in Second
                                    where f == r
                                    select new
                                    {
                                        r


                                    };
                    IsAnagram.ToList().ForEach(item => list.Add(Convert.ToString(item.r)));

                }
            }
            MessageBox.Show(list.Count() + "|" + Second.Length+'a');
            return list.Count() == Second.Length ? true : false;

        }
    }
}
