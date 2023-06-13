using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
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
