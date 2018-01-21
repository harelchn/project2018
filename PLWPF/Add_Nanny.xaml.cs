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
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for Add_Nanny.xaml
    /// </summary>
    public partial class Add_Nanny : Window
    {
        IBL bl;
        Nanny nanny = new Nanny();
        public Add_Nanny()
        {
            InitializeComponent();

            bl = FactoryBL.GetBL();
            Grid.DataContext = nanny;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource nannyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("nannyViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // nannyViewSource.Source = [generic data source]
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bl.Add_Nanny(nanny);
            Window.Visibility = Visibility.Hidden;
        }
    }
}
