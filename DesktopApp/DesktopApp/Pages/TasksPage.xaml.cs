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
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace DesktopApp.Pages
{
    public class ViewModelTasks
    {
        public List<TasksClass> Items { get; set; }
    }

    /// <summary>
    /// Логика взаимодействия для TasksPage.xaml
    /// </summary>
    public partial class TasksPage : Page
    {
        private DatabaseHelper databaseHelper;
        public TasksPage(long metaid, List<UserLogin> user)
        {
            InitializeComponent();

            Metaid = metaid;
            _user = user;
            databaseHelper = new DatabaseHelper();
            items = databaseHelper.GetTasks(Metaid);
            DataContext = new ViewModelTasks { Items = items };
        }

        private List<UserLogin> _user;
        private long Metaid;
        private List<TasksClass> items;

        private void tbTasks_MouseEnter(object sender, MouseEventArgs e)
        {
            var focusTextBlock = (TextBlock)sender;
            focusTextBlock.Foreground = new SolidColorBrush(Color.FromRgb(94, 102, 138));
            focusTextBlock.TextDecorations = TextDecorations.Underline;
        }

        private void tbTasks_MouseLeave(object sender, MouseEventArgs e)
        {
            var focusTextBlock = (TextBlock)sender;
            focusTextBlock.Foreground = new SolidColorBrush(Color.FromRgb(98, 141, 183));
            focusTextBlock.TextDecorations = null;
        }

        private void tbTasks_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new MoreInfoPage($"{Metaid}", _user));
        }

        private void spTasks_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var focusStackPanel = (StackPanel)sender;
            focusStackPanel.Height = focusStackPanel.Height > 899 ? 25 : 900;
        }

        private void spTasks_MouseEnter(object sender, MouseEventArgs e)
        {
            var focusStackPanel = (StackPanel)sender;
            focusStackPanel.Background = new SolidColorBrush(Color.FromRgb(178, 186, 217));
        }

        private void spTasks_MouseLeave(object sender, MouseEventArgs e)
        {
            var focusStackPanel = (StackPanel)sender;
            focusStackPanel.Background = new SolidColorBrush(Color.FromRgb(210, 220, 255));
        }

        private void RootFrame_Initialized(object sender, EventArgs e)
        {
            var tasksItem = ((FrameworkElement)sender).DataContext as TasksClass;
            var rootFrame = (Frame)sender;
            if (rootFrame.Content == null)
            {
                rootFrame.NavigationService.Navigate(new ResultsPage(long.Parse(tasksItem.Metaid)));
            }
        }

        //private void spResults_GotFocus(object sender, RoutedEventArgs e)
        //{
        //    var tasksItem = ((FrameworkElement)sender).DataContext as TasksClass;
        //    this.NavigationService.Navigate(new ResultsPage(long.Parse(tasksItem.Metaid)));
        //}
    }
}
