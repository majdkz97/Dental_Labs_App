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

namespace Dental.PL
{
    /// <summary>
    /// Interaction logic for PatientMainPage.xaml
    /// </summary>
    public partial class BillsPage : UserControl
    {
        public BillsPage()
        {
            InitializeComponent();
        }
        int k = 0;


        private void Radio3_Checked(object sender, RoutedEventArgs e)
        {
            Grid1.Visibility = Visibility.Hidden;
            Grid3.Visibility = Visibility.Visible;
            Grid2.Visibility = Visibility.Hidden;
            Grid4.Visibility = Visibility.Hidden;

        }

        private void Radio2_Checked(object sender, RoutedEventArgs e)
        {
            Grid1.Visibility = Visibility.Hidden;
            Grid3.Visibility = Visibility.Hidden;
            Grid2.Visibility = Visibility.Visible;
            Grid4.Visibility = Visibility.Hidden;
        }

        private void Radio1_Checked(object sender, RoutedEventArgs e)
        {

            try
            {

                if (k != 0)
                {
                    Grid1.Visibility = Visibility.Visible;
                    Grid3.Visibility = Visibility.Hidden;
                    Grid4.Visibility = Visibility.Hidden;
                    Grid2.Visibility = Visibility.Hidden;

                }
                k = 1;
            }

            catch (Exception ex)
            {

            }

        }



        private void Radio4_Checked(object sender, RoutedEventArgs e)
        {
            Grid1.Visibility = Visibility.Hidden;
            Grid3.Visibility = Visibility.Hidden;
            Grid4.Visibility = Visibility.Visible;
            Grid2.Visibility = Visibility.Hidden;
        }


    }
}
