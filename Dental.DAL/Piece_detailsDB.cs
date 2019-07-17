using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Dental.Core;
namespace Dental.DAL
{
    public static class Piece_detailsDB
    {

        public static void insertPiece_details(Piece_details item_details)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string insertItem_detailsQuerry = String.Format(@"INSERT INTO Piece_details (quintity,piece_type_id,order_id)VALUES ('{0}','{1}','{2}');", item_details.quintity, item_details.item.id, item_details.order.id);
                cmd.CommandText = insertItem_detailsQuerry;
                cmd.Connection = sql;
                cmd.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Added");

            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
            finally
            {
                sql.Close();
            }
        }

         public static void updatePiece_details(Piece_details item_details)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string updateitem_detailsQuerry = String.Format(@" UPDATE Piece_details SET quintity='{0}',piece_type_id = {1},order_id= {2}  WHERE id = {3}", item_details.quintity, item_details.item.id , item_details.order.id ,item_details.id );

                cmd.CommandText = updateitem_detailsQuerry;
                cmd.Connection = sql;
                cmd.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Updated");

            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
            finally
            {
                sql.Close();
            }

        }
        public static void deletePiece_details(Piece_details item_details)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string deleteitem_detailsQuerry = String.Format(@"DELETE FROM Piece_details WHERE id = {0};", item_details.id);
                cmd.CommandText = deleteitem_detailsQuerry;
                cmd.Connection = sql;
                cmd.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Deleted");

            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
            finally
            {
                sql.Close();
            }

        }

        public static List<Piece_details> selectPiece_details()
        {
            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;
            //List*************
            List<Piece_details> items_details = new List<Piece_details>();

            try
            {


                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                //select query ITEM_DETAILS. QUINTITY
                string selectItems_detailsQuery = @"SELECT Piece_details.ID AS ID , Piece_details.QUINTITY AS ITEM_DETAILS_QUINTITY , Piece_details.Piece_type_ID AS ITEM_ID , Piece_details.order_id AS  order_ID FROM Piece_details  , Piece_type , ORDERR WHERE Piece_details.Piece_type_ID=Piece_type.ID AND Piece_details.ORDERID = ORDERR.ID";
                cmd.CommandText = selectItems_detailsQuery;
                cmd.Connection = sql;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // create patient
                    Piece_details item_details = new Piece_details();
                    item_details.id = int.Parse(reader["ID"].ToString());
                    item_details.quintity = int.Parse(reader["ITEM_DETAILS_QUINTITY"].ToString());                   
                    Piece_type item = new Piece_type();
                    item.id = int.Parse(reader["ITEM_ID"].ToString());
                    item_details.item = item;
                    Order order_details = new Order();
                    order_details.id = int.Parse(reader["ORDER_ID"].ToString());
                    item_details.order = order_details;



                    items_details.Add(item_details);
                }
                reader.Close();
                System.Windows.Forms.MessageBox.Show("Selected");

            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
            finally
            {
                sql.Close();

            }
            return items_details;

        }



    }
}

