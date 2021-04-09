using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Zadanie
{
    class SecondSize
    {
        SecondUpperLetters SecondUpper = new SecondUpperLetters();
        SecondLowerLetters SecondLower = new SecondLowerLetters();
        internal string Second(string Second)
        {

            return "Drugi ciąg znaków: ilość dużych liter: "
                + SecondUpper.UpperSecond(Second)
                + " a małych "
                + SecondLower.LowerSecond(Second);



        }

    }
}
