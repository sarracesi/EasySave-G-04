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
using V_3._0.ViewModel;

namespace V_3._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        backupViewModel ViewModel;
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new backupViewModel();
            this.DataContext = ViewModel;
        }

        private void BackupView1_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
