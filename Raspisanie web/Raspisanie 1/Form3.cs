using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Raspisanie
{
    public partial class Form3 : Form
    {
        // путь к ключу, где Windows смотрит запуск приложений
        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        public Form3()
        {
            InitializeComponent();
            // Проверяем текущее состояние (работает при запуске или нет)
            if (rkApp.GetValue("EasyTrain") == null)
            {
                // если значения не существует, приложение не настроен на запуск при старте
                chkRun.Checked = false;
            }
            else
            {
                // если значение существует, приложение устанавливается на запуск при загрузке
                chkRun.Checked = true;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (chkRun.Checked)
            {
                // Добавляем значение в реестр  чтобы приложение запускалось при запуске
                rkApp.SetValue("EasyTrain", Application.ExecutablePath.ToString());
            }
            else
            {
                // Удаляем значение из реестра чтобы приложение не запускалось при запуске
                rkApp.DeleteValue("EasyTrain", false);
            }
            Close(); 
        }

    }
}