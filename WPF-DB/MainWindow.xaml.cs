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
using WPF_DB.DataSetTableAdapters;

namespace WPF_DB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// erm software or framework
    public partial class MainWindow : Window
    {
        private GamesTableAdapter adapter = new GamesTableAdapter();
        private DataSet dataSet = new DataSet();

        public MainWindow()
        {
            InitializeComponent();
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            adapter.Fill(dataSet.Games);
            DataContext = dataSet.Games.DefaultView;
            
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            adapter.Update(dataSet);
        }
    }
}
