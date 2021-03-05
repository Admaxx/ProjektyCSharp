using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Notatnik
{
    class CheckingIfDelete
    {
        internal string Checking(string title)
        {
            var question = MessageBox.Show("Czy napewno, chcesz usunąć tą notatkę? \n " +
                "Operacja jest nieodwracalna", "Usuwanie",MessageBoxButton.YesNo,MessageBoxImage.Warning);

            if (question == MessageBoxResult.Yes)
            {
                if (GettingNotes.GetDatas(title).Count() != 2)
                    return DeletingNote.Deleting(title);
                return "Nie istnieje taka notatka";
            }
            return "Przerwano";

            
        }


    }
}
