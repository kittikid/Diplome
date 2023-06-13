using DesktopApp.Classes;
using System.Collections.Generic;
using System.Windows.Controls;

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
