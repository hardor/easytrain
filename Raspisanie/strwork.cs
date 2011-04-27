using System;
using System.Collections.Generic;
using System.Text;

namespace Raspisanie
{
    class strwork
    {
        public string between(string htmlstr, string s1, string s2,ref int startloc, int adding)
        {
            int i, start, end;
            string s = null;
            i = htmlstr.IndexOf(s1, startloc);
            
            if (i != -1)
            {
                start = i + s1.Length + adding;
                end = htmlstr.IndexOf(s2, start);
                s = htmlstr.Substring(start, end - start);
                startloc = end;
            }

            return s;

        }
    }
   
}
