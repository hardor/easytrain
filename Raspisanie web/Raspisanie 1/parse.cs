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
        bool connect;
          HttpWebRequest req ;
          HttpWebResponse resp;
                Stream istrm ;
                StreamReader rdr ;
                string str;
        public bool ConnectionAvailable()
        {
            try
            {
                req = (HttpWebRequest)WebRequest.Create("http://www.google.com");
                resp = (HttpWebResponse)req.GetResponse();
                if (HttpStatusCode.OK == resp.StatusCode)
                {
                    // HTTP = 200 - Интернет безусловно есть!  
                    resp.Close();
                    return true;
                }
                else
                {
                    // сервер вернул отрицательный ответ, возможно что инета нет 
                    resp.Close();
                    return false;
                }
            }
            catch (WebException)
            {
                // Ошибка, значит интернета у нас нет. Плачем :'( 
                return false;
            }
        }

       public  string list(string uristr)
        { //получаем веб-адрес и возвращаем исходный код страницы
            connect = ConnectionAvailable();
            if (connect == true)
            {
                 req = (HttpWebRequest)WebRequest.Create(uristr);
                resp = (HttpWebResponse)req.GetResponse();
                 istrm = resp.GetResponseStream();
                 rdr = new StreamReader(istrm);
                str = rdr.ReadToEnd();
                return str;
            }
            else return "null";
        }              
    }
}
