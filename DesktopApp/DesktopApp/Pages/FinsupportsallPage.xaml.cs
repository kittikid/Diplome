using DesktopApp.Base;
using DesktopApp.Classes;
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

namespace DesktopApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для FinsupportsallPage.xaml
    /// </summary>
    public partial class FinsupportsallPage : Page
    {
        private DatabaseHelper databaseHelper;
        public FinsupportsallPage(long metaid, List<UserLogin> user)
        {
            InitializeComponent();
            Metaid = metaid;
            _user = user;
            databaseHelper = new DatabaseHelper();
            items = databaseHelper.GetFinSupp(Metaid);
            FinSuppDataGrid.ItemsSource = items;
        }

        private List<UserLogin> _user;
        private List<FinSuppClass> items;
        private long Metaid;

        private void tbFinsupp_MouseEnter(object sender, MouseEventArgs e)
        {
            var focusTextBlock = (TextBlock)sender;
            focusTextBlock.Foreground = new SolidColorBrush(Color.FromRgb(94, 102, 138));
            focusTextBlock.TextDecorations = TextDecorations.Underline;
        }

        private void tbFinsupp_MouseLeave(object sender, MouseEventArgs e)
        {
            var focusTextBlock = (TextBlock)sender;
            focusTextBlock.Foreground = new SolidColorBrush(Color.FromRgb(114, 125, 170));
            focusTextBlock.TextDecorations = null;
        }

        private void tbFinsupp_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new MoreInfoPage($"{Metaid}", _user));
        }
    }
}
