﻿using System;
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

    public class ViewModelFirstPanel
    {
        public List<TileData> Items { get; set; }
    }

    /// <summary>
    /// Логика взаимодействия для MoreInfoPage.xaml
    /// </summary>
    public partial class MoreInfoPage : Page
    {
        private DatabaseHelper databaseHelper;
        public MoreInfoPage(string metaid)
        {
            InitializeComponent();
            Metaid = long.Parse(metaid);
            //MessageBox.Show($"{metaid}");
            databaseHelper = new DatabaseHelper();
            items = databaseHelper.LoadFirstPanel(Metaid);
            DataContext = new ViewModelFirstPanel { Items = items };
        }

        private List<TileData> items;
        private long Metaid;

        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
        }

        //-------------------выделение текста-----------------
        private void tbRegProject_MouseEnter(object sender, MouseEventArgs e)
        {
            var focusTextBlock = (TextBlock)sender;
            focusTextBlock.Foreground = new SolidColorBrush(Color.FromRgb(77, 112, 145));
            focusTextBlock.TextDecorations = TextDecorations.Underline;
        }

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

        private void tbPurposes_MouseLeave(object sender, MouseEventArgs e)
        {
            var focusTextBlock = (TextBlock)sender;
            focusTextBlock.Foreground = new SolidColorBrush(Color.FromRgb(114, 125, 170));
            focusTextBlock.TextDecorations = null;
        }

        private void tbPurposes_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //var regProjectItem = ((FrameworkElement)sender).DataContext as TileData; //коллекция элементов 
            //if (regProjectItem != null)
            //{
            //}
            this.NavigationService.Navigate(new PurposesPage(Metaid));
        }

        private void tbTasks_MouseEnter(object sender, MouseEventArgs e)
        {
            var focusTextBlock = (TextBlock)sender;
            focusTextBlock.Foreground = new SolidColorBrush(Color.FromRgb(94, 102, 138));
            focusTextBlock.TextDecorations = TextDecorations.Underline;
        }

        private void tbTasks_MouseLeave(object sender, MouseEventArgs e)
        {
            var focusTextBlock = (TextBlock)sender;
            focusTextBlock.Foreground = new SolidColorBrush(Color.FromRgb(114, 125, 170));
            focusTextBlock.TextDecorations = null;
        }

        private void tbTasks_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new TasksPage());
        }
    }
}
