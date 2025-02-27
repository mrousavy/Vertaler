﻿using System;
using System.Windows;
using Hardcodet.Wpf.TaskbarNotification;

namespace Vertaler
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void AppStartup(object sender, StartupEventArgs e)
        {
            var trayIcon = FindResource("TrayIcon") as TaskbarIcon;

            Console.WriteLine("App started!");
        }
    }
}