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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int k = 0;
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {

            Application.Current.Shutdown();

        }

        private void Btn_Minimize_MainWindow_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GridTopBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();

        }

        private void GridTopBar_MouseEnter(object sender, MouseEventArgs e)
        {
            if (this.Cursor != Cursors.Wait)

                Mouse.OverrideCursor = Cursors.ScrollAll;

        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            if (k!=0)
            MoveCursorMenu(index);
            
            switch (index)
            {
                case 0:
                    if(k!=0)
                    {
                        GridMainView.Children.Clear();
                  //      GridMainView.Children.Add(new AppointmentsMainSelecttion());
                    }


                    break;
                case 1:
                    GridMainView.Children.Clear();
                    GridMainView.Children.Add(new OrdersPage());

                    break;
                case 2:
                    GridMainView.Children.Clear();
                    GridMainView.Children.Add(new BillsPage());
                    break;
                case 3:
                    GridMainView.Children.Clear();
                    GridMainView.Children.Add(new DoctorsPage());
                    

                    break;
                case 4:
                    GridMainView.Children.Clear();
                    GridMainView.Children.Add(new PatientsPage());
                    break;
                case 5:
                    GridMainView.Children.Clear();
                    GridMainView.Children.Add(new PieceTypePage());
                    break;
                case 6:
                    GridMainView.Children.Clear();
                    GridMainView.Children.Add(new MaterialsPage());
                    break;
                case 7:
                    GridMainView.Children.Clear();
                    GridMainView.Children.Add(new LevelsPage());
                    break;
                case 8:
                    GridMainView.Children.Clear();
                    GridMainView.Children.Add(new EmployeesPage());
                    break;
                default:
                    GridMainView.Children.Clear();

                    break;
            }
            k = 1;
        }

        private void MoveCursorMenu(int index)
        {
            TrainsitionigContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (100 + (60 * index)), 0, 0);
        }
        private void GridTopBar_MouseLeave(object sender, MouseEventArgs e)
        {

            if (this.Cursor != Cursors.Wait)

                Mouse.OverrideCursor = Cursors.Arrow;
        }

      
        private void GridTopClosePanel_MouseEnter(object sender, MouseEventArgs e)
        {
            if (this.Cursor != Cursors.Wait)

                Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void GridTopClosePanel_MouseLeave(object sender, MouseEventArgs e)
        {
            if (this.Cursor != Cursors.Wait)

                Mouse.OverrideCursor = Cursors.ScrollAll;
        }
    }
}
