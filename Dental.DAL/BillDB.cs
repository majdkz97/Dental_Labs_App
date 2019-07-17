using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

using System.Data.SQLite;
using Dental.Core;
namespace Dental.DAL
{
    public static class BillDB
    {
        public static void insertBill(Bill bill)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string insertBillQuerry = String.Format(@"INSERT INTO bill (date,price)VALUES ('{0}','{1}');", bill.date, bill.price);
                cmd.CommandText = insertBillQuerry;
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

        public static void updateBill(Bill bill)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string updateBillQuerry = String.Format(@"UPDATE bill SET date = '{0}', price = {1} WHERE id = {2}", bill.date, bill.price,bill.id);
                cmd.CommandText = updateBillQuerry;
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

        public static void deleteBill(Bill bill)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string deleteBillQuerry = String.Format(@"DELETE FROM bill WHERE id = {0};", bill.id);
                cmd.CommandText = deleteBillQuerry;
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

        public static List<Bill> selectBills()
        {
            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;
            //List*************
            List<Bill> bills = new List<Bill>();

            try
            {


                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                //select query
                string selectBillsQuery = @"SELECT BILL.ID AS ID , BILL.DATE AS BILL_DATE ,BILL.PRICE AS BILL_PRICE FROM BILL";
                cmd.CommandText = selectBillsQuery;
                cmd.Connection = sql;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // create patient
                    Bill bill = new Bill();
                    bill.id = int.Parse(reader["ID"].ToString());
               
                    bill.price = int.Parse(reader["BILL_PRICE"].ToString());

                    
                    bills.Add(bill);
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
            return bills;

        }



    }

}

