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

namespace _1Zadanie
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        CheckLength check = new CheckLength(); //Sprawdzanie, długości wyrazów
        AnagramResult ar = new AnagramResult(); //Sprawdzanie czy słowa są anagramami
        PalindromeResult pr = new PalindromeResult(); //Sprawdzanie czy wyrazy są palindromami
        FirstSize First = new FirstSize(); //Sprawdzanie wielkości liter pierwszego ciągu
        SecondSize Second = new SecondSize(); //Sprawdzanie wielkości liter drugiego ciągu
        NumberOfVowels number = new NumberOfVowels(); //Sprawdzanie ilości samogłosek
        ChooseRandomWords randoms = new ChooseRandomWords(); //Losowanie wyrazów

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckDiff_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FirstString.Text) && !string.IsNullOrWhiteSpace(SecondString.Text))
            MessageBox.Show(string.Format("" +
                "{0}, \n " +
                "{1}, \n " +
                "{2}, \n " +
                "{3}, \n " +
                "{4}, \n " +
                "{5}"
                ,pr.Result(FirstString.Text, SecondString.Text)
                ,ar.Anagram(FirstString.Text, SecondString.Text)
                ,check.Length(FirstString.Text, SecondString.Text)
                ,number.Check(FirstString.Text, SecondString.Text) 
                ,First.First(FirstString.Text)
                ,Second.Second(SecondString.Text)),
                "Wynik", MessageBoxButton.OK, MessageBoxImage.Information);
            
            else
            {
                MessageBox.Show("Wpisz dane");

            }
        }

        private void RandomWords_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FirstString.Text = "";
                SecondString.Text = "";

                FirstString.Text = randoms.Words()[0];
                SecondString.Text = randoms.Words()[1];

                randoms.Words().Clear();

            }catch(ArgumentOutOfRangeException){}
        }

        private void ClearButton1_Click(object sender, RoutedEventArgs e){FirstString.Text = "";}

        private void ClearButton2_Click(object sender, RoutedEventArgs e){SecondString.Text = "";}
    }
}
