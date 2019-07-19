using System.Data.SQLite;
using Dental.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental.DAL
{
    public static class Work_levelDB
    {
        public static void insertWork_level(Work_level work_level)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string insertWork_levelQuerry = String.Format(@"INSERT INTO work_level (employee_id,level_id,price)VALUES ('{0}','{1}',{2});", work_level.employee.id, work_level.level.id, work_level.price);
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
        public static void updateWork_level(Work_level work_level)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string updateorder_detailsQuerry = String.Format(@" UPDATE  work_level SET employee_id= {0} ,level_id= {1} ,price= {2}  WHERE id = {3}", work_level.employee.id, work_level.level.id, work_level.price , work_level.id);

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
        public static void deleteWork_level(Work_level work_level)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string deletework_levelQuerry = String.Format(@"DELETE FROM work_level WHERE id = {0};", work_level.id);
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
        public static List<Work_level> SelectWork_levelIdFound(int level_id)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;
            List<Work_level> Work_levels = new List<Work_level>();

            int id =-1;
            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string deletework_levelQuerry = String.Format(@"select work_level.id as ID ,price as price, employee_id as EMPLOYEE_ID,employee.name as name from work_level,employee where level_id={0} and work_level.employee_id = employee.id ", level_id);
                cmd.CommandText = deletework_levelQuerry;
                cmd.Connection = sql;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // create patient
                    Work_level work_level = new Work_level();
                    work_level.id = int.Parse(reader["ID"].ToString());
                    work_level.price = int.Parse(reader["price"].ToString());
                    Employee employee = new Employee();
                    employee.id = int.Parse(reader["EMPLOYEE_ID"].ToString());
                    employee.name = reader["name"].ToString();
                    work_level.employee = employee;

 
                    Work_levels.Add(work_level);
                }
               // System.Windows.Forms.MessageBox.Show("sss");

            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
            finally
            {
                sql.Close();
            }
            return Work_levels;

        }

        public static List<Work_level> SelectWork_levelId_EmployeeID(int level_id,int employee_id)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;
            List<Work_level> Work_levels = new List<Work_level>();

            int id = -1;
            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string deletework_levelQuerry = String.Format(@"select work_level.id as ID ,price as price, employee_id as EMPLOYEE_ID,employee.name as name ,level.name as level_name,level.id as level_id from work_level,employee,level where level_id={0} and work_level.employee_id = employee.id and work_level.employee_id={1} and work_level.level_id = level.id ", level_id,employee_id);
                cmd.CommandText = deletework_levelQuerry;
                cmd.Connection = sql;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // create patient
                    Work_level work_level = new Work_level();
                    work_level.id = int.Parse(reader["ID"].ToString());
                    work_level.price = int.Parse(reader["price"].ToString());
                    Employee employee = new Employee();
                    employee.id = int.Parse(reader["EMPLOYEE_ID"].ToString());
                    employee.name = reader["name"].ToString();
                    work_level.employee = employee;
                    Level level = new Level();
                    level.id = int.Parse(reader["level_id"].ToString());
                    level.name = reader["level_name"].ToString();
                    work_level.level = level;

                    Work_levels.Add(work_level);
                }
                // System.Windows.Forms.MessageBox.Show("sss");

            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
            finally
            {
                sql.Close();
            }
            return Work_levels;

        }


        public static List<Work_level> selectWork_levels()
        {
            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;
            //List*************
            List<Work_level> Work_levels = new List<Work_level>();

            try
            {


                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                //select query
                string selectWork_levelsQuery = @"SELECT WORK_LEVEL.ID AS ID 
                , WORK_LEVEL.EMPLOYEE_ID AS EMPLOYEE_ID  , WORK_LEVEL.LEVEL_ID AS LEVEL_ID ,WORK_LEVEL.price AS LEVEL_PRICE FROM WORK_LEVEL ,EMPLOYEE,LEVEL

                                     WHERE WORK_LEVEL.EMPLOYEE_id = EMPLOYEE.ID
                                                               AND
                                                               WORK_LEVEL.LEVEL_ID = LEVEL.ID
                                                                              ";


                cmd.CommandText = selectWork_levelsQuery;
                cmd.Connection = sql;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // create patient
                    Work_level work_level = new Work_level();
                    work_level.id = int.Parse(reader["ID"].ToString());
                    work_level.price = int.Parse(reader["LEVEL_PRICE"].ToString());
                    Employee employee = new Employee();
                    employee.id = int.Parse(reader["EMPLOYEE_ID"].ToString());
                    work_level.employee = employee;

                    Level level = new Level();
                    level.id = int.Parse(reader["LEVEL_ID"].ToString());
                    work_level.level = level;

                     





                    Work_levels.Add(work_level);
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
            return Work_levels;

        }

    }
}
