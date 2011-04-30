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

    public class strwork_elec
    {
        int[] begin_reis = new int[100], sered_reis = new int[100], end_reis = new int[100];
        int[] begin_otpr = new int[100], end_otpr = new int[100];
        int[] begin_pr = new int[100], end_pr = new int[100];

        ListViewItem lv1 = new ListViewItem();
        ListViewItem.ListViewSubItem lv2;
        ListViewItem.ListViewSubItem lv3;
        ListViewItem.ListViewSubItem lv4;
        ListViewItem.ListViewSubItem lv5;
        ListViewItem.ListViewSubItem lv6;

        string s_el;
        parse parse_el = new parse();

        public string zagolovok(string otprv, string nazn, string date)
        {
            //s_el = parse_el.list("http://rasp.yandex.ru/search/suburban/?fromName=" + otprv + "&fromId=&toName=" + nazn + "&&toId=&when=" + date);
            s_el = parse_el.list("http://rasp.yandex.ru/search/suburban/?fromName=" + "Марк" + "&fromId=&toName=" + "Новодачная" + "&&toId=&when=" + "29.04");

            string begin = "<title>";
            string end = "</title>";

            int begin_n = s_el.IndexOf(begin);
            int end_n = s_el.IndexOf(end);

            string zag = s_el.Substring(begin_n + begin.Length, end_n - begin_n - begin.Length);

            string begin_mon = "<strong><span>";
            string end_mon_r = "&nbsp;р";

            int begin_mon1 = s_el.IndexOf(begin_mon);
            int end_mon_r1 = s_el.IndexOf(end_mon_r);

            string zena = s_el.Substring(begin_mon1 + begin_mon.Length, end_mon_r1 - begin_mon1 - begin_mon.Length);

            zag = zag + "     Стоимость проезда " + zena + " рублей";
            return zag;

        }

        public void table(ListView listView1,   string otprv, string nazn, string date)
        {
            //s_el = parse_el.list("http://rasp.yandex.ru/search/suburban/?fromName=" + otprv + "&fromId=&toName=" + nazn + "&&toId=&when=" + date);
            s_el = parse_el.list("http://rasp.yandex.ru/search/suburban/?fromName=" + "Марк" + "&fromId=&toName=" + "Новодачная" + "&&toId=&when=" + "29.04");

            int number = 1;
            begin_reis[0] = 0;
            begin_otpr[0] = 0;
            begin_pr[0] = 0;
            while (1>0)
            {
                lv1 = new ListViewItem();
                lv2 = new ListViewItem.ListViewSubItem();
                lv3 = new ListViewItem.ListViewSubItem();
                lv4 = new ListViewItem.ListViewSubItem();
                lv5 = new ListViewItem.ListViewSubItem();
                lv6 = new ListViewItem.ListViewSubItem();

                lv1.Text = Convert.ToString(number);

                string begin_1 = @"<div class=""b-timetable__tripname_type_print""><span class=""g-nowrap"">";
                string sered_1 = @"</span> — <span class=""g-nowrap"">";
                string end_1 = @"</span></div>";

                begin_reis[number] = s_el.IndexOf(begin_1, end_reis[number - 1]);
                if (begin_reis[number] < 0) { break; }
                sered_reis[number] = s_el.IndexOf(sered_1, begin_reis[number]);
                end_reis[number] = s_el.IndexOf(end_1, sered_reis[number]);

                lv2.Text = s_el.Substring(begin_reis[number] + begin_1.Length, sered_reis[number] - begin_reis[number] - begin_1.Length) + " - " +
                   s_el.Substring(sered_reis[number] + sered_1.Length, end_reis[number] - sered_reis[number] - sered_1.Length);



                string begin_2 = @"', 'col': 'dep'}""><strong>";
                begin_otpr[number] = s_el.IndexOf(begin_2, begin_otpr[number - 1] );
                lv3.Text = s_el.Substring(begin_otpr[number] + begin_2.Length, 5);

                string begin_3 = @", 'col': 'arr'}""><strong>";                
                begin_pr[number] = s_el.IndexOf(begin_3, begin_pr[number - 1] );
                lv4.Text = s_el.Substring(begin_pr[number] + begin_3.Length, 5);

                lv5.Text = "Всfdgе";
                lv6.Text = "Все";

                lv1.SubItems.Add(lv2);
                lv1.SubItems.Add(lv3);
                lv1.SubItems.Add(lv4);
                lv1.SubItems.Add(lv5);
                lv1.SubItems.Add(lv6);

                listView1.Items.Add(lv1);
                number += 1;
            }

        }

    }
}
