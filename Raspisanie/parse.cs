using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Raspisanie
{
    class parse
    {
        public string list(string uristr)
        {            
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uristr);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream istrm = resp.GetResponseStream();
            StreamReader rdr = new StreamReader(istrm);
            string str = rdr.ReadToEnd();
            return str;
        }       
       
    }
}
