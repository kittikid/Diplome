using System;
using System.Windows;

namespace DesktopApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var Database = SourceCore.RegProjectDatabase;
                Base.users Users = new Base.users();
                Users.name = tbName.Text;
                Users.password = pbPasswordBox.Password;
                Users.role_id = 2;
                Database.users.Add(Users);
                Database.SaveChanges();
            }
            catch (Exception excep) { MessageBox.Show(excep.Message); }
            MessageBox.Show("Пользователь успешно добавлен!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
            tbName.Text = string.Empty;
            pbPasswordBox.Password = string.Empty;
        }
    }
}
