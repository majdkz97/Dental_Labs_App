using System.Data.SQLite;
using Dental.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental.DAL
{
    public static class Material_PieceDB
    {
        public static void insertMaterial_Piece(Material_piece material_Piece)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string insertMaterial_PieceQuerry = String.Format(@"INSERT INTO material_piece (wieght,piece_details_id,material_id)VALUES ({2},{1},{0});;", material_Piece.material.id,material_Piece.piece_details.id,material_Piece.wieght);
                cmd.CommandText = insertMaterial_PieceQuerry;
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

        public static List<Material_piece> SelectMaterial_Piece(int piece_id)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;
            List<Material_piece> material_Pieces = new List<Material_piece>();

            
            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string selectMaterial_PieceQuerry = String.Format(@"SELECT id,material.name as material_name,wieght FROM material_piece,material,piece_details WHERE piece_details_id = {0};", piece_id);
                cmd.CommandText = selectMaterial_PieceQuerry;
                cmd.Connection = sql;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Material_piece material_Piece = new Material_piece();
                    material_Piece.id = int.Parse(reader["id"].ToString());
                    material_Piece.wieght = double.Parse(reader["wieght"].ToString());
                    Material material = new Material();
                    material.name = reader["material_name"].ToString();
                    material_Piece.material = material;

                    material_Pieces.Add(material_Piece);
                    
                }
                

            }

            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
            finally
            {
                sql.Close();
            }
            return material_Pieces;

        }
        

    }
}
