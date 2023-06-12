using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.Json;
using System.Net;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Windows.Threading;
using System.Timers;
using System.Collections.ObjectModel;
using static DesktopApp.JsonClass;
using NodaTime;
using DesktopApp.Base;
using System.Linq.Expressions;
using System.Data.Entity.Validation;
using System.Windows.Markup;
using Microsoft.Azure.Amqp.Framing;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Data.Common;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Data.Entity;
using System.Threading;
using Timer = System.Timers.Timer;
using static DesktopApp.DatabaseHelper;
using PagedList;
using NodaTimePicker;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.Panels;
using DesktopApp.Pages;
using DesktopApp.Windows;

namespace DesktopApp
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainFrame.Navigate(new MainPage());

            //timer = new Timer();
            //timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        }

        //private DateTime alarmDateTime;
        //private System.Timers.Timer timer;

        //private void SetAlarmButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (DateTime.TryParse(dpAlarmDate.SelectedDate.Value.ToString("dd/MM/yyyy") + " " + txtAlarmTime.Text, out alarmDateTime))
        //    {
        //        TimeSpan timeToAlarm = alarmDateTime - DateTime.Now;
        //        if (timeToAlarm.TotalMilliseconds > 0)
        //        {
        //            timer.Interval = timeToAlarm.TotalMilliseconds;
        //            timer.Enabled = true;
        //            MessageBox.Show("Alarm set for " + alarmDateTime.ToString("dd/MM/yyyy hh:mm tt"));
        //        }
        //        else
        //        {
        //            MessageBox.Show("Invalid date or time. Please enter a future date and time.");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Invalid date or time format. Please enter date in dd/MM/yyyy format and time in hh:mm tt format.");
        //    }
        //}

        //private void OnTimedEvent(object source, ElapsedEventArgs e)
        //{
        //    MessageBox.Show("Hello World");
        //    //Tiles.Add(new Tile { Title = "New Tile" });
        //    timer.Enabled = false;
        //}

        //private void GridSplitter_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    if (SplitViewPanel.Width == new GridLength(0))
        //        SplitViewPanel.Width = new GridLength(240);
        //    else
        //        SplitViewPanel.Width = new GridLength(0);
        //}

        //private void SettingsButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (SplitViewPanel.Width == new GridLength(0))
        //        SplitViewPanel.Width = new GridLength(240);
        //    else
        //        SplitViewPanel.Width = new GridLength(0);
        //}
    }
}
