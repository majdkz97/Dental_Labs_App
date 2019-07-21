using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Dental.Core;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Dental.DAL
{
    public static class OrderDB
    {
        public static void insertOrder(Order order)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string insertOrderQuerry = String.Format(@"INSERT INTO orderr (date_register,date_delivered,bill_id,patient_id,doctor_id)VALUES ('{0}','{1}','{2}','{3}','{4}');", order.date_register, order.date_delivered, order.bill.id, order.patient.id, order.doctor.id);
                cmd.CommandText = insertOrderQuerry;
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

        public static void updateOrder(Order order)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string updateorderQuerry = String.Format(@" UPDATE  orderr SET date_register ='{0}', date_delivered = '{1}' ,  patient_id = {3} , doctor_id = {4} WHERE id = {5}", order.date_register, order.date_delivered,   order.patient.id, order.doctor.id, order.id);

                cmd.CommandText = updateorderQuerry;
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
        public static void deleteOrder(Order order)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string deleteorderQuerry = String.Format(@"DELETE FROM orderr WHERE id = {0};", order.id);
                cmd.CommandText = deleteorderQuerry;
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
        //    Order order = new Order();
        //    order.date_delivered = (DateTime)reader["Date_asdasd"];

        public static List<Order> selectOrders()
        {
            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;
            //List*************
            List<Order> orders = new List<Order>();

            try
            {


                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                //select query
                string selectOrdersQuery = @"SELECT ORDERR.ID AS ID , ORDERR.DATE_REGISTER AS DATE_REGISTER , ORDERR.DATE_DELIVERED AS DATE_DELIVERED ,ORDERR.PATIENT_ID AS PATIENT_ID  , ORDERR.DOCTOR_ID AS  DOCTOR_ID , doctor.name as DOCTOR_NAME,patient.name as PATIENT_NAME
                FROM ORDERR ,PATIENT,DOCTOR WHERE   ORDERR.PATIENT_ID = PATIENT.ID AND ORDERR.DOCTOR_ID = DOCTOR.ID";
                cmd.CommandText = selectOrdersQuery;
                cmd.Connection = sql;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
             
                   Order order = new Order();

                   order.id = int.Parse(reader["ID"].ToString());
                   order.date_register =   reader["Date_REGISTER"].ToString();
                   order.date_delivered = reader["Date_DELIVERED"].ToString();  
                   
                    Patient patient = new Patient();                   
                    patient.id = int.Parse(reader["PATIENT_ID"].ToString());
                    patient.name = reader["PATIENT_NAME"].ToString();
                    order.patient = patient;
                    Doctor doctor = new Doctor();                  
                    doctor.id = int.Parse(reader["DOCTOR_ID"].ToString());
                    doctor.name = reader["DOCTOR_NAME"].ToString();

                    order.doctor = doctor;



                    orders.Add(order);
                }
                reader.Close();
                //System.Windows.Forms.MessageBox.Show("Selected");

            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
            finally
            {
                sql.Close();

            }
            return orders;

        }


 
    }


}
