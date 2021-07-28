using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BattleShipsFinal
{
    /// <summary>
    /// Logika interakcji dla klasy Player1.xaml
    /// </summary>
    /// 

    public partial class Player1 : Window
    {
        AllDatas all = new AllDatas();
        RandomPlaces rp = new RandomPlaces();
        ShipLayout sl;
        CreateShips Create = new CreateShips();
        BattleBegin battle = new BattleBegin();
        RandomPlace rand = new RandomPlace();
        public Player1()
        {
            InitializeComponent();
        }
        internal void GameBegin()
        {
;           DrawRectangles(Board);
            SwitchDimensions();
        }
        void DrawRectangles(Canvas Board)
        {
            for (int j = 0; j < GameSettings.Rects.GetLength(1); j++)
            {
                for (int i = 0; i < GameSettings.Rects.GetLength(0); i++)
                {
                    Rectangle rectangle = new Rectangle
                    {
                        Height = GameSettings.size,
                        Width = GameSettings.size,
                    };
                    rectangle.Name = $"{all.StartValue}{i}{j}";
                    RegisterName($"{all.StartValue}{i}{j}", rectangle);
                    rectangle.Fill = Brushes.Blue;
                    Board.Children.Add(rectangle);

                    Canvas.SetLeft(rectangle, i * (GameSettings.size + GameSettings.space));
                    Canvas.SetTop(rectangle, j * (GameSettings.size + GameSettings.space));
                }
            }
        }
        internal void SwitchDimensions()
        {
            Horizontally();
            //Vertical() - analogicznie;
        }
        internal void Horizontally()
        {

            List<ShipModels> ModelCount = Create.Model();
            for (int item = 0; item <= ModelCount.Count - 1; item++)
            {
                for (int i = 0; i <= ModelCount[item].Counter - 1; i++)
                {
                    var RandomStart = rp.RandomStart(all.maxSize);
                    var Used = rp.UsedPlace;
                    sl = new ShipLayout(all.maxSize, ModelCount[item], RandomStart, Used, all.ShipPlaces);
                    if (sl.Horizontally() == false)
                    {
                        Used.RemoveAt(i);
                        i--;

                    }
                    else
                        foreach (var m in RandomStart)
                        {
                            all.ShipPlaces.Add($"{m.Name}{m.Height}{m.Width}");
                            all.UsedPlace.Add($"{m.Name}{m.Height}{m.Width}");
                            all.AllShipCounts += ModelCount[item].Counter;
                        }
                }
            }
            PlacingShips();
            
        }
        private void PlacingShips()
        {
            foreach (var m in all.ShipPlaces)
            {
                Rectangle tb = (Rectangle)this.FindName(m);
                tb.Fill = new SolidColorBrush(Colors.Black);

            }
            GameSettings.AmountOfShips = all.ShipPlaces.Count() - all.AllShipCounts;
        }
        internal bool PlayerChoosing(int AllShips)
        {
            int StartShipsAmount = all.ShipPlaces.Count();
            Dispatcher.Invoke(new Action(() =>
            {
                Player1Info.Text = $"{all.PlayerBehavior[1]}";

            }));
            
            Thread.Sleep(rand.RandomVal() * 1000);

            if (StartShipsAmount - all.AllShipCounts == all.minSize)
                return true;


            var GettingResult = battle.begin(all.ShipPlaces);

            if (GettingResult
            != string.Empty)
                Dispatcher.Invoke(new Action(() =>
                {
                    Rectangle tb = (Rectangle)FindName(GettingResult);
                    tb.Fill = new SolidColorBrush(Colors.Red);
                    all.Strikes.Add(GettingResult);
                    GameSettings.IsHit[0] = all.PlayerBehavior[4];
                    Result1.Foreground = new SolidColorBrush(Colors.Green);
                    Result1.Text = GameSettings.IsHit[1];
                    
                }));
            else
                Dispatcher.Invoke(new Action(() =>
                {
                    GameSettings.IsHit[0] = all.PlayerBehavior[3];
                    Result1.Foreground = new SolidColorBrush(Colors.Red);
                    Result1.Text = GameSettings.IsHit[1];
                    
                }));
            

            Dispatcher.Invoke(new Action(() =>
            {
                GameSettings.PlayerGame[0] = all.Strikes.Count;
                Text1.Text = $"{GameSettings.PlayerGame[1]}/{AllShips}";
                Player1Info.Text = $"{all.PlayerBehavior[2]}";

            }));
            return false;
        }

        private void Board_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }
    }
}
