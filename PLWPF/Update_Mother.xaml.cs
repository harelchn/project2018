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
    /// Interaction logic for Update_Mother.xaml
    /// </summary>
    public partial class Update_Mother : Window
    {
        IBL bl;
        Mother mother = new Mother();
        public Update_Mother()
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
            Grid.DataContext = mother;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource motherViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("motherViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // childViewSource.Source = [generic data source]
        }
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (mother.ID != null)
            {
                if (mother.NannyDay[0])
                {
                    mother.NannyTime[0, 0] = TimeSpan.Parse(TP01.Text);
                    mother.NannyTime[0, 1] = TimeSpan.Parse(TP11.Text);
                }
                if (mother.NannyDay[1])
                {
                    mother.NannyTime[1, 0] = TimeSpan.Parse(TP02.Text);
                    mother.NannyTime[1, 1] = TimeSpan.Parse(TP12.Text);
                }
                if (mother.NannyDay[2])
                {
                    mother.NannyTime[2, 0] = TimeSpan.Parse(TP03.Text);
                    mother.NannyTime[2, 1] = TimeSpan.Parse(TP13.Text);
                }
                if (mother.NannyDay[3])
                {
                    mother.NannyTime[3, 0] = TimeSpan.Parse(TP04.Text);
                    mother.NannyTime[3, 1] = TimeSpan.Parse(TP14.Text);
                }
                if (mother.NannyDay[4])
                {
                    mother.NannyTime[4, 0] = TimeSpan.Parse(TP05.Text);
                    mother.NannyTime[4, 1] = TimeSpan.Parse(TP15.Text);
                }
                if (mother.NannyDay[5])
                {
                    mother.NannyTime[5, 0] = TimeSpan.Parse(TP06.Text);
                    mother.NannyTime[5, 1] = TimeSpan.Parse(TP16.Text);
                }
                try
                {
                    bl.Update_Mother(mother);
                    mother = new Mother();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void MyShow()
        {
            Show();
            foreach (var mom in bl.GetMother())
            {
                idComboBox.Items.Add(mom.ID + ", " + mom.F_name + "  " + mom.L_name);
            }
        }

        private void idComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mother.ID = ((string)(idComboBox.SelectedItem)).Split(',')[0];
            mother = new Mother();
            mother = bl.GetMother().Find(x => x.ID == mother.ID);
            Grid.DataContext = mother;
            if (mother.NannyDay[0])
            {
                TP01.Text = Convert.ToString(mother.NannyTime[0, 0]).Substring(0, 5);
                TP11.Text = Convert.ToString(mother.NannyTime[0, 1]).Substring(0, 5);
            }
            if (mother.NannyDay[1])
            {
                TP02.Text = Convert.ToString(mother.NannyTime[1, 0]).Substring(0, 5);
                TP12.Text = Convert.ToString(mother.NannyTime[1, 1]).Substring(0, 5);
            }
            if (mother.NannyDay[2])
            {
                TP03.Text = Convert.ToString(mother.NannyTime[2, 0]).Substring(0, 5);
                TP13.Text = Convert.ToString(mother.NannyTime[2, 1]).Substring(0, 5);
            }
            if (mother.NannyDay[3])
            {
                TP04.Text = Convert.ToString(mother.NannyTime[3, 0]).Substring(0, 5);
                TP14.Text = Convert.ToString(mother.NannyTime[3, 1]).Substring(0, 5);
            }
            if (mother.NannyDay[4])
            {
                TP05.Text = Convert.ToString(mother.NannyTime[4, 0]).Substring(0, 5);
                TP15.Text = Convert.ToString(mother.NannyTime[4, 1]).Substring(0, 5);
            }
            if (mother.NannyDay[5])
            {
                TP06.Text = Convert.ToString(mother.NannyTime[5, 0]).Substring(0, 5);
                TP16.Text = Convert.ToString(mother.NannyTime[5, 1]).Substring(0, 5);
            }
        }
    }
}
