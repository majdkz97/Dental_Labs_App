using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Dental.Core;

namespace Dental.DAL
{
    public static class PatientDB
    {
        public static void insertPatient(Patient patient)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string insertPatientQuerry = String.Format(@"INSERT INTO patient (name,number,age)VALUES ('{0}','{1}',{2});", patient.name, patient.number, patient.age);
                cmd.CommandText = insertPatientQuerry;
                cmd.Connection = sql;
                cmd.ExecuteNonQuery();
              //  System.Windows.Forms.MessageBox.Show("Added");

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
        public static void updatepatient(Patient patient)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string updatepatientQuerry = String.Format(@"UPDATE  patient SET name ='{0}',number = {1} ,age= {2}  WHERE id = {3}", patient.name, patient.number, patient.age ,patient.id);
                
                cmd.CommandText = updatepatientQuerry;
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
        public static void deletepatient(Patient patient)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string deletepatientQuerry = String.Format(@"DELETE FROM patient WHERE id = {0};", patient.id);
                cmd.CommandText = deletepatientQuerry;
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

        // List<****>
        public static List<Patient> selectPatients()
        {
            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;
            //List*************
            List<Patient> patients = new List<Patient>();

            try
            {
                
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                //select query
                string selectPatientsQuery = @"SELECT PATIENT.ID AS ID , PATIENT.NAME AS PATIENT_NAME ,PATIENT.NUMBER AS PATIENT_NUMBER ,PATIENT.AGE AS PATIENT_AGE FROM PATIENT";
                cmd.CommandText = selectPatientsQuery;
                cmd.Connection = sql;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // create patient
                    Patient patient = new Patient();

                    patient.id = int.Parse(reader["ID"].ToString());
                    patient.name = reader["PATIENT_NAME"].ToString();
                    patient.number = reader["PATIENT_NUMBER"].ToString();
                    patient.age = int.Parse(reader["PATIENT_AGE"].ToString());

                   
                    patients.Add(patient);
                }
                reader.Close();
               // System.Windows.Forms.MessageBox.Show("Selected");

            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
            finally
            {
                sql.Close();

            }
            return patients;

        }



    }
}
