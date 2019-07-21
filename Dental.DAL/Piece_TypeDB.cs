using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Dental.Core;

namespace Dental.DAL
{
    public static class Piece_TypeDB
    {
        public static void insertPiece_type(Piece_type item)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string insertItemQuerry = String.Format(@"INSERT INTO Piece_type (name,notes)VALUES ('{0}','{1}');", item.name,item.notes);
                cmd.CommandText = insertItemQuerry;
                cmd.Connection = sql;
                cmd.ExecuteNonQuery();
                //System.Windows.Forms.MessageBox.Show("Added");

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
         public static void updatePiece_type(Piece_type item)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string updateitemQuerry = String.Format(@" UPDATE  Piece_type SET NAME='{0}',notes='{2}' WHERE id = {1}", item.name, item.id,item.notes);


                cmd.CommandText = updateitemQuerry;
                cmd.Connection = sql;
                cmd.ExecuteNonQuery();
               // //System.Windows.Forms.MessageBox.Show("Updated");

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
        public static void deletePiece_type(Piece_type item)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string deleteitemQuerry = String.Format(@"DELETE FROM Piece_type WHERE id = {0};", item.id);
                cmd.CommandText = deleteitemQuerry;
                cmd.Connection = sql;
                cmd.ExecuteNonQuery();
                //System.Windows.Forms.MessageBox.Show("Deleted");

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

        public static List<Piece_type> selectPiece_type()
        {
            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;
            //List*************
            List<Piece_type> items = new List<Piece_type>();

            try
            {


                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                //select query
                string selectItemsQuery = @"SELECT Piece_type.ID AS ID , Piece_type.NAME AS ITEM_NAME, Piece_type.notes AS ITEM_NOTES FROM Piece_type ";
                cmd.CommandText = selectItemsQuery;
                cmd.Connection = sql;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // create patient
                    Piece_type item = new Piece_type();

                    item.id = int.Parse(reader["ID"].ToString());
                    item.name = reader["ITEM_NAME"].ToString();
                    item.notes = reader["ITEM_NOTES"].ToString();



                    items.Add(item);
                }
                reader.Close();
              //  //System.Windows.Forms.MessageBox.Show("Selected");

            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
            finally
            {
                sql.Close();

            }
            return items;

        }




    }
}
