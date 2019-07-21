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
            k = id;
            Refresh_DataGrid_EditDelete(id);
            itemswrk = new List<Work_level>();
            matPieces = new List<Material_piece>();
        }
        int k = 0;
        List<Piece_details> piece_Details;
        List<Work_level> itemswrk;
        List<Material_piece> matPieces;

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
        private void Refresh_DataGrid_Material_Piece()
        {
            List<Material_piece> material_Pieces = new List<Material_piece>();
            material_Pieces = matPieces;
            DataGridMaterials.ItemsSource = null;
            DataGridMaterials.ItemsSource = material_Pieces;
        }

        private void ComboBoxPieceType_DropDownOpened(object sender, EventArgs e)
        {

            List<Piece_type> piece_Types = new List<Piece_type>();
            piece_Types = Piece_TypeDB.selectPiece_type();
            ComboBoxPieceType.ItemsSource = piece_Types;
            ComboBoxPieceType.SelectedValuePath = "id";
            ComboBoxPieceType.DisplayMemberPath = "name";

        }

        private void ComboBoxPieceType_DropDownOpened_1(object sender, EventArgs e)
        {

        }

        private void ComboBoxMaterial_DropDownOpened(object sender, EventArgs e)
        {
            List<Material> materials = new List<Material>();
            materials = MaterialDB.selectMaterials();
            ComboBoxMaterial.ItemsSource = materials;
            ComboBoxMaterial.SelectedValuePath = "id";
            ComboBoxMaterial.DisplayMemberPath = "name";
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
            Piece_details piece_Details = new Piece_details();
            Piece_type piece_Type = new Piece_type();
            piece_Type.id = int.Parse(ComboBoxPieceType.SelectedValue.ToString());
            piece_Details.item = piece_Type;
            Order order = new Order();
            order.id = k;
            piece_Details.order = order;
            piece_Details.quintity = int.Parse(TextBoxPieceQuintity.Text);

            Piece_detailsDB.insertPiece_details(piece_Details);
            var temp = Piece_detailsDB.selectPiece_details();
            int piece_id = temp[temp.Count - 1].id;
           // MessageBox.Show("Add Piece");

            foreach (Work_level x in itemswrk)
            {
                Work_level_Piece work_Level_Piece = new Work_level_Piece();
                Piece_details p = new Piece_details();
                p.id = piece_id;
                work_Level_Piece.piece_details = p;
                work_Level_Piece.work_level = x;

                Work_level_PieceDB.insertWork_level_Piece(work_Level_Piece);
            }

            foreach (Material_piece x in matPieces)
            {
                Material_piece material_Piece = new Material_piece();
                
                Piece_details p = new Piece_details();
                p.id = piece_id;
                material_Piece.piece_details = p;
                Material m = new Material();
                m = x.material;
                material_Piece.material = m;
                material_Piece.wieght = x.wieght;

                Material_PieceDB.insertMaterial_Piece(material_Piece);

            }

            ComboBoxEmployee.SelectedIndex = -1;
            ComboBoxLevel.SelectedIndex = -1;
            ComboBoxMaterial.SelectedIndex = -1;
            ComboBoxPieceType.SelectedIndex = -1;
            TextBoxMaterialWieght.Clear();
            TextBoxPieceQuintity.Clear();
            itemswrk.Clear();
            matPieces.Clear();
            Refresh_DataGrid_EditDelete(k);
            Refresh_DataGrid_Material_Piece();
            Refresh_DataGrid_WorkLevel();





        }

        private void ComboBoxLevel_DropDownOpened(object sender, EventArgs e)
        {
            List<Level> levels = new List<Level>();
            levels = LevelDB.selectLevels();
            ComboBoxLevel.ItemsSource = levels;
            ComboBoxLevel.SelectedValuePath = "id";
            ComboBoxLevel.DisplayMemberPath = "name";
        }

        private void ButtonAddMaterial_Click(object sender, RoutedEventArgs e)
        {
            Material_piece material_Piece = new Material_piece();
            Material m = new Material();
            m.id = int.Parse(ComboBoxMaterial.SelectedValue.ToString());
            m.name = ComboBoxMaterial.Text.ToString();
            material_Piece.material = m;
            material_Piece.wieght = double.Parse(TextBoxMaterialWieght.Text);

            matPieces.Add(material_Piece);
            Refresh_DataGrid_Material_Piece();
        }

        private void ButtonCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
