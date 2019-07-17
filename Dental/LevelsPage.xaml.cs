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
    public partial class LevelsPage : UserControl
    {
        public LevelsPage()
        {
            InitializeComponent();
            for (int i = 0; i < 1100; i++)
                temp.Add("");
        }
        int k = 0;
        List<Level> items;
        List<Work_level> itemswrk;
        List<String> temp = new List<string>();

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
            Refresh_DataGrid_Prices_Levels();
        }

        private void ButtonAddLevel_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Level level = new Level();
                level.name = TextBoxName.Text;
                level.note = TextBoxNotes.Text;

                if(level.name=="")
                {

                    MessageBox.Show("أدخل اسم المرحلة");

                }
                else
                {

                    LevelDB.insertLevel(level);
                    TextBoxName.Clear();
                    TextBoxNotes.Clear();
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
            Level p = new Level();
            p = items[DataGridEditDelete.SelectedIndex];

            TextBoxNameEdit.Text = p.name;
            TextBoxNotesEdit.Text = p.note;
            TextBoxNameEdit.Uid = p.id.ToString();

        }


        private void Refresh_DataGrid_EditDelete()
        {
            items = LevelDB.selectLevels();
            DataGridEditDelete.ItemsSource = items;
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {

            Level p = new Level();
            p.name = TextBoxNameEdit.Text;
            p.note = TextBoxNotesEdit.Text;
            p.id = int.Parse(TextBoxNameEdit.Uid);
            LevelDB.updateLevel(p);
            MessageBox.Show("تم التعديل");
            StackPanelEditAccount.Visibility = Visibility.Hidden;
            Refresh_DataGrid_EditDelete();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(TextBoxDelete.Uid);
            Level p = new Level();
            p.id = id;
            LevelDB.deleteLevel(p);
            StackPanelDelete.Visibility = Visibility.Hidden;
            MessageBox.Show("تم الحذف");
            Refresh_DataGrid_EditDelete();
        }
        private void ButtonDeleteDG_Click(object sender, RoutedEventArgs e)
        {
            StackPanelDelete.Visibility = Visibility.Visible;
            Level p = new Level();
            p = items[DataGridEditDelete.SelectedIndex];

            TextBoxDelete.Text = "هل أنت متأكد من حذف " + p.name + " ؟";
            TextBoxDelete.Uid = p.id.ToString();
        }

        private void Refresh_DataGrid_ViewSearch()
        {
            items = LevelDB.selectLevels();
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
                List<Level> newItems = new List<Level>();
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

 
        private void ButtonViewSearch3_Click(object sender, RoutedEventArgs e)
        {
            String search = TextBoxViewSearch3.Text;
            if (search == "")
            {
                Refresh_DataGrid_ViewSearch();
            }
            else
            {
                List<Level> newItems = new List<Level>();
                foreach (var item in items)
                {
                    if (item.note.Contains(search))
                    {
                        newItems.Add(item);
                    }
                }
                DataGridViewSearch.ItemsSource = newItems;
            }
        }
        private void Refresh_DataGrid_Prices_Levels()
        {
            items = LevelDB.selectLevels();
            DataGridPricesLevels.ItemsSource = items;
        }

        private void Refresh_DataGrid_Prices_Employees(int id)
        {
            itemswrk = Work_levelDB.SelectWork_levelIdFound(id);
            DataGridPricesEmployees.ItemsSource = itemswrk;
        }


 

        private void ButtonSelectDG_Click(object sender, RoutedEventArgs e)
        {
            
            int index = DataGridPricesLevels.SelectedIndex;
            int id = items[index].id;
            ButtonAddWorkLevel.Uid = id.ToString();
            ButtonEditWorkLevel.Uid = id.ToString();
            ButtonDeleteWorkLevel.Uid = id.ToString();

             GridEmployees.Visibility = Visibility.Visible;
            Refresh_DataGrid_Prices_Employees(id);
        }

        

        private void ComboBoxEmployee_DropDownOpened(object sender, EventArgs e)
        {
            List<Employee> emps = EmployeeDB.selectEmployees();
            List<Employee> empsCombo = new List<Employee>();
            foreach(var item in emps)
            {
                int flag = 0;
                foreach(var empItem in itemswrk)
                {
                    if(item.id == empItem.employee.id)
                    {
                        flag = 1; break;
                    }
                }
                if(flag==0)
                {
                    empsCombo.Add(item);
                }
            }
            ComboBoxEmployee.ItemsSource = empsCombo;
            ComboBoxEmployee.SelectedValuePath = "id";
            ComboBoxEmployee.DisplayMemberPath = "name";


        }

        private void ButtonAddWorkLevel_Click(object sender, RoutedEventArgs e)
        {
            Work_level wrk = new Work_level();
            Level level = new Level();
            level.id = int.Parse(ButtonAddWorkLevel.Uid);
            Employee employee = new Employee();
            employee.id = int.Parse(ComboBoxEmployee.SelectedValue.ToString());
            wrk.level = level;
            wrk.employee = employee;
            wrk.price = int.Parse(TextBoxPriceAddWorkLEVEL.Text);
            Work_levelDB.insertWork_level(wrk);
            Refresh_DataGrid_Prices_Employees(level.id);

            TextBoxPriceAddWorkLEVEL.Clear();
            ComboBoxEmployee.SelectedIndex = -1;
        }

        private void ButtonEditWorkLevel_Click(object sender, RoutedEventArgs e)
        {
            Work_level wrk = new Work_level();
            wrk.id = int.Parse(ButtonEditWorkLevel.Uid);
            wrk.price = int.Parse(TextBoxPriceEditWorkLEVEL.Text);
            Employee emp = new Employee();
            emp.id = itemswrk[DataGridPricesEmployees.SelectedIndex].employee.id;
            wrk.employee = emp;
            Level level = new Level();
            level.id = int.Parse(ButtonAddWorkLevel.Uid);
            wrk.level = level;
            Work_levelDB.updateWork_level(wrk);
            Refresh_DataGrid_Prices_Employees(level.id);


            StackPanelWorkLevelEdit.Visibility = Visibility.Hidden ;
        }

        private void ButtonEditWorkLevelDG_Click(object sender, RoutedEventArgs e)
        {
            ButtonEditWorkLevel.Uid = itemswrk[DataGridPricesEmployees.SelectedIndex].id.ToString();

            StackPanelWorkLevelEdit.Visibility = Visibility.Visible;
            TextBoxPriceEditWorkLEVEL.Text = itemswrk[DataGridPricesEmployees.SelectedIndex].price.ToString();
        }

        private void ButtonDeleteWorkLevel_Click(object sender, RoutedEventArgs e)
        {
            Work_level wrk = new Work_level();
            wrk.id = int.Parse(ButtonEditWorkLevel.Uid);
            Work_levelDB.deleteWork_level(wrk);
            Refresh_DataGrid_Prices_Employees(int.Parse(ButtonAddWorkLevel.Uid));

            StackPanelWorkLevelEdit.Visibility = Visibility.Hidden;

        }
    }
}
