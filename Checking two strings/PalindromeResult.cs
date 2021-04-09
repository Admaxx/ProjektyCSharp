using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Zadanie
{
    class PalindromeResult
    {
        CheckIfPalindrome cp = new CheckIfPalindrome();
        internal string Result(string First, string Second)
        {


            return "Status palindromu: "+cp.Palindrome(First, Second);

        }
    }
}
