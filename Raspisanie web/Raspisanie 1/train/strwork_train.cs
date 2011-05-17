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

    public class strwork_train
    {
        int[] begin_reis = new int[100], sered_reis = new int[100], sered_reis2 = new int[100], sered_reis3 = new int[100], end_reis = new int[100];
        int[] begin_otpr = new int[100], end_otpr = new int[100], otshet_otpr = new int[100];
        int[] begin_pr = new int[100], end_pr = new int[100], otshet_pr = new int[100];
        int[] begin_zena = new int[100], end_zena = new int[100];

        ListViewItem lv1 = new ListViewItem();
        ListViewItem.ListViewSubItem lv2;
        ListViewItem.ListViewSubItem lv3;
        ListViewItem.ListViewSubItem lv4;
        ListViewItem.ListViewSubItem lv5;

        string s_train;

        string begin_1 = @"<div class=""b-timetable__tripname"">";
        string sered_1 = @"""><strong>";
        string sered_2 = @"</strong> <span class=""g-nowrap"">";
        string sered_3 = @"</span> — <span class=""g-nowrap"">";
        string end_1 = @"</span></a>";

        string otshet_2 = @"<td class=""b-timetable__column b-timetable__column_type_departure b-timetable__column_state_current"">";
        string begin_2 = @"}, 'local': '";
        string end_2 = @"', 'col': 'dep'}""><strong>";

        string otshet_3 = @"<td class=""b-timetable__column b-timetable__column_type_arrival"">" + "\n";
        string begin_3 = @"}, 'local': '";
        string end_3 = @"', 'col': 'arr'}""><strong>";

        parse parse_train = new parse();

        public string zagolovok(string otprv, string nazn, string date)
        {

            s_train = parse_train.list(" http://rasp.yandex.ru/search/train/?fromName=" + otprv + "&fromId=&toName=" + nazn + "&&toId=&when=" + date);

            if (s_train == "null")
            {
                return "Отсутствует соединение";
            }
            if ((s_train.IndexOf("у нас нет информации") > 0) || (s_train.IndexOf("нет данных") > 0))
            {
                return "Нет информации";
            }
            else
            {
                string begin = "<title>";
                string end = "</title>";

                int begin_n = s_train.IndexOf(begin);
                int end_n = s_train.IndexOf(end);
                string zag = s_train.Substring(begin_n + begin.Length, end_n - begin_n - begin.Length);

                return zag;
            }
        }

        public void table(ListView listView2, string otprv, string nazn, string date)
        {
            s_train = parse_train.list(" http://rasp.yandex.ru/search/train/?fromName=" + otprv + "&fromId=&toName=" + nazn + "&&toId=&when=" + date);
            //s_train = parse_train.list(" http://rasp.yandex.ru/search/train/?fromName=" + "Москва" + "&fromId=&toName=" + "Уфа" + "&&toId=&when=" + date);

            int number = 1;

            while (1 > 0)
            {
                lv1 = new ListViewItem();
                lv2 = new ListViewItem.ListViewSubItem();
                lv3 = new ListViewItem.ListViewSubItem();
                lv4 = new ListViewItem.ListViewSubItem();
                lv5 = new ListViewItem.ListViewSubItem();

                lv1.Text = Convert.ToString(number);

                begin_reis[number] = s_train.IndexOf(begin_1, end_reis[number - 1]);
                if (begin_reis[number] < 0) { break; }
                sered_reis[number] = s_train.IndexOf(sered_1, begin_reis[number]);
                sered_reis2[number] = s_train.IndexOf(sered_2, sered_reis[number]);
                sered_reis3[number] = s_train.IndexOf(sered_3, sered_reis2[number]);
                end_reis[number] = s_train.IndexOf(end_1, sered_reis3[number]);
                lv2.Text = s_train.Substring(sered_reis[number] + sered_1.Length, sered_reis2[number] - sered_reis[number] - sered_1.Length) + "  " + s_train.Substring(sered_reis2[number] + sered_2.Length, sered_reis3[number] - sered_reis2[number] - sered_2.Length) + " - " + s_train.Substring(sered_reis3[number] + sered_3.Length, end_reis[number] - sered_reis3[number] - sered_3.Length);



                otshet_otpr[number] = s_train.IndexOf(otshet_2, end_otpr[number - 1]);
                begin_otpr[number] = s_train.IndexOf(begin_2, otshet_otpr[number]);
                end_otpr[number] = s_train.IndexOf(end_2, begin_otpr[number]);
                lv3.Text = s_train.Substring(begin_otpr[number] + begin_2.Length, end_otpr[number] - begin_otpr[number] - begin_2.Length);

                time_srvn tsrv = new time_srvn();
                bool time = tsrv.srvn(lv3.Text);
                if (time == true)
                {
                    lv1.BackColor = Color.Gray;
                }


                otshet_pr[number] = s_train.IndexOf(otshet_3, end_pr[number - 1]);
                begin_pr[number] = s_train.IndexOf(begin_3, otshet_pr[number]);
                end_pr[number] = s_train.IndexOf(end_3, begin_pr[number]);
                lv4.Text = s_train.Substring(begin_pr[number] + begin_3.Length, end_pr[number] - begin_pr[number] - begin_3.Length);

                lv1.SubItems.Add(lv2);
                lv1.SubItems.Add(lv3);
                lv1.SubItems.Add(lv4);
                lv1.SubItems.Add(lv5);

                listView2.Items.Add(lv1);
                number += 1;
            }

        }

    }
}
