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
using DesktopApp.Classes;

namespace DesktopApp
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(List<UserLogin> user)
        {
            InitializeComponent();

            MainFrame.Navigate(new MainPage(user));
        }

        private void ExitImage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            AutorizationWindow autorizationWindow = new AutorizationWindow();
            autorizationWindow.Show();
            this.Close();
        }
    }
}
