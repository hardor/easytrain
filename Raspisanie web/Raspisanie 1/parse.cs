using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace mark
{
    class parse
    {
        public string[] list(string uristr,ref int n)
        {
            string[] mas = new string[200];

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uristr);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream istrm = resp.GetResponseStream();
            StreamReader rdr = new StreamReader(istrm);
            string str = rdr.ReadToEnd();

            strwork c = new strwork();
            int loc = 0; string be, en;
            be = @"rel=""tooltip""  />" + "\n" + "						<a href=";

            en = "</a>";
            string s2 = "12345", prevs2 = "00000" ;
            //string[] mas = new string[1000];
            n = 0;

            while ((s2 != null) && (s2.Length == 5))
            {
                s2 = c.between(str, be, en, ref  loc, 24+16);
                if (s2 != prevs2)
                {
                    mas[n] = s2;
                    n++;
                }
                prevs2 = s2;
            }
            spisok = mas;
            return mas;

        }

       
       
    }
}
