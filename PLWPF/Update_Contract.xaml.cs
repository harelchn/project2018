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
    /// Interaction logic for Update_Contract.xaml
    /// </summary>
    public partial class Update_Contract : Window
    {
        IBL bl;
        Contract contract = new Contract();
        public Update_Contract()
        {
            InitializeComponent();

            bl = FactoryBL.GetBL();
            Grid.DataContext = contract;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.Update_Contract(contract);
                contract = new Contract();
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void MyShow()
        {
            Nanny n;
            Child c;
            Mother m;
            foreach (var cont in bl.GetContract())
            {
                n = bl.GetNanny().Find(x => x.ID == cont.IdNanny);
                c = bl.GetChild().Find(x => x.IdC == cont.IdChild);
                m = bl.GetMother().Find(x => x.ID == c.IdM);
                numComboBox.Items.Add(cont.Num + ":     " + "nanny:  " + n.F_name + ' ' + n.L_name
                    + "\n  mother:  " + m.F_name + ' ' + m.L_name + " child:  " + c.Name);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contract c;
            contract.Num = int.Parse(((string)(numComboBox.SelectedItem)).Split(':')[0]);
            c = bl.GetContract().Find(x => x.Num == contract.Num);
            contract.IdChild = c.IdChild;
            contract.Salary = c.Salary;
            salaryLabel.Content = contract.Salary;
        }
    }
}
