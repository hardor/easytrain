using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Threading; 


namespace Raspisanie
{
    class worklist
    {
        public int flag(string str,string name)
        {
            string s = File.ReadAllText(name);
            if (s.IndexOf(str)>0)
            {
                return 1;
            }
            else 
            {
                return 0;
            }
        }
        public void zapoln(ListBox l1, ListBox l2, string name)
        {            
            l1.Items.AddRange(File.ReadAllLines(name));
            l2.Items.AddRange(File.ReadAllLines(name));
        }

            public void create(string a, string b, string c)
            {
                if (File.Exists(a) != true)
                {
                    File.Create(a);
                }
                if (File.Exists(b) != true)
                {
                    File.Create(b);
                }
                if (File.Exists(c) != true)
                {
                    File.Create(c);
                }
            }
     

    }
}
