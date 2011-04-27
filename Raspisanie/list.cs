using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Raspisanie
{
    public class Lists 
    {
        public void list()
        {
            ListView listVw = new ListView();
                     
            ListViewItem lvi = new ListViewItem();
            ListViewItem.ListViewSubItem lvsi;
            ListViewItem.ListViewSubItem lvsisi;
            //-----------------------------
            lvi = new ListViewItem();
            lvsi = new ListViewItem.ListViewSubItem();
            lvsisi = new ListViewItem.ListViewSubItem();
            lvi.Text = "1";
            lvsi.Text = "Свеча горела";
            lvsisi.Text = "Алла Пугачёва";
            lvi.SubItems.Add(lvsisi);
            lvi.SubItems.Add(lvsi);                     
            listVw.Items.Add(lvi);
            //-----------------------------
            lvi = new ListViewItem();
            lvsi = new ListViewItem.ListViewSubItem();
            lvsisi = new ListViewItem.ListViewSubItem();
            lvi.Text = "2";
            lvsi.Text = "Ты кидал";
            lvsisi.Text = "Пятница";
            lvi.SubItems.Add(lvsisi);
            lvi.SubItems.Add(lvsi);
            listVw.Items.Add(lvi);
        }

    }
}
