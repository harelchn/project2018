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
    /// Interaction logic for Add_Child.xaml
    /// </summary>
    public partial class Add_Child : Window
    {
        IBL bl;
        Child child = new Child();
        public Add_Child()
        {
            InitializeComponent();

            bl = FactoryBL.GetBL();
            Grid.DataContext = child;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource childViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("childViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // childViewSource.Source = [generic data source]
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (specialNeedsTextBox.Text != "")
                    child.IsSpecial = true;

                bl.Add_Child(child);
                Close();
                child = new Child();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void MyShow()
        {
            Show();
            foreach (Mother mom in bl.GetMother())
            {
                ComboBoxItem newItem = new ComboBoxItem();
                newItem.Content = mom.ID;
                idMComboBox.Items.Add(newItem);
            }
        }
    }
}
