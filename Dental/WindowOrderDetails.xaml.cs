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
        }
        int k = 0;
        List<Piece_details> piece_Details;
        private void Refresh_DataGrid_EditDelete(int order_id)
        {
            piece_Details = Piece_detailsDB.selectPiece_details_ByOrderId(order_id);
            DataGridOrder_Pieces.ItemsSource = piece_Details;
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
            

        }


       

        private void ButtonAddWorkLevel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
