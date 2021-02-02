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
    /// Logika interakcji dla klasy WebPages.xaml
    /// </summary>
    public partial class WebPages : Window
    {
        public WebPages()
        {
            InitializeComponent();
            WebPage.Source = new Uri("https://google.com");
            BackButton.IsEnabled = false;
            ForwardButton.IsEnabled = false;

        }

        private void WebSearch_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                BackButton.IsEnabled = true;
                WebPage.Source = new Uri(UrlGrabber.Text);
                //ActualAddress();
               
            }
            catch (Exception)
            {
                
               
                
                WebPage.Source = new Uri("http://www."+UrlGrabber.Text);
                
                UrlGrabber.Text = "http://www." + UrlGrabber.Text;
                //ActualAddress();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

            WebPage.GoBack();
            if (WebPage.CanGoBack == false)
            {
                BackButton.IsEnabled = false;


            }
            else
            {
                ForwardButton.IsEnabled = true;
                MessageBox.Show("Fajki");
                BackButton.IsEnabled = true;
                WebPage.GoBack();
            }
                    
                    //ActualAddress();
        }

        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            WebPage.GoForward();
            if(WebPage.CanGoForward == false)
            {
                ForwardButton.IsEnabled = false;

            }
            else
            {
                ForwardButton.IsEnabled = true;
                BackButton.IsEnabled = true;
                WebPage.GoForward();

            }
               
                //ActualAddress();

            
        }
        private void ActualAddress()
        {
            UrlGrabber.Text = Convert.ToString(WebPage.Source);

        }
    }
}