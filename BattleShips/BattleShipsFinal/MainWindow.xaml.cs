using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace BattleShipsFinal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>s
    static class GameSettings
    {
        internal static Options GameOptions = new Options();
        internal static readonly bool[,] Rects = new bool[10, 10];
        internal static int size = GameOptions.SizeChange();
        internal static readonly int space = 2;
        internal static bool GameOver = false;
        internal static int AmountOfShips = 0;
        internal static List<int> PlayerGame = new List<int>()
        {{0 },{0 }};
        internal static List<string> IsHit = new List<string>()
        {{""},{""}};
    }
    
    public partial class MainWindow : Window
    {
        Player1 pl1 = new Player1();
        Player2 pl2 = new Player2();
        GameBegin begin = new GameBegin();
        
        public MainWindow()
        {

            InitializeComponent();
            
        }
        private async void GameStart_Click(object sender, RoutedEventArgs e)
        {
            pl1.Show();
            pl2.Show();
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
        private void Options_Click(object sender, RoutedEventArgs e)
        {
            GameSettings.GameOptions.Show();
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
