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

        Add_Child add_Child;
        Add_Contract add_Contract;
        Add_Mother add_Mother;
        Add_Nanny add_Nanny;

        Remove_Child remove_Child;
        Remove_Contract remove_Contract;
        Remove_Mother remove_Mother;
        Remove_Nanny remove_Nanny;

        Update_Child update_Child;
        Update_Mother update_Mother;
        Update_Nanny update_Nanny;
        Update_Contract update_Contract;
        public MainWindow()
        {
            InitializeComponent();

            bl = FactoryBL.GetBL();

            bl.InIt();
            
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

        #region menu buttons
        private void nannyButton_Click(object sender, RoutedEventArgs e)
        {
            if (nanny_addButton.Visibility == Visibility.Visible)
            {
                Hide();
                mother_image.Visibility = Visibility.Visible;
                contract_image.Visibility = Visibility.Visible;
                child_image.Visibility = Visibility.Visible;
            }
            else
            {
                Hide();
                nanny_addButton.Visibility = Visibility.Visible;
                nanny_removeButton.Visibility = Visibility.Visible;
                nanny_updateButton.Visibility = Visibility.Visible;
              mother_image.Visibility = Visibility.Visible;
                contract_image.Visibility = Visibility.Visible;
                child_image.Visibility = Visibility.Visible;
            }
        }

        private void motherButon_Click(object sender, RoutedEventArgs e)
        {
            if (mother_addButton.Visibility == Visibility.Visible)
            {
                Hide();
                mother_image.Visibility = Visibility.Visible;
                contract_image.Visibility = Visibility.Visible;
                child_image.Visibility = Visibility.Visible;
               
            }
            else
            {
                Hide();
                mother_addButton.Visibility = Visibility.Visible;
                mother_removeButton.Visibility = Visibility.Visible;
                mother_updateButton.Visibility = Visibility.Visible;
                mother_image.Visibility = Visibility.Hidden;
                contract_image.Visibility = Visibility.Visible;
                child_image.Visibility = Visibility.Visible;
                
            }
        }

        private void childButton_Click(object sender, RoutedEventArgs e)
        {
            if (child_addButton.Visibility == Visibility.Visible)
            {
                Hide();
                mother_image.Visibility = Visibility.Visible;
                contract_image.Visibility = Visibility.Visible;
                child_image.Visibility = Visibility.Visible;
            }
            else
            {
                Hide();
                child_addButton.Visibility = Visibility.Visible;
                child_removeButton.Visibility = Visibility.Visible;
                child_updateButton.Visibility = Visibility.Visible;
                child_image.Visibility = Visibility.Hidden;
                mother_image.Visibility = Visibility.Visible;
                contract_image.Visibility = Visibility.Visible;
              
            }
        }

        private void contractButton_Click(object sender, RoutedEventArgs e)
        {
            if (contract_addButton.Visibility == Visibility.Visible)
            {
                Hide();
                mother_image.Visibility = Visibility.Visible;
                contract_image.Visibility = Visibility.Visible;
                child_image.Visibility = Visibility.Visible;
            }
            else
            {
                Hide();
                contract_addButton.Visibility = Visibility.Visible;
                contract_removeButton.Visibility = Visibility.Visible;
                contract_updateButton.Visibility = Visibility.Visible;
                contract_image.Visibility = Visibility.Hidden;
                mother_image.Visibility = Visibility.Visible;
                child_image.Visibility = Visibility.Visible;
            }
        }
        #endregion

        #region add buttons
        private void nanny_addButton_Click(object sender, RoutedEventArgs e)
        {
            add_Nanny = new Add_Nanny();
            add_Nanny.Show();
        }

        private void mother_addButton_Click(object sender, RoutedEventArgs e)
        {
            add_Mother = new Add_Mother();
            add_Mother.Show();
        }

        private void child_addButton_Click(object sender, RoutedEventArgs e)
        {
            add_Child = new Add_Child();
            add_Child.MyShow();
        }

        private void contract_addButton_Click(object sender, RoutedEventArgs e)
        {
            add_Contract = new Add_Contract();
            add_Contract.MyShow();
        }
        #endregion

        #region remove buttons
        private void nanny_removeButton_Click(object sender, RoutedEventArgs e)
        {
            remove_Nanny = new Remove_Nanny();
            remove_Nanny.MyShow();
        }

        private void mother_removeButton_Click(object sender, RoutedEventArgs e)
        {
            remove_Mother = new Remove_Mother();
            remove_Mother.MyShow();
        }

        private void child_removeButton_Click(object sender, RoutedEventArgs e)
        {
            remove_Child = new Remove_Child();
            remove_Child.MyShow();
        }

        private void contract_removeButton_Click(object sender, RoutedEventArgs e)
        {
            remove_Contract = new Remove_Contract();
            remove_Contract.MyShow();
        }
        #endregion

        #region update buttons

        private void nanny_updateButton_Click(object sender, RoutedEventArgs e)
        {
            update_Nanny = new Update_Nanny();
            update_Nanny.MyShow();
        }

        private void mother_updateButton_Click_1(object sender, RoutedEventArgs e)
        {
            update_Mother = new Update_Mother();
            update_Mother.MyShow();
        }

        private void contract_updateButton_Click(object sender, RoutedEventArgs e)
        {
            update_Contract = new Update_Contract();
            update_Contract.Show();
        }

        private void child_updateButton_Click(object sender, RoutedEventArgs e)
        {
            update_Child = new Update_Child();
            update_Child.MyShow();
        }

        #endregion
    }
}
