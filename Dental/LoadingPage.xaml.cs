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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoadingPage : Window
    {
        public LoadingPage()
        {
            InitializeComponent();
 
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //اضافة دكتور
            Doctor doctor = new Doctor();
            doctor.name = "Majd";
            doctor.address = "asas";
            doctor.number = "45678";

            DoctorDB.insertDoctor(doctor);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //اضافة مريض
            Patient patient = new Patient();
            patient.name = "asas";
            patient.age = 22;
            patient.number = "45678 ";
            PatientDB.insertPatient(patient);

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //اضافة نوع قطعة
            Piece_type item = new Piece_type();
            item.name = "rrr";
            Piece_TypeDB.insertPiece_type(item);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            //اضافة موظف
            Employee employee = new Employee();
            employee.name = "majd";
            employee.study = "Asa";
            employee.note = "new";
            EmployeeDB.insertEmployee(employee);


        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            //اضافة مرحلة
            Level level = new Level();
            level.name = "صب";
            level.note = "null";
            LevelDB.insertLevel(level);
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            //اضافة مادة
            Material piece = new Material();
            piece.name = "as";
            piece.type = "da";
            piece.note = "af";
           
            //piece.order_details = order_details;
            MaterialDB.insertMaterial(piece);
            
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            //اضافة طلبية
            Order order = new Order();
           
            Bill bill = new Bill();
            bill.id = 1;
            order.bill = bill;
            Patient patient = new Patient();
            patient.id = 1;
            order.patient = patient;
            Doctor doctor = new Doctor();
            doctor.id = 1;
            order.doctor = doctor;

            OrderDB.insertOrder(order);
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            //اضافة فاتورة
            Bill bill = new Bill();
            bill.date = DateTime.Now;
            bill.price = 3000;
            BillDB.insertBill(bill);
        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            //اضافة تفاصيل قطعة
            Piece_details item_details = new Piece_details();
            item_details.quintity = 4;
            Order order_details = new Order();
            order_details.id = 1;
            item_details.order = order_details;
            Piece_type item = new Piece_type();
            item.id = 1;
            item_details.item = item;
            Piece_detailsDB.insertPiece_details(item_details);
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            //اضافة تفاصيل طلبية
            
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            //اضافة مرحلة العمل
            Work_level work_level = new Work_level();
            Employee employee = new Employee();
            employee.id = 1;
            Level level = new Level();
            level.id = 1;
         
            work_level.employee = employee;
            work_level.level = level;
            work_level.price = 123;

            Work_levelDB.insertWork_level(work_level);
        }

        private void button11_Click(object sender, RoutedEventArgs e)
        {
            //تعديل فاتورة
            Bill bill = new Bill();
            bill.id = 1;
            bill.date = DateTime.Now;
            bill.price = 9999;
            BillDB.updateBill(bill);
        }

        private void button12_Click(object sender, RoutedEventArgs e)
        {
            //حذف فاتورة
            Bill bill = new Bill();
            bill.id = 1;
          
            BillDB.deleteBill(bill);
        }

        private void button13_Click(object sender, RoutedEventArgs e)
        {
            //تعديل طلبية
            Order order = new Order();
            order.id = 1;
        //    order.date_delivered = DateTime.Now;
           // order.date_register = DateTime.Now;
            Bill bill = new Bill();
            bill.id = 1;
            order.bill = bill;
            Patient patient = new Patient();
            patient.id = 1;
            order.patient = patient;
            Doctor doctor = new Doctor();
            doctor.id = 1;
            order.doctor = doctor;

            OrderDB.updateOrder(order);

        }

        private void button14_Click(object sender, RoutedEventArgs e)
        {
            //تعديل مريض
            Patient patient = new Patient();
            patient.id = 2;
            patient.name = "asas";
            patient.age = 22;
            patient.number = "45678 ";
            PatientDB.updatepatient(patient);
        }

        private void button17_Click(object sender, RoutedEventArgs e)
        {
            //تعديل دكتور
            Doctor doctor = new Doctor();
            doctor.id=1;
            doctor.name = "renad";
            doctor.address = "eee";
            doctor.number = "45678";

            DoctorDB.updateDoctor(doctor);
        }

        private void button15_Click(object sender, RoutedEventArgs e)
        {
            //تعديل تفاصيل طلبية
           
        }

        private void button16_Click(object sender, RoutedEventArgs e)
        {
            //تعديل مادة
            //اضافة نوع قطعة
            Piece_type item = new Piece_type();
            item.name = "rrr";
            item.id = 1;
            Piece_TypeDB.updatePiece_type(item);
        }

        private void button18_Click(object sender, RoutedEventArgs e)
        {
            //تعديل مرحلة العمل
           
        }

    
        private void button19_Click(object sender, RoutedEventArgs e)
        {
            //تعديل موظف
            Employee employee = new Employee();
            employee.id = 1;
            employee.name = "majd";
            employee.study = "1";
            employee.note = "new";
            EmployeeDB.updateEmployee(employee);
        }

        private void button20_Click(object sender, RoutedEventArgs e)
        {
            //تعديل مرحلة
            Level level = new Level();
            level.id = 1;
            level.name = "صب";
            level.note = "null";
            LevelDB.updateLevel(level);
        }

        private void button21_Click(object sender, RoutedEventArgs e)
        {
            //تعديل 
            // مادة
            Material piece = new Material();
            piece.name = "as";
            piece.type = "da";
            piece.note = "af";
            piece.id = 1;
            //piece.order_details = order_details;
            MaterialDB.updateMaterial(piece);
        }

        private void button22_Click(object sender, RoutedEventArgs e)
        {
            //تعديل  // تفاصيل قطعة
            Piece_details item_details = new Piece_details();
            item_details.quintity = 14;
            //Order_details order_details = new Order_details();
          //  order_details.id = 1;
           // item_details.order_details = order_details;
            Piece_type item = new Piece_type();
            item.id = 1;
            item_details.item = item;
            item_details.id = 1;
            Piece_detailsDB.updatePiece_details(item_details);
        }

        private void button23_Click(object sender, RoutedEventArgs e)
        {
            //  حذف طلبية
            Order order = new Order();
            order.id = 1;
            OrderDB.deleteOrder(order);

        }

        private void button24_Click(object sender, RoutedEventArgs e)
        {
            // حذف مريض
            Patient patient = new Patient();
            patient.id = 1;
            PatientDB.deletepatient(patient);
        }

        private void button25_Click(object sender, RoutedEventArgs e)
        {
            // حذف دكتور
            Doctor doctor = new Doctor();
            doctor.id = 1;
            DoctorDB.deleteDoctor(doctor);
        }

        private void button26_Click(object sender, RoutedEventArgs e)
        {
            // حذف موظف
            Employee employee = new Employee();
            employee.id = 1;
            EmployeeDB.deleteEmployee(employee);
        }

        private void button27_Click(object sender, RoutedEventArgs e)
        {
            // حذف مرحلة
            Level level = new Level();
            level.id = 1;
            LevelDB.deleteLevel(level);


        }

        private void button28_Click(object sender, RoutedEventArgs e)
        {
            // حذف مادة
            Material piece = new Material();
            piece.id = 1;

            //piece.order_details = order_details;
            MaterialDB.deleteMaterial(piece);
        }

        private void button29_Click(object sender, RoutedEventArgs e)
        {
            // حذف 
            // نوع قطعة
            Piece_type item = new Piece_type();
            item.id = 1;
            Piece_TypeDB.deletePiece_type(item);
        }

        private void button30_Click(object sender, RoutedEventArgs e)
        {
            //حذف تفاصيل قطعة
            Piece_details item_details = new Piece_details();
            item_details.id = 1;
            Piece_detailsDB.deletePiece_details(item_details);
        }

        private void button31_Click(object sender, RoutedEventArgs e)
        {
            // حذف تفاصيل طلبية
            //Order_details order_details = new Order_details();
        //    order_details.id = 1;
       //     Order_detailsDB.deleteOrder_details(order_details);
        }

        private void button32_Click(object sender, RoutedEventArgs e)
        {
            // حذف مرحلة عمل
            Work_level work_level = new Work_level();
            work_level.id =1;
            Work_levelDB.deleteWork_level(work_level);
        }

        private void button33_Click(object sender, RoutedEventArgs e)
        {
            // جلب مرضى
            List<Patient> patients = PatientDB.selectPatients();
            dataGrid.ItemsSource = patients;
            
        }

        private void button35_Click(object sender, RoutedEventArgs e)
        {
            // جلب أنواع قطع
            List<Piece_type> items = Piece_TypeDB.selectPiece_type();
            dataGrid.ItemsSource = items;
        }

        private void button34_Click(object sender, RoutedEventArgs e)
        {
            // جلب فواتير
            List<Bill> bills = BillDB.selectBills();
            dataGrid.ItemsSource = bills;

        }

        private void button36_Click(object sender, RoutedEventArgs e)
        {
            // جلب دكاترة
            List<Doctor> doctors = DoctorDB.selectDoctors();
            dataGrid.ItemsSource = doctors;
        }

        private void button37_Click(object sender, RoutedEventArgs e)
        {
            // جلب طلبيات
            List<Order> orders = OrderDB.selectOrders();
            dataGrid.ItemsSource = orders;
        }

        private void button40_Click(object sender, RoutedEventArgs e)
        {
            // جلب مواد
            List<Material> Pieces = MaterialDB.selectMaterials();
            dataGrid.ItemsSource = Pieces;
        }

        private void button39_Click(object sender, RoutedEventArgs e)
        {
            // جلب مراحل
            List<Level> Levels = LevelDB.selectLevels();
            dataGrid.ItemsSource = Levels;
        }

        private void button38_Click(object sender, RoutedEventArgs e)
        {
            // جلب موظفين
            List<Employee> Employees = EmployeeDB.selectEmployees();
            dataGrid.ItemsSource = Employees;
        }

        private void button41_Click(object sender, RoutedEventArgs e)
        {
            // جلب مراحل العمل
            List<Work_level> Work_levels = Work_levelDB.selectWork_levels();
            dataGrid.ItemsSource = Work_levels;
        }

        private void button42_Click(object sender, RoutedEventArgs e)
        {
            // جلب تفاصيل قطع
            List<Piece_details> Items_details = Piece_detailsDB.selectPiece_details();
            dataGrid.ItemsSource = Items_details; 
        }

        private void button43_Click(object sender, RoutedEventArgs e)
        {
            // جلب تفاصيل طلبيات
        //    List<Order_details> Orders_details = Order_detailsDB.selectOrders_details();
        //    dataGrid.ItemsSource = Orders_details;
        }

        private void button44_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
        }
    }
}
