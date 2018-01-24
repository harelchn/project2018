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
    /// Interaction logic for Remove_Contract.xaml
    /// </summary>
    public partial class Remove_Contract : Window
    {
        private IBL bl;
        private Contract contract = new Contract();
        public Remove_Contract()
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
            Grid.DataContext = contract;
            Contract.Counter--;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource contractViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("contractViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // motherViewSource.Source = [generic data source]
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.Remove_Contract(contract);
                numComboBox.Items.Remove(contract.Num);
                contract = new Contract();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void MyShow()
        {
            Show();
            foreach (var con in bl.GetContract())
            {
                ComboBoxItem newItem = new ComboBoxItem();
                newItem.Content = con.Num;
                numComboBox.Items.Add(newItem);
            }
        }
    }
}
