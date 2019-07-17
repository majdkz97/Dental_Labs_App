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
using Dental.Core;
using Dental.DAL;
namespace Dental.PL
{
    /// <summary>
    /// Interaction logic for PatientMainPage.xaml
    /// </summary>
    public partial class PatientsPage : UserControl
    {
        public PatientsPage()
        {
            InitializeComponent();
        }

        int k = 0;
        List<Patient> items;

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

        private void ButtonAddPatient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Patient patient = new Patient();
                patient.name = TextBoxName.Text;
                patient.age = int.Parse(TextBoxAge.Text);
                patient.number = TextBoxNotes.Text;
                if(patient.name=="")
                {
                    MessageBox.Show("أدخل اسم المريض");

                }
                else
                {
                    PatientDB.insertPatient(patient);


                    TextBoxName.Clear();
                    TextBoxNotes.Clear();
                    TextBoxAge.Clear();

                    Snackbar_Added.IsActive = true;
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               
            }
        
        }


        private void ButtonEditDG_Click(object sender, RoutedEventArgs e)
        {
            StackPanelEditAccount.Visibility = Visibility.Visible;
            Patient p = new Patient();
            p = items[DataGridEditDelete.SelectedIndex];

            TextBoxNameEdit.Text = p.name;
            TextBoxNotesEdit.Text = p.number;
            TextBoxAgeEdit.Text = p.age.ToString();
            TextBoxNameEdit.Uid = p.id.ToString();

        }


        private void Refresh_DataGrid_EditDelete()
        {
            items = PatientDB.selectPatients();
            DataGridEditDelete.ItemsSource = items;
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {

            Patient p = new Patient();
            p.name = TextBoxNameEdit.Text;
            p.number = TextBoxNotesEdit.Text;
            p.age = int.Parse(TextBoxAgeEdit.Text);
            p.id = int.Parse(TextBoxNameEdit.Uid);
            PatientDB.updatepatient(p);
            MessageBox.Show("تم التعديل");
            StackPanelEditAccount.Visibility = Visibility.Hidden;
            Refresh_DataGrid_EditDelete();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(TextBoxDelete.Uid);
            Patient p = new Patient();
            p.id = id;
            PatientDB.deletepatient(p);
            StackPanelDelete.Visibility = Visibility.Hidden;
            MessageBox.Show("تم الحذف");
            Refresh_DataGrid_EditDelete();
        }
        private void ButtonDeleteDG_Click(object sender, RoutedEventArgs e)
        {
            StackPanelDelete.Visibility = Visibility.Visible;
            Patient p = new Patient();
            p = items[DataGridEditDelete.SelectedIndex];

            TextBoxDelete.Text = "هل أنت متأكد من حذف " + p.name + " ؟";
            TextBoxDelete.Uid = p.id.ToString();
        }

        private void Refresh_DataGrid_ViewSearch()
        {
            items = PatientDB.selectPatients();
            DataGridViewSearch.ItemsSource = items;
        }

        private void ButtonViewSearch1_Click(object sender, RoutedEventArgs e)
        {
            String search = TextBoxViewSearch1.Text;
            if (search == "")
            {
                Refresh_DataGrid_ViewSearch();
            }
            else
            {
                List<Patient> newItems = new List<Patient>();
                foreach (var item in items)
                {
                    if (item.name.Contains(search))
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
                List<Patient> newItems = new List<Patient>();
                foreach (var item in items)
                {
                    if (item.age.ToString().Contains(search))
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
                List<Patient> newItems = new List<Patient>();
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

 
    }
}
