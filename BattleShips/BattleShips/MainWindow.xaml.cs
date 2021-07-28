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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BattleShips
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>s
    static class GameSettings
    {
        internal static readonly bool[,] Rects = new bool[10, 10];
        internal static readonly int size = 20;
        internal static readonly int space = 2;

    }
    public partial class MainWindow : Window
    {
        Player1 pl1 = new Player1();
        Player2 pl2 = new Player2();
        
        public MainWindow()
        {

            InitializeComponent();
            //bo.GetValues();
            //DrawRectangles(Board);
            //Example();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pl1.Show();
            pl2.Show();
            Close();
        }
    }
}
