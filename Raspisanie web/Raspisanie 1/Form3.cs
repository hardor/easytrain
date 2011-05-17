using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Raspisanie
{
    public partial class Form3 : Form
    {
        // ���� � �����, ��� Windows ������� ������ ����������
        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        public Form3()
        {
            InitializeComponent();
            // ��������� ������� ��������� (�������� ��� ������� ��� ���)
            if (rkApp.GetValue("EasyTrain") == null)
            {
                // ���� �������� �� ����������, ���������� �� �������� �� ������ ��� ������
                chkRun.Checked = false;
            }
            else
            {
                // ���� �������� ����������, ���������� ��������������� �� ������ ��� ��������
                chkRun.Checked = true;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (chkRun.Checked)
            {
                // ��������� �������� � ������  ����� ���������� ����������� ��� �������
                rkApp.SetValue("EasyTrain", Application.ExecutablePath.ToString());
            }
            else
            {
                // ������� �������� �� ������� ����� ���������� �� ����������� ��� �������
                rkApp.DeleteValue("EasyTrain", false);
            }
            Close(); 
        }

    }
}