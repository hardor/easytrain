﻿using System;
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
        

        private void label1_Click(object sender, EventArgs e)
        {

            Close();
            Music music2 = new Music();
            music2.music_off();
        }
        
    }
}
