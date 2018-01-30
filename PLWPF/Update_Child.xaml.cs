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
    /// Interaction logic for Update_Child.xaml
    /// </summary>
    public partial class Update_Child : Window
    {
        IBL bl;
        Child child = new Child();
        public Update_Child()
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (child.IdC != null)
                {
                    if (child.SpecialNeeds != "")
                        child.IsSpecial = true;
                    bl.Update_Child(child);
                    child = new Child();
                    Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void MyShow()
        {
            Show();
            foreach (var ch in bl.GetChild())
            {
                Mother m = bl.GetMother().Find(x => x.ID == ch.IdM);
                idComboBox.Items.Add(ch.IdC + ",    " + ch.Name 
                    + "(mother: " + m.F_name + ' ' + m.L_name + ')');
            }
        }

        private void idComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            child.IdC = ((string)(idComboBox.SelectedItem)).Split(',')[0];
            child.IdM = bl.GetChild().Find(x => x.IdC == child.IdC).IdM;
        }
    }
}
