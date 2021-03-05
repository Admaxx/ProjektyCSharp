using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System;
using System.Threading;

namespace Notatnik
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            FindAllTitles();
            Task.WhenAll(TextLength());
            
        }

        internal void Getter()
        {
            MessageBox.Show(CheckingIfNullInput.InputChecker(Title.Text, TextValues.Text));
            FindAllTitles();

        }
        internal void CorrectText()
        {
            TextValues.Text = TextGet.Text;
            Title.Text = TitleGet.Text;

        }
        internal void FindAllTitles()
        {
            Combo.ItemsSource = "";
            Combo.ItemsSource = GettingDatas.GetDatas();
            //MessageBox.Show(GettingDatas.GetDatas().Count.ToString());
        }

        private void Input_Click(object sender, RoutedEventArgs e)
        {
            Getter();

        }
        private void ConfirmToDelete()
        {
            var result = MessageBox.Show("Czy napewno chcesz usunąć? \n Operacja nie jest odwracalna",
                "Usuwanie"
                ,MessageBoxButton.YesNo,MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
                MethodsToDelete();
            else
                MessageBox.Show("Przerwano");

        }
        private void MethodsToDelete()
        {

            MessageBox.Show(DeletingNote.Deleting(Combo.Text));
            FindAllTitles();
            TitleGet.Text = "";
            TextGet.Text = "";

        }
        private async Task TextLength()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        Dispatcher.Invoke
                        (new Action(() =>
                        LengthOfText.Text = "Pozostała ilość znaków: " + (TextValues.MaxLength - TextValues.Text.Length).ToString()
                        ));
                        Thread.Sleep(100);
                    }
                    catch (TaskCanceledException)
                    {

                    }
                        

                }

            });


        }

        private void CorrectText_Click(object sender, RoutedEventArgs e)
        {
            CorrectText();
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TitleGet.Text = GettingNotes.GetDatas(Combo.Text)[0];
                TextGet.Text = GettingNotes.GetDatas(Combo.Text)[1];
            }catch(ArgumentOutOfRangeException)
            {
                TitleGet.Text = "";
                TextGet.Text = "";
                MessageBox.Show("Tytuł nie może być pusty!");

            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

            ConfirmToDelete();
            
        }

        private void CleanTitle_Click(object sender, RoutedEventArgs e)
        {
            Title.Text = "";
        }

        private void CleanContent_Click(object sender, RoutedEventArgs e)
        {
            TextValues.Text = "";
        }
    }
}
