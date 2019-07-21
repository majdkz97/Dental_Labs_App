using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Dental.Core;
namespace Dental.DAL
{
    public static class MaterialDB
    {

        public static void insertMaterial(Material material)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string insertPieceQuerry = String.Format(@"INSERT INTO material (name,type,note)VALUES ('{0}','{1}','{2}');", material.name, material.type, material.note);
                cmd.CommandText = insertPieceQuerry;
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
        public static void updateMaterial(Material material)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string updatepieceQuerry = String.Format(@"UPDATE  material SET name ='{0}' ,type = '{1}' ,note = '{2}'  WHERE id = {3}", material.name, material.type, material.note,  material.id);

                cmd.CommandText = updatepieceQuerry;
                cmd.Connection = sql;
                cmd.ExecuteNonQuery();
                //System.Windows.Forms.MessageBox.Show("Updated");

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
        public static void deleteMaterial(Material material)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string deletepieceQuerry = String.Format(@"DELETE FROM material WHERE id = {0};", material.id);
                cmd.CommandText = deletepieceQuerry;
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
        public static List<Material> selectMaterials()
        {
            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;
            //List*************
            List<Material> pieces = new List<Material>();

            try
            {


                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                //select query
                string selectPiecesQuery = @"SELECT Material.ID AS ID , Material.NAME AS PIECE_NAME, Material.TYPE AS Piece_TYPE  , Material.NOTE AS PIECE_NOTE FROM  Material";
               
                cmd.CommandText = selectPiecesQuery;
                cmd.Connection = sql;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // create patient
                    Material piece = new Material();

                    piece.id = int.Parse(reader["ID"].ToString());
                    piece.name = reader["PIECE_NAME"].ToString();
                    piece.type = reader["PIECE_TYPE"].ToString();
                    piece.note = reader["PIECE_NOTE"].ToString();
                    

                    pieces.Add(piece);
                }
                reader.Close();
            //    //System.Windows.Forms.MessageBox.Show("Selected");

            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
            finally
            {
                sql.Close();

            }
            return pieces;

        }



    }

}

