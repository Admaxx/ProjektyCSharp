using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Zadanie
{
    class FirstSize
    {
        FirstUpperLetters FirstUpper = new FirstUpperLetters();
        FirstLowerLetters FirstLower = new FirstLowerLetters();
        internal string First(string First)
        {

            return "Pierwszy ciąg znaków: ilość dużych liter: " 
                + FirstUpper.UpperFirst(First) 
                + " a małych " 
                + FirstLower.LowerFirst(First);



        }
    }
}
