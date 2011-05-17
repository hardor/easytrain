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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            richTextBox1.Text = "Создатели : \n  Вильданов Руслан \n Никитин Никита \n Лбов анатолий \n По всем пожеланиям писать на hardorzz@gmail.com";
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            // label1.Visible = true;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            //label1.Visible = false;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            // label3.Visible = true;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            //label3.Visible = false;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            //label2.Visible = true;          
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            //label2.Visible = false;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            // label4.Visible = true;
            
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            // label4.Visible = false;          
        }


     
    }
}
