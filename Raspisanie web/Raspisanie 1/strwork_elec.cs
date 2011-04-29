using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

//1)заголовок и стоимость
//2)рейсы

namespace Raspisanie
{


    public class strwork_elec
    {
        int[] begin_reis = new int[100], sered_reis = new int[100], end_reis = new int[100];
        int[] begin_otpr = new int[100], end_otpr = new int[100];
        int[] begin_pr = new int[100], end_pr = new int[100];

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

        public string table(int vid, int number, string otprv, string nazn, string date)
        {
            //s_el = parse_el.list("http://rasp.yandex.ru/search/suburban/?fromName=" + otprv + "&fromId=&toName=" + nazn + "&&toId=&when=" + date);
            s_el = parse_el.list("http://rasp.yandex.ru/search/suburban/?fromName=" + "Марк" + "&fromId=&toName=" + "Новодачная" + "&&toId=&when=" + "29.04");
            if (vid == 1)//рейсы
            {
                string begin = @"<div class=""b-timetable__tripname_type_print""><span class=""g-nowrap"">";
                string sered = @"</span> — <span class=""g-nowrap"">";
                string end = @"</span></div>";

                begin_reis[0] = 0;
                sered_reis[0] = 0;
                end_reis[0] = 0;

                if (s_el.IndexOf(begin, end_reis[number - 1]) == -1)
                {
                    return "No";
                }

                else
                {
                    begin_reis[number] = s_el.IndexOf(begin, end_reis[number - 1]);

                    sered_reis[number] = s_el.IndexOf(sered, begin_reis[number]);
                    end_reis[number] = s_el.IndexOf(end, sered_reis[number]);

                    string reiss = s_el.Substring(begin_reis[number] + begin.Length, sered_reis[number] - begin_reis[number] - begin.Length) + " - " +
                        s_el.Substring(sered_reis[number] + sered.Length, end_reis[number] - sered_reis[number] - sered.Length);

                    return reiss;
                }
            }

            if (vid == 2)//время отправления
            {
                string begin = @"', 'col': 'dep'}""><strong>";
                begin_otpr[0] = 0;


                begin_otpr[number] = s_el.IndexOf(begin, begin_otpr[number - 1] +1);

                string otpr = s_el.Substring(begin_otpr[number] + begin.Length, 5);

                return otpr;

            }


            if (vid == 3)//время прибытия
            {
                string begin = @", 'col': 'arr'}""><strong>";

                begin_pr[0] = 0;


                begin_pr[number] = s_el.IndexOf(begin, begin_pr[number - 1] + 1);


                string pr = s_el.Substring(begin_pr[number] + begin.Length, 5);

                return pr;

            }
            else { return "Warning"; }

        }

    }
}
