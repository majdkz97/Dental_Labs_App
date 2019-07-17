using System.Data.SQLite;
using Dental.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental.DAL
{
    public static class Work_level_PieceDB
    {
        public static void insertWork_level_Piece(Work_level_Piece work_level)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string insertWork_levelQuerry = String.Format(@"INSERT INTO work_level_piece (work_level_id,piece_details_id)VALUES ({0},{1});", work_level.work_level.id, work_level.piece_details.id);
                cmd.CommandText = insertWork_levelQuerry;
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
        public static void updateWork_level_Piece(Work_level_Piece work_level)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string updateorder_detailsQuerry = String.Format(@" UPDATE  work_level_piece SET work_level_id= {0} ,piece_details_id= {1} WHERE id = {2}", work_level.work_level.id, work_level.piece_details.id, work_level.id);

                cmd.CommandText = updateorder_detailsQuerry;
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
        public static void deleteWork_level_Piece(Work_level_Piece work_level)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string deletework_levelQuerry = String.Format(@"DELETE FROM work_level_piece WHERE id = {0};", work_level.id);
                cmd.CommandText = deletework_levelQuerry;
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
        public static List<Work_level_Piece> SelectWork_level_PieceIdFound(int piece_id)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;
            List<Work_level_Piece> Work_level_Pieces = new List<Work_level_Piece>();

            int id =-1;
            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string selectwork_levelQuerry = String.Format(@"select work_level_piece.id as ID ,work_level_piece.work_level_id as work_level_id , employee.name as employee_name , level.name as level_name
from work_level,work_level_piece,employee,level where piece_id = {0} and level.id = work_level.level_id and work_level.employee_id = employee.id and work_level_piece.work_level_id = work_level.id ", piece_id);
                cmd.CommandText = selectwork_levelQuerry;
                cmd.Connection = sql;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Work_level_Piece wrkp = new Work_level_Piece();
                    Work_level wrk = new Work_level();
                    wrk.id = int.Parse(reader["ID"].ToString());
                    Level level = new Level();
                    level.name = reader["level_name"].ToString();
                    wrk.level = level;
                    Employee emp = new Employee();
                    emp.name = reader["employee_name"].ToString();
                    wrk.employee = emp;


                    wrkp.work_level = wrk;

                    Work_level_Pieces.Add(wrkp);

                    
                }
                System.Windows.Forms.MessageBox.Show("sss");

            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
            finally
            {
                sql.Close();
            }
            return Work_level_Pieces;

        }
        

    }
}
