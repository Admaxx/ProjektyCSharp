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

namespace PomocnikStudenta
{
    /// <summary>
    /// Logika interakcji dla klasy WebShowed.xaml
    /// </summary>
    public partial class WebShowed : Window
    {
        public WebShowed()
        {
            InitializeComponent();
            
        }

        internal void WebPages(string WebName)
        {
            Finder f = new Finder();
            var finder = from fin in f.Teachers()
                         where fin.Key == WebName
                         select new
                         {
                             fin.Value


                         };

           finder.ToList().ForEach(item => WebPage.Source = new Uri(item.Value));
        }

    }
}
