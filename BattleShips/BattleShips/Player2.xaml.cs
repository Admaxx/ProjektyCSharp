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

namespace BattleShips
{
    /// <summary>
    /// Logika interakcji dla klasy Player1.xaml
    /// </summary>
    /// 

    public partial class Player2 : Window
    {
        GameBoard bo = new GameBoard();
        AllDatas all = new AllDatas();
        RandomPlaces rp = new RandomPlaces();
        ShipLayout sl;
        CreateShips Create = new CreateShips();
        AmountOfShips Ships = new AmountOfShips();
        BattleBegin battle = new BattleBegin();
        public Player2()
        {
            InitializeComponent();
            GameBegin();

        }
        internal void GameBegin()
        {
            DrawRectangles(Board);
            Horizontally();
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
        public void Example()
        {
            Rectangle pinkRectangle = new Rectangle();
            pinkRectangle.Width = 50;
            pinkRectangle.Height = 50;
            pinkRectangle.Stroke = new SolidColorBrush(Colors.Black);
            pinkRectangle.Fill = new SolidColorBrush(Colors.Gray);
            pinkRectangle.Name = all.StartValue;
            RegisterName(all.StartValue, pinkRectangle);
            Canvas.SetRight(pinkRectangle, 300);
            Canvas.SetRight(pinkRectangle, 100);
            Board.Children.Add(pinkRectangle);
            Rectangle tb = (Rectangle)FindName(all.StartValue);
            tb.Fill = new SolidColorBrush(Colors.HotPink);
        }
        internal void Horizontally()
        {

            List<ShipModels> ModelCount = Create.Model();
            //MessageBox.Show($"{ModelCount[0].Counter},{ModelCount[1].Counter}, {ModelCount.Count}");
            for (int item = 0; item <= ModelCount.Count - 1; item++)
            {
                for (int i = 0; i <= ModelCount[item].Counter - 1; i++)
                {

                    //MessageBox.Show($"{ModelCount[item].Name}{ModelCount[item].Length}{ModelCount[item].Counter}");
                    var RandomStart = rp.RandomStart(all.maxSize);
                    var Used = rp.UsedPlace;
                    sl = new ShipLayout(all.maxSize, ModelCount[item], RandomStart, Used, all.ShipPlaces);
                    //MessageBox.Show(Used.Count.ToString() + "du");
                    //MessageBox.Show(Used.Count.ToString() + "m");
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

                    //all.UsedPlaces.Add($"{RandomStart[i].Name}{RandomStart[i].Height}{RandomStart[i].Width}");
                    //MessageBox.Show($"i: {i}, Item: {item}");





                }
                //foreach (var m in all.ShipPlaces)
                //{
                //    MessageBox.Show(m);
                //}
            }
            //MessageBox.Show(all.ShipPlaces.Count().ToString());
            foreach (var m in all.ShipPlaces)
            {
                //MessageBox.Show(m);
                Rectangle tb = (Rectangle)this.FindName(m);
                tb.Fill = new SolidColorBrush(Colors.Black);

            }

        }
        //private void RedButton_Click(object sender, RoutedEventArgs e)
        //{
        //    int StartShipsAmount = all.ShipPlaces.Count();
        //    //MessageBox.Show(StartShipsAmount.ToString());
        //    while (true)
        //    {
        //        var GettingResult = battle.begin(all.ShipPlaces);
        //        if (GettingResult
        //            != string.Empty)
        //        {
        //            Rectangle tb = (Rectangle)FindName(GettingResult);
        //            tb.Fill = new SolidColorBrush(Colors.Red);
        //            all.Strikes.Add(GettingResult);
        //            MessageBox.Show($"{StartShipsAmount}, {all.Strikes.Count()},{all.AllShipCounts}");
        //        }
        //        //MessageBox.Show(all.Strikes.Count().ToString());
        //        if (StartShipsAmount ==
        //            all.Strikes.Count() + all.AllShipCounts)
        //        {
        //            MessageBox.Show("Wysrau jebany");
        //            break;

        //        }

        //    }


        //}

        //private void BlueButton_Click(object sender, RoutedEventArgs e)
        //{
        //    //var RandomStart = rp.RandomStart(all.Size);
        //    //MessageBox.Show(RandomStart);

        //    //Rectangle tb = (Rectangle)this.FindName(RandomStart);
        //    //tb.Fill = new SolidColorBrush(Colors.Blue);
        //    //all.UsedPlace.Add(RandomStart);
        //    Horizontally();
        //}
    }
}
