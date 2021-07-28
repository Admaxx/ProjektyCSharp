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

namespace BattleShipsFinal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>s
    static class GameSettings
    {
        internal static readonly bool[,] Rects = new bool[10, 10];
        internal static readonly int size = 25;
        internal static readonly int space = 2;
        internal static bool GameOver = false;
        internal static int AmountOfShips = 0;
        internal static List<int> PlayerGame = new List<int>()
        {{0 }, {0 }};
        internal static List<string> IsHit = new List<string>()
        {
            {""},
            {""}
        };
    }
    
    public partial class MainWindow : Window
    {
        Player1 pl1 = new Player1();
        Player2 pl2 = new Player2();
        GameBegin begin = new GameBegin();
        public MainWindow()
        {

            InitializeComponent();
            pl1.Show();
            pl2.Show();
            
        }
        private async void GameStart_Click(object sender, RoutedEventArgs e)
        {
            Close();
            await Task.WhenAll(Game());
            
        }
        private async Task Game()
        {
            Close();
            await Task.Run(() => 
            {
                while (GameSettings.GameOver == false)
                    begin.Game
                    (
                        pl1.PlayerChoosing(GameSettings.AmountOfShips),
                        pl2.PlayerChoosing(GameSettings.AmountOfShips)
                    );

            });
            
        }
    }
}
