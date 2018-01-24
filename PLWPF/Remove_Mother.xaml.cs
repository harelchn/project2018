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
    /// Interaction logic for Remove_Mother.xaml
    /// </summary>
    public partial class Remove_Mother : Window
    {
        IBL bl;
        Mother mother = new Mother();
        public Remove_Mother()
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(mother.ID != null)
                mother = bl.GetMother().Find(x => x.ID == mother.ID);
            if (mother.F_name != null)
                if (mother.L_name != null)
                    mother = bl.GetMother().Find(x => x.F_name == mother.F_name && x.L_name == mother.L_name);
            try
            {
                bl.Remove_Mother(mother);
                idComboBox.Items.Remove(mother.ID);
                mother = new Mother();
                Window.Visibility = Visibility.Hidden;
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
                idComboBox.Items.Add(newItem);
            }
        }
    }
}
