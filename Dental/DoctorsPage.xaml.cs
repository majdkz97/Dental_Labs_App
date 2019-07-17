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
using Dental.DAL;
using Dental.Core;

namespace Dental.PL
{
    /// <summary>
    /// Interaction logic for PatientMainPage.xaml
    /// </summary>
    public partial class DoctorsPage : UserControl
    {
        public DoctorsPage()
        {
            InitializeComponent();
        }
        int k = 0;
        List<Doctor> items;

        private void Radio3_Checked(object sender, RoutedEventArgs e)
        {
            Grid1.Visibility = Visibility.Hidden;
            Grid3.Visibility = Visibility.Visible;
            Grid2.Visibility = Visibility.Hidden;
            Grid4.Visibility = Visibility.Hidden;
            Refresh_DataGrid_ViewSearch();
        }

        private void Radio2_Checked(object sender, RoutedEventArgs e)
        {
            Grid1.Visibility = Visibility.Hidden;
            Grid3.Visibility = Visibility.Hidden;
            Grid2.Visibility = Visibility.Visible;
            Grid4.Visibility = Visibility.Hidden;
            Refresh_DataGrid_EditDelete();
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

        private void ButtonAddDoctor_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Doctor doctor = new Doctor();
                doctor.name = TextBoxName.Text;
                doctor.address = TextBoxAddress.Text;
                doctor.number = TextBoxPhone.Text;
                doctor.notes = TextBoxNotes.Text;

                if (doctor.name == "")
                {
                    MessageBox.Show("أدخل اسم الطبيب");
                }
                else
                {
                    DoctorDB.insertDoctor(doctor);
                    TextBoxName.Clear();
                    TextBoxAddress.Clear();
                    TextBoxNotes.Clear();
                    TextBoxPhone.Clear();
                    Snackbar_Added.IsActive = true;

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          



        }

        private void ButtonEditDG_Click(object sender, RoutedEventArgs e)
        {
            StackPanelEditAccount.Visibility = Visibility.Visible;
            Doctor p = new Doctor();
            p = items[DataGridEditDelete.SelectedIndex];

            TextBoxNameEdit.Text = p.name;
            TextBoxNotesEdit.Text = p.notes;
            TextBoxNumberEdit.Text = p.number;
            TextBoxAddressEdit.Text = p.address;
            TextBoxNameEdit.Uid = p.id.ToString();

        }


        private void Refresh_DataGrid_EditDelete()
        {
            items = DoctorDB.selectDoctors();
            DataGridEditDelete.ItemsSource = items;
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {

            Doctor p = new Doctor();
            p.name = TextBoxNameEdit.Text;
            p.notes = TextBoxNotesEdit.Text;
            p.number = TextBoxNumberEdit.Text;
            p.address = TextBoxNotesEdit.Text;

            p.id = int.Parse(TextBoxNameEdit.Uid);
            DoctorDB.updateDoctor(p);
            MessageBox.Show("تم التعديل");
            StackPanelEditAccount.Visibility = Visibility.Hidden;
            Refresh_DataGrid_EditDelete();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(TextBoxDelete.Uid);
            Doctor p = new Doctor();
            p.id = id;
            DoctorDB.deleteDoctor(p);
            StackPanelDelete.Visibility = Visibility.Hidden;
            MessageBox.Show("تم الحذف");
            Refresh_DataGrid_EditDelete();
        }
        private void ButtonDeleteDG_Click(object sender, RoutedEventArgs e)
        {
            StackPanelDelete.Visibility = Visibility.Visible;
            Doctor p = new Doctor();
            p = items[DataGridEditDelete.SelectedIndex];

            TextBoxDelete.Text = "هل أنت متأكد من حذف " + p.name + " ؟";
            TextBoxDelete.Uid = p.id.ToString();
        }

        private void Refresh_DataGrid_ViewSearch()
        {
            items = DoctorDB.selectDoctors();
            DataGridViewSearch.ItemsSource = items;
        }

        private void ButtonViewSearch1_Click(object sender, RoutedEventArgs e)
        {
            String search = TextBoxViewSearch1.Text;
            if(search=="")
            {
                Refresh_DataGrid_ViewSearch();
            }
            else
            {
                List<Doctor> newItems = new List<Doctor>();
                foreach(var item in items)
                {
                    if(item.name.Contains(search))
                    {
                        newItems.Add(item);
                    }
                }
                DataGridViewSearch.ItemsSource = newItems;
            }
        }

        private void ButtonViewSearch2_Click(object sender, RoutedEventArgs e)
        {
            String search = TextBoxViewSearch2.Text;
            if (search == "")
            {
                Refresh_DataGrid_ViewSearch();
            }
            else
            {
                List<Doctor> newItems = new List<Doctor>();
                foreach (var item in items)
                {
                    if (item.address.Contains(search))
                    {
                        newItems.Add(item);
                    }
                }
                DataGridViewSearch.ItemsSource = newItems;
            }
        }

        private void ButtonViewSearch3_Click(object sender, RoutedEventArgs e)
        {
            String search = TextBoxViewSearch3.Text;
            if (search == "")
            {
                Refresh_DataGrid_ViewSearch();
            }
            else
            {
                List<Doctor> newItems = new List<Doctor>();
                foreach (var item in items)
                {
                    if (item.number.Contains(search))
                    {
                        newItems.Add(item);
                    }
                }
                DataGridViewSearch.ItemsSource = newItems;
            }
        }

        private void ButtonViewSearch4_Click(object sender, RoutedEventArgs e)
        {

            String search = TextBoxViewSearch4.Text;
            if (search == "")
            {
                Refresh_DataGrid_ViewSearch();
            }
            else
            {
                List<Doctor> newItems = new List<Doctor>();
                foreach (var item in items)
                {
                    if (item.notes.Contains(search))
                    {
                        newItems.Add(item);
                    }
                }
                DataGridViewSearch.ItemsSource = newItems;
            }
        }
    }
}
