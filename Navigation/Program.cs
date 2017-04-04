﻿using System;
using System.Windows.Forms;

namespace Navigation
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            welcome we = new welcome();
            we.ShowDialog();
            Application.Run(new MainForm());
        }
    }
}