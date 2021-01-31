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
        }

        private void WebSearch_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                WebPage.Source = new Uri(UrlGrabber.Text);

            }
            catch (Exception)
            {
                WebPage.Source = new Uri("http://www."+UrlGrabber.Text);
                
                UrlGrabber.Text = "http://www." + UrlGrabber.Text;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WebPage.GoBack();
            }
            catch (System.Runtime.InteropServices.COMException)
            {

                
            }

        }

        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WebPage.GoForward();
            }
            catch (System.Runtime.InteropServices.COMException)
            {

                
            }
            
        }
    }
}
