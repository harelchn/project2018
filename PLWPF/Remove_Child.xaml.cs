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
using BL;
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for Remove_Child.xaml
    /// </summary>
    public partial class Remove_Child : Window
    {
        IBL bl;
        Child child = new Child();
        public Remove_Child()
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
            Grid.DataContext = child;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource childViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("childViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // motherViewSource.Source = [generic data source]
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (child.IdC != null)
                child = bl.GetChild().Find(x => x.IdC == child.IdC);
            if (child.Name != null)
                child = bl.GetChild().Find(x => x.Name == child.Name);
            try
            {
                bl.Remove_Child(child);
                idComboBox.Items.Remove(child.IdC);
                child = new Child();
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
            foreach (var ch in bl.GetChild())
            {
                ComboBoxItem newItem = new ComboBoxItem();
                newItem.Content = ch.IdC;
                idComboBox.Items.Add(newItem);
            }
        }
    }
}
