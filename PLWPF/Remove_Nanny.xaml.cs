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
    /// Interaction logic for Remove_Nanny.xaml
    /// </summary>
    public partial class Remove_Nanny : Window
    {
        IBL bl;
        Nanny nanny = new Nanny();
        public Remove_Nanny()
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
            Grid.DataContext = nanny;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource nannyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("nannyViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // motherViewSource.Source = [generic data source]
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (nanny.ID != null)
                nanny = bl.GetNanny().Find(x => x.ID == nanny.ID);
            if (nanny.F_name != null)
                if (nanny.L_name != null)
                    nanny = bl.GetNanny().Find(x => x.F_name == nanny.F_name && x.L_name == nanny.L_name);
            try
            {
                bl.Remove_Nanny(nanny);
                idComboBox.Items.Remove(nanny.ID);
                nanny = new Nanny();
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
            foreach (var nan in bl.GetNanny())
            {
                ComboBoxItem newItem = new ComboBoxItem();
                newItem.Content = nan.ID;
                idComboBox.Items.Add(newItem);
            }
        }
    }
}
