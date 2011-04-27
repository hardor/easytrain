using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;


namespace Raspisanie
{
    public partial class Form1 : Form
    {

        ListViewItem lv1 = new ListViewItem();
        ListViewItem.ListViewSubItem lv2;
        ListViewItem.ListViewSubItem lv3;
        ListViewItem.ListViewSubItem lv4;
        ListViewItem.ListViewSubItem lv5;
        ListViewItem.ListViewSubItem lv6;
        ListViewItem.ListViewSubItem lv7;

        public Form1()
        {
            InitializeComponent();

        }

        private void zvukon_Click(object sender, EventArgs e)
        {
            Zvuk Zvuk1 = new Zvuk();
            Zvuk1.zvukon1();

        }

        private void zvukoff_Click(object sender, EventArgs e)
        {
            Zvuk Zvuk2 = new Zvuk();
            Zvuk2.zvukoff1();
        }


       private void elec_search_Click(object sender, EventArgs e)
        {

            listView1.Items.Clear();
          
            //-----------------------------
            lv1 = new ListViewItem();
            lv2 = new ListViewItem.ListViewSubItem();
            lv3 = new ListViewItem.ListViewSubItem();
            lv4 = new ListViewItem.ListViewSubItem();
            lv5 = new ListViewItem.ListViewSubItem();
            lv6 = new ListViewItem.ListViewSubItem();
            lv7 = new ListViewItem.ListViewSubItem();
            lv1.Text = "1";
            lv2.Text = "Свеча горела";
            lv3.Text = "Алла Пугва";
            lv4.Text = "Алла Пугаёва";
            lv5.Text = "Алла Пугчёва";
            lv6.Text = "Алла Пгачёва";
            lv7.Text = "Ал Пгачёва";   
            listView1.Items.Add(lv1);
            lv1.SubItems.Add(lv2);
            lv1.SubItems.Add(lv3);
            lv1.SubItems.Add(lv4);
            lv1.SubItems.Add(lv5);
            lv1.SubItems.Add(lv6);
            lv1.SubItems.Add(lv7);

        //    parse parse_el = new parse();
        //    string s_el = parse_el.list("http://rasp.yandex.ru/search/suburban/?fromName=" + elec_otpr.Text + "&fromId=&toName=" + elec_nazn.Text + "&&toId=&when=" + elec_data.Text);
        //    listBox1.Items.Add(s_el); 
          

      }
        private void train_search_Click(object sender, EventArgs e)
        {
            parse parse_tr = new parse();
            string s_tr = parse_tr.list(" http://rasp.yandex.ru/search/train/?fromName=" + train_otpr.Text + "&fromId=&toName=" + train_nazn.Text + "&toId=&when=" + train_data.Text);
            listBox2.Items.Add(s_tr); 

        }

        private void avia_search_Click(object sender, EventArgs e)
        {
            parse parse_av = new parse();
            string s_av = parse_av.list(" http://rasp.yandex.ru/search/plane/?fromName=" + avia_otpr.Text + "&fromId=&toName=" + avia_nazn.Text + "&toId=&when=" + avia_data.Text);
            listBox3.Items.Add(s_av);       
        }


        private void Form1_Deactivate_1(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon2.Visible = true;
            }
        }


        private void notifyIcon2_MouseClick(object sender, MouseEventArgs e)
        {
            notifyIcon2.ShowBalloonTip(5000, "Расписание", "Близжайшая электричка с\n" + elec_otpr.Text + "до" + elec_nazn.Text, ToolTipIcon.Info);
        }


        private void notifyIcon2_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                notifyIcon2.Visible = false;
            }

        }


        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            avia_data.Text = e.End.ToString("dd/MM/yyyy");
            train_data.Text = e.End.ToString("dd/MM/yyyy");
            elec_data.Text = e.End.ToString("dd/MM/yyyy");

        }



        private void timer1_Tick(object sender, EventArgs e)
        {


            DateTime curr_time = DateTime.Now;
            if (alarm_on_ch.Checked == true)
            {
               // if ((curr_time.Hour == hour_on.Value) && (curr_time.Minute == minute_on.Value) && (curr_time.Second == 0))
                {
                    alarm_on_ch.Checked = false;
                    Form2 napomin = new Form2();
                    napomin.Show();
                    if (checkBox1.Checked == true)
                    {
                        Music music1 = new Music();
                        music1.music_on();
                        checkBox1.Checked = false;
                    }

                }
            }
        }
        private void hour_on_ValueChanged(object sender, System.EventArgs e)
        {

            if (hour_on.Value > 23)
            {
                hour_on.Value = 0;
            }
        }
        private void minute_on_ValueChanged(object sender, System.EventArgs e)
        {
            if (minute_on.Value > 59)
            {
                minute_on.Value = 0;
                hour_on.Value = hour_on.Value + 1;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {//показ времени
            DateTime curr_time = DateTime.Now;
            time.Text = Convert.ToString(curr_time.Hour) + ":" + Convert.ToString(curr_time.Minute) + ":" + Convert.ToString(curr_time.Second);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form3 auto = new Form3();
            auto.Show();

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (rkApp.GetValue("EasyTrain") == null)
            {
                label31.Text = "выкл";
            }
            else
            {
                label31.Text = "вкл";
            }

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Караваны успешно ограблены");
        }

     


    }
}
