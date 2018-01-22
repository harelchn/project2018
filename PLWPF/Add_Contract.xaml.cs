﻿using System;
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
            Grid.DataContext = contract;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource contractViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("contractViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // contractViewSource.Source = [generic data source]
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.Add_Contract(contract);
                contract = new Contract();
                Window.Visibility = Visibility.Hidden;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Close(object sender, EventArgs e)
        {
            Contract.Counter--;
        }
    }
}
