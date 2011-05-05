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

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Караваны успешно ограблены");
        }
    }
}
