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
    class listViewZapolnenie_avia
    {
        strwork_avia avia_str = new strwork_avia();

        public void lists(ListView listView3, Label label, TextBox avia_otpr, TextBox avia_nazn, TextBox avia_data)
        {
            listView3.Items.Clear();

            ListViewItem lv1 = new ListViewItem();
            ListViewItem.ListViewSubItem lv2;
            ListViewItem.ListViewSubItem lv3;
            ListViewItem.ListViewSubItem lv4;
            ListViewItem.ListViewSubItem lv5;
            ListViewItem.ListViewSubItem lv6;
            label.Visible = true;
            label.Text = avia_str.zagolovok(avia_otpr.Text, avia_nazn.Text, avia_data.Text);


            int end;
            for (end = 1; end < 10; end++)
            {
                lv1 = new ListViewItem();
                lv2 = new ListViewItem.ListViewSubItem();
                lv3 = new ListViewItem.ListViewSubItem();
                lv4 = new ListViewItem.ListViewSubItem();
                lv5 = new ListViewItem.ListViewSubItem();
                lv6 = new ListViewItem.ListViewSubItem();

                lv1.Text = Convert.ToString(end);
                lv2.Text = avia_str.table(1, end, avia_otpr.Text, avia_nazn.Text, avia_data.Text);
                lv3.Text = avia_str.table(2, end, avia_otpr.Text, avia_nazn.Text, avia_data.Text);
                lv4.Text = avia_str.table(3, end, avia_otpr.Text, avia_nazn.Text, avia_data.Text);

                //lv5.Text = Convert.ToString(Convert.ToDouble(lv4.Text) - Convert.ToDouble(lv3.Text));
                lv6.Text = "Все";


                lv1.SubItems.Add(lv2);
                lv1.SubItems.Add(lv3);
                lv1.SubItems.Add(lv4);
                lv1.SubItems.Add(lv5);
                lv1.SubItems.Add(lv6);

                listView3.Items.Add(lv1);
            }
        }
    }
}
