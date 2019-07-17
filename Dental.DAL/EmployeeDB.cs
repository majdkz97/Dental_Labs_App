using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Dental.Core;
namespace Dental.DAL
{
    public static class EmployeeDB
    {
        public static void insertEmployee(Employee employee)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string insertEmployeeQuerry = String.Format(@"INSERT INTO employee ( NAME,study,note)VALUES ('{0}','{1}','{2}');", employee.name, employee.study, employee.note);
                cmd.CommandText = insertEmployeeQuerry;
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
         public static void updateEmployee(Employee employee)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string updateemployeeQuerry = String.Format(@" UPDATE  employee SET NAME='{0}',study='{1}',note='{2}' WHERE id = {3}", employee.name, employee.study, employee.note , employee.id);
             

                cmd.CommandText = updateemployeeQuerry;
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
        public static void deleteEmployee(Employee employee)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string deleteemployeeQuerry = String.Format(@"DELETE FROM employee WHERE id = {0};", employee.id);
                cmd.CommandText = deleteemployeeQuerry;
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
        public static List<Employee> selectEmployees()
        {
            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;
            //List*************
            List<Employee> Employees = new List<Employee>();

            try
            {


                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                //select query
                string selectEmployeesQuery = @"SELECT EMPLOYEE.ID AS ID , EMPLOYEE.NAME as EMPLOYEE_NAME  , EMPLOYEE.study AS EMPLOYEE_STUDY , EMPLOYEE.NOTE AS EMPLOYEE_NOTE  FROM EMPLOYEE ";
                cmd.CommandText = selectEmployeesQuery;
                cmd.Connection = sql;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // create patient
                    Employee employee = new Employee();

                    employee.id = int.Parse(reader["ID"].ToString());
                    employee.name = reader["EMPLOYEE_NAME"].ToString();
                    employee.study =  reader["EMPLOYEE_STUDY"].ToString();
                   employee.note = reader["EMPLOYEE_NOTE"].ToString();


                    Employees.Add(employee);
                }
                reader.Close();
            //    System.Windows.Forms.MessageBox.Show("Selected");

            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
            finally
            {
                sql.Close();

            }
            return Employees;

        }



    }

}
