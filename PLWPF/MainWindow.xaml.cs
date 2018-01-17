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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BL;
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL bl;
        public MainWindow()
        {
            InitializeComponent();

            bl = FactoryBL.GetBL();

            Hide();
        }

        private void Hide()
        {
            nanny_addButton.Visibility = Visibility.Hidden;
            nanny_removeButton.Visibility = Visibility.Hidden;
            nanny_updateButton.Visibility = Visibility.Hidden;

            mother_addButton.Visibility = Visibility.Hidden;
            mother_removeButton.Visibility = Visibility.Hidden;
            mother_updateButton.Visibility = Visibility.Hidden;

            child_addButton.Visibility = Visibility.Hidden;
            child_removeButton.Visibility = Visibility.Hidden;
            child_updateButton.Visibility = Visibility.Hidden;

            contract_addButton.Visibility = Visibility.Hidden;
            contract_removeButton.Visibility = Visibility.Hidden;
            contract_updateButton.Visibility = Visibility.Hidden;
        }

        private void nannyButton_Click(object sender, RoutedEventArgs e)
        {
            if (nanny_addButton.Visibility == Visibility.Visible)
                Hide();
            else
            {
                Hide();
                nanny_addButton.Visibility = Visibility.Visible;
                nanny_removeButton.Visibility = Visibility.Visible;
                nanny_updateButton.Visibility = Visibility.Visible;
            }
        }

        private void motherButon_Click(object sender, RoutedEventArgs e)
        {
            if (mother_addButton.Visibility == Visibility.Visible)
                Hide();
            else
            {
                Hide();
                mother_addButton.Visibility = Visibility.Visible;
                mother_removeButton.Visibility = Visibility.Visible;
                mother_updateButton.Visibility = Visibility.Visible;
            }
        }

        private void childButton_Click(object sender, RoutedEventArgs e)
        {
            if (child_addButton.Visibility == Visibility.Visible)
                Hide();
            else
            {
                Hide();
                child_addButton.Visibility = Visibility.Visible;
                child_removeButton.Visibility = Visibility.Visible;
                child_updateButton.Visibility = Visibility.Visible;
            }
        }

        private void contractButton_Click(object sender, RoutedEventArgs e)
        {
            if (contract_addButton.Visibility == Visibility.Visible)
                Hide();
            else
            {
                Hide();
                contract_addButton.Visibility = Visibility.Visible;
                contract_removeButton.Visibility = Visibility.Visible;
                contract_updateButton.Visibility = Visibility.Visible;
            }
        }

        private void nanny_addButton_Click(object sender, RoutedEventArgs e)
        {
            Window w = new Add_Nanny();
            w.Show();
        }

        private void mother_addButton_Click(object sender, RoutedEventArgs e)
        {
            Window w = new Add_Mother();
            w.Show();
        }

        private void child_addButton_Click(object sender, RoutedEventArgs e)
        {
            Window w = new Add_Child();
            w.Show();
        }

        private void contract_addButton_Click(object sender, RoutedEventArgs e)
        {
            Window w = new Add_Contract();
            w.Show();
        }
    }
}
