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
        public Form1()
        {
            InitializeComponent();            
        }
        worklist listw = new worklist();

        private void elec_search_Click(object sender, EventArgs e)
        {//вызов поиска электричек
            if ((elec_otpr.Text == "") || (elec_nazn.Text == "") || (elec_nazn.Text == elec_otpr.Text))
            {
                label32.Visible = true;
                label32.Text = "ВВЕДИТЕ ПРАВИЛЬНО СТАНЦИИ";
                checkBox2.Enabled = false;
            }
            else
            {
                listView1.Items.Clear();
                strwork_elec el = new strwork_elec();
                label32.Visible = true;
                label32.Text = el.zagolovok(elec_otpr.Text, elec_nazn.Text, elec_data.Text);
                if (label32.Text != "Нет информации")
                {
                    el.table(listView1, elec_otpr.Text, elec_nazn.Text, elec_data.Text);
                }
                checkBox2.Enabled = true;

                int a = listw.flag(elec_otpr.Text, "elec.txt");
                if (a==0)
                {
                    File.AppendAllText("elec.txt", "\n" + elec_otpr.Text);
                    listw.zapoln(listBox1, listBox2, "elec.txt");
                }
                int b = listw.flag(elec_nazn.Text, "elec.txt");
                if (b == 0)
                {
                    File.AppendAllText("elec.txt", "\n" + elec_nazn.Text);
                    listw.zapoln(listBox1, listBox2, "elec.txt");
                }
                

            }

        }

        private void train_search_Click(object sender, EventArgs e)
        {//вызов поиска поездов
            if ((train_otpr.Text == "") || (train_nazn.Text == "") || (train_nazn.Text == train_otpr.Text))
            {
                label34.Visible = true;
                label34.Text = "ВВЕДИТЕ ПРАВИЛЬНО СТАНЦИИ";
            }
            else
            {
                listView2.Items.Clear();
                strwork_train ек = new strwork_train();
                label34.Visible = true;
                label34.Text = ек.zagolovok(train_otpr.Text, train_nazn.Text, train_data.Text);
                if (label34.Text != "Нет информации")
                {
                    ек.table(listView2, train_otpr.Text, train_nazn.Text, train_data.Text);
                }
                int a = listw.flag(train_otpr.Text, "train.txt");
                if (a == 0)
                {
                    File.AppendAllText("train.txt", "\n" + train_otpr.Text);
                    listw.zapoln(listBox3, listBox4, "train.txt");
                }
                int b = listw.flag(train_nazn.Text, "train.txt");
                if (b == 0)
                {
                    File.AppendAllText("train.txt", "\n" + train_nazn.Text);
                    listw.zapoln(listBox3, listBox4, "train.txt");
                }
            }
        }

        private void avia_search_Click(object sender, EventArgs e)
        {//вызов поиска самолётов
            if ((avia_otpr.Text == "") || (avia_nazn.Text == "") || (avia_nazn.Text == avia_otpr.Text))
            {
                label33.Visible = true;
                label33.Text = "ВВЕДИТЕ ПРАВИЛЬНО СТАНЦИИ";
            }
            else
            {
                listView3.Items.Clear();
                strwork_avia ava = new strwork_avia();
                label33.Visible = true;
                label33.Text = ava.zagolovok(avia_otpr.Text, avia_nazn.Text, avia_data.Text);
                if (label34.Text != "Нет информации")
                {
                    ava.table(listView3, avia_otpr.Text, avia_nazn.Text, avia_data.Text);
                }
                int a = listw.flag(avia_otpr.Text, "avia.txt");
                if (a == 0)
                {
                    File.AppendAllText("avia.txt", "\n" + avia_otpr.Text);
                    listw.zapoln(listBox5, listBox6, "avia.txt");
                }
                int b = listw.flag(avia_nazn.Text, "avia.txt");
                if (b == 0)
                {
                    File.AppendAllText("avia.txt", "\n" + avia_nazn.Text);
                    listw.zapoln(listBox5, listBox6, "avia.txt");
                }
            }
        }
        
        private void Form1_Deactivate_1(object sender, EventArgs e)
        {//трей
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon2.Visible = true;
            }
        }
        
       
        private void notifyIcon2_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {//востановление из трея
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                notifyIcon2.Visible = false;
            }

        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {//заполнение даты с помощью календаря
            avia_data.Text = e.End.ToString("dd/MM/yyyy");
            train_data.Text = e.End.ToString("dd/MM/yyyy");
            elec_data.Text = e.End.ToString("dd/MM/yyyy");

        }

        private void timer1_Tick(object sender, EventArgs e)
        {//будильник
            DateTime curr_time = DateTime.Now;
            if (alarm_on_ch.Checked == true)
            {
                if ((curr_time.Hour == hour_on.Value) && (curr_time.Minute == minute_on.Value) && (curr_time.Second == 0))
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
        {//оптимизация ввода часов для будильника
            if (hour_on.Value > 23)
            {
                hour_on.Value = 0;
            }
        }
        private void minute_on_ValueChanged(object sender, System.EventArgs e)
        {//оптимизация ввода минут для будильника
            if (minute_on.Value > 59)
            {
                minute_on.Value = 0;
                hour_on.Value = hour_on.Value + 1;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {//показ времени
            DateTime curr_time = DateTime.Now;
            string vr = Convert.ToString(curr_time.TimeOfDay);
            time.Text = vr.Substring(0, 8);
        }

        private void button8_Click(object sender, EventArgs e)
        {//вызываем форму с настройками автозапуском
            Form3 auto = new Form3();
            auto.Show();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {//проверка состояния на автозапуск и вывод вывод метку
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
        private void label36_Click(object sender, EventArgs e)
        {//вызов формы "о программе"
            Form4 spr = new Form4();
            spr.Show();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if ((checkBox2.Checked == true) && (Convert.ToInt32(numericUpDown1.Value) > 0))
            {
                timer4.Interval = 1000 * 60 * Convert.ToInt32(numericUpDown1.Value);                
                elec_search_Click(sender, e);
            }
            
        }   

        private void listBox1_Click(object sender, EventArgs e)
        {
            elec_otpr.Text = listBox1.Text;
            listBox1.Visible = false;
        }
        private void listBox2_Click(object sender, EventArgs e)
        {
            elec_nazn.Text = listBox2.Text;
            listBox2.Visible = false;
        }
        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            train_otpr.Text = listBox3.Text;
            listBox3.Visible = false;
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            train_nazn.Text = listBox4.Text;
            listBox4.Visible = false;
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            avia_otpr.Text = listBox5.Text;
            listBox5.Visible = false;
        }

        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            avia_nazn.Text = listBox6.Text;
            listBox6.Visible = false;
        }  

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            if (e.CurrentValue == CheckState.Unchecked)
            {
                alarm_on_ch.Checked = true;
                string t = listView1.Items[e.Index].SubItems[2].Text;
                int min_n = Convert.ToInt32(t.Substring(t.Length - 5, 2));
                int hour_n = Convert.ToInt32(t.Substring(t.Length - 8, 2));
                int min = Convert.ToInt32(numericUpDown2.Value);
                if (min_n > min)
                {
                    hour_on.Value = hour_n;
                    minute_on.Value = min_n - min;
                }
                else
                {
                    int c = min % 60;
                    minute_on.Value = min_n + 60 - min % 60;
                    hour_on.Value = hour_n - min / 60 - 1;
                }
            }
            else
            {
                alarm_on_ch.Checked = false;
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIcon2.Visible = false;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label36_Click(this,e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listw.create("elec.txt","train.txt","avia.txt");
            listw.zapoln(listBox1, listBox2, "elec.txt");
            listw.zapoln(listBox3, listBox4, "train.txt");
            listw.zapoln(listBox5, listBox6, "avia.txt");
        }
        private void button9_Click(object sender, EventArgs e)
        {
            File.Delete("elec.txt");
            File.Create("elec.txt");
            File.Delete("train.txt");
            File.Create("train.txt");
            File.Delete("avia.txt");
            File.Create("avia.txt"); 
        }

        private void elec_otpr_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.Visible == false)
            {
                listBox1.Visible = true;
            }
            else
            {
                listBox1.Visible = false;
            } 
        }
        private void elec_nazn_DoubleClick(object sender, EventArgs e)
        {
            if (listBox2.Visible == false)
            {
                listBox2.Visible = true;
            }
            else
            {
                listBox2.Visible = false;
            } 
        }
        private void train_otpr_DoubleClick(object sender, EventArgs e)
        {
            if (listBox3.Visible == false)
            {
                listBox3.Visible = true;
            }
            else
            {
                listBox3.Visible = false;
            } 
        }
        private void train_nazn_DoubleClick(object sender, EventArgs e)
        {
            if (listBox4.Visible == false)
            {
                listBox4.Visible = true;
            }
            else
            {
                listBox4.Visible = false;
            } 
        }
        private void avia_otpr_DoubleClick(object sender, EventArgs e)
        {
            if (listBox5.Visible == false)
            {
                listBox5.Visible = true;
            }
            else
            {
                listBox5.Visible = false;
            } 
        }
        private void avia_nazn_DoubleClick(object sender, EventArgs e)
        {
            if (listBox6.Visible == false)
            {
                listBox6.Visible = true;
            }
            else
            {
                listBox6.Visible = false;
            } 
        }     


    }
}
