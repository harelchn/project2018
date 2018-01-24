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
    /// Interaction logic for Add_Nanny.xaml
    /// </summary>
    public partial class Add_Nanny : Window
    {
        IBL bl;
        Nanny nanny = new Nanny();
        public Add_Nanny()
        {
            InitializeComponent();

            bl = FactoryBL.GetBL();
            Grid.DataContext = nanny;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource nannyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("nannyViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // nannyViewSource.Source = [generic data source]
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
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

            try
            {
                bl.Add_Nanny(nanny);
                Window.Visibility = Visibility.Hidden;
                nanny = new Nanny();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
