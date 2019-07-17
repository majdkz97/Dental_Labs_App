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
    public partial class PieceTypePage : UserControl
    {
        public PieceTypePage()
        {
            InitializeComponent();
        }
        int k = 0;
        List<Piece_type> items;

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

        private void ButtonAddPiece_Type_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Piece_type item = new Piece_type();
                item.name = TextBoxName.Text;
                item.notes = TextBoxNotes.Text;

                if(item.name=="")
                {
                    MessageBox.Show("أدخل نوع القطعة");
                }
                else
                {
                    Piece_TypeDB.insertPiece_type(item);
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
            Piece_type p = new Piece_type();
            p = items[DataGridEditDelete.SelectedIndex];
            
            TextBoxNameEdit.Text = p.name;
            TextBoxNotesEdit.Text = p.notes;
            TextBoxNameEdit.Uid = p.id.ToString();

        }

     
        private void Refresh_DataGrid_EditDelete()
        {
            items = Piece_TypeDB.selectPiece_type();
            DataGridEditDelete.ItemsSource = items;
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {

            Piece_type p = new Piece_type();
            p.name = TextBoxNameEdit.Text;
            p.notes = TextBoxNotesEdit.Text;
            p.id = int.Parse(TextBoxNameEdit.Uid);
            Piece_TypeDB.updatePiece_type(p);
            MessageBox.Show("تم التعديل");
            StackPanelEditAccount.Visibility = Visibility.Hidden;
            Refresh_DataGrid_EditDelete();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(TextBoxDelete.Uid);
            Piece_type p = new Piece_type();
            p.id = id;
            Piece_TypeDB.deletePiece_type(p);
            StackPanelDelete.Visibility = Visibility.Hidden;
            MessageBox.Show("تم الحذف");
            Refresh_DataGrid_EditDelete();
        }
        private void ButtonDeleteDG_Click(object sender, RoutedEventArgs e)
        {
            StackPanelDelete.Visibility = Visibility.Visible;
            Piece_type p = new Piece_type();
            p = items[DataGridEditDelete.SelectedIndex];

            TextBoxDelete.Text = "هل أنت متأكد من حذف " + p.name + " ؟";
            TextBoxDelete.Uid = p.id.ToString();
        
        }

        private void Refresh_DataGrid_ViewSearch()
        {
            items = Piece_TypeDB.selectPiece_type();
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
                List<Piece_type> newItems = new List<Piece_type>();
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
                List<Piece_type> newItems = new List<Piece_type>();
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
