using DesktopApp.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace DesktopApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для AutorizationWindow.xaml
    /// </summary>
    public partial class AutorizationWindow : Window
    {
        public AutorizationWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = new List<UserLogin>();
            var Database = SourceCore.RegProjectDatabase.users;
            Database.Where(x => x.name == tbName.Text && x.password == pbPasswordBox.Password).ToList().ForEach(rpt =>
            {
                user.Add(new UserLogin
                {
                    Id = rpt.id,
                    Name = rpt.name,
                    Password = rpt.password,
                    Role = (int)rpt.role_id
                });
            });
            MainWindow mainWindow = new MainWindow(user);
            mainWindow.Show();
            this.Close();
        }
    }
}
