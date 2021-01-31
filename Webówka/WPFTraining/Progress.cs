using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WPFTraining
{
    internal class Progress
    {
        internal static string[] Certypide = File.ReadAllLines(@"C:\Users\Jakub\source\repos\WPFTraining\WPFTraining\bin\Debug\Stonoga.txt");
        internal static string[] Yasiexor = File.ReadAllLines(@"C:\Users\Jakub\source\repos\WPFTraining\WPFTraining\bin\Debug\Winda.txt");
        internal static List<string> list = new List<string>();
        internal static List<string> Second = new List<string>();
        internal async void StonogaTalk()
        {
            foreach(string s in Certypide)
            {
                list.Add(s);
                await Task.Delay(100);
                

            }

            
        }
        internal async void YasiexorSong()
        {
            foreach(string s in Yasiexor)
            {
                Second.Add(s);
                await Task.Delay(100);

            }


        }
        
    }
}
