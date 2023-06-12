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

    public class ViewModelResults
    {
        public List<ResultsClass> Items { get; set; }
    }

    /// <summary>
    /// Логика взаимодействия для ResultsPage.xaml
    /// </summary>
    public partial class ResultsPage : Page
    {
        private DatabaseHelper databaseHelper;
        public ResultsPage(long metaid)
        {
            InitializeComponent();

            Metaid = metaid;
            databaseHelper = new DatabaseHelper();
            items = databaseHelper.GetResults(Metaid);
            DataContext = new ViewModelResults { Items = items };
        }

        private long Metaid;
        private List<ResultsClass> items;


    }
}
