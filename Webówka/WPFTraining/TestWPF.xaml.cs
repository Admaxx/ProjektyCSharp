using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFTraining
{
    /// <summary>
    /// Logika interakcji dla klasy TestWPF.xaml
    /// </summary>
    public partial class TestWPF : Window
    {
        public TestWPF()
        {
            InitializeComponent();
            Yas();
        }
        internal async void Yas()
        {
            Progress p = new Progress();
            p.YasiexorSong();
            PB.Maximum = Progress.Yasiexor.Length - 1;
            for(int i = 0;i<=Progress.Yasiexor.Length-1;i++)
            {
                PB.Value = i;
                Block.Text = Progress.Second[i];
                await Task.Delay(500);
            }
            Block.Text = "NJEWIEM";


        }
    }
}
