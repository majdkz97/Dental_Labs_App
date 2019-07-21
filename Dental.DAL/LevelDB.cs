using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Dental.Core;
namespace Dental.DAL
{
    public static class LevelDB
    {
        public static void insertLevel(Level level)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string insertLevelQuerry = String.Format(@"INSERT INTO level (name,note)VALUES('{0}','{1}');", level.name, level.note);
                cmd.CommandText = insertLevelQuerry;
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
        public static void updateLevel(Level level)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string updatelevelQuerry = String.Format(@"UPDATE level SET NAME ='{0}',note = '{1}' WHERE id = {2}", level.name, level.note , level.id);


                cmd.CommandText = updatelevelQuerry;
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
        public static void deleteLevel(Level level)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string deletelevelQuerry = String.Format(@"DELETE FROM level WHERE id = {0};", level.id);
                cmd.CommandText = deletelevelQuerry;
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


        public static List<Level> selectLevels()
        {
            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;
            //List*************
            List<Level> levels = new List<Level>();

            try
            {


                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                //select query
                string selectLevelsQuery = @"SELECT LEVEL.ID AS ID , LEVEL.NAME AS LEVEL_NAME , LEVEL.NOTE AS LEVEL_NOTE FROM LEVEL";
                cmd.CommandText = selectLevelsQuery;
                cmd.Connection = sql;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // create patient
                    Level level = new Level();

                    level.id = int.Parse(reader["ID"].ToString());
                    level.name = reader["LEVEL_NAME"].ToString();
                    level.note = reader["LEVEL_NOTE"].ToString();
                    


                    levels.Add(level);
                }
                reader.Close();

            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
            finally
            {
                sql.Close();

            }
            return levels;

        }



    }
}

    
