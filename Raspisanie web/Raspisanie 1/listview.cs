using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;


namespace Raspisanie 
{
    class listViewZapolnenie 
    {

        public void lists(ListView listView1, Label label, TextBox elec_otpr, TextBox elec_nazn, TextBox elec_data)
        {
         listView1.Items.Clear();

            ListViewItem lv1 = new ListViewItem();
            ListViewItem.ListViewSubItem lv2;
            ListViewItem.ListViewSubItem lv3;
            ListViewItem.ListViewSubItem lv4;
            ListViewItem.ListViewSubItem lv5;
            ListViewItem.ListViewSubItem lv6;

            
           
            int end;
            for (end = 1; end <4; end++)
            {
                strwork_elec el_str = new strwork_elec();
                label.Visible = true;
                label.Text = el_str.zagolovok(1, 1, elec_otpr.Text, elec_nazn.Text, elec_data.Text);        

                lv1 = new ListViewItem();
                lv2 = new ListViewItem.ListViewSubItem();
                lv3 = new ListViewItem.ListViewSubItem();
                lv4 = new ListViewItem.ListViewSubItem();
                lv5 = new ListViewItem.ListViewSubItem();
                lv6 = new ListViewItem.ListViewSubItem();               

                lv1.Text = Convert.ToString(end);
                lv2.Text = el_str.zagolovok(2, end, elec_otpr.Text, elec_nazn.Text, elec_data.Text); 
                lv3.Text = "10 45";
                lv4.Text = "12 00";
                lv5.Text = "2 45 ";
                lv6.Text = "Все";
                

                lv1.SubItems.Add(lv2);
                lv1.SubItems.Add(lv3);
                lv1.SubItems.Add(lv4);
                lv1.SubItems.Add(lv5);
                lv1.SubItems.Add(lv6);
                
                listView1.Items.Add(lv1);
            }
        }
    }
}
