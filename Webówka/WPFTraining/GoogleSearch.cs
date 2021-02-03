using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTraining
{
    class GoogleSearch
    {
        internal bool Search(string url)
        {
            bool IsError = false;
            try
            {
                url.Split(new string[] { "." }, StringSplitOptions.None).GetValue(1);

            }
            catch (Exception)
            {
                IsError = true;
                
            }

            return IsError;
        }
    }
}
