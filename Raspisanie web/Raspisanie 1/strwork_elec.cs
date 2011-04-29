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
        int[] begin_reis = new int[10], sered_reis = new int[10], end_reis = new int[10];
        
        public string zagolovok(int vid, int number,string otprv, string nazn, string date)
        {
            string s_el;
            parse parse_el = new parse();
            //s_el = parse_el.list("http://rasp.yandex.ru/search/suburban/?fromName=" + otprv + "&fromId=&toName=" + nazn + "&&toId=&when=" + date);
            s_el = parse_el.list("http://rasp.yandex.ru/search/suburban/?fromName=" + "Марк" + "&fromId=&toName=" + "Новодачная" + "&&toId=&when=" + "29.04");

            if ((vid == 1) && (number==1))  //заголовок
            {
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


            if (vid == 2)//рейсы
            {
                string begin = @"<div class=""b-timetable__tripname_type_print""><span class=""g-nowrap"">";
                string sered = @"</span> — <span class=""g-nowrap"">";
                string end = @"</span></div>";

                begin_reis[0] = 0;
                sered_reis[0] = 0;
                end_reis[0] = 0;

                begin_reis[number] = s_el.IndexOf(begin, end_reis[number - 1]);
                sered_reis[number] = s_el.IndexOf(sered, begin_reis[number]);
                end_reis[number] = s_el.IndexOf(end, sered_reis[number]);

                string reiss = Convert.ToString(begin_reis[number])+"  " + s_el.Substring(begin_reis[number] + begin.Length, sered_reis[number] - begin_reis[number] - begin.Length) + " - " +
                    s_el.Substring(sered_reis[number] + sered.Length, end_reis[number] - sered_reis[number] - sered.Length);
                return reiss;
            }
            else { return "Warning"; }

        }

    }
}
