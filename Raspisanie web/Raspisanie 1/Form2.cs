using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Raspisanie
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Music music2 = new Music();

        private void label1_Click(object sender, EventArgs e)
        {           
            Close();   
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            music2.music_off();
        }
        
    }
}
