using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _1Zadanie
{
    
    class CheckLength
    {
        CharsOfFirstString FirstChars = new CharsOfFirstString();
        CharsOfSecondString SecondChars = new CharsOfSecondString();
        internal string Length(string First, string Second)
        {

            //MessageBox.Show(SecondChars.CharsCals(First)[0] + "|" + SecondChars.CharsCals(First)[1] + "|" + SecondChars.CharsCals(First)[2] + "|" + SecondChars.CharsCals(First)[3]);
            return string.Format("" +
                "Pierwszy ciąg, posiada " +
                "{0} znaków/znaki, w tym - {1} liter/y, {2} cyfr/y, {3} znaki/ów białe oraz {4} znaki/ów inne/ych" + '\n'+ 

                "Drugi posiada " +
                "{5} znaków/znaki, w tym - {6} liter/y, {7} cyfr/y, {8} znaki/ów białe oraz {9} znaki/ów inne/ych " + '\n'+

                "więc różnica będzie wynosić {10} znaków/ki",

                First.Length, FirstChars.CharsCals(First)[0], FirstChars.CharsCals(First)[1], 
                FirstChars.CharsCals(First)[2], FirstChars.CharsCals(First)[3],

                Second.Length, SecondChars.CharsCals(Second)[0], SecondChars.CharsCals(Second)[1], 
                SecondChars.CharsCals(Second)[2], SecondChars.CharsCals(Second)[3], 

                Math.Abs(First.Length - Second.Length));
        }

    }
}
