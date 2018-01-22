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
    /// Interaction logic for Add_Mother.xaml
    /// </summary>
    public partial class Add_Mother : Window
    {
        IBL bl;
        Mother mother = new Mother();
        public Add_Mother()
        {
            InitializeComponent();

            bl = FactoryBL.GetBL();
            Grid.DataContext = mother;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource motherViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("motherViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // motherViewSource.Source = [generic data source]
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.Add_Mother(mother);
                mother = new Mother();
                Window.Visibility = Visibility.Hidden;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
