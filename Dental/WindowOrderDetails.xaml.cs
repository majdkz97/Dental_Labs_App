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
    public partial class WindowOrderDetails : Window
    {
        public WindowOrderDetails(int id)
        {
            InitializeComponent();
            Refresh_DataGrid_EditDelete(id);
            itemswrk = new List<Work_level>();

        }
        int k = 0;
        List<Piece_details> piece_Details;
        List<Work_level> itemswrk;

        private void Refresh_DataGrid_EditDelete(int order_id)
        {
            piece_Details = Piece_detailsDB.selectPiece_details_ByOrderId(order_id);
            DataGridOrder_Pieces.ItemsSource = piece_Details;
        }
        private void Refresh_DataGrid_WorkLevel()
        {
            List<Work_level> work_Levels = new List<Work_level>();
            work_Levels = itemswrk;
            DataGridWorkLevel.ItemsSource = null;
            DataGridWorkLevel.ItemsSource = work_Levels;
        }

        private void ComboBoxPieceType_DropDownOpened(object sender, EventArgs e)
        {

        }

        private void ComboBoxPieceType_DropDownOpened_1(object sender, EventArgs e)
        {

        }

        private void ComboBoxMaterial_DropDownOpened(object sender, EventArgs e)
        {

        }

        private void ButtonEditWorkLevelDG_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ComboBoxEmployee_DropDownOpened(object sender, EventArgs e)
        {
            List<Employee> emps = new List<Employee>();
            List<Work_level> work_Levels = new List<Work_level>();
            work_Levels = Work_levelDB.SelectWork_levelIdFound(int.Parse(ComboBoxLevel.SelectedValue.ToString()));
            foreach( var x in work_Levels)
            {

                emps.Add(x.employee);
            }
            ComboBoxEmployee.ItemsSource = emps;
            ComboBoxEmployee.SelectedValuePath = "id";
            ComboBoxEmployee.DisplayMemberPath = "name";


        }




       

        private void ButtonAddWorkLevel_Click(object sender, RoutedEventArgs e)
        {
            List<Work_level> work_Levels = Work_levelDB.SelectWork_levelId_EmployeeID(int.Parse(ComboBoxLevel.SelectedValue.ToString()), int.Parse(ComboBoxEmployee.SelectedValue.ToString()));
            Work_level work_Level = work_Levels[0];
            itemswrk.Add(work_Level);
            Refresh_DataGrid_WorkLevel();

        }

        private void ButtonAddPiece_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ComboBoxLevel_DropDownOpened(object sender, EventArgs e)
        {
            List<Level> levels = new List<Level>();
            levels = LevelDB.selectLevels();
            ComboBoxLevel.ItemsSource = levels;
            ComboBoxLevel.SelectedValuePath = "id";
            ComboBoxLevel.DisplayMemberPath = "name";
        }
    }
}
