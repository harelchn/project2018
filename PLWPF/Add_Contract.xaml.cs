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
    /// Interaction logic for Add_Contract.xaml
    /// </summary>
    public partial class Add_Contract : Window
    {
        IBL bl;
        Contract contract = new Contract();
        public Add_Contract()
        {
            InitializeComponent();

            bl = FactoryBL.GetBL();
            grid.DataContext = contract;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource contractViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("contractViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // contractViewSource.Source = [generic data source]
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.Add_Contract(contract);
                Close();
                contract = new Contract();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void MyShow()
        {
            Show();
            foreach (Child ch in bl.GetChild())
            {
                ComboBoxItem newItem = new ComboBoxItem();
                newItem.Content = ch.IdC;
                idChildComboBox.Items.Add(newItem);
            }
            foreach (Nanny nan in bl.GetNanny())
            {
                ComboBoxItem newItem = new ComboBoxItem();
                newItem.Content = nan.ID;
                idNannyComboBox.Items.Add(newItem);
            }
        }

        private void Window_Close(object sender, EventArgs e)
        {
            Contract.Counter--;
        }

        private void CalculateSalary()
        {
            if (contract.IdChild != null && contract.IdNanny != null)
            {
                int counter = 1;
                Child child = bl.GetChild().Find(x => x.IdC == contract.IdChild);
                Nanny nanny = bl.GetNanny().Find(x => x.ID == contract.IdNanny);
                Mother mother = bl.GetMother().Find(x => x.ID == child.IdM);

                contract.IsHour = (mother.IsHour && nanny.IsHour);
                double pay = nanny.SalaryMonth;

                foreach (Contract cont in bl.GetContract())
                {
                    string idM = bl.GetChild().Find(x => x.IdC == cont.IdChild).IdM;
                    if (cont.IdNanny == nanny.ID && idM == mother.ID)
                        counter++;
                }
                if (contract.IsHour)
                {
                    contract.PayHour = nanny.PayHour;
                    double time = 0;
                    for (int i = 0; i < 6; i++)
                        if (mother.NannyDay[i])
                        {
                            time += (mother.NannyTime[i, 1] - mother.NannyTime[i, 0]).Hours;
                            time += (mother.NannyTime[i, 1] - mother.NannyTime[i, 0]).Minutes / 60;
                        }
                    time *= 4;
                    pay = time * nanny.PayHour;
                }

                contract.Salary = pay - pay * (counter) * 0.2;
                salaryLabel.Content = contract.Salary.ToString();
            }
        }

        private void IdChild_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalculateSalary();
        }

        private void IdNanny_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalculateSalary();
        }

        private void IdChild_TextInput(object sender, TextCompositionEventArgs e)
        {
            CalculateSalary();
        }

        private void IdNanny_TextInput(object sender, TextCompositionEventArgs e)
        {
            CalculateSalary();
        }
    }
}
