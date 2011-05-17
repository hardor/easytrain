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
        Music music2 = new Music();
        public Form2()
        {
            InitializeComponent();
        }
        
        private void label1_Click(object sender, EventArgs e)
        { //закрываем окно с напоминанием          
            Close();   
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {//отклчаем музыку при закрытии формы
            music2.music_off();
        }
        
    }
}
