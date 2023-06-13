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
    public class ViewModelPurposes
    {
        public List<PurposesClass> Items { get; set; }
    }

    /// <summary>
    /// Логика взаимодействия для PurposesPage.xaml
    /// </summary>
    public partial class PurposesPage : Page
    {
        private DatabaseHelper databaseHelper;
        public PurposesPage(long metaid, List<UserLogin> user)
        {
            InitializeComponent();

            Metaid = metaid;
            _user = user;
            databaseHelper = new DatabaseHelper();
            items = databaseHelper.GetPurposes(Metaid);
            DataContext = new ViewModelPurposes { Items = items };
        }

        private List<UserLogin> _user;
        private long Metaid;
        private List<PurposesClass> items;

        private void tbRegProject_MouseLeave(object sender, MouseEventArgs e)
        {
            //#628db7
            var focusTextBlock = (TextBlock)sender;
            focusTextBlock.Foreground = new SolidColorBrush(Color.FromRgb(98, 141, 183));
            focusTextBlock.TextDecorations = null;
        }

        private void tbPurposes_MouseEnter(object sender, MouseEventArgs e)
        {
            var focusTextBlock = (TextBlock)sender;
            focusTextBlock.Foreground = new SolidColorBrush(Color.FromRgb(94, 102, 138));
            focusTextBlock.TextDecorations = TextDecorations.Underline;
        }

        private void tbPurposes_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //var regProjectItem = ((FrameworkElement)sender).DataContext as TileData; //коллекция элементов 
            //if (regProjectItem != null)
            //{
            //}
            this.NavigationService.Navigate(new MoreInfoPage($"{Metaid}", _user));
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            var focusTextBlock = (TextBlock)sender;
            focusTextBlock.Foreground = new SolidColorBrush(Color.FromRgb(94, 102, 138));
            focusTextBlock.TextDecorations = TextDecorations.Underline;
        }

        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            var focusTextBlock = (TextBlock)sender;
            focusTextBlock.Foreground = new SolidColorBrush(Color.FromRgb(114, 125, 170));
            focusTextBlock.TextDecorations = null;
        }

        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void spPurposes_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var focusStackPanel = (StackPanel)sender;
            focusStackPanel.Height = focusStackPanel.Height > 799 ? 25 : 800;
        }

        private void spPurposes_MouseEnter(object sender, MouseEventArgs e)
        {
            var focusStackPanel = (StackPanel)sender;
            focusStackPanel.Background = new SolidColorBrush(Color.FromRgb(178, 186, 217));
        }

        private void spPurposes_MouseLeave(object sender, MouseEventArgs e)
        {
            var focusStackPanel = (StackPanel)sender;
            focusStackPanel.Background = new SolidColorBrush(Color.FromRgb(210, 220, 255));
        }
    }
}
