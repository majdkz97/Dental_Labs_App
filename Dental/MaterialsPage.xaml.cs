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
    public partial class MaterialsPage : UserControl
    {
        public MaterialsPage()
        {
            InitializeComponent();
        }
        int k = 0;
        List<Material> items;

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

        private void ButtonAddMaterial_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Material piece = new Material();
                piece.name = TextBoxName.Text;
                piece.type = TextBoxNotes.Text;
                piece.note = TextBoxType.Text;

                if(piece.name=="")
                {
                    MessageBox.Show("أدخل اسم المادة");
                }
                else
                {
                    MaterialDB.insertMaterial(piece);
                    TextBoxName.Clear();
                    TextBoxNotes.Clear();
                    TextBoxType.Clear();
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
            Material p = new Material();
            p = items[DataGridEditDelete.SelectedIndex];

            TextBoxNameEdit.Text = p.name;
            TextBoxNotesEdit.Text = p.note;
            TextBoxTypeEdit.Text = p.type;
            TextBoxNameEdit.Uid = p.id.ToString();

        }


        private void Refresh_DataGrid_EditDelete()
        {
            items = MaterialDB.selectMaterials();
            DataGridEditDelete.ItemsSource = items;
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {

            Material p = new Material();
            p.name = TextBoxNameEdit.Text;
            p.note = TextBoxNotesEdit.Text;
            p.type =TextBoxTypeEdit.Text;
            p.id = int.Parse(TextBoxNameEdit.Uid);
            MaterialDB.updateMaterial(p);
            MessageBox.Show("تم التعديل");
            StackPanelEditAccount.Visibility = Visibility.Hidden;
            Refresh_DataGrid_EditDelete();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(TextBoxDelete.Uid);
            Material p = new Material();
            p.id = id;
            MaterialDB.deleteMaterial(p);
            StackPanelDelete.Visibility = Visibility.Hidden;
            MessageBox.Show("تم الحذف");
            Refresh_DataGrid_EditDelete();
        }
        private void ButtonDeleteDG_Click(object sender, RoutedEventArgs e)
        {
            StackPanelDelete.Visibility = Visibility.Visible;
            Material p = new Material();
            p = items[DataGridEditDelete.SelectedIndex];

            TextBoxDelete.Text = "هل أنت متأكد من حذف " + p.name + " ؟";
            TextBoxDelete.Uid = p.id.ToString();
        }

        private void Refresh_DataGrid_ViewSearch()
        {
            items = MaterialDB.selectMaterials();
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
                List<Material> newItems = new List<Material>();
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
                List<Material> newItems = new List<Material>();
                foreach (var item in items)
                {
                    if (item.type.Contains(search))
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
                List<Material> newItems = new List<Material>();
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

    }
}
