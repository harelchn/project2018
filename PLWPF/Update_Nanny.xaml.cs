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
    /// Interaction logic for Update_Nanny.xaml
    /// </summary>
    public partial class Update_Nanny : Window
    {
        IBL bl;
        Nanny nanny = new Nanny();
        public Update_Nanny()
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
            Grid.DataContext = nanny;
            payHourLabel.Visibility = Visibility.Hidden;
            payHourTextBox.Visibility = Visibility.Hidden;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource nannyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("nannyViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // childViewSource.Source = [generic data source]
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (nanny.ID != null)
                {
                    if (nanny.WorkDay[0])
                    {
                        nanny.WorkTime[0, 0] = TimeSpan.Parse(TP01.Text);
                        nanny.WorkTime[0, 1] = TimeSpan.Parse(TP11.Text);
                    }
                    if (nanny.WorkDay[1])
                    {
                        nanny.WorkTime[1, 0] = TimeSpan.Parse(TP02.Text);
                        nanny.WorkTime[1, 1] = TimeSpan.Parse(TP12.Text);
                    }
                    if (nanny.WorkDay[2])
                    {
                        nanny.WorkTime[2, 0] = TimeSpan.Parse(TP03.Text);
                        nanny.WorkTime[2, 1] = TimeSpan.Parse(TP13.Text);
                    }
                    if (nanny.WorkDay[3])
                    {
                        nanny.WorkTime[3, 0] = TimeSpan.Parse(TP04.Text);
                        nanny.WorkTime[3, 1] = TimeSpan.Parse(TP14.Text);
                    }
                    if (nanny.WorkDay[4])
                    {
                        nanny.WorkTime[4, 0] = TimeSpan.Parse(TP05.Text);
                        nanny.WorkTime[4, 1] = TimeSpan.Parse(TP15.Text);
                    }
                    if (nanny.WorkDay[5])
                    {
                        nanny.WorkTime[5, 0] = TimeSpan.Parse(TP06.Text);
                        nanny.WorkTime[5, 1] = TimeSpan.Parse(TP16.Text);
                    }
                    bl.Update_Nanny(nanny);
                    nanny = new Nanny();
                    Close();
                }
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
                idComboBox.Items.Add(nan.ID + ", " + nan.F_name + "  " + nan.L_name);
            }
        }

        private void IsHour_Click(object sender, RoutedEventArgs e)
        {
            if (payHourTextBox.Visibility == Visibility.Hidden)
            {
                payHourTextBox.Visibility = Visibility.Visible;
                payHourLabel.Visibility = Visibility.Visible;
            }
            else
            {
                payHourTextBox.Visibility = Visibility.Hidden;
                payHourLabel.Visibility = Visibility.Hidden;
            }
        }

        private void idComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nanny = new Nanny();
            nanny.ID = ((string)(idComboBox.SelectedItem)).Split(',')[0];
            nanny = bl.GetNanny().Find(x => x.ID == nanny.ID);
            Grid.DataContext = nanny;
            if (nanny.IsHour)
            {
                payHourLabel.Visibility = Visibility.Visible;
                payHourTextBox.Visibility = Visibility.Visible;
            }
            if (nanny.WorkDay[0])
            {
                TP01.Text = Convert.ToString( nanny.WorkTime[0, 0]).Substring(0,5);
                TP11.Text = Convert.ToString(nanny.WorkTime[0, 1]).Substring(0, 5);
            }
            if (nanny.WorkDay[1])
            {
                TP02.Text = Convert.ToString(nanny.WorkTime[1, 0]).Substring(0, 5);
                TP12.Text = Convert.ToString(nanny.WorkTime[1, 1]).Substring(0, 5);
            }
            if (nanny.WorkDay[2])
            {
                TP03.Text = Convert.ToString(nanny.WorkTime[2, 0]).Substring(0, 5);
                TP13.Text = Convert.ToString(nanny.WorkTime[2, 1]).Substring(0, 5);
            }
            if (nanny.WorkDay[3])
            {
                TP04.Text = Convert.ToString(nanny.WorkTime[3, 0]).Substring(0, 5);
                TP14.Text = Convert.ToString(nanny.WorkTime[3, 1]).Substring(0, 5);
            }
            if (nanny.WorkDay[4])
            {
                TP05.Text = Convert.ToString(nanny.WorkTime[4, 0]).Substring(0, 5);
                TP15.Text = Convert.ToString(nanny.WorkTime[4, 1]).Substring(0, 5);
            }
            if (nanny.WorkDay[5])
            {
                TP01.Text = Convert.ToString(nanny.WorkTime[5, 0]).Substring(0, 5);
                TP11.Text = Convert.ToString(nanny.WorkTime[5, 1]).Substring(0, 5);
            }
        }
    }
}
