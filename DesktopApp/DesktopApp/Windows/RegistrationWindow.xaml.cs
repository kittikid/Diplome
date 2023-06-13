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
using System.Windows.Shapes;

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
