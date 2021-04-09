using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _1Zadanie
{
    class FirstAnagram
    {
        internal bool Anagram(string First, string Second)
        {
            List<string> list = new List<string>();
            foreach (char r in Second)
            {
                if (!list.Any(item => Convert.ToString(r).Contains(item)))
                {
                    var IsAnagram = from f in First
                                    where f == r
                                    select new
                                    {
                                        r


                                    };
                    IsAnagram.ToList().ForEach(item => list.Add(Convert.ToString(MessageBox.Show(item.r + ""))));

                }
                
            }
            MessageBox.Show(list.Count() + "|" + Second.Length);
            return list.Count() == First.Length ? true : false;

        }
    }
}
