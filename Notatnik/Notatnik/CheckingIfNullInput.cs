using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Notatnik
{
    static class CheckingIfNullInput
    {
        static internal string InputChecker(string Title, string Content)
        {
            if (string.IsNullOrWhiteSpace(Title))
                return "Tytuł nie może być pusty!";
            else
                return InsertData.CheckingIfExist(Title, Content);
        }


    }
}
