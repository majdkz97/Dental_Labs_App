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
using System.Text.RegularExpressions;

namespace Dental.PL
{
    /// <summary>
    /// Interaction logic for PatientMainPage.xaml
    /// </summary>
    public partial class OrdersPage : UserControl
    {
        public OrdersPage()
        {
            InitializeComponent();
        }
        int k = 0;
        List<Order> items;

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

        private void ButtonEditDG_Click(object sender, RoutedEventArgs e)
        {
            StackPanelEditAccount.Visibility = Visibility.Visible;
            Order p = new Order();
            p = items[DataGridEditDelete.SelectedIndex];
            DatePickerOrderDelEdit.Uid = p.id.ToString();
            
            DatePickerOrderEdit.Text = p.date_register;
            DatePickerOrderDelEdit.Text = p.date_delivered;
            

        }


        private void Refresh_DataGrid_EditDelete()
        {
            items = OrderDB.selectOrders();
            DataGridEditDelete.ItemsSource = items;
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {

            Order p = new Order();
            p.date_register = DatePickerOrderEdit.SelectedDate.Value.ToString("yyyy/MM/dd");

            p.date_delivered = DatePickerOrderDelEdit.SelectedDate.Value.ToString("yyyy/MM/dd");
            p.id = int.Parse(DatePickerOrderDelEdit.Uid.ToString());
            Doctor doctor = new Doctor();
            doctor.id = int.Parse(ComboBoxDoctorEdit.SelectedValue.ToString());
            p.doctor = doctor;

            Patient patient = new Patient();
            patient.id = int.Parse(ComboBoxPatientEdit.SelectedValue.ToString());
            p.patient = patient;

            Bill bill = new Bill();
            bill.id = 0;
            p.bill = bill;

            OrderDB.updateOrder(p);
            MessageBox.Show("تم التعديل");
            StackPanelEditAccount.Visibility = Visibility.Hidden;
            Refresh_DataGrid_EditDelete();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(TextBoxDelete.Uid);
            Order p = new Order();
            p.id = id;
            OrderDB.deleteOrder(p);
            StackPanelDelete.Visibility = Visibility.Hidden;
            MessageBox.Show("تم الحذف");
            Refresh_DataGrid_EditDelete();
        }
        private void ButtonDeleteDG_Click(object sender, RoutedEventArgs e)
        {
            StackPanelDelete.Visibility = Visibility.Visible;
            Order p = new Order();
            p = items[DataGridEditDelete.SelectedIndex];

            TextBoxDelete.Text = "هل أنت متأكد من حذف الطلبية  " + p.id + " ؟";
            TextBoxDelete.Uid = p.id.ToString();
        }


        private void ComboBoxDoctor_DropDownOpened(object sender, EventArgs e)
        {
            List<Doctor> doctors = DoctorDB.selectDoctors();
            Doctor d = new Doctor();
            d.id = -2;
            d.name = "إضافة طبيب جديد";
            doctors.Add(d);
            doctors.Reverse();
            ComboBoxDoctor.ItemsSource = doctors;
            ComboBoxDoctor.SelectedValuePath = "id";
            ComboBoxDoctor.DisplayMemberPath = "name";
            ComboBoxDoctorEdit.ItemsSource = doctors;
            ComboBoxDoctorEdit.SelectedValuePath = "id";
            ComboBoxDoctorEdit.DisplayMemberPath = "name";
        }

        private void ComboBoxDoctor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int first = 0;
            int index = ComboBoxDoctor.SelectedIndex;
            if(index == first)
            {
                GridAddDoctor.Visibility = Visibility.Visible;
            }
        }

        private void ComboBoxPatient_DropDownOpened(object sender, EventArgs e)
        {
            List<Patient> patients = PatientDB.selectPatients();
            Patient d = new Patient();
            d.id = -2;
            d.name = "إضافة مريض جديد";
            patients.Add(d);
            patients.Reverse();
            ComboBoxPatient.ItemsSource = patients;
            ComboBoxPatient.SelectedValuePath = "id";
            ComboBoxPatient.DisplayMemberPath = "name";
            ComboBoxPatientEdit.ItemsSource = patients;
            ComboBoxPatientEdit.SelectedValuePath = "id";
            ComboBoxPatientEdit.DisplayMemberPath = "name";
        }
        private void ComboBoxPatient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int first = 0;
            int index = ComboBoxPatient.SelectedIndex;
            if (index == first)
            {
                GridAddPatient.Visibility = Visibility.Visible;
            }
        }

        private void ButtonAddDoctor_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Doctor doctor = new Doctor();
                doctor.name = TextBoxNameDoctor.Text;
                doctor.address = TextBoxAddressDoctor.Text;
                doctor.number = TextBoxPhoneDoctor.Text;
                doctor.notes = TextBoxNotesDoctor.Text;

                if (doctor.name == "")
                {
                    MessageBox.Show("أدخل اسم الطبيب");
                }
                else
                {
                    DoctorDB.insertDoctor(doctor);
                    TextBoxNameDoctor.Clear();
                    TextBoxAddressDoctor.Clear();
                    TextBoxPhoneDoctor.Clear();
                    TextBoxNotesDoctor.Clear();

                    GridAddDoctor.Visibility = Visibility.Hidden;
                }
                ComboBoxDoctor.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        private void ButtonAddPatient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Patient patient = new Patient();
                patient.name = TextBoxNamePatient.Text;
                patient.age = int.Parse(TextBoxAgePatient.Text);
                patient.number = TextBoxNotesPatient.Text;
              

                if (patient.name == "")
                {
                    MessageBox.Show("أدخل اسم المريض");
                }
                else
                {
                    PatientDB.insertPatient(patient);
                    TextBoxNameDoctor.Clear();
                    TextBoxAddressDoctor.Clear();
                    TextBoxPhoneDoctor.Clear();
                    TextBoxNotesDoctor.Clear();

                    GridAddPatient.Visibility = Visibility.Hidden;
                }
                ComboBoxPatient.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void ButtonAddOrder_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            Bill bill = new Bill();
            bill.id = 0;
            order.bill=bill;

            order.date_register = DatePickerOrder.SelectedDate.Value.ToString("yyyy/MM/dd") ;

            Doctor doctor = new Doctor();
            doctor.id = int.Parse(ComboBoxDoctor.SelectedValue.ToString());
            order.doctor = doctor;

            Patient patient = new Patient();
            patient.id = int.Parse(ComboBoxPatient.SelectedValue.ToString());
            order.patient = patient;

            OrderDB.insertOrder(order);

            ComboBoxPatient.SelectedIndex = -1;
            ComboBoxDoctor.SelectedIndex = -1;
            DatePickerOrder.Text = "";
        }

        private void Refresh_DataGrid_ViewSearch()
        {
            items = OrderDB.selectOrders();
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
                List<Order> newItems = new List<Order>();
                foreach (var item in items)
                {
                    if (item.doctor.name.Contains(search))
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
                List<Order> newItems = new List<Order>();
                foreach (var item in items)
                {
                    if (item.patient.name.Contains(search))
                    {
                        newItems.Add(item);
                    }
                }
                DataGridViewSearch.ItemsSource = newItems;
            }
        }

        private void ButtonViewSearch3_Click(object sender, RoutedEventArgs e)
        {

            if (DatePickerSearchRegister.Text == "")
            {
                Refresh_DataGrid_ViewSearch();
            }
            else
            {
                String d = DatePickerSearchRegister.Text;
           //     d = Reverse(d);

                List<Order> newItems = new List<Order>();
                foreach (var item in items)
                {
                    if (item.date_register.Contains(d))
                    {
                        newItems.Add(item);
                    }
                }
                DataGridViewSearch.ItemsSource = newItems;
            }
        }

        private void ButtonViewSearch4_Click(object sender, RoutedEventArgs e)
        {


            if (DatePickerSearchDelivered.Text == "")
            {
                Refresh_DataGrid_ViewSearch();
            }
            else
            {
                String d = DatePickerSearchDelivered.Text;


                List<Order> newItems = new List<Order>();
                foreach (var item in items)
                {
                    if (item.date_delivered.Contains(d))
                    {
                        newItems.Add(item);
                    }
                }
                DataGridViewSearch.ItemsSource = newItems;
            }
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        private void ButtonViewLastOrder_Click(object sender, RoutedEventArgs e)
        {
            Refresh_DataGrid_ViewSearch();
            List<Order> newItems = new List<Order>();
            newItems.Add(items[items.Count - 1]);
            DataGridViewSearch.ItemsSource = newItems;

        }
        private void ButtonDetailsDG_Click(object sender, RoutedEventArgs e)
        {
            WindowOrderDetails w = new WindowOrderDetails();
            w.ShowDialog();
        }

        
    }
}
