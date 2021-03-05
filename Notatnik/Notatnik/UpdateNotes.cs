using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Notatnik
{
    static class UpdateNotes
    {
        static internal string CheckingUpdate(string title, string content)
        {
            var Answer = MessageBox.Show("Czy napewno chcesz nadpisać?","Nadpisywanie",MessageBoxButton.YesNo,MessageBoxImage.Question);

            if(Answer == MessageBoxResult.Yes)
            {

                return UpdateQuery.Update(title, content);
            }

            return "Przerwano";
        }




    }
}
