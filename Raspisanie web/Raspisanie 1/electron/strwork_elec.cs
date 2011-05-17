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
        int[] begin_otpr = new int[100], end_otpr = new int[100], otshet_otpr = new int[100];
        int[] begin_pr = new int[100], end_pr = new int[100], otshet_pr = new int[100];
        int[] begin_ost = new int[100], end_ost = new int[100];

        ListViewItem lv1 = new ListViewItem();
        ListViewItem.ListViewSubItem lv2;
        ListViewItem.ListViewSubItem lv3;
        ListViewItem.ListViewSubItem lv4;
        ListViewItem.ListViewSubItem lv5;
        ListViewItem.ListViewSubItem lv6;

        string s_el;
        string begin = "<title>";
        string end = "</title>";
        string begin_mon = "<strong><span>";
        string end_mon_r = "&nbsp;р";

        string begin_1 = @"<div class=""b-timetable__tripname_type_print""><span class=""g-nowrap"">";
        string sered_1 = @"</span> — <span class=""g-nowrap"">";
        string end_1 = @"</span></div>";

        string otshet_2 = @"<td class=""b-timetable__column b-timetable__column_type_departure b-timetable__column_state_current"">";
        string begin_2 = @"}, 'local': '";
        string end_2 = @"', 'col': 'dep'}""><strong>";

        string otshet_3 = @"<td class=""b-timetable__column b-timetable__column_type_arrival"">" + "\n";
        string begin_3 = @"}, 'local': '";
        string end_3 = @"', 'col': 'arr'}""><strong>";

        string begin_4 = @"<span class=""b-timetable__stations"">";
        string end_4 = @"</span>";

        parse parse_el = new parse();

        public string zagolovok(string otprv, string nazn, string date)
        {
            s_el = parse_el.list("http://rasp.yandex.ru/search/suburban/?fromName=" + otprv + "&fromId=&toName=" + nazn + "&&toId=&when=" + date);

            if (s_el == "null")
            {
                return "Отсутствует соединение";
            }
            if ((s_el.IndexOf("у нас нет информации") > 0) || (s_el.IndexOf("нет данных") > 0) )
            {
                return "Нет информации";
            }
            else
            {

                int begin_n = s_el.IndexOf(begin);
                int end_n = s_el.IndexOf(end);

                string zag = s_el.Substring(begin_n + begin.Length, end_n - begin_n - begin.Length);


                int begin_mon1 = s_el.IndexOf(begin_mon);
                int end_mon_r1 = s_el.IndexOf(end_mon_r);

                string zena = s_el.Substring(begin_mon1 + begin_mon.Length, end_mon_r1 - begin_mon1 - begin_mon.Length);

                zag = zag + "     Стоимость проезда " + zena + " рублей";
                return zag;
            }

        }

        public void table(ListView listView1, string otprv, string nazn, string date)
        {
            s_el = parse_el.list("http://rasp.yandex.ru/search/suburban/?fromName=" + otprv + "&fromId=&toName=" + nazn + "&&toId=&when=" + date);
            int number = 1;

            while (1 > 0)
            {
                lv1 = new ListViewItem();
                lv2 = new ListViewItem.ListViewSubItem();
                lv3 = new ListViewItem.ListViewSubItem();
                lv4 = new ListViewItem.ListViewSubItem();
                lv5 = new ListViewItem.ListViewSubItem();
                lv6 = new ListViewItem.ListViewSubItem();

                lv1.Text = Convert.ToString(number);


                //рейсы
                begin_reis[number] = s_el.IndexOf(begin_1, end_reis[number - 1]);
                if (begin_reis[number] < 0) { break; }
                sered_reis[number] = s_el.IndexOf(sered_1, begin_reis[number]);
                end_reis[number] = s_el.IndexOf(end_1, sered_reis[number]);
                lv2.Text = s_el.Substring(begin_reis[number] + begin_1.Length, sered_reis[number] - begin_reis[number] - begin_1.Length) + " - " + s_el.Substring(sered_reis[number] + sered_1.Length, end_reis[number] - sered_reis[number] - sered_1.Length);

                //отправление

                otshet_otpr[number] = s_el.IndexOf(otshet_2, end_otpr[number - 1]);
                begin_otpr[number] = s_el.IndexOf(begin_2, otshet_otpr[number]);
                end_otpr[number] = s_el.IndexOf(end_2, begin_otpr[number]);
                lv3.Text = s_el.Substring(begin_otpr[number] + begin_2.Length, end_otpr[number] - begin_otpr[number] - begin_2.Length);

                time_srvn tsrv = new time_srvn();
                bool time = tsrv.srvn(lv3.Text);
                if (time == true)
                {
                    lv1.BackColor = Color.Gray;
                }

                //прибытие

                otshet_pr[number] = s_el.IndexOf(otshet_3, end_pr[number - 1]);
                begin_pr[number] = s_el.IndexOf(begin_3, otshet_pr[number]);
                end_pr[number] = s_el.IndexOf(end_3, begin_pr[number]);
                lv4.Text = s_el.Substring(begin_pr[number] + begin_3.Length, end_pr[number] - begin_pr[number] - begin_3.Length);

                //остановки

                begin_ost[number] = s_el.IndexOf(begin_4, end_ost[number - 1]);
                end_ost[number] = s_el.IndexOf(end_4, begin_ost[number]);
                lv5.Text = s_el.Substring(begin_ost[number] + begin_4.Length, end_ost[number] - begin_ost[number] - begin_4.Length);


                lv1.SubItems.Add(lv2);
                lv1.SubItems.Add(lv3);
                lv1.SubItems.Add(lv4);
                lv1.SubItems.Add(lv5);                
                string rezult = lv2.Text + lv2.Text + lv2.Text + lv2.Text;

                listView1.Items.Add(lv1);
                number += 1;
            }

        }

    }
}
